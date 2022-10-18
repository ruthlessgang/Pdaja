using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class ImagesContentGallery
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<ImagesContentGallery>();
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
                this.UpdateSave<ImagesContentGallery>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<ImagesContentGallery> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.ImagesContentGalleries
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Sort);
        }

        public static ImagesContentGallery GetByID(long ID)
        {
            IQueryable<ImagesContentGallery> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<ImagesContentGallery> GetByContentWebID(long contentWebID)
        {
            IQueryable<ImagesContentGallery> res = GetAll().Where(x => x.ContentWebID == contentWebID);
            return res;
        }

        public static IQueryable<ImagesContentGallery> GetByParentID(long parentID)
        {
            IQueryable<ImagesContentGallery> res = GetAll().Where(x => x.ParentID == parentID);
            return res;
        }

    }
}
