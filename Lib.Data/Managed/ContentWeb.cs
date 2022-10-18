using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ContentWeb
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ContentWeb>();
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
                this.UpdateSave<ContentWeb>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ContentWeb> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ContentWebs
                .Where(x => x.IsDeleted == false);
        }

        public static ContentWeb GetByID(long ID)
        {
            IQueryable<ContentWeb> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static ContentWeb GetBySlug(string slug)
        {
            IQueryable<ContentWeb> res = GetAll().Where(x => x.Slug.ToLower() == slug.ToLower() && x.IsApproved);
            return res.FirstOrDefault();
        }

        public static List<ContentWeb> GetByCategory(long ID)
        {
            IQueryable<ContentWeb> res = GetAll().Where(x => x.CategoryID == ID);
            return res.ToList();
         }

    }
}
