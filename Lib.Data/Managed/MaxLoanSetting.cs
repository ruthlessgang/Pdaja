using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class MaxLoanSetting
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<MaxLoanSetting>();
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
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.UpdatedDate = DateTime.Now;
                this.UpdateSave<MaxLoanSetting>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<MaxLoanSetting> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.MaxLoanSettings
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CreatedDate);
        }

        public static MaxLoanSetting GetByID(long ID)
        {
            IQueryable<MaxLoanSetting> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<MaxLoanSetting> GetAllMaxLoan()
        {
            var res = GetAll().Where(x => x.IsApproved).GroupBy(l => l.DocumentType)
                                .Select(g => g.OrderByDescending(l => l.ID).FirstOrDefault());

            return res;
        }

    }
}
