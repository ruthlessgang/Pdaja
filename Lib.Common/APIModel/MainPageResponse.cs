using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class MainPageResponse
    {
        public List<ContentMainPage> Contents{ get; set; }
        public List<BannerModels> Banners { get; set; }
        public Status Status { get; set; }
        public List<RFStatisticModels> listRFStatisticModels { get; set; }

        public MainPageResponse()
        {
            Contents = new List<ContentMainPage>();
            Banners = new List<BannerModels>();
            listRFStatisticModels = new List<RFStatisticModels>();
            Status = new Status();
        }
    }
}
