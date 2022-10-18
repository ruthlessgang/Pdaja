using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class CMSRoleTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CMSRoleTemp>();
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
                this.UpdateSave<CMSRoleTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<CMSRoleTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CMSRoleTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static CMSRoleTemp GetByID(long ID)
        {
            IQueryable<CMSRoleTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static CMSRoleTemp GetByCMSRoleIDandTypeDocument(long RoleID, int TypeDocument)
        {
            IQueryable<CMSRoleTemp> res = GetAll().Where(x => x.RoleID == RoleID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
