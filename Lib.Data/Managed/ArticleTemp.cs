using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ArticleTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ArticleTemp>();
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
                this.UpdateSave<ArticleTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ArticleTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ArticleTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static ArticleTemp GetByID(long ID)
        {
            IQueryable<ArticleTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static ArticleTemp GetByArticleIDandTypeDocument(long ArticleID, int TypeDocument)
        {
            IQueryable<ArticleTemp> res = GetAll().Where(x => x.ArticleID == ArticleID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }

        public static ArticleTemp GetByArticleID(long ArticleID)
        {
            IQueryable<ArticleTemp> res = DataRepositoryFactory.CurrentRepository.ArticleTemps
                .Where(x => x.ArticleID == ArticleID);
            return res.FirstOrDefault();
        }
    }
}
