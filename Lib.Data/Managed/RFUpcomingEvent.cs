using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFUpcomingEvent
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFUpcomingEvent>();
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
                this.UpdateSave<RFUpcomingEvent>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFUpcomingEvent> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFUpcomingEvents
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Sort);
        }

        public static IQueryable<RFUpcomingEvent> GetAllApprove()
        {
            return DataRepositoryFactory.CurrentRepository.RFUpcomingEvents
                .Where(x => x.IsDeleted == false && x.IsApproved == true)
                .OrderBy(x => x.Sort);
        }

        public static RFUpcomingEvent GetByID(long ID)
        {
            IQueryable<RFUpcomingEvent> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<RFUpcomingEvent> GetRFUpcomingEventIsAutoPublish()
        {
            IQueryable<RFUpcomingEvent> res = GetAll().Where(x => x.IsAutoPublish == true && x.PublishDate <= DateTime.Now && x.ExpiredDate >= DateTime.Now);
            return res;
        }

    }
}
