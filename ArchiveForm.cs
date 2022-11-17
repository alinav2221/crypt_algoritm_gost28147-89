using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace УП03
{
    public partial class ArchiveForm : Form
    {
        public string pathArchive, pathFile, zipPathMain, zipExtract;
        public static byte[] byteCryptFile, byteDecryptFile, encryptFile, decryptByteFile, keyBytes;
        List<string> files;
        int flag = 0;
        public ArchiveForm()
        {
            InitializeComponent();
            pathCryptTextBox.ReadOnly = true;
            pathFileTextBox.ReadOnly = true;
            extractTextBox.ReadOnly = true;
        }
        /// <summary>
        /// Извлечение файлов из архива
        /// </summary>
        public void ExtractZip()
        {
            D32 d32;
            using (ZipFile zip = ZipFile.Read(zipPathMain))
            {
                foreach (ZipEntry ef in zip)
                {
                    if (files.Contains(ef.FileName))
                    {
                        ef.Extract(zipExtract);
                        d32 = new D32(File.ReadAllBytes(zipExtract + '\\' + ef.FileName), byteKey);
                        decryptByteFile = d32.GetDecryptFile;
                        File.WriteAllBytes(zipExtract + '\\' + ef.FileName, decryptByteFile);
                    }
                }
                MessageBox.Show("Файлы извлечены в " + zipExtract);
            }
        }
        
        /// <summary>
        /// Создание архива
        /// </summary>
        /// <param name="zipPath">Путь, где будет создан архив</param>
        public void CreateZip(string zipPath)
        {
            using (ZipFile zip = new ZipFile())
            {
                if (Properties.Settings.Default.nameZip != "")
                {
                    zip.Save(zipPath + "\\" + Properties.Settings.Default.nameZip);
                    zipPathMain = zipPath + "\\" + Properties.Settings.Default.nameZip;
                }
                else
                {
                    zip.Save(zipPath + "\\Archive.zip");
                    zipPathMain = zipPath + "\\Archive.zip";
                }
                MessageBox.Show("Создана zip-папка в " + zipPathMain);
            }
        }

        /// <summary>
        /// Добавление файла в архив
        /// </summary>
        /// <param name="zipPathFile">Путь файла</param>
        public void AddZip(string zipPathFile)
        {
            try
            {
                using (ZipFile zip = new ZipFile(zipPathMain))
                {
                    zip.AddFile(zipPathFile, "");
                    zip.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// Отображение файлов в архиве
        /// </summary>
        /// <param name="zipPath">Путь к архиву</param>
        public void ShowZip(string zipPath)
        {
            using (ZipFile zip = new ZipFile(zipPath))
            {
                foreach (var file in zip)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = file.FileName;
                    lvi.ImageIndex = 0;
                    cryptLlistView.Items.Add(lvi);
                    zip.Save();
                }
            }
        }

        /// <summary>
        /// Удаление файлов из архива
        /// </summary>
        public void DeleteFileZip()
        {
            using (ZipFile zip = new ZipFile(zipPathMain))
            {
                foreach (var file in files)
                {
                    if (zip.Entries.Any(x => x.FileName == file))
                    {
                        zip.RemoveEntry(file);
                        zip.Save();
                    }
                }
            }
            MessageBox.Show("Файлы удалены");
        }

        /// <summary>
        /// Выбор файла для добавления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseFileButtonOnClick(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                pathFileTextBox.Text = file.FileName;
                pathFile = file.FileName;
                
                byteCryptFile = File.ReadAllBytes(pathFile);
                while (byteCryptFile.Length % 8 != 0)
                {
                    Array.Resize(ref byteCryptFile, byteCryptFile.Length + 1);
                    byteCryptFile.Append((byte) 0 );
                }
            }
        }
        /// <summary>
        /// Нажатие на кнопку создания архива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СreateZipButtonOnClick(object sender, EventArgs e)
        {
            flag = 1;
            NameZipForm zipForm = new NameZipForm(); 
            zipForm.ShowDialog();
            MessageBox.Show("Выберите папку, где необходимо создать архив.");
        }

        /// <summary>
        /// Нажатие на кнопку "Удалить" файл из архива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButtonOnClick(object sender, EventArgs e)
        {
            DeleteFileZip();
            cryptLlistView.Items.Clear();
            ShowZip(zipPathMain);

            extractChooseButton.Enabled = false;
            extractTextBox.Enabled = false;
            exctractButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        /// <summary>
        /// Событие, возникающее при выборе файла из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CryptLlistViewOnSelectedIndexChanged(object sender, EventArgs e)
        {
            string nameFile = "";
            if (cryptLlistView.SelectedItems.Count > 0)
            {
                files = new List<string>();
                extractChooseButton.Enabled = true;
                exctractButton.Enabled = true;
                deleteButton.Enabled = true;
                for (int i = 0; i < cryptLlistView.SelectedItems.Count; i++)
                {
                    if (cryptLlistView.SelectedItems[i].Selected)
                    {
                        int index = cryptLlistView.SelectedItems[i].Index;
                        nameFile = cryptLlistView.Items[index].Text;
                        files.Add(nameFile);
                    }
                }
            }
            else
            {
                extractChooseButton.Enabled = false;
                extractTextBox.Enabled = false;
                exctractButton.Enabled = false;
                deleteButton.Enabled = false;
            }
        }

        /// <summary>
        /// Выбор пути для извлечения туда файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExtractChooseButtonOnClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderCrypt = new FolderBrowserDialog();
            if (folderCrypt.ShowDialog() == DialogResult.OK)
            {
                extractTextBox.Text = folderCrypt.SelectedPath;
                zipExtract = folderCrypt.SelectedPath;
            }
        }

        public byte[] byteKey; //массив для хранения ключа

        /// <summary>
        /// Добавление файла в архив
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButtonOnClick(object sender, EventArgs e)
        {
            E32 e32; D32 d32;
            if (pathCryptTextBox.Text != "" || pathFileTextBox.Text != "")
            {
                e32 = new E32(byteCryptFile, byteKey);
                encryptFile = e32.GetEncryptFile;
                File.WriteAllBytes(pathFile, encryptFile);

                AddZip(pathFile);
                cryptLlistView.Items.Clear();
                ShowZip(zipPathMain);

                d32 = new D32(File.ReadAllBytes(pathFile), byteKey);
                decryptByteFile = d32.GetDecryptFile;
                File.WriteAllBytes(pathFile, decryptByteFile);
            }
            else
            {
                MessageBox.Show("Введите путь архива и(или) папки!");
            }
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ArchiveFormOnLoad(object sender, EventArgs e)
        {
            cryptLlistView.Items.Clear();
            cryptLlistView.SmallImageList = fileImageList;
            exctractButton.Enabled = false;
            extractChooseButton.Enabled = false;
            deleteButton.Enabled = false;
            Random random = new Random();
            byteKey = new byte[32];
            random.NextBytes(byteKey);
        }

        /// <summary>
        /// Кнопка извлечения файла из архива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExctractButtonOnClick(object sender, EventArgs e)
        {
            if (extractTextBox.Text != "")
            {
                if (files.Count > 0)
                {
                    ExtractZip();
                    cryptLlistView.Items.Clear();
                    ShowZip(pathCryptTextBox.Text);
                    extractTextBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Выберите путь папки для извлечения!");
            }
        }

        /// <summary>
        /// Выбор пути для архива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СhoosePathButtonOnClick(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                OpenFileDialog zipFileDialog = new OpenFileDialog();
                zipFileDialog.Filter = "ZIP-папка (*.zip) | *.zip";
                if (zipFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathCryptTextBox.Text = zipFileDialog.FileName;
                    zipPathMain = zipFileDialog.FileName;
                    createZipButton.Enabled = false;
                    cryptLlistView.Items.Clear();
                    ShowZip(pathCryptTextBox.Text);
                    zipPathMain = pathCryptTextBox.Text;
                }
            }
            else
            {
                FolderBrowserDialog folderCrypt = new FolderBrowserDialog();
                if (folderCrypt.ShowDialog() == DialogResult.OK)
                {
                    pathArchive = folderCrypt.SelectedPath;
                    CreateZip(pathArchive);
                    pathCryptTextBox.Text = zipPathMain;
                    cryptLlistView.Items.Clear();
                    ShowZip(pathCryptTextBox.Text);
                }
            }
        }
    }
}
