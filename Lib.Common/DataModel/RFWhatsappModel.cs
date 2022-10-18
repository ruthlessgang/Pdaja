using System;

namespace Lib.Common.DataModel
{
    public class RFWhatsappModel
    {
        public Guid ID { get; set; }
        public string PhoneName { get; set; }
        public string PhoneNumber { get; set; }
        public string BodyText { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsMekarinAja { get; set; }
    }
}
