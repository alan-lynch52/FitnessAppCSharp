namespace FitnessApp
{
    partial class AddExerciseRecordForm
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.weightLbl = new System.Windows.Forms.Label();
            this.exercisesLbl = new System.Windows.Forms.Label();
            this.exerciseCmb = new System.Windows.Forms.ComboBox();
            this.weightTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(269, 187);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(372, 187);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // weightLbl
            // 
            this.weightLbl.AutoSize = true;
            this.weightLbl.Location = new System.Drawing.Point(266, 134);
            this.weightLbl.Name = "weightLbl";
            this.weightLbl.Size = new System.Drawing.Size(44, 13);
            this.weightLbl.TabIndex = 1;
            this.weightLbl.Text = "Weight:";
            // 
            // exercisesLbl
            // 
            this.exercisesLbl.AutoSize = true;
            this.exercisesLbl.Location = new System.Drawing.Point(266, 97);
            this.exercisesLbl.Name = "exercisesLbl";
            this.exercisesLbl.Size = new System.Drawing.Size(50, 13);
            this.exercisesLbl.TabIndex = 1;
            this.exercisesLbl.Text = "Exercise:";
            // 
            // exerciseCmb
            // 
            this.exerciseCmb.FormattingEnabled = true;
            this.exerciseCmb.Location = new System.Drawing.Point(372, 97);
            this.exerciseCmb.Name = "exerciseCmb";
            this.exerciseCmb.Size = new System.Drawing.Size(121, 21);
            this.exerciseCmb.TabIndex = 2;
            // 
            // weightTxt
            // 
            this.weightTxt.Location = new System.Drawing.Point(372, 134);
            this.weightTxt.Name = "weightTxt";
            this.weightTxt.Size = new System.Drawing.Size(121, 20);
            this.weightTxt.TabIndex = 3;
            // 
            // AddExerciseRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.weightTxt);
            this.Controls.Add(this.exerciseCmb);
            this.Controls.Add(this.exercisesLbl);
            this.Controls.Add(this.weightLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Name = "AddExerciseRecordForm";
            this.Text = "AddExerciseRecordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button submitBtn;
        public System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label weightLbl;
        private System.Windows.Forms.Label exercisesLbl;
        public System.Windows.Forms.ComboBox exerciseCmb;
        public System.Windows.Forms.TextBox weightTxt;
    }
}