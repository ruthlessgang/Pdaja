using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lib.Data
{
    public partial class CMSAdmin
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CMSAdmin>();
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
                this.UpdateSave<CMSAdmin>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<CMSAdmin> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CMSAdmins.Where(x => x.IsDeleted == false).OrderBy(x => x.UserName);
        }

        public static CMSAdmin GetByUsernameAndPassword(string Username, string Password){
            CMSAdmin res = GetAll().Where(x => x.UserName == Username && x.Password == Password).FirstOrDefault();
            return res;
        }

        public static CMSAdmin GetByUsername(string Username) {
            CMSAdmin res = GetAll().Where(x => x.UserName == Username).FirstOrDefault();
            return res;
        }

        public static CMSAdmin GetByID(long ID) {
            CMSAdmin res = GetAll().Where(x => x.ID == ID).FirstOrDefault();
            return res;
        }

       
    }
}
