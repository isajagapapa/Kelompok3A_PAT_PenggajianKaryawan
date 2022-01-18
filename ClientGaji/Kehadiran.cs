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
    public partial class Kehadiran : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Kehadiran()
        {
            InitializeComponent();
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
            TampilData();
        }

        public void Clear()
        {
            textBoxIdHadir.Clear();
            comboBoxBulan.SelectedItem = null;
            textBoxIdKaryawan.Clear();
            textBoxLem.Clear();
            textBoxMasuk.Clear();

            textBoxIdHadir.Enabled = true;
            buttonSimpan.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
        }

        public void TampilData()
        {
            var List = service.Hadir1();
            dataGridView1.DataSource = List;

            dataGridView1.Columns["idhadir"].DisplayIndex = 0;
            dataGridView1.Columns["bulan"].DisplayIndex = 1;
            dataGridView1.Columns["idkaryawan"].DisplayIndex = 2;
            dataGridView1.Columns["lembur"].DisplayIndex = 3;
            dataGridView1.Columns["masuk"].DisplayIndex = 4;

            dataGridView1.Columns["idhadir"].HeaderText = "ID Hadir";
            dataGridView1.Columns["bulan"].HeaderText = "Bulan";
            dataGridView1.Columns["idkaryawan"].HeaderText = "ID Karyawan";
            dataGridView1.Columns["lembur"].HeaderText = "Lembur";
            dataGridView1.Columns["masuk"].HeaderText = "Masuk";
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            Hide();
            m.Show();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if(textBoxMasuk.Text == "" || comboBoxBulan.Text == "" || textBoxIdKaryawan.Text == "" || textBoxLem.Text == "" || textBoxMasuk.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            
            else
            {
                int id = Convert.ToInt32(textBoxIdHadir.Text);
                string bulan = Convert.ToString(comboBoxBulan.Text);
                int idkar = Convert.ToInt32(textBoxIdKaryawan.Text);
                int lembur = Convert.ToInt32(textBoxLem.Text);
                int masuk = Convert.ToInt32(textBoxMasuk.Text);                

                if (masuk > 31)
                {
                    MessageBox.Show("Maksimal masuk dalam sebulan adalah 31 hari!");
                }
                else if (lembur > 31)
                {
                    MessageBox.Show("Maksimal lembur dalam sebulan adalah 31 hari!");
                }
                else
                {
                    string a = service.hadir(id, bulan, idkar, lembur, masuk);
                    MessageBox.Show(a);
                    Clear();
                    TampilData();

                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxMasuk.Text == "" || comboBoxBulan.Text == "" || textBoxIdKaryawan.Text == "" || textBoxLem.Text == "" || textBoxMasuk.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                int id = Convert.ToInt32(textBoxIdHadir.Text);
                string bulan = Convert.ToString(comboBoxBulan.Text);
                int idkar = Convert.ToInt32(textBoxIdKaryawan.Text);
                int lembur = Convert.ToInt32(textBoxLem.Text);
                int masuk = Convert.ToInt32(textBoxMasuk.Text);

                if (masuk > 31)
                {
                    MessageBox.Show("Maksimal masuk dalam sebulan adalah 31 hari!");
                }
                else if (lembur > 31)
                {
                    MessageBox.Show("Maksimal lembur dalam sebulan adalah 31 hari!");
                }
                else
                {
                    string a = service.edithadir(id, bulan, idkar, lembur, masuk);
                    MessageBox.Show(a);
                    Clear();
                    TampilData();

                }
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxIdHadir.Text);

            DialogResult dr = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string a = service.deletehadir(id);
                MessageBox.Show(a);
                Clear();
                TampilData();
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIdHadir.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idhadir"].Value);
            comboBoxBulan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["bulan"].Value);
            textBoxIdKaryawan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idkaryawan"].Value);
            textBoxLem.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["lembur"].Value);
            textBoxMasuk.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["masuk"].Value);

            textBoxIdHadir.Enabled = false;
            buttonHapus.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSimpan.Enabled = false;
        }
    }
}
