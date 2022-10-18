using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class DocumentSyncData
    {
        public bool ACTIVE { get; set; }
        public string CORE_CODE { get; set; }   
        public string DOC_CODE { get; set; }
        public string DOC_DESC { get; set; }
        public string DOC_TYPE { get; set; }
    }
}
