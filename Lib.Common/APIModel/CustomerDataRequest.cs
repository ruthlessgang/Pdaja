using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class CustomerDataRequest
    {
        public LoanApplication LoanApplication { get; set; }
        public PersonalData PersonalData { get; set; }
        public List<PersonalDocument> PersonalDocument { get; set; }
    }
}
