using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace УП03
{
    public partial class NameZipForm : Form
    {
        public NameZipForm()
        {
            InitializeComponent();
        }

        public string name; 

        /// <summary>
        /// При установлении названия архива
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameButtonOnClick(object sender, EventArgs e)
        {
            if (nameZipTextBox.Text.Contains(".zip"))
            {
                name = nameZipTextBox.Text;
            }
            else
            {
                name = nameZipTextBox.Text + ".zip";
            }
            Properties.Settings.Default.nameZip = name;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
