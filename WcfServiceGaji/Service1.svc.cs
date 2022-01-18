using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceGaji
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string constring = "Data Source=DESKTOP-E4RVH2C;Initial Catalog=gajikaryawan;Persist Security Info=True;User ID=sa;Password=anonim07";
        SqlConnection connection;
        SqlCommand com;

        //REGISTER DAN LOGIN
        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select id,username,pass,kategori from dbo.login";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.pass = reader.GetString(2);
                    data.kategori = reader.GetString(3);
                    list.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return list;
        }
        public string Login(string username, string pass)
        {
            string kategori = "";
            string sql = "select kategori from login where username= '" + username + "' and pass='" + pass + "'";
            connection = new SqlConnection(constring);
            com = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                kategori = reader.GetString(0);
            }
            return kategori;
        }
        public string Register(string username, string pass, string kategori)
        {
            try
            {
                string sql = "insert into login values('" + username + "' , '" + pass + "','" + kategori + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                return "Register Sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string UpdateRegister(string username, string pass, string kategori, int id)
        {
            try
            {
                string sql2 = "update dbo.login set username = '" + username + "', pass = '" + pass + "', kategori = '" + kategori + "' where id =" + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                return "Sukses Mengubah Data";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        public string DeleteRegister(string username)
        {
            try
            {
                int id = 0;
                string sql = "select id from dbo.login where username = '" + username + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                connection.Close();
                string sql2 = "delete from dbo.login where id = " + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "Sukses Menghapus Data";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        //JABATAN---------------------------------------------------------------------------------------------------------------------------------------
        public string jabatan(int idjabatan, string jabatan, int gajipokok, int tjjabatan)
        {
            string a = "Gagal Menambahkan Data";
            try
            {
                string sql = "insert into dbo.jabatan values ('" + idjabatan + "', '" + jabatan + "', '" + gajipokok + "', '" + tjjabatan + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menambahkan Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<jabatanview> jabatanview()
        {
            List<jabatanview> jabatanviews = new List<jabatanview>();
            try
            {
                string sql = "select idjabatan,jabatan,gajipokok,tjjabatan from dbo.jabatan";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    jabatanview data = new jabatanview();
                    data.idjabatan = reader.GetInt32(0);
                    data.jabatan = reader.GetString(1);
                    data.gajipokok = reader.GetInt32(2);
                    data.tjjabatan = reader.GetInt32(3);
                    jabatanviews.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return jabatanviews;
        }
        public string editjabatan(int idjabatan, string jabatan, int gajipokok, int tjjabatan)
        {
            string a = "Gagal Mengubah Data";
            try
            {
                string sql = "update dbo.jabatan set jabatan = '" + jabatan + "', gajipokok = '" + gajipokok + "', tjjabatan = '" + tjjabatan + "' " +
                    "where idjabatan = '" + idjabatan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Mengubah Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string deletejabatan(int idjabatan)
        {
            string a = "Gagal Menghapus Data";
            try
            {
                string sql = "delete dbo.jabatan where idjabatan = '" + idjabatan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menghapus Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        //GOLONGAN---------------------------------------------------------------------------------------------------------------------------------------
        public string golongan(int idgolongan, int golongan, int tjkeluarga, int tjkesehatan, int uanglembur, int uangmakan)
        {
            string a = "Gagal Menambahkan Data";
            try
            {
                string sql = "insert into dbo.golongan values ('" + idgolongan + "', '" + golongan + "', '" + tjkeluarga + "', '" + tjkesehatan + "', '" + uanglembur + "', '" + uangmakan + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menambahkan Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<Golongan> Golongan()
        {
            List<Golongan> golongans = new List<Golongan>();
            try
            {
                string sql = "select * from dbo.golongan";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Golongan data = new Golongan();
                    data.idgolongan = reader.GetInt32(0);
                    data.golongan = reader.GetInt32(1);
                    data.tjkeluarga = reader.GetInt32(2);
                    data.tjkesehatan = reader.GetInt32(3);
                    data.uanglembur = reader.GetInt32(4);
                    data.uangmakan = reader.GetInt32(5);
                    golongans.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return golongans;
        }
        public string editgolongan(int idgolongan, int golongan, int tjkeluarga, int tjkesehatan, int uanglembur, int uangmakan)
        {
            string a = "Gagal Mengubah Data";
            try
            {
                string sql = "update dbo.golongan set golongan = '" + golongan + "', tjkeluarga = '" + tjkeluarga + "', tjkesehatan = '" + tjkesehatan + "', uanglembur = '" + uanglembur + "', uangmakan = '" + uangmakan + "' " +
                    "where idgolongan = '" + idgolongan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Mengubah Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string deletegolongan(int idgolongan)
        {
            string a = "Gagal Menghapus Data";
            try
            {
                string sql = "delete dbo.golongan where idgolongan = '" + idgolongan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menghapus Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        //KARYAWAN---------------------------------------------------------------------------------------------------------------------------------------
        public string karyawan(int idkaryawan, int nip, string nama, string jeniskelamin, string alamat, int idjabatan, int idgolongan, string status)
        {
            string a = "Gagal Menambahkan Data";
            try
            {
                string sql = "insert into dbo.karyawan values ('" + idkaryawan + "', '" + nip + "', '" + nama + "', '" + jeniskelamin + "', '" + alamat + "', '" + idjabatan + "', '" + idgolongan + "', '" + status + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menambahkan Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<Karyawan> Karyawan()
        {
            List<Karyawan> karyawans = new List<Karyawan>();
            try
            {
                string sql = "select * from dbo.karyawan";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Karyawan data = new Karyawan();
                    data.idkaryawan = reader.GetInt32(0);
                    data.nip = reader.GetInt32(1);
                    data.nama = reader.GetString(2);
                    data.jeniskelamin = reader.GetString(3);
                    data.alamat = reader.GetString(4);
                    data.idjabatan = reader.GetInt32(5);
                    data.idgolongan = reader.GetInt32(6);
                    data.status = reader.GetString(7);
                    karyawans.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return karyawans;
        }
        public string editkaryawan(int idkaryawan, int nip, string nama, string jeniskelamin, string alamat, int idjabatan, int idgolongan, string status)
        {
            string a = "Gagal Mengubah data";
            try
            {
                string sql = "update dbo.karyawan set nip = '" + nip + "', nama = '" + nama + "', jeniskelamin = '" + jeniskelamin + "', alamat = '" + alamat + "', idjabatan = '" + idjabatan + "', idgolongan = '" + idgolongan + "', status = '" + status + "' " +
                    "where idkaryawan = '" + idkaryawan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Mengubah Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string deletekaryawan(int idkaryawan)
        {
            string a = "Gagal Menghapus Data";
            try
            {
                string sql = "delete dbo.karyawan where idkaryawan = '" + idkaryawan + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menghapus Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        //HADIR---------------------------------------------------------------------------------------------------------------------------------------
        public string hadir(int idhadir, string bulan, int idkaryawan, int lembur, int masuk)
        {
            string a = "Gagal Menambahkan Data";
            try
            {
                string sql = "insert into dbo.hadir values ('" + idhadir + "', '" + bulan + "', '" + idkaryawan + "', '" + lembur + "', '" + masuk + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menambahkan Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<Hadir> Hadir()
        {
            List<Hadir> hadirs = new List<Hadir>();
            try
            {
                string sql = "select * from dbo.hadir";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Hadir data = new Hadir();
                    data.idhadir = reader.GetInt32(0);
                    data.bulan = reader.GetString(1);
                    data.idkaryawan = reader.GetInt32(2);
                    data.lembur = reader.GetInt32(3);
                    data.masuk = reader.GetInt32(4);
                    hadirs.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return hadirs;
        }
        public string edithadir(int idhadir, string bulan, int idkaryawan, int lembur, int masuk)
        {
            string a = "Gagal Mengubah Data";
            try
            {
                string sql = "update dbo.hadir set bulan = '" + bulan + "', idkaryawan = '" + idkaryawan + "', lembur = '" + lembur + "', masuk = '" + masuk + "' " +
                    "where idhadir = '" + idhadir + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Mengubah Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string deletehadir(int idhadir)
        {
            string a = "Gagal Menghapus Data";
            try
            {
                string sql = "delete dbo.hadir where idhadir = '" + idhadir + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menghapus Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        //GAJI---------------------------------------------------------------------------------------------------------------------------------------
        public string gaji(int noslip, DateTime tanggal, int idhadir, int subtotal, int pph)
        {
            string a = "Gagal Menambahkan Data";
            try
            {
                string t1 = tanggal.ToString("MM/dd/yyyy");
                string sql = "insert into dbo.gaji values ('" + noslip + "', '" + t1 + "', '" + idhadir + "', '" + subtotal + "', '" + pph + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menambahkan Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<gajiview> gajiview()
        {
            List<gajiview> gajiviews = new List<gajiview>();
            try
            {
                string sql = "select * from dbo.gaji";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    gajiview data = new gajiview();
                    data.idgaji = reader.GetInt32(0);
                    data.noslip = reader.GetInt32(1);
                    data.tanggal = reader.GetDateTime(2);
                    data.idhadir = reader.GetInt32(3);
                    data.subtotal = reader.GetInt32(4);
                    data.pph = reader.GetInt32(5);
                    data.total = reader.GetInt32(6);
                    gajiviews.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return gajiviews;
        }
        public string editgaji(int idgaji, int noslip, DateTime tanggal, int idhadir, int subtotal, int pph)
        {
            string a = "Gagal Mengubah Data";
            try
            {
                string t1 = tanggal.ToString("MM/dd/yyyy");
                string sql = "update dbo.gaji set noslip = '" + noslip + "', tanggal = '" + t1 + "', idhadir = '" + idhadir + "', subtotal = '" + subtotal + "', pph = '" + pph + "' where idgaji = '" + idgaji + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Mengubah Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public string deletegaji(int noslip)
        {
            string a = "Gagal Menghapus Data";
            try
            {
                string sql = "delete dbo.gaji where noslip = '" + noslip + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses Menghapus Data";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }
        public List<Gajisub> Gajisub(int idhadir)
        {
            List<Gajisub> gajisubs = new List<Gajisub>();
            try
            {
                string sql = "select (gajipokok+tjjabatan+tjkeluarga+tjkesehatan+( uangmakan*masuk)+(uanglembur*lembur)) as subtot from dbo.hadir h join dbo.karyawan k on h.idkaryawan = k.idkaryawan join jabatan j on k.idjabatan = j.idjabatan join golongan o on k.idgolongan = o.idgolongan where idhadir = '" + idhadir + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Gajisub data = new Gajisub();
                    data.subtot = reader.GetInt32(0);
                    gajisubs.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return gajisubs;
        }

        public List<Gaji> Gaji(int nip)
        {
            List<Gaji> gajis = new List<Gaji>();
            try
            {
                string sql = "select noslip, tanggal, bulan, nip, nama, jabatan, gajipokok, tjjabatan, golongan, tjkeluarga, tjkesehatan, uanglembur, uangmakan, lembur, masuk, subtotal, pph, total " +
                    "from gaji g join dbo.hadir h on g.idhadir = h.idhadir join dbo.karyawan k on h.idkaryawan = k.idkaryawan join jabatan j on k.idjabatan = j.idjabatan join golongan o on k.idgolongan = o.idgolongan where nip = '" + nip + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Gaji data = new Gaji();
                    data.noslip = reader.GetInt32(0);
                    data.tanggal = reader.GetDateTime(1);
                    data.bulan = reader.GetString(2);
                    data.nip = reader.GetInt32(3);
                    data.nama = reader.GetString(4);
                    data.jabatan = reader.GetString(5);
                    data.gajipokok = reader.GetInt32(6);
                    data.tjjabatan = reader.GetInt32(7);
                    data.golongan = reader.GetInt32(8);
                    data.tjkeluarga = reader.GetInt32(9);
                    data.tjkesehatan = reader.GetInt32(10);
                    data.uanglembur = reader.GetInt32(11);
                    data.uangmakan = reader.GetInt32(12);
                    data.lembur = reader.GetInt32(13);
                    data.masuk = reader.GetInt32(14);
                    data.subtotal = reader.GetInt32(15);
                    data.pph = reader.GetInt32(16);
                    data.total = reader.GetInt32(17);
                    gajis.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return gajis;
        }
        public List<gajiviewall> gajiviewall()
        {
            List<gajiviewall> gajiviewalls = new List<gajiviewall>();
            try
            {
                string sql = "select noslip, tanggal, bulan, nip, nama, jabatan, gajipokok, tjjabatan, golongan, tjkeluarga, tjkesehatan, uanglembur, uangmakan, lembur, masuk, subtotal, pph, total " +
                    "from gaji g join dbo.hadir h on g.idhadir = h.idhadir join dbo.karyawan k on h.idkaryawan = k.idkaryawan join jabatan j on k.idjabatan = j.idjabatan join golongan o on k.idgolongan = o.idgolongan";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    gajiviewall data = new gajiviewall();
                    data.noslip = reader.GetInt32(0);
                    data.tanggal = reader.GetDateTime(1);
                    data.bulan = reader.GetString(2);
                    data.nip = reader.GetInt32(3);
                    data.nama = reader.GetString(4);
                    data.jabatan = reader.GetString(5);
                    data.gajipokok = reader.GetInt32(6);
                    data.tjjabatan = reader.GetInt32(7);
                    data.golongan = reader.GetInt32(8);
                    data.tjkeluarga = reader.GetInt32(9);
                    data.tjkesehatan = reader.GetInt32(10);
                    data.uanglembur = reader.GetInt32(11);
                    data.uangmakan = reader.GetInt32(12);
                    data.lembur = reader.GetInt32(13);
                    data.masuk = reader.GetInt32(14);
                    data.subtotal = reader.GetInt32(15);
                    data.pph = reader.GetInt32(16);
                    data.total = reader.GetInt32(17);
                    gajiviewalls.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return gajiviewalls;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
