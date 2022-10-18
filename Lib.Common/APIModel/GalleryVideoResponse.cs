using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class GalleryVideoResponse 
    {
        public GalleryVideoModel Video { get; set; }
        public Status Status { get; set; }
        public GalleryVideoResponse()
        {
            Video = new GalleryVideoModel();
            Status = new Status();
        }
    }
}
