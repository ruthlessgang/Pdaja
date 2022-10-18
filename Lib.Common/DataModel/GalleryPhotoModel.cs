using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.DataModel
{
    public class GalleryPhotoModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ImageThumbnail { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GalleryPhotoListModel> PhotoList { get; set; }
        public object Status { get; set; }
    }

    public class GalleryPhotoListModel
    {
        public string PhotoImage { get; set; }
        public string Caption { get; set; }
    }
}
