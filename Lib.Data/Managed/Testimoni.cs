using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class Testimoni
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<Testimoni>();
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
                this.UpdateSave<Testimoni>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<Testimoni> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.Testimonis
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Sort);
        }

        public static Testimoni GetByID(long ID)
        {
            IQueryable<Testimoni> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

    }
}
