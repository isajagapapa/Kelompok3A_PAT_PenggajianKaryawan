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
    public partial class Karyawan : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Karyawan()
        {
            InitializeComponent();
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
            TampilData();
        }

        public void TampilData()
        {
            var List = service.Karyawan1();
            dataGridView1.DataSource = List;

            dataGridView1.Columns["idkaryawan"].DisplayIndex = 0;
            dataGridView1.Columns["nip"].DisplayIndex = 1;
            dataGridView1.Columns["nama"].DisplayIndex = 2;
            dataGridView1.Columns["jeniskelamin"].DisplayIndex = 3;
            dataGridView1.Columns["alamat"].DisplayIndex = 4;
            dataGridView1.Columns["idjabatan"].DisplayIndex = 5;
            dataGridView1.Columns["idgolongan"].DisplayIndex = 6;
            dataGridView1.Columns["status"].DisplayIndex = 7;

            dataGridView1.Columns["idkaryawan"].HeaderText = "ID Karyawan";
            dataGridView1.Columns["nip"].HeaderText = "NIP";
            dataGridView1.Columns["nama"].HeaderText = "Nama";
            dataGridView1.Columns["jeniskelamin"].HeaderText = "Jenis Kelamin";
            dataGridView1.Columns["alamat"].HeaderText = "Alamat";
            dataGridView1.Columns["idjabatan"].HeaderText = "ID Jabatan";
            dataGridView1.Columns["idgolongan"].HeaderText = "ID Golongan";
            dataGridView1.Columns["status"].HeaderText = "Status";
        }

        public void Clear()
        {
            textBoxID.Clear();
            textBoxAlamat.Clear();
            textBoxIDGol.Clear();
            textBoxIDJab.Clear();
            comboBoxJK.SelectedItem = null;
            textBoxNama.Clear();
            textBoxNip.Clear();
            comboBoxStatus.SelectedItem = null;

            textBoxID.Enabled = true;
            buttonSimpan.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            Hide();
            m.Show();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (comboBoxStatus.Text == "" || textBoxNip.Text == "" || textBoxNama.Text == "" ||
                comboBoxJK.Text == "" || textBoxIDJab.Text == "" || textBoxIDGol.Text == "" || textBoxID.Text == "" || textBoxAlamat.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                int id = Convert.ToInt32(textBoxID.Text);
                int nip = Convert.ToInt32(textBoxNip.Text);
                string nama = Convert.ToString(textBoxNama.Text);
                string jk = Convert.ToString(comboBoxJK.Text);
                string alamat = Convert.ToString(textBoxAlamat.Text);
                int idjab = Convert.ToInt32(textBoxIDJab.Text);
                int idgol = Convert.ToInt32(textBoxIDGol.Text);
                string stat = Convert.ToString(comboBoxStatus.Text);
                string a = service.karyawan(id, nip, nama, jk, alamat, idjab, idgol, stat);

                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxID.Text);
            int nip = Convert.ToInt32(textBoxNip.Text);
            string nama = Convert.ToString(textBoxNama.Text);
            string jk = Convert.ToString(comboBoxJK.Text);
            string alamat = Convert.ToString(textBoxAlamat.Text);
            int idjab = Convert.ToInt32(textBoxIDJab.Text);
            int idgol = Convert.ToInt32(textBoxIDGol.Text);
            string stat = Convert.ToString(comboBoxStatus.Text);
            string a = service.editkaryawan(id, nip, nama, jk, alamat, idjab, idgol, stat);

            if (comboBoxStatus.Text == "" || textBoxNip.Text == "" || textBoxNama.Text == "" ||
                comboBoxJK.Text == "" || textBoxIDJab.Text == "" || textBoxIDGol.Text == "" || textBoxID.Text == "" || textBoxAlamat.Text == "")
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
            int id = Convert.ToInt32(textBoxID.Text);

            DialogResult dr = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string a = service.deletekaryawan(id);
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
            textBoxID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idkaryawan"].Value);
            textBoxNip.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["nip"].Value);
            textBoxNama.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["nama"].Value);
            comboBoxJK.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["jeniskelamin"].Value);
            textBoxAlamat.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["alamat"].Value);
            textBoxIDJab.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idjabatan"].Value);
            textBoxIDGol.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idgolongan"].Value);
            comboBoxStatus.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["status"].Value);

            textBoxID.Enabled = false;
            buttonHapus.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSimpan.Enabled = false;
        }
    }
}
