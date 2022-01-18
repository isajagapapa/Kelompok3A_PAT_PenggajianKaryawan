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
    public partial class Login : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string pass = textBoxPass.Text;

            string kategori = service.Login(username, pass);

            if (textBoxUsername.Text == "" || textBoxPass.Text == "")
            {
                MessageBox.Show("Username dan Password wajib diisi.");
            }
            else
            {
                if (kategori == "Admin")
                {
                    Menu m = new Menu();
                    Hide();
                    m.Show();
                }
                else if (kategori == "User")
                {
                    GajiUser g = new GajiUser();
                    Hide();
                    g.Show();
                }
                else
                {
                    MessageBox.Show("Username atau Password invalid, silahkan hubungi admin.");
                    textBoxUsername.Clear();
                    textBoxPass.Clear();
                }
            }            
        }

        private void labelDaftar_Click(object sender, EventArgs e)
        {
            Daftar d = new Daftar();
            Hide();
            d.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
