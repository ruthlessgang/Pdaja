using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class Article
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<Article>();
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
                this.UpdateSave<Article>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<Article> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.Articles
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.CreatedDate);
        }

        public static IQueryable<Article> GetAllActive()
        {
            return DataRepositoryFactory.CurrentRepository.Articles
                .Where(x => x.IsDeleted == false && x.IsApproved)
                .OrderBy(x => x.CreatedDate);
        }

        public static Article GetByID(long ID)
        {
            IQueryable<Article> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<Article> GetArticle()
        {
            IQueryable<Article> res = GetAll().Where(x => !x.IsDeleted);
            return res;
        }
    }
}
