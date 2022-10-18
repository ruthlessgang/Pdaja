using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class PersonalDocument
    {
        public long LoanApplicationID { get; set; }
        public string NomorID { get; set; }
        public string CategoryDocument { get; set; }
        public string Images { get; set; }
        public int Sort { get; set; }
    }
}
