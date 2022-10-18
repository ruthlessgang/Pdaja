using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class LoanRequest
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<LoanRequest>();
                model.ID = this.ID;
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public EFResponse Update()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.UpdateSave<LoanRequest>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<LoanRequest> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.LoanRequests;
        }

        public static LoanRequest GetLoanRequestWithRequestDateRange(DateTime startDate, DateTime endDate)
        {
            IQueryable<LoanRequest> res = GetAll().Where(x => x.CreatedDate.Date >= startDate.Date && x.CreatedDate.Date <= endDate.Date);
            return res.FirstOrDefault();
        }

        public static LoanRequest GetLoanRequestForUpdate(LoanApplication data)
        {
            IQueryable<LoanRequest> res = GetAll().Where(x => 
                x.JenisJaminan == data.JenisJaminan 
                && x.LuasBangunan == data.LuasBangunan && x.LuasTanah == data.LuasTanah 
                && x.latitude == data.latitude && x.longitude == data.longitude
                && x.NamaProperty== data.NamaProperty
                && (x.LoanApplicationID == null || x.LoanApplicationID == 0)).OrderByDescending(x => x.CreatedDate);
            return res.FirstOrDefault();
        }
        public static LoanRequest GetLoanRequestByCustIDAnGuid(string custID, string guid)
        {
            IQueryable<LoanRequest> res = GetAll().Where(x => x.CustID == custID && x.Guid_LogLDML == guid).OrderByDescending(x => x.CreatedDate);
            return res.FirstOrDefault();
        }
    }
}
