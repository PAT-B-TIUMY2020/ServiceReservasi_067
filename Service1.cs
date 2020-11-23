using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=DESKTOP-SU3D3TD;Initial Catalog=WCFTest;Persist Security Info=True; User ID=sa;Password=goldensilk2020";
        SqlConnection connection;
        SqlCommand command; // Untuk mengkoneksikan database ke Visual Studio

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<DetailLokasi> DetailLokasi()
        {
            // Proses untuk mendeklarasikan nama list yang telah dibuat dengan nama baru
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
            try
            {
                // Mengkoneksikan query
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                // Fungsi koneksi ke database
                connection = new SqlConnection(constring);
                // Proses mengeksekusi query
                command = new SqlCommand(sql, connection);
                // Membuka Koneksi
                connection.Open();
                // Menampilkan data query
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    /* Nama class */
                    //Deklarasikan data dan mengambil satu per satu dari database
                    DetailLokasi data = new DetailLokasi();
                    // Bentuk array
                    // Index berupa 0, ada di kolom ke berapa di string sql diatas
                    data.IDLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    // Mengumpulkan data yang awalnya dari array
                    LokasiFull.Add(data);
                }
                // Untuk menutup akses ke database
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }

        public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelpon, int JumlahPemesanan, string IDLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values('" + IDPemesanan + "', '" + NamaCustomer + "', '" + NoTelpon + "', '" + JumlahPemesanan + "', '" + IDLokasi + "')";
                // Fungsi koneksi ke database
                connection = new SqlConnection(constring);
                command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string editPemesanan(string IDPemesanan, string NamaCustomer)
        {
            throw new NotImplementedException();
        }

        public string deletePemesanan(string IDPemesanan)
        {
            throw new NotImplementedException();
        }

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        //        public CompositeType GetDataUsingDataContract(CompositeType composite)
        //        {
        //            if (composite == null)
        //            {
        //                throw new ArgumentNullException("composite");
        //            }
        //            if (composite.BoolValue)
        //            {
        //                composite.StringValue += "Suffix";
        //            }
        //            return composite;
        //        }
    }
}
