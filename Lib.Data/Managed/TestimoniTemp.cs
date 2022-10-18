using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class TestimoniTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<TestimoniTemp>();
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
                this.UpdateSave<TestimoniTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<TestimoniTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.TestimoniTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static TestimoniTemp GetByID(long ID)
        {
            IQueryable<TestimoniTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static TestimoniTemp GetByTetimoniIDandTypeDocument(long TestiID, int TypeDocument)
        {
            IQueryable<TestimoniTemp> res = GetAll().Where(x => x.TestimoniID == TestiID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

    }
}
