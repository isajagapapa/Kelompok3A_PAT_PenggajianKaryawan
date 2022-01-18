using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientGaji
{
    public partial class Akun : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Akun()
        {
            InitializeComponent();
            textBoxId.Visible = false;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
            TampilData();
        }

        public void TampilData()
        {
            var List = service.DataRegist();
            dataGridViewAkun.DataSource = List;

            dataGridViewAkun.Columns[0].HeaderText = "ID";
            dataGridViewAkun.Columns[1].HeaderText = "Username";
            dataGridViewAkun.Columns[2].HeaderText = "Password";
            dataGridViewAkun.Columns[3].HeaderText = "Kategori";
        }

        private void Clear()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            comboBoxKategori.SelectedItem = null;

            buttonDaftar.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
        }

        private void buttonDaftar_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                string kategori = comboBoxKategori.Text;
                string a = service.Register(username, password, kategori);

                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = Convert.ToString(dataGridViewAkun.Rows[e.RowIndex].Cells[0].Value);
            textBoxUsername.Text = Convert.ToString(dataGridViewAkun.Rows[e.RowIndex].Cells[1].Value);
            textBoxPassword.Text = Convert.ToString(dataGridViewAkun.Rows[e.RowIndex].Cells[2].Value);
            comboBoxKategori.Text = Convert.ToString(dataGridViewAkun.Rows[e.RowIndex].Cells[3].Value);

            buttonHapus.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonDaftar.Enabled = false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string user = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            string kategori = comboBoxKategori.Text;
            int id = Int32.Parse(textBoxId.Text);
            string a = service.UpdateRegister(user, pass, kategori, id);

            if (textBoxUsername.Text == "" || textBoxPassword.Text == "" || comboBoxKategori.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;

            DialogResult dr = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string a = service.DeleteRegister(username);
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            Hide();
            m.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
