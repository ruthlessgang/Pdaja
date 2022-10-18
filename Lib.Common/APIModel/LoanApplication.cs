using System;

namespace Lib.Common.APIModel
{
    public class LoanApplication
    {
        public string CustID { get; set; }
        public int JenisJaminan { get; set; }
        public string KondisiJaminan { get; set; }
        public string Alamat { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public decimal LuasTanah { get; set; }
        public decimal LuasBangunan { get; set; }
        public bool TempatTinggal { get; set; }
        public bool TempatUsaha { get; set; }
        public bool SedangDisewakan { get; set; }
        public string PRK { get; set; }
        public decimal RangePinjamanMin { get; set; }
        public decimal RangePinjamanMax { get; set; }
        public decimal BungaEfektif { get; set; }
        public string Provisi { get; set; }
        public decimal NilaiPengajuan { get; set; }
        public int JangkaWaktu { get; set; }
        public string ApplicationStatus { get; set; }
        public int IdDataAsset { get; set; }
        public string NamaProperty { get; set; }
        public string RefferalName { get; set; }
        public string DOC_CODE { get; set; }
        public decimal EstimasiNilaiAset { get; set; }
        public bool IsAlamatBerbeda { get; set; }
        public string AlamatJaminanInput { get; set; }
        public string Guid_LogLDML { get; set; }
        public string JenisProduct { get; set; }
        public decimal NominalAngsuran { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Handphone { get; set; }
    }
}
