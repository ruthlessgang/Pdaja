using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class RFSpotContestTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<RFSpotContestTemp>();
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
                this.UpdateSave<RFSpotContestTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<RFSpotContestTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.RFSpotContestTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static RFSpotContestTemp GetByID(long ID)
        {
            IQueryable<RFSpotContestTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static RFSpotContestTemp GetByRFSpotContestIDandTypeDocument(long RFSpotContestID, int TypeDocument)
        {
            IQueryable<RFSpotContestTemp> res = GetAll().Where(x => x.RFSpotContestID == RFSpotContestID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

    }
}
