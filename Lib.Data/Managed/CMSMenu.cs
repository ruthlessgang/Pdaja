using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lib.Data
{
    public partial class CMSMenu
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CMSMenu>();
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
                this.UpdateSave<CMSMenu>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<CMSMenu> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CMSMenus.Where(x => x.IsDeleted == false).OrderBy(x => x.Menu);
        }

        public static CMSMenu GetByID(long ID) {
            CMSMenu res = GetAll().Where(x => x.ID == ID).FirstOrDefault();
            return res;
        }

        public static IQueryable<CMSMenu> GetRoleMenuList(long ID) {
            List<long> Roles = new List<long>();
            IQueryable<CMSRole> _Roles = CMSRole.GetMenuByID(ID);
            if(_Roles != null){
               foreach(var x in _Roles){
                Roles.Add(Convert.ToInt64(x.MenuID));
               }
            }
            IQueryable<CMSMenu> res = GetAll().Where( x => !Roles.Contains( x.ID));
            return res;
        }

        public static IQueryable<CMSMenu> GetMenuParent() {
            IQueryable<CMSMenu> res = GetAll().Where( x => x.ParentID == 0);
                return res;
        }

        public static IQueryable<CMSMenu> GetChildMenu(long parentID)
        {
            IQueryable<CMSMenu> res = GetAll().Where(x => x.ParentID == parentID);
            return res;
        }

    }
}
