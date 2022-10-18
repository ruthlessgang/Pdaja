using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public static class ResponseStatus
    {
        public static Status Success = new Status() { Code = "000", Type = "SUCCESS", Message = "Success"};

        public static Status NotFound = new Status() { Code = "999", Type = "SUCCESS", Message = "Notfound" };

        public static Status Error = new Status() { Code = "900", Type = "ERROR", Message = "ERROR" };
    }
}
