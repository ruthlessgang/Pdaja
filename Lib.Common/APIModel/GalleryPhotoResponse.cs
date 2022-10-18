using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class GalleryPhotoResponse
    {
        public GalleryPhotoModel Photo { get; set; }
        public Status Status { get; set; }
        public GalleryPhotoResponse()
        {
            Photo = new GalleryPhotoModel();
            Status = new Status();
        }
    }
}
