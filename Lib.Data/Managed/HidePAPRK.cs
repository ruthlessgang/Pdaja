using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class HidePAPRK
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<HidePAPRK>();
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
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.UpdatedDate = DateTime.Now;
                this.UpdateSave<HidePAPRK>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<HidePAPRK> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.HidePAPRKs
                .Where(x => !x.IsDeleted)
                .OrderByDescending(y => y.ID);
        }

        public static HidePAPRK GetByID(long ID)
        {
            IQueryable<HidePAPRK> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static HidePAPRK GetWordingPRK()
        {
            IQueryable<HidePAPRK> res = GetAll();
            return res.FirstOrDefault();
        }
    }
}
