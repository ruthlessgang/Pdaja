using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class StatusAppRequest
    {
        public int Id { get; set; }
        public string IdCust { get; set; }
        public string AP_REGNO { get; set; }
        public decimal Limit { get; set; }
        public string TR_CODE { get; set; }
        public string TR_DESC { get; set; }
        public string AlamatJaminan { get; set; }
        public DateTime AP_LASTTRDATE { get; set; }
        public string Stage_By { get; set; }
        public string Jabatan { get; set; }
        public bool ISUpdate { get; set; }
        public decimal LimitApprove { get; set; }
        public string Origination { get; set; }
        public string Status_Post { get; set; }
    }
    public class StatusAppResponse
    {
        public StatusAppRequest StatusApp { get; set; }
        public Status Status { get; set; }

        public StatusAppResponse()
        {
            StatusApp = new StatusAppRequest();
            Status = new Status();
        }
    }
}
