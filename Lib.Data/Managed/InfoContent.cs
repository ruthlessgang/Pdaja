using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class InfoContent
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<InfoContent>();
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
                this.UpdateSave<InfoContent>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<InfoContent> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.InfoContents
                .Where(x => x.IsDeleted == false);
        }

        public static InfoContent GetByID(long ID)
        {
            IQueryable<InfoContent> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static InfoContent GetBySlug(string slug)
        {
            IQueryable<InfoContent> res = GetAll().Where(x => x.Slug.ToLower() == slug.ToLower() && x.IsApproved);
            return res.FirstOrDefault();
        }

    }
}
