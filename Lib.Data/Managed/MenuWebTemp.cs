using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class MenuWebTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<MenuWebTemp>();
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
                this.UpdateSave<MenuWebTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<MenuWebTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.MenuWebTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static MenuWebTemp GetByID(long ID)
        {
            IQueryable<MenuWebTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static MenuWebTemp GetByMenuWebIDandTypeDocument(long MenuWebID, int TypeDocument)
        {
            IQueryable<MenuWebTemp> res = GetAll().Where(x => x.MenuWebID == MenuWebID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
