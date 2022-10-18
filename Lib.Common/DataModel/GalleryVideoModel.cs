using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.DataModel
{
    public class GalleryVideoModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ImageThumbnail { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<GalleryVideoListModel> VideoList { get; set; }
    }
    
    public class GalleryVideoListModel
    {
        public string VideoUrl { get; set; }
        public string Caption { get; set; }
        public string VideoID { get; set; }
    }
}
