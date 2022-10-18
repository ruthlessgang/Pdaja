using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lib.Data
{
    public partial class LoanApplication
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<LoanApplication>();
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

        public static IQueryable<LoanApplication> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.LoanApplications;
        }

        public static LoanApplication GetByCustID(string CustID)
        {
            IQueryable<LoanApplication> res = GetAll().Where(x => x.CustID == CustID);
            return res.FirstOrDefault();
        }

        public EFResponse Update()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.UpdateSave<LoanApplication>();
                model.Success = true;
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }
    }
}
