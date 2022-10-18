using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class JenisDokumenJaminanRequest
    {
        public string DOC_CODE { get; set; }
        public string DOC_DESC { get; set; }
        public string DOC_INFO { get; set; }
    }

    public class JenisDokumenJaminanResponse
    {
        public List<JenisDokumenJaminanRequest> JenisDokumenJaminan { get; set; }
        public Status Status { get; set; }

        public JenisDokumenJaminanResponse()
        {
            JenisDokumenJaminan = new List<JenisDokumenJaminanRequest>();
            Status = new Status();
        }
    }
}
