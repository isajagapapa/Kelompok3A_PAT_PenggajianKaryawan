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
    public partial class Daftar : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Daftar()
        {
            InitializeComponent();
            textBoxId.Visible = false;
            textBoxKategori.Enabled = false;
        }

        private void buttonDaftar_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;
                string kategori = textBoxKategori.Text;
                string a = service.Register(username, password, kategori);
                MessageBox.Show(a);
                clear();
                Refresh();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            Hide();
            l.Show();
        }

        private void clear()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
        }
    }
}
