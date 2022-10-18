using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFStatistic
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFStatistic>();
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
                this.UpdatedDate = DateTime.Now;
                this.UpdateSave<RFStatistic>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFStatistic> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFStatistics.Where(x => x.IsDeleted == false);
        }
        public static IQueryable<RFStatistic> GetAllApprove()
        {
            return DataRepositoryFactory.CurrentRepository.RFStatistics.Where(x => x.IsDeleted == false && x.IsApproved == true);
        }

        public static RFStatistic GetByID(long ID)
        {
            IQueryable<RFStatistic> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }
    }
}
