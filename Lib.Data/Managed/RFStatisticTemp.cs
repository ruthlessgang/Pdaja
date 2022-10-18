using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFStatisticTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFStatisticTemp>();
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
                this.UpdateSave<RFStatisticTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFStatisticTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFStatisticTemps.Where(x => x.IsDeleted == false);
        }

        public static RFStatisticTemp GetByID(long ID)
        {
            IQueryable<RFStatisticTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }
        public static RFStatisticTemp GetNotSuccesByID(long ID)
        {
            IQueryable<RFStatisticTemp> res = GetAll().Where(x => x.ID == ID && x.IsSuccess != true);
            return res.FirstOrDefault();
        }
    }
}
