using System.Collections.Generic;

namespace Lib.Common.DataModel
{
    public class ContentGallery
    {
        public long ID { get; set; }
        public long ContentWebID { get; set; }
        public long ParentID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Sort { get; set; }
        public bool IsShow { get; set; }
        public List<ContentGallery> Children { get; set; }
    }
}