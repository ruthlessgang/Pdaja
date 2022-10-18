using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class MenuWeb
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<MenuWeb>();
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
                this.UpdateSave<MenuWeb>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<MenuWeb> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.MenuWebs
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Sort);
        }

        public static MenuWeb GetByID(long ID)
        {
            IQueryable<MenuWeb> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<MenuWeb> GetMenuByParentID(long parentID)
        {
            IQueryable<MenuWeb> res = GetAll().Where(x => x.ParentID == parentID);
            return res;
        }
    }
}
