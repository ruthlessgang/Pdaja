using System.Web;

namespace Lib.Common.DataModel
{
    public class ImagesGalleryModel
    {
        public long ID { get; set; }
        public long ContentWebID { get; set; }
        public HttpPostedFileBase ImagesWeb { get; set; }
        public string ImagesWebPath { get; set; }
        public HttpPostedFileBase ImagesMobile { get; set; }
        public string ImagesMobilePath { get; set; }
        public string Type { get; set; }
        public int Sort { get; set; }
    }
}