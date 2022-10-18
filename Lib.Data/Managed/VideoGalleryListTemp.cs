using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class VideoGalleryListTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<VideoGalleryListTemp>();
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
                this.UpdateSave<VideoGalleryListTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<VideoGalleryListTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.VideoGalleryListTemps
                .OrderBy(x => x.VideoGalleryTempID);
        }

        public static VideoGalleryListTemp GetByID(long ID)
        {
            IQueryable<VideoGalleryListTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<VideoGalleryListTemp> GetVideoGalleryListTemp(long VideoGalleryTempID)
        {
            IQueryable<VideoGalleryListTemp> res = GetAll().Where(x => x.VideoGalleryTempID == VideoGalleryTempID);
            return res;
        }

        public EFResponse Remove()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<VideoGalleryListTemp>();
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
