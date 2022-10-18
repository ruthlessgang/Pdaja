using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class LOSInquiryRequest
    {
        public string Nomorhandphone { get; set; }
        public string NoAplikasi { get; set; }
        public string Code { get; set; }

        public ReqAppStatus AppStatus { get; set; }
    }

    public class LOSInquiryResponseData
    {
        public List<LOSInquiryResponse> Inquiry { get; set; }
        public Status Status { get; set; }
        public LOSInquiryResponseData()
        {
            Inquiry = new List<LOSInquiryResponse>();
            Status = new Status();
        }
    }

    public class LOSInquiryResponse
    {
        public string NoAplikasi { get; set; }
        public string Namadebitur { get; set; }
        public decimal limit { get; set; }
        public int tenor { get; set; }
        public string TanggalPengajuan { get; set; }
        public string StatusAplikasi { get; set; }
    }

    public class InquiryResponse
    {
        public string IdCust { get; set; }
        public string NoHandphone { get; set; }
        public string NoAplikasi { get; set; }
        public string StatusApp { get; set; }
    }
}
