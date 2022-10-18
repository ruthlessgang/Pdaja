using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class LoanRequestReport
    {
        public static List<SP_LoanRequest_Report_Result> GetAll(int start, int pageSize, string jenisJaminan, string tanggalPengajuanStart, string tanggalPengajuanEnd)
        {
            return DataRepositoryFactory.CurrentRepository.SP_LoanRequest_Report(start, pageSize, tanggalPengajuanStart, tanggalPengajuanEnd, jenisJaminan).ToList();
        }
        
    }
}
