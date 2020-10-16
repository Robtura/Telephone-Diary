using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneDiary
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                phoneBooksBindingSource.Filter = $"FullName like '*{txtSearch.Text}*' or Mobile='{txtSearch.Text}'";
        }

        private void From1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/data.dat"))
                database.ReadXml($"{Application.StartupPath}/data.dat");
        }

        private void phoneBooksBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            phoneBooksBindingSource.EndEdit();
            database.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Your data has been successfully save.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
