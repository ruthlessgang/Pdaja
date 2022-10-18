using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public class EFResponse
    {
        public EFResponse()  // static ctor
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string ErrorEntity { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class EFResponse_with_ID
    {
        public EFResponse_with_ID()  // static ctor
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string ErrorEntity { get; set; }
        public string ErrorMessage { get; set; }
        public long ID { get; set; }
    }
}
