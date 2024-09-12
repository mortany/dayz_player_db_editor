using Microsoft.Data.Sqlite;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DZ_Players
{
    public partial class Form1 : Form
    {
        public string Latest_DB_Path = string.Empty;
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            CreateSettings();
        }

        private void CreateSettings()
        {
            OpenFileDialog.Filter = "DayZ player datebase |*.db";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == OpenFileDialog.ShowDialog(this))
            {
                Latest_DB_Path = OpenFileDialog.FileName;
                panel1.LoadPlayerDB(Latest_DB_Path);
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Latest_DB_Path != string.Empty)
            {
                panel1.ReloadDB(Latest_DB_Path);
            }
        }
    }
}
