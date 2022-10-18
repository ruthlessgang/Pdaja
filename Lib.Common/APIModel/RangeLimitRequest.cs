using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class RangeLimitRequest
    {
        public string IdCust { get; set; }
        public int JenisJaminan { get; set; }
        public string KondisiJaminan { get; set; }
        public double LT { get; set; }
        public double LB { get; set; }
        public string AlamatJaminan { get; set; }
        public long Provinsi { get; set; }
        public long Kota { get; set; }
        //public long Kabupaten { get; set; }
        public long Kecamatan { get; set; }
        public long Kelurahan { get; set; }
        public string KodePos { get; set; }
        public long IdDataAsset { get; set; }
        public string NamaProperty { get; set; }
        public bool IsPrime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public string Guid_LogLDML { get; set; }
        public string CT_CODE { get; set; }
        //public decimal Limit { get; set; }
        public bool IsAlamatBerbeda { get; set; }
        public string AlamatJaminanInput { get; set; }

        // penambahan api requestapp - Tommy 3/3/2020 //
        public string Custype { get; set; }
        public string Tenor { get; set; }
        public string BusinessSegment { get; set; }
        public string Product { get; set; }
        // end of penambahan api requestapp - Tommy 3/3/2020  //

        // penambahan api requestapp - Fikri 27/05/2021 //
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Handphone { get; set; }
        public string ReferralCode { get; set; }
        // end of penambahan api requestapp - Fikri 27/05/2021 //
    }
}
