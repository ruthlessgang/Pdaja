using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class GalleryPhotosResponse
    {
        public List<GalleryPhotoModel> Photos { get; set; }
        public Status Status { get; set; }
        public GalleryPhotosResponse()
        {
            Photos = new List<GalleryPhotoModel>();
            Status = new Status();
        }
    }
}
