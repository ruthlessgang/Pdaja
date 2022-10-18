using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lib.Data
{
    public partial class CMSRole
    {

        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CMSRole>();
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
                this.UpdateSave<CMSRole>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<CMSRole> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CMSRoles.Where(x => x.IsDeleted == false).OrderBy(x => x.ID);
        }

        public static CMSRole GetByID(long ID) {
            CMSRole res = GetAll().Where(x => x.ID == ID).FirstOrDefault();
            return res;
        }

        public static IQueryable<CMSRole> GetMenuByUser(string Username)
        {
            IQueryable<CMSRole> res = GetAll().Where(x => x.CMSAdmin.UserName == Username);
            return res;
        }

        public static IQueryable<CMSRole> GetMenuByID(long ID)
        {
            IQueryable<CMSRole> res = GetAll().Where(x => x.CMSAdmin.ID == ID);
            return res;
        }

        public static CMSRole GetMenuByURLandUser(string LinkUrl, string Username)
        {
            IQueryable<CMSRole> res = GetAll().Where(x => x.CMSMenu.LinkUrl.Contains(LinkUrl) &&  x.CMSAdmin.UserName == Username);
            return res.FirstOrDefault();
        }

    }
}
