using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class CustomerDataResponse
    {
        public LOSSendDataResponse Data { get; set; }
        public Status Status { get; set; }
        public CustomerDataResponse()
        {
            Data = new LOSSendDataResponse();
            Status = new Status();
        }
    }
}
