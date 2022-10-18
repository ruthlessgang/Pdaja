using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class CertTypeRequest
    {
        public string CT_CODE { get; set; }
        public string CT_DESC { get; set; }
        public string CORE_CODE { get; set; }
        public bool ISPDAJA { get; set; }
        public bool ACTIVE { get; set; }
        public string STATUS_POST { get; set; }

    }

    public class CertTypeResponse
    {
        public List<CertTypeRequest> CertType { get; set; }
        public Status Status { get; set; }

        public CertTypeResponse()
        {
            CertType = new List<CertTypeRequest>();
            Status = new Status();
        }
    }
}
