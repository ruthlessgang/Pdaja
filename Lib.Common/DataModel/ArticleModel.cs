using System;

namespace Lib.Common.DataModel
{
    public class ArticleModel
    {
        public long ID { get; set; }
        public string Headline { get; set; }
        public string Description { get; set; }
        public string ImagesWeb { get; set; }
        public string ImagesWebPath { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
