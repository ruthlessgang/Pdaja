using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class VideoGalleryList
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<VideoGalleryList>();
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
                this.UpdateSave<VideoGalleryList>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<VideoGalleryList> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.VideoGalleryLists
                .OrderBy(x => x.VideoGalleryID);
        }

        public static VideoGalleryList GetByID(long ID)
        {
            IQueryable<VideoGalleryList> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<VideoGalleryList> GetVideoGalleryList(long VideoGalleryID)
        {
            IQueryable<VideoGalleryList> res = GetAll().Where(x => x.VideoGalleryID == VideoGalleryID);
            return res;
        }

        public EFResponse Remove()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<VideoGalleryList>();
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
