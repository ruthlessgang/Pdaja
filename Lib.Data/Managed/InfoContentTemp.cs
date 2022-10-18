using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class InfoContentTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<InfoContentTemp>();
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
                this.UpdateSave<InfoContentTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<InfoContentTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.InfoContentTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static InfoContentTemp GetByID(long ID)
        {
            IQueryable<InfoContentTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static InfoContentTemp GetByInfoContentIDandTypeDocument(long ContentID, int TypeDocument)
        {
            IQueryable<InfoContentTemp> res = GetAll().Where(x => x.ContentID == ContentID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
