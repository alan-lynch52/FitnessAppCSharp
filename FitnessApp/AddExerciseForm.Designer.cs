namespace FitnessApp
{
    partial class AddExerciseForm
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
            this.exerciseNameLbl = new System.Windows.Forms.Label();
            this.exerciseNameTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(312, 217);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(408, 217);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // exerciseNameLbl
            // 
            this.exerciseNameLbl.AutoSize = true;
            this.exerciseNameLbl.Location = new System.Drawing.Point(306, 142);
            this.exerciseNameLbl.Name = "exerciseNameLbl";
            this.exerciseNameLbl.Size = new System.Drawing.Size(81, 13);
            this.exerciseNameLbl.TabIndex = 1;
            this.exerciseNameLbl.Text = "Exercise Name:";
            // 
            // exerciseNameTxt
            // 
            this.exerciseNameTxt.Location = new System.Drawing.Point(408, 142);
            this.exerciseNameTxt.Name = "exerciseNameTxt";
            this.exerciseNameTxt.Size = new System.Drawing.Size(100, 20);
            this.exerciseNameTxt.TabIndex = 2;
            // 
            // AddExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exerciseNameTxt);
            this.Controls.Add(this.exerciseNameLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Name = "AddExerciseForm";
            this.Text = "AddExerciseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button submitBtn;
        public System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label exerciseNameLbl;
        public System.Windows.Forms.TextBox exerciseNameTxt;
    }
}