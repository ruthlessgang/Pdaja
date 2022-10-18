using System;

namespace Lib.Common.DataModel
{
    public class RFSpotContestModels
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkUrl { get; set; }
        public string ImagesWeb { get; set; }
        public string ImagesWebPath { get; set; }
        public string ImagesMobile { get; set; }
        public string ImagesMobilePath { get; set; }
        public int Sort { get; set; }
        public bool IsAutoPublish { get; set; }
        public string IsAutoPublishString { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public bool IsMekarinAja { get; set; }
    }
}
