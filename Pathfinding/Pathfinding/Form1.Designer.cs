namespace Pathfinding
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gridMatrix = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRandomlyFuzz = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gridFuzzyMatrix = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.nudPointOfDeparture = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnPathFind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRandomly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.increaseVertex = new System.Windows.Forms.NumericUpDown();
            this.drawingGraph = new System.Windows.Forms.Button();
            this.drawField = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.теорияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нечеткаяЛогикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прикладнаяЗадачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.строительствоДорогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.логистикаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuzzyMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointOfDeparture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseVertex)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMatrix
            // 
            this.gridMatrix.AllowUserToAddRows = false;
            this.gridMatrix.AllowUserToDeleteRows = false;
            this.gridMatrix.AllowUserToResizeColumns = false;
            this.gridMatrix.AllowUserToResizeRows = false;
            this.gridMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMatrix.ColumnHeadersVisible = false;
            this.gridMatrix.Location = new System.Drawing.Point(222, 74);
            this.gridMatrix.MultiSelect = false;
            this.gridMatrix.Name = "gridMatrix";
            this.gridMatrix.RowHeadersVisible = false;
            this.gridMatrix.Size = new System.Drawing.Size(192, 201);
            this.gridMatrix.TabIndex = 0;
            this.gridMatrix.TabStop = false;
            this.gridMatrix.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridMatrix_CellBeginEdit);
            this.gridMatrix.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridMatrix_CellMouseClick);
            this.gridMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMatrix_CellValueChanged);
            this.gridMatrix.SelectionChanged += new System.EventHandler(this.gridMatrix_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRandomlyFuzz);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.gridFuzzyMatrix);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.nudPointOfDeparture);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnPathFind);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRandomly);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.increaseVertex);
            this.groupBox1.Controls.Add(this.drawingGraph);
            this.groupBox1.Controls.Add(this.gridMatrix);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 468);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // btnRandomlyFuzz
            // 
            this.btnRandomlyFuzz.Location = new System.Drawing.Point(11, 281);
            this.btnRandomlyFuzz.Name = "btnRandomlyFuzz";
            this.btnRandomlyFuzz.Size = new System.Drawing.Size(92, 23);
            this.btnRandomlyFuzz.TabIndex = 20;
            this.btnRandomlyFuzz.Text = "Случайные";
            this.btnRandomlyFuzz.UseVisualStyleBackColor = true;
            this.btnRandomlyFuzz.Click += new System.EventHandler(this.btnRandomlyFuzz_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Матрица нечетких отношений";
            // 
            // gridFuzzyMatrix
            // 
            this.gridFuzzyMatrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridFuzzyMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFuzzyMatrix.ColumnHeadersVisible = false;
            this.gridFuzzyMatrix.Location = new System.Drawing.Point(11, 74);
            this.gridFuzzyMatrix.Name = "gridFuzzyMatrix";
            this.gridFuzzyMatrix.RowHeadersVisible = false;
            this.gridFuzzyMatrix.Size = new System.Drawing.Size(187, 200);
            this.gridFuzzyMatrix.TabIndex = 18;
            this.gridFuzzyMatrix.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridFuzzyMatrix_CellBeginEdit);
            this.gridFuzzyMatrix.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridFuzzyMatrix_CellMouseClick);
            this.gridFuzzyMatrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFuzzyMatrix_CellValueChanged);
            this.gridFuzzyMatrix.SelectionChanged += new System.EventHandler(this.gridFuzzyMatrix_SelectionChanged);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(312, 347);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // nudPointOfDeparture
            // 
            this.nudPointOfDeparture.Enabled = false;
            this.nudPointOfDeparture.Location = new System.Drawing.Point(222, 32);
            this.nudPointOfDeparture.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPointOfDeparture.Name = "nudPointOfDeparture";
            this.nudPointOfDeparture.Size = new System.Drawing.Size(192, 20);
            this.nudPointOfDeparture.TabIndex = 16;
            this.nudPointOfDeparture.TabStop = false;
            this.nudPointOfDeparture.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPointOfDeparture.ValueChanged += new System.EventHandler(this.nudPointOfDeparture_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox1.Location = new System.Drawing.Point(9, 376);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(405, 82);
            this.textBox1.TabIndex = 14;
            this.textBox1.TabStop = false;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // btnPathFind
            // 
            this.btnPathFind.BackColor = System.Drawing.Color.Red;
            this.btnPathFind.Enabled = false;
            this.btnPathFind.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnPathFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPathFind.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPathFind.Location = new System.Drawing.Point(12, 347);
            this.btnPathFind.Name = "btnPathFind";
            this.btnPathFind.Size = new System.Drawing.Size(124, 23);
            this.btnPathFind.TabIndex = 0;
            this.btnPathFind.TabStop = false;
            this.btnPathFind.Text = "Найти решение";
            this.btnPathFind.UseVisualStyleBackColor = false;
            this.btnPathFind.Click += new System.EventHandler(this.btnPathFind_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Выберите точку отправления:";
            // 
            // btnRandomly
            // 
            this.btnRandomly.Location = new System.Drawing.Point(222, 281);
            this.btnRandomly.Name = "btnRandomly";
            this.btnRandomly.Size = new System.Drawing.Size(93, 23);
            this.btnRandomly.TabIndex = 14;
            this.btnRandomly.TabStop = false;
            this.btnRandomly.Text = "Случайные";
            this.btnRandomly.UseVisualStyleBackColor = true;
            this.btnRandomly.Click += new System.EventHandler(this.btnRandomly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Матрица смежности";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Число насленных пунктов:";
            // 
            // increaseVertex
            // 
            this.increaseVertex.Location = new System.Drawing.Point(11, 32);
            this.increaseVertex.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.increaseVertex.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.increaseVertex.Name = "increaseVertex";
            this.increaseVertex.Size = new System.Drawing.Size(187, 20);
            this.increaseVertex.TabIndex = 0;
            this.increaseVertex.TabStop = false;
            this.increaseVertex.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.increaseVertex.ValueChanged += new System.EventHandler(this.increaseVertex_ValueChanged);
            // 
            // drawingGraph
            // 
            this.drawingGraph.Location = new System.Drawing.Point(321, 281);
            this.drawingGraph.Name = "drawingGraph";
            this.drawingGraph.Size = new System.Drawing.Size(93, 23);
            this.drawingGraph.TabIndex = 2;
            this.drawingGraph.TabStop = false;
            this.drawingGraph.Text = "Построить ";
            this.drawingGraph.UseVisualStyleBackColor = true;
            this.drawingGraph.Click += new System.EventHandler(this.drawingGraph_Click);
            // 
            // drawField
            // 
            this.drawField.BackgroundImage = global::Pathfinding.Properties.Resources.background;
            this.drawField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawField.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.drawField.Location = new System.Drawing.Point(438, 30);
            this.drawField.Name = "drawField";
            this.drawField.Size = new System.Drawing.Size(467, 468);
            this.drawField.TabIndex = 2;
            this.drawField.TabStop = false;
            this.drawField.Text = "Отрисовка";
            this.drawField.Paint += new System.Windows.Forms.PaintEventHandler(this.drawField_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.теорияToolStripMenuItem,
            this.прикладнаяЗадачаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(917, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.aboutToolStripMenuItem.Text = "Помощь";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // теорияToolStripMenuItem
            // 
            this.теорияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нечеткаяЛогикаToolStripMenuItem,
            this.алгоритмToolStripMenuItem});
            this.теорияToolStripMenuItem.Name = "теорияToolStripMenuItem";
            this.теорияToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.теорияToolStripMenuItem.Text = "Теория";
            // 
            // нечеткаяЛогикаToolStripMenuItem
            // 
            this.нечеткаяЛогикаToolStripMenuItem.Name = "нечеткаяЛогикаToolStripMenuItem";
            this.нечеткаяЛогикаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.нечеткаяЛогикаToolStripMenuItem.Text = "Нечеткая логика";
            // 
            // алгоритмToolStripMenuItem
            // 
            this.алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            this.алгоритмToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.алгоритмToolStripMenuItem.Text = "Алгоритм";
            // 
            // прикладнаяЗадачаToolStripMenuItem
            // 
            this.прикладнаяЗадачаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.строительствоДорогToolStripMenuItem,
            this.логистикаToolStripMenuItem});
            this.прикладнаяЗадачаToolStripMenuItem.Name = "прикладнаяЗадачаToolStripMenuItem";
            this.прикладнаяЗадачаToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.прикладнаяЗадачаToolStripMenuItem.Text = "Прикладная задача";
            // 
            // строительствоДорогToolStripMenuItem
            // 
            this.строительствоДорогToolStripMenuItem.Name = "строительствоДорогToolStripMenuItem";
            this.строительствоДорогToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.строительствоДорогToolStripMenuItem.Text = "Строительство дорог";
            // 
            // логистикаToolStripMenuItem
            // 
            this.логистикаToolStripMenuItem.Name = "логистикаToolStripMenuItem";
            this.логистикаToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.логистикаToolStripMenuItem.Text = "Логистика";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 503);
            this.Controls.Add(this.drawField);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск логистического центра и кратчайшего пути";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridMatrix)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFuzzyMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointOfDeparture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.increaseVertex)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMatrix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown increaseVertex;
        private System.Windows.Forms.GroupBox drawField;
        private System.Windows.Forms.Button drawingGraph;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnRandomly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPathFind;
        private System.Windows.Forms.NumericUpDown nudPointOfDeparture;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridFuzzyMatrix;
        private System.Windows.Forms.Button btnRandomlyFuzz;
        private System.Windows.Forms.ToolStripMenuItem теорияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нечеткаяЛогикаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прикладнаяЗадачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem строительствоДорогToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem логистикаToolStripMenuItem;
    }
}

