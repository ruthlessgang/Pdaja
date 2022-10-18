using System;

namespace Lib.Common.DataModel
{
    public class RFStatisticModels
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsApproved { get; set; }
        public int TypeStatus { get; set; }
        public bool IsMekarinAja { get; set; }
    }
}