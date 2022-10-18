using Lib.Common.DataModel;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class MenuResponse
    {
        public List<MenuWebModel> Menu { get; set; }
        public Status Status { get; set; }

        public MenuResponse()
        {
            Menu = new List<MenuWebModel>();
            Status = new Status();
        }
    }
}
