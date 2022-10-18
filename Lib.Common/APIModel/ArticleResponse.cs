using Lib.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class ArticleResponse
    {
        public List<ArticleModel> Articles { get; set; }
        public Status Status { get; set; }

        public ArticleResponse()
        {
            Articles = new List<ArticleModel>();
            Status = new Status();
        }
    }
}
