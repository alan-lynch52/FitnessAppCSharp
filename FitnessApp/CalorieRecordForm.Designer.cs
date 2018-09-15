namespace FitnessApp
{
    partial class CalorieRecordForm
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
            this.backBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.CaloriesTxtLbl = new System.Windows.Forms.Label();
            this.caloriesValueLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(161, 53);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(566, 53);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // CaloriesTxtLbl
            // 
            this.CaloriesTxtLbl.AutoSize = true;
            this.CaloriesTxtLbl.Location = new System.Drawing.Point(338, 58);
            this.CaloriesTxtLbl.Name = "CaloriesTxtLbl";
            this.CaloriesTxtLbl.Size = new System.Drawing.Size(47, 13);
            this.CaloriesTxtLbl.TabIndex = 1;
            this.CaloriesTxtLbl.Text = "Calories:";
            // 
            // caloriesValueLbl
            // 
            this.caloriesValueLbl.AutoSize = true;
            this.caloriesValueLbl.Location = new System.Drawing.Point(418, 58);
            this.caloriesValueLbl.Name = "caloriesValueLbl";
            this.caloriesValueLbl.Size = new System.Drawing.Size(13, 13);
            this.caloriesValueLbl.TabIndex = 2;
            this.caloriesValueLbl.Text = "0";
            // 
            // CalorieRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.caloriesValueLbl);
            this.Controls.Add(this.CaloriesTxtLbl);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.backBtn);
            this.Name = "CalorieRecordForm";
            this.Text = "CalorieRecordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button backBtn;
        public System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label CaloriesTxtLbl;
        public System.Windows.Forms.Label caloriesValueLbl;
    }
}