namespace EduCal
{
    partial class frmDescription
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnOkClose = new System.Windows.Forms.Button();
            this.frmTxtBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.frmTxtBoxLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Description:";
            // 
            // btnOkClose
            // 
            this.btnOkClose.Location = new System.Drawing.Point(558, 543);
            this.btnOkClose.Name = "btnOkClose";
            this.btnOkClose.Size = new System.Drawing.Size(75, 27);
            this.btnOkClose.TabIndex = 2;
            this.btnOkClose.Text = "OK";
            this.btnOkClose.UseVisualStyleBackColor = true;
            this.btnOkClose.Click += new System.EventHandler(this.btnOkCloseClick);
            // 
            // frmTxtBoxDescription
            // 
            this.frmTxtBoxDescription.Location = new System.Drawing.Point(74, 115);
            this.frmTxtBoxDescription.Multiline = true;
            this.frmTxtBoxDescription.Name = "frmTxtBoxDescription";
            this.frmTxtBoxDescription.ReadOnly = true;
            this.frmTxtBoxDescription.Size = new System.Drawing.Size(559, 415);
            this.frmTxtBoxDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location:";
            // 
            // frmTxtBoxLocation
            // 
            this.frmTxtBoxLocation.Location = new System.Drawing.Point(74, 55);
            this.frmTxtBoxLocation.Multiline = true;
            this.frmTxtBoxLocation.Name = "frmTxtBoxLocation";
            this.frmTxtBoxLocation.ReadOnly = true;
            this.frmTxtBoxLocation.Size = new System.Drawing.Size(244, 35);
            this.frmTxtBoxLocation.TabIndex = 5;
            // 
            // frmDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 589);
            this.Controls.Add(this.frmTxtBoxLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.frmTxtBoxDescription);
            this.Controls.Add(this.btnOkClose);
            this.Controls.Add(this.label1);
            this.Name = "frmDescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDescription";
            this.Load += new System.EventHandler(this.frmDescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOkClose;
        private System.Windows.Forms.TextBox frmTxtBoxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox frmTxtBoxLocation;
    }
}