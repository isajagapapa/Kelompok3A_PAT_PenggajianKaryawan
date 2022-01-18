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
    public partial class Gaji : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public Gaji()
        {
            InitializeComponent();
            textBoxID.Visible = false;
            textBoxSbtot.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonHapus.Enabled = false;
            TampilData();
        }

        public void TampilData()
        {
            var List = service.gajiview();
            dataGridView1.DataSource = List;

            dataGridView1.Columns["idgaji"].DisplayIndex = 0;
            dataGridView1.Columns["noslip"].DisplayIndex = 1;
            dataGridView1.Columns["tanggal"].DisplayIndex = 2;
            dataGridView1.Columns["idhadir"].DisplayIndex = 3;
            dataGridView1.Columns["subtotal"].DisplayIndex = 4;
            dataGridView1.Columns["pph"].DisplayIndex = 5;
            dataGridView1.Columns["total"].DisplayIndex = 6;

            dataGridView1.Columns["idgaji"].HeaderText = "ID Gaji";
            dataGridView1.Columns["noslip"].HeaderText = "No Slip";
            dataGridView1.Columns["tanggal"].HeaderText = "Tanggal";
            dataGridView1.Columns["idhadir"].HeaderText = "ID Kehadiran";
            dataGridView1.Columns["subtotal"].HeaderText = "Sub Total";
            dataGridView1.Columns["pph"].HeaderText = "Pph (%)";
            dataGridView1.Columns["total"].HeaderText = "Total";
        }

        public void TampilDataSub()
        {
            int idhadir = Convert.ToInt32(textBoxIdhadir.Text);
            var List = service.Gajisub(idhadir);
            dataGridView2.DataSource = List;

            dataGridView2.Columns["subtot"].HeaderText = "Sub Total";
        }

        public void Clear()
        {
            textBoxIdhadir.Clear();
            textBoxNoSlip.Clear();
            dateTimePicker1.Value = DateTime.Now;
            textBoxPph.Clear();
            textBoxSbtot.Clear();
            dataGridView2.DataSource = null;

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
            if (textBoxSbtot.Text == "" || textBoxPph.Text == "" || textBoxNoSlip.Text == "" || textBoxIdhadir.Text == "")
            {
                MessageBox.Show("Semua data wajib diisi.");
            }
            else
            {
                int no = Convert.ToInt32(textBoxNoSlip.Text);
                DateTime tanggal = Convert.ToDateTime(dateTimePicker1.Text);
                int idhadir = Convert.ToInt32(textBoxIdhadir.Text);
                int subtot = Convert.ToInt32(textBoxSbtot.Text);
                int pph = Convert.ToInt32(textBoxPph.Text);
                string a = service.gaji(no, tanggal, idhadir, subtot, pph);

                MessageBox.Show(a);
                Clear();
                TampilData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxID.Text);
            int no = Convert.ToInt32(textBoxNoSlip.Text);
            DateTime tanggal = Convert.ToDateTime(dateTimePicker1.Text);
            int idhadir = Convert.ToInt32(textBoxIdhadir.Text);
            int subtot = Convert.ToInt32(textBoxSbtot.Text);
            int pph = Convert.ToInt32(textBoxPph.Text);
            string a = service.editgaji(id, no, tanggal, idhadir, subtot, pph);

            if (textBoxSbtot.Text == "" || textBoxPph.Text == "" || textBoxNoSlip.Text == "" || textBoxIdhadir.Text == "")
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
            int no = Convert.ToInt32(textBoxNoSlip.Text);

            DialogResult dr = MessageBox.Show("Apakah anda yakin ingin menghapus data ini ?", "Hapus Data", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                string a = service.deletegaji(no);
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
            textBoxID.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idgaji"].Value);
            textBoxNoSlip.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["noslip"].Value);
            dateTimePicker1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["tanggal"].Value);
            textBoxIdhadir.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["idhadir"].Value);
            textBoxSbtot.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["subtotal"].Value);
            textBoxPph.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["pph"].Value);

            buttonHapus.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSimpan.Enabled = false;
        }

        private void buttonHitg_Click(object sender, EventArgs e)
        {
            TampilDataSub();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxSbtot.Text = Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells["subtot"].Value);
        }
    }
}
