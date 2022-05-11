using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace Pathfinding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int vertecesCount = 0;
        public int cellsNumber = 0;
        public int minVertecesCount = 0;

        
        public int[,] AdjMatrix;
        public double[,] FzMatrix; //матрица нечетких соотношений
        public int[,] _AdjMatrix;
        public ArrayList graphComponents = new ArrayList();
        static int d = (int)DateTime.Now.Ticks;
        Random rnd = new Random(d);
        public string Line = Environment.NewLine;
        int H, W;


        private static int Nmax;

        private int[,] A;
        private int[,] Alg_P;
        private int[] Exc; //массив эксцентриситетов вершин
        private int[,] Fl; //массив кратчайших расстояний по алгоритму Флойда-Уоршела
        private double[] Cent; // массив центров графа
        private double[] minmas;
        int rad = 10000; // радиус графа
        private int[] Stack;
        int[][] Ribs;
        List<Edge> edgeArchive = new List<Edge>();
        public int PointOfDeparture;
        public List<int> Price = new List<int>();
        private void Form1_Load(object sender, EventArgs e)
        {
            increaseVertex_ValueChanged(sender, e);
            W = drawField.Width;
            H = drawField.Height;
        }

        private void increaseVertex_ValueChanged(object sender, EventArgs e)
        {

            vertecesCount = (int)increaseVertex.Value;
            cellsNumber = (int)increaseVertex.Value + 1;

            Nmax = vertecesCount;
            int N_St = Nmax * (Nmax - 1) / 2;
            Ribs = new int[Nmax - 1][];
            Alg_P = new int[Nmax, Nmax];
            Stack = new int[0];

            gridMatrix.ColumnCount = cellsNumber;
            gridMatrix.RowCount = cellsNumber;

            gridFuzzyMatrix.ColumnCount = cellsNumber;
            gridFuzzyMatrix.RowCount = cellsNumber;

            AdjMatrix = new int[cellsNumber, cellsNumber];
            FzMatrix = new double[cellsNumber, cellsNumber];

            gridMatrix.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            gridMatrix.Rows[0].Cells[0].Style.ForeColor = SystemColors.AppWorkspace;

            gridFuzzyMatrix.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            gridFuzzyMatrix.Rows[0].Cells[0].Style.ForeColor = SystemColors.AppWorkspace;

            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[0, i].Value = i;
                gridMatrix[0, i].Style.BackColor = Color.LightGray;
                gridMatrix[i, 0].Value = gridMatrix[0, i].Value;
                gridMatrix[i, 0].Style.BackColor = gridMatrix[0, i].Style.BackColor;

                gridFuzzyMatrix[0, i].Value = i;
                gridFuzzyMatrix[0, i].Style.BackColor = Color.LightGray;
                gridFuzzyMatrix[i, 0].Value = gridFuzzyMatrix[0, i].Value;
                gridFuzzyMatrix[i, 0].Style.BackColor = gridFuzzyMatrix[0, i].Style.BackColor;
            }

            //заполнение диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[i, i].Value = 0;
                gridFuzzyMatrix[i, i].Value = 0;

                gridMatrix[i, i].Style.BackColor = Color.Bisque;
                gridFuzzyMatrix[i, i].Style.BackColor = Color.Bisque;
            }
        }

        private void drawField_Paint(object sender, PaintEventArgs e)
        {

        }

        private void drawingGraph_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = true;
            nudPointOfDeparture.Enabled = true;
            nudPointOfDeparture.Minimum = 1;
            nudPointOfDeparture.Maximum = vertecesCount;
            btnPathFind.Enabled = true;

            Applying();
            drawField.Refresh();

            Graphics gr = drawField.CreateGraphics();
            Vertex[] verteces = new Vertex[vertecesCount]; //массив вершин
            Edge[] edges = new Edge[vertecesCount]; //массив рёбер

            int size = 30; //размер вершины
            int x = rnd.Next(size, drawField.Width - size);
            int y = rnd.Next(size, drawField.Height - size);

            for (int i = 0; i < vertecesCount; i++)
            {
                switch (i)
                {
                    case 0:
                        x = rnd.Next(W / 4 - size);
                        y = rnd.Next(H / 2 - size);
                        break;
                    case 1:
                        x = rnd.Next(W / 4 - size, W / 2 - size);
                        y = rnd.Next(H / 2 - size);
                        break;
                    case 2:
                        x = rnd.Next(W / 2 - size, 3 * W / 4 - size);
                        y = rnd.Next(H / 2 - size);
                        break;
                    case 3:
                        x = rnd.Next(3 * W / 4 - size, W - size);
                        y = rnd.Next(H / 2 - size);
                        break;
                    case 4:
                        x = rnd.Next(W / 4 - size);
                        y = rnd.Next(H / 2 - size, H - size);
                        break;
                    case 5:
                        x = rnd.Next(W / 4 - size, W / 2 - size);
                        y = rnd.Next(H / 2 - size, H - size);
                        break;
                    case 6:
                        x = rnd.Next(W / 2 - size, 3 * W / 4 - size);
                        y = rnd.Next(H / 2 - size, H - size);
                        break;
                    case 7:
                        x = rnd.Next(3 * W / 4 - size, W - size);
                        y = rnd.Next(H / 2 - size, H - size);
                        break;
                }
                verteces[i] = new Vertex(x, y, size, size, (i + 1).ToString());
            }
            
            //создание, отрисовка рёбер
            for (int i = 0; i < vertecesCount; i++)
            {
                for (int j = i + 1; j < vertecesCount; j++)
                {
                    if (_AdjMatrix[i, j] != 0)
                    {
                        edges[i] = new Edge(verteces[i].X + size / 2, verteces[i].Y + size / 2, verteces[j].X + size / 2, verteces[j].Y + size / 2, _AdjMatrix[i, j].ToString());
                        edges[i].Draw(gr);
                        edgeArchive.Add(edges[i]);
                    }
                }
            }

            foreach (var v in verteces)
                v.Draw(gr);
            Init();


        }

        //инициализация вершин и массива
        private void Init()
        {
            Nmax = vertecesCount;
            A = _AdjMatrix;
        }

        // Строит каркас минимального веса
        private void FindTree(int[,] Alg_P)
        {
            Set Sp = new Set();
            int min = 100;
            int l = 0, t = 0;
            for (int i = 0; i < Nmax - 1; i++)
                for (int j = 1; j < Nmax; j++)
                    if ((A[i, j] < min) && (A[i, j] != 0))
                    {
                        min = A[i, j];
                        l = i;
                        t = j;
                    }
            Alg_P[l, t] = A[l, t];
            Alg_P[t, l] = A[t, l];
            Sp.Add(l + 1);
            Sp.Add(t + 1);

            int ribIndex = 0;
            Ribs[ribIndex] = new int[2];
            Ribs[ribIndex][0] = l + 1;
            Ribs[ribIndex][1] = t + 1;
            ribIndex++;

            while (!Sp.Contains(1, Nmax))
            {
                min = 100;
                l = 0; t = 0;
                for (int i = 0; i < Nmax; i++)
                    if (Sp.Contains(i + 1))
                        for (int j = 0; j < Nmax; j++)
                            if (!Sp.Contains(j + 1) && (A[i, j] < min) && (A[i, j] != 0))
                            {
                                min = A[i, j];
                                l = i;
                                t = j;
                            }
                Alg_P[l, t] = A[l, t];
                Alg_P[t, l] = A[t, l];
                Sp.Add(l + 1);
                Sp.Add(t + 1);

                Ribs[ribIndex] = new int[2];
                Ribs[ribIndex][0] = l + 1;
                Ribs[ribIndex][1] = t + 1;
                ribIndex++;
            }
        }

        //Поиск пути
        private void FindWay(int v)
        {
            for (int i = 0; i < Nmax; i++)
                if (Alg_P[v, i] != 0)
                {
                    Alg_P[v, i] = 0;
                    FindWay(i);
                }
            int[] temp = (int[])Stack.Clone();
            Stack = new int[Stack.Length + 1];
            for (int i = 0; i < temp.Length; i++)
                Stack[i] = temp[i];
            Stack[Stack.Length - 1] = v + 1;
        }

        int s = 0;

       private void Centre()
        {
            Fl = new int[Nmax, Nmax];
            Exc = new int[9];
            Cent = new double[9];
            minmas = new double[9];

            for (int i = 0; i < Nmax; i++)
            {
                minmas[i] = 99;
            }

            for (int i = 0; i < Nmax; i++)
            {
                for (int j = 0; j < Nmax; j++)
                {
                        Fl[i, j] = A[i, j];                  
                }
            }

            for (int i = 0; i < Nmax; i++)
            {
                for (int j = 0; j < Nmax; j++) 
                {
                    if (Fl[i, j] > Exc[i])
                        Exc[i] = Fl[i, j];
                }
            }

            for (int i = 0; i < Nmax; i++)
            {
                if (Exc[i] < rad) 
                {
                    rad = Exc[i];
                }
            }

            //for (int i = 0; i < Nmax; i++)
            //{
            //    Exc[Nmax - i] = Exc[Nmax - i -1];
            //}
             //отсюда
            for (int i = 0; i < Nmax; i++)
            {
                if (Exc[i] == rad)
                {
                    Cent[i] = 1; // массив центров графа, потом для каждого индекса единицы перебрать фзматрицу
                                     // ищем в подходящих строках минимальное значение степени достоверности, заменяем единицу на него
                                     // после этого сравниваем минимумы и находим максимальное из них, ответом является его индекс
                                     // в массиве
                }
            }

            for (int i = 0; i < Nmax; i++)
            {
                double stmin = 1;
                for (int j = 1; j < Nmax + 1; j++)
                {
                    if (Cent[i] != 0)
                    {
                        if ((FzMatrix[i + 1, j] < stmin) && (i + 1 != j))
                        {
                            stmin = FzMatrix[i + 1, j];
                            Cent[i] = stmin;
                            minmas[i] = stmin;
                        }
                    }
                }

            }

            double stmax = 0;
            for (int i = 0; i < Nmax; i++)
            {
                if (Cent[i] > stmax)
                {
                    stmax = Cent[i];
                }
            }

            for (int i = 0; i < Nmax; i++)
            {
                if (Cent[i] < stmax)
                {
                    Cent[i] = 0;
                }
            } // конец

        }


        // Вывод результата
        private void OutPut()
        {
            Set Way = new Set();
            int i, pred_v, Cost = 0;
            textBox1.Text += "Кратчайший путь: ";
            textBox1.Text += Stack[0] + "-";
            Way.Add(Stack[0]);
            pred_v = Stack[0];
            for (i = 1; i < Stack.Length; i++)
                if (!Way.Contains(Stack[i]))
                {
                    textBox1.Text += Stack[i] + "-";
                    Way.Add(Stack[i]);
                    Cost += A[pred_v - 1, Stack[i] - 1];
                    pred_v = Stack[i];
                    Price.Add(pred_v);
                }
            textBox1.Text += string.Format("{0} ", Stack[0]);

            Cost += A[pred_v - 1, Stack[0] - 1];
            

            textBox1.Text += Line;
            textBox1.Text += "Длина пути: " + Cost;
            textBox1.Text += Line;           
            s = Cost;
            textBox1.Text += Line;
            textBox1.Text += "Вершины, входящие в центр графа: ";
            int check = 0;
            for (i = 0; i < Nmax; i++)
                if (Exc[i] == rad)
                {
                    check++;
                }
            int z = 0;       
            for (i = 0; i < Nmax; i++)
                if (Exc[i] == rad)
                {
                    z++;
                    textBox1.Text += i+1;
                    //if (check == 1 || (check == z))
                    //    textBox1.Text += ".";
                    if ((check > 1) && (check != z))
                        textBox1.Text += ", ";
                }

            textBox1.Text += Line;
            textBox1.Text += Line;

            textBox1.Text += "Максимальные расстояния по вершинам: ";
            for (i = 0; i < Nmax; i++)               
            {
                if (i < Nmax-1)
                    textBox1.Text += Exc[i] + ", ";
                else
                    textBox1.Text += Exc[i];
            }
            textBox1.Text += Line;
            textBox1.Text += Line;
            textBox1.Text += "Радиус графа: " + rad;
            int newmax = 9;
            textBox1.Text += Line;
            textBox1.Text += Line;
            textBox1.Text += "Cent: ";
            for (i = 0; i < Nmax; i++)
            {
                textBox1.Text += Cent[i] + " ";
            }
            textBox1.Text += Line;
            textBox1.Text += "minmas: ";
            for (i = 0; i < Nmax; i++)
            {
                textBox1.Text += minmas[i] + " ";
            }
            textBox1.Text += Line;
            //textBox1.Text += "exc: ";
            //for (i = 0; i < Nmax; i++)
            //{
            //    textBox1.Text += Exc[i] + " ";
            //}
            textBox1.Text += Line;
            textBox1.Text += Line;
            textBox1.Text += "Населенные пункты с наибольшей степенью достоверности: ";
            for (i = 1; i < newmax; i++)
            {
                if (Cent[i] != 0) 
                {
                    textBox1.Text += i+1 + ", ";
                }
            }
            textBox1.Text += Line;
            textBox1.Text += Line;
            
        }


        private void gridMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //зеркальное отображение значений
            gridMatrix[e.RowIndex, e.ColumnIndex].Value = gridMatrix[e.ColumnIndex, e.RowIndex].Value;

        }

        private void gridFuzzyMatrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //зеркальное отображение значений
            gridFuzzyMatrix[e.RowIndex, e.ColumnIndex].Value = gridFuzzyMatrix[e.ColumnIndex, e.RowIndex].Value;

        }

        private void gridMatrix_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //запрет на изменение значений по диагонали
            if (e.RowIndex == e.ColumnIndex)
                e.Cancel = true;


            //запрет на редактирование ячеек
            //отвечающих за нумерацию строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                if (e.RowIndex == 0 && e.ColumnIndex == i || (e.RowIndex == i && e.ColumnIndex == 0))
                    e.Cancel = true;
            }
        }

        private void gridFuzzyMatrix_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //запрет на изменение значений по диагонали
            if (e.RowIndex == e.ColumnIndex)
                e.Cancel = true;


            //запрет на редактирование ячеек
            //отвечающих за нумерацию строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                if (e.RowIndex == 0 && e.ColumnIndex == i || (e.RowIndex == i && e.ColumnIndex == 0))
                    e.Cancel = true;
            }
        }

        private void gridMatrix_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }


        }

        private void gridFuzzyMatrix_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }


        }

        private void gridMatrix_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridMatrix.BeginEdit(true);
        }

        private void gridFuzzyMatrix_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridFuzzyMatrix.BeginEdit(true);
        }

        private void btnRandomlyFuzz_Click(object sender, EventArgs e)
        {
            vertecesCount = (int)increaseVertex.Value;
            cellsNumber = (int)increaseVertex.Value + 1;

            gridFuzzyMatrix.ColumnCount = cellsNumber;
            gridFuzzyMatrix.RowCount = cellsNumber;

            gridFuzzyMatrix.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            gridFuzzyMatrix.Rows[0].Cells[0].Style.ForeColor = SystemColors.AppWorkspace;

            //нумерация строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                gridFuzzyMatrix[0, i].Value = i;
                gridFuzzyMatrix[0, i].Style.BackColor = Color.LightGray;
                gridFuzzyMatrix[i, 0].Value = gridFuzzyMatrix[0, i].Value;
                gridFuzzyMatrix[i, 0].Style.BackColor = gridFuzzyMatrix[0, i].Style.BackColor;
            }

            //заполнение диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                gridFuzzyMatrix[i, i].Value = 0;
                gridFuzzyMatrix[i, i].Style.BackColor = Color.Bisque;
            }

            //случайное заполнение матрицы ниже главной диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                for (int j = i + 1; j < cellsNumber; j++)
                {
                    if (i == j)
                        gridFuzzyMatrix[i, i].Value = 99;
                    else
                    {
                        double d = rnd.NextDouble();
                        if (d < 0.05)
                            d = 0;
                        if ((d > 0.05) & (d < 0.15))
                            d = 0.1;
                        if ((d > 0.15) & (d < 0.25))
                            d = 0.2;
                        if ((d > 0.25) & (d < 0.35))
                            d = 0.3;
                        if ((d > 0.35) & (d < 0.45))
                            d = 0.4;
                        if ((d > 0.45) & (d < 0.55))
                            d = 0.5;
                        if ((d > 0.55) & (d < 0.65))
                            d = 0.6;
                        if ((d > 0.65) & (d < 0.75))
                            d = 0.7;
                        if ((d > 0.75) & (d < 0.85))
                            d = 0.8;
                        if ((d > 0.85) & (d < 0.95))
                            d = 0.9;
                        if (d > 0.95)
                            d = 1;

                        gridFuzzyMatrix[i, j].Value = d;
                    }
                }
            }

            for (int i = 1; i < cellsNumber; i++)
            {
                for (int j = 1; j < cellsNumber; j++)
                {
                    FzMatrix[i, j] = Convert.ToDouble(gridFuzzyMatrix[i, j].Value);
                }
            }
        }
        private void btnRandomly_Click(object sender, EventArgs e)
        {
            vertecesCount = (int)increaseVertex.Value;
            cellsNumber = (int)increaseVertex.Value + 1;

            gridMatrix.ColumnCount = cellsNumber;
            gridMatrix.RowCount = cellsNumber;

            AdjMatrix = new int[cellsNumber, cellsNumber];

            gridMatrix.Rows[0].Cells[0].Style.BackColor = SystemColors.AppWorkspace;
            gridMatrix.Rows[0].Cells[0].Style.ForeColor = SystemColors.AppWorkspace;

            //нумерация строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[0, i].Value = i;
                gridMatrix[0, i].Style.BackColor = Color.LightGray;
                gridMatrix[i, 0].Value = gridMatrix[0, i].Value;
                gridMatrix[i, 0].Style.BackColor = gridMatrix[0, i].Style.BackColor;
            }

            //заполнение диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                gridMatrix[i, i].Value = 0;
                gridMatrix[i, i].Style.BackColor = Color.Bisque;
            }

            //случайное заполнение матрицы ниже главной диагонали
            for (int i = 1; i < cellsNumber; i++)
            {
                for (int j = i + 1; j < cellsNumber; j++)
                {
                    if (i == j)
                        gridMatrix[i, i].Value = 99;
                    else
                        gridMatrix[i, j].Value = rnd.Next(0, 15);
                }
            }

            ////заполнение матрицы выше главной диагонали происходит с помощью метода gridMatrix_CellValueChanged()
            //в котором реализовано зеркальное отображение значений

            //матрица смежности без учета нумерации строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                for (int j = 1; j < cellsNumber; j++)
                {
                    AdjMatrix[i, j] = Convert.ToInt32(gridMatrix[i, j].Value);
                }
            }
            Applying();
        }

        //сохранение введённых значений в таблице
        //запись данных в матрицу смежности
        private void Applying()
        {
            //матрица смежности без учета нумерации строк и столбцов
            for (int i = 1; i < cellsNumber; i++)
            {
                for (int j = 1; j < cellsNumber; j++)
                {
                    AdjMatrix[i, j] = Convert.ToInt32(gridMatrix[i, j].Value);
                }
            }

            _AdjMatrix = new int[vertecesCount, vertecesCount];

            for (int i = 0; i < AdjMatrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < AdjMatrix.GetLength(1) - 1; j++)
                {
                    _AdjMatrix[i, j] = AdjMatrix[i + 1, j + 1];
                }
            }
        }

        private void cmbPointOfDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPathFind.Enabled = true;
        }

        int start;
        private void btnPathFind_Click(object sender, EventArgs e)
        {
            
            int start = (int)nudPointOfDeparture.Value - 1;
            FindTree(Alg_P);
            FindWay(start);
            Centre();
            OutPut();

            Price.Clear();

            Nmax = vertecesCount;
            int N_St = Nmax * (Nmax - 1) / 2;
            Ribs = new int[Nmax - 1][];
            Alg_P = new int[Nmax, Nmax];
            Stack = new int[0];
            rad = 10000;
            Exc = new int[8];
        }

        private void nudPointOfDeparture_ValueChanged(object sender, EventArgs e)
        {
            btnPathFind.Enabled = true;
            start = (int)nudPointOfDeparture.Value;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label2.Focus();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            drawField.Invalidate();
            textBox1.Text = string.Empty;
        }
    }
}
