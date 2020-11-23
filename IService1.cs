﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //        [OperationContract]
        //        string GetData(int value);

        //        [OperationContract]
        //        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        // Method proses input data
        [OperationContract]
        string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelpon, int JumlahPemesanan, string IDLokasi);
        [OperationContract]
        string editPemesanan(string IDPemesanan, string NamaCustomer);
        [OperationContract]
        string deletePemesanan(string IDPemesanan);
        [OperationContract]
        List<CekLokasi> ReviewLokasi(); // Menampilkan data yang ada dalam database (select all) // Menampilkan isi dari yang ada contract-nya
        [OperationContract]
        List<DetailLokasi> DetailLokasi(); // Menampilkan detail lokasi
        [OperationContract]
        List<Pemesanan> Pemesanan();
    }

    [DataContract]
    public class CekLokasi // Daftar lokasi nongkrong
    {
        [DataMember]
        public string IDLokasi { get; set; } // Variabel dari public class
        [DataMember]
        public string NamaLokasi { get; set; }
        [DataMember]
        public string DeskripsiSingkat { get; set; }
    }

    [DataContract]
    public class DetailLokasi // Menampilkan detail lokasi
    {
        [DataMember]
        public string IDLokasi { get; set; }
        [DataMember]
        public string NamaLokasi { get; set; }
        [DataMember]
        public string DeskripsiFull { get; set; }
        [DataMember]
        public int Kuota { get; set; }
    }

    [DataContract]
    public class Pemesanan // Create
    {
        [DataMember]
        public string IDPemesanan { get; set; }
        [DataMember]
        public string NamaCustomer { get; set; } // Method
        [DataMember]
        public string NoTelpon { get; set; }
        [DataMember]
        public int JumlahPemesanan { get; set; }
        [DataMember]
        public string IDLokasi { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceReservasi.ContractType".
//    [DataContract]
//    public class CompositeType
//    {
//        bool boolValue = true;
//        string stringValue = "Hello ";

//        [DataMember]
//        public bool BoolValue
//        {
//            get { return boolValue; }
//            set { boolValue = value; }
//        }

//        [DataMember]
//        public string StringValue
//        {
//            get { return stringValue; }
//            set { stringValue = value; }
//        }
//    }
}