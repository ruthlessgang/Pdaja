using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.APIModel
{
    public class MaxLoanData
    {
        public string DocumentType { get; set; }
        public decimal MaxLoan { get; set; }
        public Status Status { get; set; }

        public MaxLoanData()
        {
            Status = new Status();
        }
    }
}
