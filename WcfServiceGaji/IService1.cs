using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceGaji
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string jabatan(int idjabatan, string jabatan, int gajipokok, int tjjabatan);
        [OperationContract]
        string editjabatan(int idjabatan, string jabatan, int gajipokok, int tjjabatan);
        [OperationContract]
        string deletejabatan(int idjabatan);
        [OperationContract]
        List<jabatanview> jabatanview();

        [OperationContract]
        string golongan(int idgolongan, int golongan, int tjkeluarga, int tjkesehatan, int uanglembur, int uangmakan);
        [OperationContract]
        string editgolongan(int idgolongan, int golongan, int tjkeluarga, int tjkesehatan, int uanglembur, int uangmakann);
        [OperationContract]
        string deletegolongan(int idgolongan);
        [OperationContract]
        List<Golongan> Golongan();

        [OperationContract]
        string karyawan(int idkaryawan, int nip, string nama, string jeniskelamin, string alamat, int idjabatan, int idgolongan, string status);
        [OperationContract]
        string editkaryawan(int idkaryawan, int nip, string nama, string jeniskelamin, string alamat, int idjabatan, int idgolongan, string status);
        [OperationContract]
        string deletekaryawan(int idkaryawan);
        [OperationContract]
        List<Karyawan> Karyawan();

        [OperationContract]
        string hadir(int idhadir, string bulan, int idkaryawan, int lembur, int masuk);
        [OperationContract]
        string edithadir(int idhadir, string bulan, int idkaryawan, int lembur, int masuk);
        [OperationContract]
        string deletehadir(int idhadir);
        [OperationContract]
        List<Hadir> Hadir();

        [OperationContract]
        string gaji(int noslip, DateTime tanggal, int idhadir, int subtotal, int pph);
        [OperationContract]
        string editgaji(int idgaji, int noslip, DateTime tanggal, int idhadir, int subtotal, int pph);
        [OperationContract]
        string deletegaji(int noslip);
        [OperationContract]
        List<Gajisub> Gajisub(int idhadir);
        [OperationContract]
        List<gajiview> gajiview();
        [OperationContract]
        List<Gaji> Gaji(int nip);
        [OperationContract]
        List<gajiviewall> gajiviewall();

        [OperationContract]
        string Login(string username, string pass);
        [OperationContract]
        string Register(string username, string pass, string kategori);
        [OperationContract]
        string UpdateRegister(string username, string pass, string kategori, int id);
        [OperationContract]
        string DeleteRegister(string username);
        [OperationContract]
        List<DataRegister> DataRegist();

        // TODO: Add your service operations here
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string pass { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }

    [DataContract]
    public class jabatanview
    {
        [DataMember]
        public int idjabatan { get; set; }
        [DataMember]
        public string jabatan { get; set; }
        [DataMember]
        public int gajipokok { get; set; }
        [DataMember]
        public int tjjabatan { get; set; }
    }

    [DataContract]
    public class Golongan
    {
        [DataMember]
        public int idgolongan { get; set; }
        [DataMember]
        public int golongan { get; set; }
        [DataMember]
        public int tjkeluarga { get; set; }
        [DataMember]
        public int tjkesehatan { get; set; }
        [DataMember]
        public int uanglembur { get; set; }
        [DataMember]
        public int uangmakan { get; set; }
    }

    [DataContract]
    public class Karyawan
    {
        [DataMember]
        public int idkaryawan { get; set; }
        [DataMember]
        public int nip { get; set; }
        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public string jeniskelamin { get; set; }
        [DataMember]
        public string alamat { get; set; }
        [DataMember]
        public int idjabatan { get; set; }
        [DataMember]
        public int idgolongan { get; set; }
        [DataMember]
        public string status { get; set; }
    }

    [DataContract]
    public class Hadir
    {
        [DataMember]
        public int idhadir { get; set; }
        [DataMember]
        public string bulan { get; set; }
        [DataMember]
        public int idkaryawan { get; set; }
        [DataMember]
        public int lembur { get; set; }
        [DataMember]
        public int masuk { get; set; }
    }

    [DataContract]
    public class Gajisub
    {
        [DataMember]
        public int subtot { get; set; }

    }

    [DataContract]
    public class gajiview
    {
        [DataMember]
        public int idgaji { get; set; }
        [DataMember]
        public int noslip { get; set; }
        [DataMember]
        public DateTime tanggal { get; set; }
        [DataMember]
        public int idhadir { get; set; }
        [DataMember]
        public int subtotal { get; set; }
        [DataMember]
        public int pph { get; set; }
        [DataMember]
        public int total { get; set; }
    }

    [DataContract]
    public class Gaji
    {
        [DataMember]
        public int noslip { get; set; }
        [DataMember]
        public DateTime tanggal { get; set; }
        [DataMember]
        public string bulan { get; set; }
        [DataMember]
        public int lembur { get; set; }
        [DataMember]
        public int masuk { get; set; }
        [DataMember]
        public int subtotal { get; set; }
        [DataMember]
        public int pph { get; set; }
        [DataMember]
        public int total { get; set; }

        [DataMember]
        public string jabatan { get; set; }
        [DataMember]
        public int gajipokok { get; set; }
        [DataMember]
        public int tjjabatan { get; set; }

        [DataMember]
        public int golongan { get; set; }
        [DataMember]
        public int tjkeluarga { get; set; }
        [DataMember]
        public int tjkesehatan { get; set; }
        [DataMember]
        public int uanglembur { get; set; }
        [DataMember]
        public int uangmakan { get; set; }

        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public int nip { get; set; }
    }

    [DataContract]
    public class gajiviewall
    {
        [DataMember]
        public int noslip { get; set; }
        [DataMember]
        public DateTime tanggal { get; set; }
        [DataMember]
        public string bulan { get; set; }
        [DataMember]
        public int lembur { get; set; }
        [DataMember]
        public int masuk { get; set; }
        [DataMember]
        public int subtotal { get; set; }
        [DataMember]
        public int pph { get; set; }
        [DataMember]
        public int total { get; set; }

        [DataMember]
        public string jabatan { get; set; }
        [DataMember]
        public int gajipokok { get; set; }
        [DataMember]
        public int tjjabatan { get; set; }

        [DataMember]
        public int golongan { get; set; }
        [DataMember]
        public int tjkeluarga { get; set; }
        [DataMember]
        public int tjkesehatan { get; set; }
        [DataMember]
        public int uanglembur { get; set; }
        [DataMember]
        public int uangmakan { get; set; }

        [DataMember]
        public string nama { get; set; }
        [DataMember]
        public int nip { get; set; }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
