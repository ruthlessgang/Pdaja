using System.Collections.Generic;

namespace Lib.Common.APIModel
{
    public class AddressRequest
    {
        public long ID_RFPROVINSI { get; set; }
        public long ID_RFKABUPATEN_KODYA { get; set; }
        public long ID_RFKECAMATAN { get; set; }
        public long ID_RFKELURAHAN { get; set; }
        public string NAMA_PROVINSI { get; set; }
        public string NAMA_KABUPATEN_KODYA { get; set; }
        public string NAMA_KECAMATAN { get; set; }
        public string NAMA_KELURAHAN { get; set; }
        public string KODE_POS { get; set; }
        public string STATUS_POST { get; set; }
        public bool IS_DELETED { get; set; }
    }

    public class AddressResponse
    {
        public List<AddressRequest> Address { get; set; }
        public Status Status { get; set; }

        public AddressResponse()
        {
            Address = new List<AddressRequest>();
            Status = new Status();
        }
    }
}