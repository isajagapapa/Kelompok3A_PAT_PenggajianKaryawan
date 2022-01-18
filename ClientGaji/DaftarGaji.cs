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
    public partial class DaftarGaji : Form
    {
        ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
        public DaftarGaji()
        {
            InitializeComponent();
        }

        public void TampilSemua()
        {
            var List = service.gajiviewall();
            dataGridViewGajiUser.DataSource = List;

            dataGridViewGajiUser.Columns["noslip"].DisplayIndex = 0;
            dataGridViewGajiUser.Columns["tanggal"].DisplayIndex = 1;
            dataGridViewGajiUser.Columns["bulan"].DisplayIndex = 2;
            dataGridViewGajiUser.Columns["nip"].DisplayIndex = 3;
            dataGridViewGajiUser.Columns["nama"].DisplayIndex = 4;
            dataGridViewGajiUser.Columns["jabatan"].DisplayIndex = 5;
            dataGridViewGajiUser.Columns["golongan"].DisplayIndex = 6;
            dataGridViewGajiUser.Columns["masuk"].DisplayIndex = 7;
            dataGridViewGajiUser.Columns["lembur"].DisplayIndex = 8;
            dataGridViewGajiUser.Columns["gajipokok"].DisplayIndex = 9;
            dataGridViewGajiUser.Columns["tjjabatan"].DisplayIndex = 10;
            dataGridViewGajiUser.Columns["tjkeluarga"].DisplayIndex = 11;
            dataGridViewGajiUser.Columns["tjkesehatan"].DisplayIndex = 12;
            dataGridViewGajiUser.Columns["uanglembur"].DisplayIndex = 13;
            dataGridViewGajiUser.Columns["uangmakan"].DisplayIndex = 14;
            dataGridViewGajiUser.Columns["subtotal"].DisplayIndex = 15;
            dataGridViewGajiUser.Columns["pph"].DisplayIndex = 16;
            dataGridViewGajiUser.Columns["total"].DisplayIndex = 17;

            dataGridViewGajiUser.Columns["noslip"].HeaderText = "No Slip";
            dataGridViewGajiUser.Columns["tanggal"].HeaderText = "Tanggal";
            dataGridViewGajiUser.Columns["bulan"].HeaderText = "Bulan";
            dataGridViewGajiUser.Columns["nip"].HeaderText = "NIP";
            dataGridViewGajiUser.Columns["nama"].HeaderText = "Nama";
            dataGridViewGajiUser.Columns["jabatan"].HeaderText = "Jabatan";
            dataGridViewGajiUser.Columns["golongan"].HeaderText = "Golongan";
            dataGridViewGajiUser.Columns["masuk"].HeaderText = "Masuk";
            dataGridViewGajiUser.Columns["lembur"].HeaderText = "Lembur";
            dataGridViewGajiUser.Columns["gajipokok"].HeaderText = "Gaji Pokok";
            dataGridViewGajiUser.Columns["tjjabatan"].HeaderText = "Tunjangan Jabatan";
            dataGridViewGajiUser.Columns["tjkeluarga"].HeaderText = "Tunjangan Keluarga";
            dataGridViewGajiUser.Columns["tjkesehatan"].HeaderText = "Tunjangan Kesehatan";
            dataGridViewGajiUser.Columns["uanglembur"].HeaderText = "Uang Lembur";
            dataGridViewGajiUser.Columns["uangmakan"].HeaderText = "Uang Makan";
            dataGridViewGajiUser.Columns["subtotal"].HeaderText = "Sub Total";
            dataGridViewGajiUser.Columns["pph"].HeaderText = "Pph (%)";
            dataGridViewGajiUser.Columns["total"].HeaderText = "Total";
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            if (textBoxNip.Text == "")
            {
                MessageBox.Show("Kotak pencarian kosong.");
            }
            else
            {
                int nip = Convert.ToInt32(textBoxNip.Text);
                var List = service.Gaji1(nip);
                dataGridViewGajiUser.DataSource = List;

                dataGridViewGajiUser.Columns["noslip"].DisplayIndex = 0;
                dataGridViewGajiUser.Columns["tanggal"].DisplayIndex = 1;
                dataGridViewGajiUser.Columns["bulan"].DisplayIndex = 2;
                dataGridViewGajiUser.Columns["nip"].DisplayIndex = 3;
                dataGridViewGajiUser.Columns["nama"].DisplayIndex = 4;
                dataGridViewGajiUser.Columns["jabatan"].DisplayIndex = 5;
                dataGridViewGajiUser.Columns["golongan"].DisplayIndex = 6;
                dataGridViewGajiUser.Columns["masuk"].DisplayIndex = 7;
                dataGridViewGajiUser.Columns["lembur"].DisplayIndex = 8;
                dataGridViewGajiUser.Columns["gajipokok"].DisplayIndex = 9;
                dataGridViewGajiUser.Columns["tjjabatan"].DisplayIndex = 10;
                dataGridViewGajiUser.Columns["tjkeluarga"].DisplayIndex = 11;
                dataGridViewGajiUser.Columns["tjkesehatan"].DisplayIndex = 12;
                dataGridViewGajiUser.Columns["uanglembur"].DisplayIndex = 13;
                dataGridViewGajiUser.Columns["uangmakan"].DisplayIndex = 14;
                dataGridViewGajiUser.Columns["subtotal"].DisplayIndex = 15;
                dataGridViewGajiUser.Columns["pph"].DisplayIndex = 16;
                dataGridViewGajiUser.Columns["total"].DisplayIndex = 17;

                dataGridViewGajiUser.Columns["noslip"].HeaderText = "No Slip";
                dataGridViewGajiUser.Columns["tanggal"].HeaderText = "Tanggal";
                dataGridViewGajiUser.Columns["bulan"].HeaderText = "Bulan";
                dataGridViewGajiUser.Columns["nip"].HeaderText = "NIP";
                dataGridViewGajiUser.Columns["nama"].HeaderText = "Nama";
                dataGridViewGajiUser.Columns["jabatan"].HeaderText = "Jabatan";
                dataGridViewGajiUser.Columns["golongan"].HeaderText = "Golongan";
                dataGridViewGajiUser.Columns["masuk"].HeaderText = "Masuk";
                dataGridViewGajiUser.Columns["lembur"].HeaderText = "Lembur";
                dataGridViewGajiUser.Columns["gajipokok"].HeaderText = "Gaji Pokok";
                dataGridViewGajiUser.Columns["tjjabatan"].HeaderText = "Tunjangan Jabatan";
                dataGridViewGajiUser.Columns["tjkeluarga"].HeaderText = "Tunjangan Keluarga";
                dataGridViewGajiUser.Columns["tjkesehatan"].HeaderText = "Tunjangan Kesehatan";
                dataGridViewGajiUser.Columns["uanglembur"].HeaderText = "Uang Lembur";
                dataGridViewGajiUser.Columns["uangmakan"].HeaderText = "Uang Makan";
                dataGridViewGajiUser.Columns["subtotal"].HeaderText = "Sub Total";
                dataGridViewGajiUser.Columns["pph"].HeaderText = "Pph (%)";
                dataGridViewGajiUser.Columns["total"].HeaderText = "Total";
            }
        }

        private void buttonSemua_Click(object sender, EventArgs e)
        {
            TampilSemua();
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            Hide();
            m.Show();
        }
    }
}
