namespace FitnessApp
{
    partial class ExerciseRecordForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.backBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.exerciseCmb = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.exerciseList = new System.Windows.Forms.ListBox();
            this.removeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(124, 63);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(595, 63);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // exerciseCmb
            // 
            this.exerciseCmb.FormattingEnabled = true;
            this.exerciseCmb.Location = new System.Drawing.Point(351, 65);
            this.exerciseCmb.Name = "exerciseCmb";
            this.exerciseCmb.Size = new System.Drawing.Size(121, 21);
            this.exerciseCmb.TabIndex = 1;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(259, 265);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(300, 173);
            this.chart.TabIndex = 2;
            this.chart.Text = "Exercise Record Chart";
            // 
            // exerciseList
            // 
            this.exerciseList.FormattingEnabled = true;
            this.exerciseList.Location = new System.Drawing.Point(259, 122);
            this.exerciseList.Name = "exerciseList";
            this.exerciseList.Size = new System.Drawing.Size(212, 95);
            this.exerciseList.TabIndex = 3;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(483, 122);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(75, 23);
            this.removeBtn.TabIndex = 4;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            // 
            // ExerciseRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.exerciseList);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.exerciseCmb);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.backBtn);
            this.Name = "ExerciseRecordForm";
            this.Text = "ExerciseRecordForm";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button backBtn;
        public System.Windows.Forms.Button addBtn;
        public System.Windows.Forms.ComboBox exerciseCmb;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
        public System.Windows.Forms.ListBox exerciseList;
        public System.Windows.Forms.Button removeBtn;
    }
}