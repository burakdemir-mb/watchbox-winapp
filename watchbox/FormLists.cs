using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watchbox
{
    public partial class FormLists : Form
    {
        public FormLists()
        {
            InitializeComponent();
        }
        private void LoadLists()
        {
            lstLists.Items.Clear();

            foreach (var list in ListRepository.GetUserLists(CurrentUser.Id))
            {
                lstLists.Items.Add(list);
            }
        }
        private void btnCreateList_Click(object sender, EventArgs e)
        {
            FormCreateList f = new FormCreateList();

            if (f.ShowDialog() == DialogResult.OK)
                LoadLists();
        }

        private void lstLists_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedList();
        }

        private void btnOpenList_Click(object sender, EventArgs e)
        {
            OpenSelectedList();
        }

        private void OpenSelectedList()
        {
            if (lstLists.SelectedItem is not ListItem list)
                return;

            var frm = new FormListDetail(list);
            if (frm.ShowDialog() == DialogResult.OK)
                LoadLists();
        }

        private void FormLists_Load(object sender, EventArgs e)
        {
            LoadLists();
        }
    }
}
