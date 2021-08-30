namespace StudentProfileManagementApp
{
    partial class ClassMonitorForm
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
            this.lbNumOfStudents = new System.Windows.Forms.Label();
            this.lbClassAvg = new System.Windows.Forms.Label();
            this.lbClassAvgDisplay = new System.Windows.Forms.Label();
            this.lbNumOfStudentsDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbNumOfStudents
            // 
            this.lbNumOfStudents.AutoSize = true;
            this.lbNumOfStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumOfStudents.Location = new System.Drawing.Point(22, 21);
            this.lbNumOfStudents.Name = "lbNumOfStudents";
            this.lbNumOfStudents.Size = new System.Drawing.Size(140, 18);
            this.lbNumOfStudents.TabIndex = 0;
            this.lbNumOfStudents.Text = "Number of Students";
            // 
            // lbClassAvg
            // 
            this.lbClassAvg.AutoSize = true;
            this.lbClassAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClassAvg.Location = new System.Drawing.Point(22, 55);
            this.lbClassAvg.Name = "lbClassAvg";
            this.lbClassAvg.Size = new System.Drawing.Size(103, 18);
            this.lbClassAvg.TabIndex = 2;
            this.lbClassAvg.Text = "Class Average";
            // 
            // lbClassAvgDisplay
            // 
            this.lbClassAvgDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbClassAvgDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClassAvgDisplay.Location = new System.Drawing.Point(185, 53);
            this.lbClassAvgDisplay.Name = "lbClassAvgDisplay";
            this.lbClassAvgDisplay.Size = new System.Drawing.Size(100, 23);
            this.lbClassAvgDisplay.TabIndex = 3;
            this.lbClassAvgDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNumOfStudentsDisplay
            // 
            this.lbNumOfStudentsDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbNumOfStudentsDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumOfStudentsDisplay.Location = new System.Drawing.Point(186, 19);
            this.lbNumOfStudentsDisplay.Name = "lbNumOfStudentsDisplay";
            this.lbNumOfStudentsDisplay.Size = new System.Drawing.Size(100, 23);
            this.lbNumOfStudentsDisplay.TabIndex = 1;
            this.lbNumOfStudentsDisplay.Text = "0";
            this.lbNumOfStudentsDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ClassMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 95);
            this.ControlBox = false;
            this.Controls.Add(this.lbNumOfStudentsDisplay);
            this.Controls.Add(this.lbClassAvgDisplay);
            this.Controls.Add(this.lbClassAvg);
            this.Controls.Add(this.lbNumOfStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassMonitorForm";
            this.Text = "Class Monitor";
            this.Load += new System.EventHandler(this.ClassMonitorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumOfStudents;
        private System.Windows.Forms.Label lbClassAvg;
        private System.Windows.Forms.Label lbClassAvgDisplay;
        private System.Windows.Forms.Label lbNumOfStudentsDisplay;
    }
}