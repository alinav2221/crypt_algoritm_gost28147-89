namespace УП03
{
    partial class NameZipForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameZipTextBox = new System.Windows.Forms.TextBox();
            this.nameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 52);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(239, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название для архива (на английском языке):";
            // 
            // nameZipTextBox
            // 
            this.nameZipTextBox.Location = new System.Drawing.Point(12, 82);
            this.nameZipTextBox.Name = "nameZipTextBox";
            this.nameZipTextBox.Size = new System.Drawing.Size(307, 20);
            this.nameZipTextBox.TabIndex = 1;
            // 
            // nameButton
            // 
            this.nameButton.Location = new System.Drawing.Point(125, 130);
            this.nameButton.Name = "nameButton";
            this.nameButton.Size = new System.Drawing.Size(75, 23);
            this.nameButton.TabIndex = 2;
            this.nameButton.Text = "Установить";
            this.nameButton.UseVisualStyleBackColor = true;
            this.nameButton.Click += new System.EventHandler(this.NameButtonOnClick);
            // 
            // NameZipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(348, 175);
            this.Controls.Add(this.nameButton);
            this.Controls.Add(this.nameZipTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "NameZipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NameZipForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameZipTextBox;
        private System.Windows.Forms.Button nameButton;
    }
}