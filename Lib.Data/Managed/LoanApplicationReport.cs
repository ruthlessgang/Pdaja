using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Data
{
    public partial class LoanApplicationReport
    {
        public static List<SP_LoanApplication_Report_Result> GetAll(int start, int pageSize, string noAplikasi, string jenisJaminan, string tanggalPengajuanStart, string tanggalPengajuanEnd, string namaDebitur, string tanggalStatusStart, string tanggalStatusEnd, string origination, string stageCode)
        {
            return DataRepositoryFactory.CurrentRepository.SP_LoanApplication_Report(noAplikasi, start, pageSize, namaDebitur, tanggalPengajuanStart, tanggalPengajuanEnd, jenisJaminan, tanggalStatusStart, tanggalStatusEnd, origination, stageCode).ToList();
        }
    }
}
