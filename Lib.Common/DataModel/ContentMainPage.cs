using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.DataModel
{
    public class ContentMainPage
    {
        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryDescription { get; set; }
        public string Type { get; set; }
        public List<ContentWebModel> Contents { get; set; }
        public List<TestimoniModel> Testimoni { get; set; }
        public bool IsMekarinAja { get; set; }
        public ContentMainPage()
        {
            CategoryName = string.Empty;
            CategoryTitle = string.Empty;
            CategoryDescription = string.Empty;
            Type = string.Empty;
            Contents = new List<ContentWebModel>();
            Testimoni = new List<TestimoniModel>();
        }
    }
}
