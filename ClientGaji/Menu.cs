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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            Hide();
            l.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Akun a = new Akun();
            Hide();
            a.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Jabatan j = new Jabatan();
            Hide();
            j.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Golongan g = new Golongan();
            Hide();
            g.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Karyawan k = new Karyawan();
            Hide();
            k.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Kehadiran ke = new Kehadiran();
            Hide();
            ke.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Gaji g = new Gaji();
            Hide();
            g.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DaftarGaji dg = new DaftarGaji();
            Hide();
            dg.Show();
        }
    }
}
