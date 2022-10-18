using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class AuditTrail
    {
        public EFResponse Insert(long AdminID, string Activity)
        {
            EFResponse model = new EFResponse();

            try
            {
                this.AdminID = AdminID;
                this.Activity = Activity;
                this.ActivityDate = DateTime.Now;
                this.Save<AuditTrail>();

            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }

            return model;
        }


        public static IQueryable<AuditTrail> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.AuditTrails
            .Where(x => x.IsDeleted == false)
            .OrderByDescending(x => x.ActivityDate);
        }

        public static AuditTrail GetByID(long ID)
        {
            IQueryable<AuditTrail> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<AuditTrail> GetByAdminID(long AdminID)
        {
            IQueryable<AuditTrail> res = GetAll().Where(x => x.AdminID == AdminID);
            return res;
        }
    }
}
