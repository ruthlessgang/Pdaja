using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class ContentWebResponse
    {
        public List<ContentWebModel> Content { get; set;}
        public Status Status { get; set; }
        public ContentWebResponse()
        {
            Content = new List<ContentWebModel>();
            Status = new Status();
        }
    }
}
