namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTimeSeries = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxDeath = new System.Windows.Forms.TextBox();
            this.textBoxCases = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "display data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 524);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(468, 218);
            this.dataGridView1.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(557, 524);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(141, 225);
            this.listBox2.TabIndex = 3;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(59, 76);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(619, 209);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // chartTimeSeries
            // 
            chartArea4.Name = "ChartArea1";
            this.chartTimeSeries.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartTimeSeries.Legends.Add(legend4);
            this.chartTimeSeries.Location = new System.Drawing.Point(59, 331);
            this.chartTimeSeries.Name = "chartTimeSeries";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTimeSeries.Series.Add(series2);
            this.chartTimeSeries.Size = new System.Drawing.Size(619, 180);
            this.chartTimeSeries.TabIndex = 6;
            this.chartTimeSeries.Text = "chart2";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Population",
            "Confirmed cases",
            "Current deaths"});
            this.comboBox1.Location = new System.Drawing.Point(59, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Order by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Time Series - Deaths";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cumulative Values";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(230, 25);
            this.numericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown.TabIndex = 12;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nb of countries";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxDate);
            this.panel1.Controls.Add(this.textBoxDeath);
            this.panel1.Controls.Add(this.textBoxCases);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(702, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 311);
            this.panel1.TabIndex = 14;
            // 
            // textBoxDate
            // 
            this.textBoxDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDate.Location = new System.Drawing.Point(28, 18);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(167, 13);
            this.textBoxDate.TabIndex = 4;
            // 
            // textBoxDeath
            // 
            this.textBoxDeath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDeath.Location = new System.Drawing.Point(96, 130);
            this.textBoxDeath.Name = "textBoxDeath";
            this.textBoxDeath.ReadOnly = true;
            this.textBoxDeath.Size = new System.Drawing.Size(100, 13);
            this.textBoxDeath.TabIndex = 3;
            // 
            // textBoxCases
            // 
            this.textBoxCases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCases.Location = new System.Drawing.Point(95, 63);
            this.textBoxCases.Name = "textBoxCases";
            this.textBoxCases.ReadOnly = true;
            this.textBoxCases.Size = new System.Drawing.Size(100, 13);
            this.textBoxCases.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Total Deaths";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Cases";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 799);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chartTimeSeries);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTimeSeries;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxDeath;
        private System.Windows.Forms.TextBox textBoxCases;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

