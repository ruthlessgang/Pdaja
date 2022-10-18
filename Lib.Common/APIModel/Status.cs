using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class Status
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }

        public Status()
        {
            Code = string.Empty;
            Message = string.Empty;
            Type = string.Empty;
        }
    }
}
