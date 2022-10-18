using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class BannerResponse
    {
        public List<Banner> Banner { get; set; }
        public Status Status { get; set; }
        public BannerResponse()
        {
            Banner = new List<Banner>();
            Status = new Status();
        }
    }
}
