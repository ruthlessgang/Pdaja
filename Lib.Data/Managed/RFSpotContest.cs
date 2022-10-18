using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFSpotContest
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFSpotContest>();
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
                this.UpdateSave<RFSpotContest>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFSpotContest> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFSpotContests
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Sort);
        }

        public static IQueryable<RFSpotContest> GetAllApprove()
        {
            return DataRepositoryFactory.CurrentRepository.RFSpotContests
                .Where(x => x.IsDeleted == false && x.IsApproved == true)
                .OrderBy(x => x.Sort);
        }

        public static RFSpotContest GetLast()
        {
            return DataRepositoryFactory.CurrentRepository.RFSpotContests
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreatedDate).FirstOrDefault();
        }

        public static RFSpotContest GetByID(long ID)
        {
            IQueryable<RFSpotContest> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<RFSpotContest> GetRFSpotContestIsAutoPublish()
        {
            IQueryable<RFSpotContest> res = GetAll().Where(x => x.IsAutoPublish == true && x.PublishDate <= DateTime.Now && x.ExpiredDate >= DateTime.Now);
            return res;
        }

    }
}
