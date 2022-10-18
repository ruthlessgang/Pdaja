using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class PhotoGalleryList
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<PhotoGalleryList>();
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
                this.UpdateSave<PhotoGalleryList>();
                model.Success = true;
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<PhotoGalleryList> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.PhotoGalleryLists
                .OrderBy(x => x.PhotoGalleryID);
        }

        public static PhotoGalleryList GetByID(long ID)
        {
            IQueryable<PhotoGalleryList> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<PhotoGalleryList> GetPhotoGalleryList(long PhotoGalleryID)
        {
            IQueryable<PhotoGalleryList> res = GetAll().Where(x => x.PhotoGalleryID == PhotoGalleryID);
            return res;
        }


        public EFResponse Remove()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<PhotoGalleryList>();
                model.Success = true;
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }
    }
}
