namespace FitnessApp
{
    partial class MainForm
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
            this.exerciseBtn = new System.Windows.Forms.Button();
            this.exerciseRecordBtn = new System.Windows.Forms.Button();
            this.calorieRecordBtn = new System.Windows.Forms.Button();
            this.bodyweightRecordBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exerciseBtn
            // 
            this.exerciseBtn.AccessibleName = "";
            this.exerciseBtn.Location = new System.Drawing.Point(328, 121);
            this.exerciseBtn.Name = "exerciseBtn";
            this.exerciseBtn.Size = new System.Drawing.Size(184, 40);
            this.exerciseBtn.TabIndex = 0;
            this.exerciseBtn.Text = "Exercise";
            this.exerciseBtn.UseVisualStyleBackColor = true;
            // 
            // exerciseRecordBtn
            // 
            this.exerciseRecordBtn.Location = new System.Drawing.Point(328, 182);
            this.exerciseRecordBtn.Name = "exerciseRecordBtn";
            this.exerciseRecordBtn.Size = new System.Drawing.Size(184, 40);
            this.exerciseRecordBtn.TabIndex = 0;
            this.exerciseRecordBtn.Text = "Exercise Record";
            this.exerciseRecordBtn.UseVisualStyleBackColor = true;
            // 
            // calorieRecordBtn
            // 
            this.calorieRecordBtn.Location = new System.Drawing.Point(328, 241);
            this.calorieRecordBtn.Name = "calorieRecordBtn";
            this.calorieRecordBtn.Size = new System.Drawing.Size(184, 40);
            this.calorieRecordBtn.TabIndex = 0;
            this.calorieRecordBtn.Text = "Calorie Record";
            this.calorieRecordBtn.UseVisualStyleBackColor = true;
            // 
            // bodyweightRecordBtn
            // 
            this.bodyweightRecordBtn.Location = new System.Drawing.Point(328, 297);
            this.bodyweightRecordBtn.Name = "bodyweightRecordBtn";
            this.bodyweightRecordBtn.Size = new System.Drawing.Size(184, 40);
            this.bodyweightRecordBtn.TabIndex = 0;
            this.bodyweightRecordBtn.Text = "Bodyweight Record";
            this.bodyweightRecordBtn.UseVisualStyleBackColor = true;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(695, 21);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(83, 40);
            this.logoutBtn.TabIndex = 0;
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.bodyweightRecordBtn);
            this.Controls.Add(this.calorieRecordBtn);
            this.Controls.Add(this.exerciseRecordBtn);
            this.Controls.Add(this.exerciseBtn);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button exerciseBtn;
        public System.Windows.Forms.Button exerciseRecordBtn;
        public System.Windows.Forms.Button calorieRecordBtn;
        public System.Windows.Forms.Button bodyweightRecordBtn;
        public System.Windows.Forms.Button logoutBtn;
    }
}