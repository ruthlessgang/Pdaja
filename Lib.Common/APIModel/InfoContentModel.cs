using Lib.Common.DataModel;
using Lib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class InfoContentModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ContentBody { get; set; }
        public string Slug { get; set; }
        public Status Status { get; set; }
        public InfoContentModel()
        {
            Status = new Status();
        }
    }
}
