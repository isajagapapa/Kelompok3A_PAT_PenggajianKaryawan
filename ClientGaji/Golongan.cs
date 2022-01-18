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
    public partial class Golongan : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Golongan()
        {
            InitializeComponent();
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
            TampilData();
        }

        public void TampilData()
        {
            var List = service.Golongan1();
            dataGridView1.DataSource = List;

            dataGridView1.Columns["idgolongan"].DisplayIndex = 0;
            dataGridView1.Columns["golongan"].DisplayIndex = 1;
            dataGridView1.Columns["tjkeluarga"].DisplayIndex = 2;
            dataGridView1.Columns["tjkesehatan"].DisplayIndex = 3;
            dataGridView1.Columns["uanglembur"].DisplayIndex = 4;
            dataGridView1.Columns["uangmakan"].DisplayIndex = 5;

            dataGridView1.Columns["idgolongan"].HeaderText = "ID Golongan";
            dataGridView1.Columns["golongan"].HeaderText = "Golongan";
            dataGridView1.Columns["tjkeluarga"].HeaderText = "Tunjangan Keluarga";
            dataGridView1.Columns["tjkesehatan"].HeaderText = "Tunjangan Kesehatan";
            dataGridView1.Columns["uanglembur"].HeaderText = "Uang Lembur";
            dataGridView1.Columns["uangmakan"].HeaderText = "Uang Makan";
        }

        public void Clear()
        {
            textBoxGolongan.Clear();
            textBoxID.Clear();
            textBoxTjKel.Clear();
            textBoxTjKes.Clear();
            textBoxUangLem.Clear();
            textBoxUangMak.Clear();

            textBoxID.Enabled = true;
            buttonSimpan.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            if (textBoxGolongan.Text == "" || textBoxID.Text == "" || textBoxTjKel.Text == "" ||
                textBoxTjKes.Text == "" || textBoxUangLem.Text == "" || textBoxUangMak.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                int id = Convert.ToInt32(textBoxID.Text);
                int golongan = Convert.ToInt32(textBoxGolongan.Text);
                int tjkel = Convert.ToInt32(textBoxTjKel.Text);
                int tjkes = Convert.ToInt32(textBoxTjKes.Text);
                int uanglem = Convert.ToInt32(textBoxUangLem.Text);
                int uangmak = Convert.ToInt32(textBoxUangMak.Text);
                string a = service.golongan(id, golongan, tjkel, tjkes, uanglem, uangmak);

                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxID.Text);
            int golongan = Convert.ToInt32(textBoxGolongan.Text);
            int tjkel = Convert.ToInt32(textBoxTjKel.Text);
            int tjkes = Convert.ToInt32(textBoxTjKes.Text);
            int uanglem = Convert.ToInt32(textBoxUangLem.Text);
            int uangmak = Convert.ToInt32(textBoxUangMak.Text);
            string a = service.editgolongan(id, golongan, tjkel, tjkes, uanglem, uangmak);

            if (textBoxGolongan.Text == "" || textBoxID.Text == "" || textBoxTjKel.Text == "" ||
                textBoxTjKes.Text == "" || textBoxUangLem.Text == "" || textBoxUangMak.Text == "")
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
                string a = service.deletegolongan(id);
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
            textBoxID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idgolongan"].Value);
            textBoxGolongan.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["golongan"].Value);
            textBoxTjKel.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["tjkeluarga"].Value);
            textBoxTjKes.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["tjkesehatan"].Value);
            textBoxUangLem.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["uanglembur"].Value);
            textBoxUangMak.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["uangmakan"].Value);

            textBoxID.Enabled = false;
            buttonHapus.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSimpan.Enabled = false;
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            Hide();
            m.Show();
        }
    }
}
