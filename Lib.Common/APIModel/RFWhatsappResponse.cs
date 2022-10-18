using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class RFWhatsappResponse
    {
        public List<RFWhatsappModel> RFWhatsapps { get; set; }
        public Status Status { get; set; }

        public RFWhatsappResponse()
        {
            RFWhatsapps = new List<RFWhatsappModel>();
            Status = new Status();
        }
    }
}
