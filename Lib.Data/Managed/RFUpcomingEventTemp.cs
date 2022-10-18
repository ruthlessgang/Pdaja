using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFUpcomingEventTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFUpcomingEventTemp>();
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
                this.UpdateSave<RFUpcomingEventTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFUpcomingEventTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFUpcomingEventTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static RFUpcomingEventTemp GetByID(long ID)
        {
            IQueryable<RFUpcomingEventTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static RFUpcomingEventTemp GetByRFUpcomingEventIDandTypeDocument(long RFUpcomingEventID, int TypeDocument)
        {
            IQueryable<RFUpcomingEventTemp> res = GetAll().Where(x => x.RFUpcomingEventID == RFUpcomingEventID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

    }
}
