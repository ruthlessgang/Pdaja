using System.Web;

namespace Lib.Common.DataModel
{
    public class TestimoniModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Images { get; set; }
        public string ImagesPath { get; set; }
        public string Message { get; set; }
        public int Sort { get; set; }
        public bool IsMekarinAja { get; set; }
    }

}