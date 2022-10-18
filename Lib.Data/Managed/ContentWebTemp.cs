using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ContentWebTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ContentWebTemp>();
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
                this.UpdateSave<ContentWebTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ContentWebTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ContentWebTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static ContentWebTemp GetByID(long ID)
        {
            IQueryable<ContentWebTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static ContentWebTemp GetByContentWebIDandTypeDocument(long ContentWebID, int TypeDocument)
        {
            IQueryable<ContentWebTemp> res = GetAll().Where(x => x.ContentWebID == ContentWebID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
