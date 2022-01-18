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
    public partial class Jabatan : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Jabatan()
        {
            InitializeComponent();
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
            TampilData();
        }

        public void TampilData()
        {
            var List = service.jabatanview();
            dataGridViewJabatan.DataSource = List;

            dataGridViewJabatan.Columns["idjabatan"].DisplayIndex = 0;
            dataGridViewJabatan.Columns["jabatan"].DisplayIndex = 1;
            dataGridViewJabatan.Columns["gajipokok"].DisplayIndex = 2;
            dataGridViewJabatan.Columns["tjjabatan"].DisplayIndex = 3;

            dataGridViewJabatan.Columns["idjabatan"].HeaderText = "ID Jabatan";
            dataGridViewJabatan.Columns["jabatan"].HeaderText = "Jabatan";
            dataGridViewJabatan.Columns["gajipokok"].HeaderText = "Gaji Pokok";
            dataGridViewJabatan.Columns["tjjabatan"].HeaderText = "Tunjangan Jabatan";
        }

        public void Clear()
        {
            textBoxIdJabatan.Clear();
            textBoxJabatan.Clear();
            textBoxGjPokok.Clear();
            textBoxTjJabatan.Clear();

            textBoxIdJabatan.Enabled = true;
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
            if(textBoxTjJabatan.Text == "" || textBoxJabatan.Text == "" || textBoxIdJabatan.Text == "" || textBoxGjPokok.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                int id = Int32.Parse(textBoxIdJabatan.Text);
                string jabatan = textBoxJabatan.Text;
                int gajipokok = Int32.Parse(textBoxGjPokok.Text);
                int tjjabatan = Convert.ToInt32(textBoxTjJabatan.Text);
                string a = service.jabatan(id, jabatan, gajipokok, tjjabatan);

                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBoxIdJabatan.Text);
            string jabatan = textBoxJabatan.Text;
            int gajipokok = Int32.Parse(textBoxGjPokok.Text);
            int tjjabatan = Convert.ToInt32(textBoxTjJabatan.Text);
            string a = service.editjabatan(id, jabatan, gajipokok, tjjabatan);

            if (textBoxTjJabatan.Text == "" || textBoxJabatan.Text == "" || textBoxIdJabatan.Text == "" || textBoxGjPokok.Text == "")
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
            int id = Int32.Parse(textBoxIdJabatan.Text);

            DialogResult dr = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string a = service.deletejabatan(id);
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

        private void dataGridViewJabatan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIdJabatan.Text = Convert.ToString(dataGridViewJabatan.Rows[e.RowIndex].Cells["idjabatan"].Value);
            textBoxJabatan.Text = Convert.ToString(dataGridViewJabatan.Rows[e.RowIndex].Cells["jabatan"].Value);
            textBoxGjPokok.Text = Convert.ToString(dataGridViewJabatan.Rows[e.RowIndex].Cells["gajipokok"].Value);
            textBoxTjJabatan.Text = Convert.ToString(dataGridViewJabatan.Rows[e.RowIndex].Cells["tjjabatan"].Value);

            textBoxIdJabatan.Enabled = false;
            buttonHapus.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSimpan.Enabled = false;
        }
    }
}
