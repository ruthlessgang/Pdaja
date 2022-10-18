using System.Collections.Generic;
using System.Web;

namespace Lib.Common.DataModel
{
    public class ContentWebModel
    {
        public long ID { get; set; }
        public long CategoryID { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ContentBody { get; set; }
        public string ThumbnailImage { get; set; }
        public string ThumbnailImagePath { get; set; }
        public string ImagesWeb { get; set; }
        public string ImagesWebPath { get; set; }
        public string ImagesMobile { get; set; }
        public string ImagesMobilePath { get; set; }
        public List<ContentGallery> Galeries { get; set; }
        public bool IsMekarinAja { get; set; }
    }

}