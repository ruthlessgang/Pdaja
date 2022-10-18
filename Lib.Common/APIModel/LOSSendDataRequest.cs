using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class LOSSendDataRequest
    {
        public string IdCust { get; set; }
        public string TanggalPengajuan { get; set; }
        public string AgentCode { get; set; }
        public string Refferal { get; set; }
        public string NamaDebitur { get; set; }
        public string Email { get; set; }
        public string NomorHandphone { get; set; }
        public string NamaPasangan { get; set; }
        public int Tenor { get; set; }
        public string AlamatJaminan { get; set; }
        public decimal Limit { get; set; }
        public decimal SukuBunga { get; set; }
        public string Provisi { get; set; }
        public string JenisJaminan { get; set; }
        public string KondisiJaminan { get; set; }
        public double LuasTanah { get; set; }
        public double LuasBangunan { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string KtpDebiturNo { get; set; }
        public string KtpDebiturFoto { get; set; }
        public string KtpPasanganNo { get; set; }
        public string KtpPasanganFoto { get; set; }
        public string PBBNo { get; set; }
        public string PBBFoto { get; set; }
        public string SertifikatNo { get; set; }
        public string SertifikatFoto1 { get; set; }
        public string SertifikatFoto2 { get; set; }
        public string SertifikatFoto3 { get; set; }
        public string Guid_LogLDML { get; set; }
        public string RefferalName { get; set; }
        public string CT_CODE { get; set; }
        public decimal EstimasiNilaiAset { get; set; }
        public bool IsAlamatBerbeda { get; set; }
        public string AlamatJaminanInput { get; set; }
        public string BusinessSegment { get; set; }
        public string Product { get; set; }
    }
}
