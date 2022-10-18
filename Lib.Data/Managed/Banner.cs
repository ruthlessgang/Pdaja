using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class Banner
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<Banner>();
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
                this.UpdateSave<Banner>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<Banner> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.Banners
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Sort);
        }

        public static Banner GetByID(long ID)
        {
            IQueryable<Banner> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<Banner> GetBannerIsAutoPublish()
        {
            IQueryable<Banner> res = GetAll().Where(x => x.IsAutoPublish == true && x.PublishDate <= DateTime.Now && x.ExpiredDate >= DateTime.Now);
            return res;
        }
    }
}
