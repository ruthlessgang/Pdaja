using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class GalleryVideosResponse 
    {
        public List<GalleryVideoModel> Videos { get; set; }
        public Status Status { get; set; }
        public GalleryVideosResponse()
        {
            Videos = new List<GalleryVideoModel>();
            Status = new Status();
        }
    }
}
