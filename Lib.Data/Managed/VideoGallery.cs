using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class VideoGallery
    {
        public EFResponse_with_ID Insert()
        {
            EFResponse_with_ID model = new EFResponse_with_ID();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<VideoGallery>();
                model.ID = this.ID;
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
                this.UpdateSave<VideoGallery>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<VideoGallery> GetAllActive()
        {
            return DataRepositoryFactory.CurrentRepository.VideoGalleries
                .Where(x => !x.IsDeleted && x.IsApproved)
                .OrderBy(x => x.CreatedDate);
        }


        public static IQueryable<VideoGallery> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.VideoGalleries
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CreatedDate);
        }

        public static VideoGallery GetByID(long ID)
        {
            IQueryable<VideoGallery> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static IQueryable<VideoGallery> GetVideoGallery()
        {
            IQueryable<VideoGallery> res = GetAll().Where(x => !x.IsDeleted);
            return res;
        }
    }
}
