namespace УП03
{
    partial class ArchiveForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveForm));
            this.pathCryptTextBox = new System.Windows.Forms.TextBox();
            this.pathCryptLabel = new System.Windows.Forms.Label();
            this.choosePathButton = new System.Windows.Forms.Button();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.pathFileTextBox = new System.Windows.Forms.TextBox();
            this.cryptLlistView = new System.Windows.Forms.ListView();
            this.fileImageList = new System.Windows.Forms.ImageList(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.exctractButton = new System.Windows.Forms.Button();
            this.listCryptLabel = new System.Windows.Forms.Label();
            this.createZipButton = new System.Windows.Forms.Button();
            this.extractChooseButton = new System.Windows.Forms.Button();
            this.extractLabel = new System.Windows.Forms.Label();
            this.extractTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathCryptTextBox
            // 
            this.pathCryptTextBox.Location = new System.Drawing.Point(29, 53);
            this.pathCryptTextBox.Name = "pathCryptTextBox";
            this.pathCryptTextBox.Size = new System.Drawing.Size(588, 20);
            this.pathCryptTextBox.TabIndex = 0;
            // 
            // pathCryptLabel
            // 
            this.pathCryptLabel.AutoSize = true;
            this.pathCryptLabel.Location = new System.Drawing.Point(29, 34);
            this.pathCryptLabel.Name = "pathCryptLabel";
            this.pathCryptLabel.Size = new System.Drawing.Size(69, 13);
            this.pathCryptLabel.TabIndex = 1;
            this.pathCryptLabel.Text = "Путь архива";
            // 
            // choosePathButton
            // 
            this.choosePathButton.Location = new System.Drawing.Point(624, 53);
            this.choosePathButton.Name = "choosePathButton";
            this.choosePathButton.Size = new System.Drawing.Size(32, 23);
            this.choosePathButton.TabIndex = 2;
            this.choosePathButton.Text = "...";
            this.choosePathButton.UseVisualStyleBackColor = true;
            this.choosePathButton.Click += new System.EventHandler(this.СhoosePathButtonOnClick);
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(627, 123);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(32, 23);
            this.chooseFileButton.TabIndex = 5;
            this.chooseFileButton.Text = "...";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.ChooseFileButtonOnClick);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(32, 104);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(69, 13);
            this.fileLabel.TabIndex = 4;
            this.fileLabel.Text = "Путь файла ";
            // 
            // pathFileTextBox
            // 
            this.pathFileTextBox.Location = new System.Drawing.Point(32, 123);
            this.pathFileTextBox.Name = "pathFileTextBox";
            this.pathFileTextBox.Size = new System.Drawing.Size(588, 20);
            this.pathFileTextBox.TabIndex = 3;
            // 
            // cryptLlistView
            // 
            this.cryptLlistView.HideSelection = false;
            this.cryptLlistView.LargeImageList = this.fileImageList;
            this.cryptLlistView.Location = new System.Drawing.Point(35, 206);
            this.cryptLlistView.Name = "cryptLlistView";
            this.cryptLlistView.Size = new System.Drawing.Size(516, 187);
            this.cryptLlistView.SmallImageList = this.fileImageList;
            this.cryptLlistView.TabIndex = 6;
            this.cryptLlistView.UseCompatibleStateImageBehavior = false;
            this.cryptLlistView.View = System.Windows.Forms.View.List;
            this.cryptLlistView.SelectedIndexChanged += new System.EventHandler(this.CryptLlistViewOnSelectedIndexChanged);
            // 
            // fileImageList
            // 
            this.fileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileImageList.ImageStream")));
            this.fileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileImageList.Images.SetKeyName(0, "file.jpg");
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(494, 152);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(162, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Добавить файл в архив";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButtonOnClick);
            // 
            // exctractButton
            // 
            this.exctractButton.Location = new System.Drawing.Point(494, 454);
            this.exctractButton.Name = "exctractButton";
            this.exctractButton.Size = new System.Drawing.Size(162, 23);
            this.exctractButton.TabIndex = 9;
            this.exctractButton.Text = "Извлечь файл из архива";
            this.exctractButton.UseVisualStyleBackColor = true;
            this.exctractButton.Click += new System.EventHandler(this.ExctractButtonOnClick);
            // 
            // listCryptLabel
            // 
            this.listCryptLabel.AutoSize = true;
            this.listCryptLabel.Location = new System.Drawing.Point(32, 190);
            this.listCryptLabel.Name = "listCryptLabel";
            this.listCryptLabel.Size = new System.Drawing.Size(91, 13);
            this.listCryptLabel.TabIndex = 10;
            this.listCryptLabel.Text = "Файлы в архиве";
            // 
            // createZipButton
            // 
            this.createZipButton.Location = new System.Drawing.Point(549, 24);
            this.createZipButton.Name = "createZipButton";
            this.createZipButton.Size = new System.Drawing.Size(110, 23);
            this.createZipButton.TabIndex = 11;
            this.createZipButton.Text = "Создать архив";
            this.createZipButton.UseVisualStyleBackColor = true;
            this.createZipButton.Click += new System.EventHandler(this.СreateZipButtonOnClick);
            // 
            // extractChooseButton
            // 
            this.extractChooseButton.Location = new System.Drawing.Point(624, 425);
            this.extractChooseButton.Name = "extractChooseButton";
            this.extractChooseButton.Size = new System.Drawing.Size(32, 23);
            this.extractChooseButton.TabIndex = 14;
            this.extractChooseButton.Text = "...";
            this.extractChooseButton.UseVisualStyleBackColor = true;
            this.extractChooseButton.Click += new System.EventHandler(this.ExtractChooseButtonOnClick);
            // 
            // extractLabel
            // 
            this.extractLabel.AutoSize = true;
            this.extractLabel.Location = new System.Drawing.Point(36, 409);
            this.extractLabel.Name = "extractLabel";
            this.extractLabel.Size = new System.Drawing.Size(114, 13);
            this.extractLabel.TabIndex = 13;
            this.extractLabel.Text = "Путь для извлечения";
            // 
            // extractTextBox
            // 
            this.extractTextBox.Location = new System.Drawing.Point(36, 425);
            this.extractTextBox.Name = "extractTextBox";
            this.extractTextBox.Size = new System.Drawing.Size(582, 20);
            this.extractTextBox.TabIndex = 12;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(557, 370);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(99, 23);
            this.deleteButton.TabIndex = 15;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonOnClick);
            // 
            // ArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(668, 486);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.extractChooseButton);
            this.Controls.Add(this.extractLabel);
            this.Controls.Add(this.extractTextBox);
            this.Controls.Add(this.createZipButton);
            this.Controls.Add(this.listCryptLabel);
            this.Controls.Add(this.exctractButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.cryptLlistView);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.pathFileTextBox);
            this.Controls.Add(this.choosePathButton);
            this.Controls.Add(this.pathCryptLabel);
            this.Controls.Add(this.pathCryptTextBox);
            this.Name = "ArchiveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Режим простой замены";
            this.Load += new System.EventHandler(this.ArchiveFormOnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathCryptTextBox;
        private System.Windows.Forms.Label pathCryptLabel;
        private System.Windows.Forms.Button choosePathButton;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox pathFileTextBox;
        private System.Windows.Forms.ListView cryptLlistView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button exctractButton;
        private System.Windows.Forms.Label listCryptLabel;
        private System.Windows.Forms.Button createZipButton;
        private System.Windows.Forms.ImageList fileImageList;
        private System.Windows.Forms.Button extractChooseButton;
        private System.Windows.Forms.Label extractLabel;
        private System.Windows.Forms.TextBox extractTextBox;
        private System.Windows.Forms.Button deleteButton;
    }
}

