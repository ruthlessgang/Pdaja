﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class CMSAdminTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<CMSAdminTemp>();
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
                this.UpdateSave<CMSAdminTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<CMSAdminTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.CMSAdminTemps
                .Where(x => x.IsSuccess == false && x.TypeDocument != 1 && !x.IsApproved)
                .OrderByDescending(x => x.CreatedDate);
        }

        public static CMSAdminTemp GetByID(long ID)
        {
            IQueryable<CMSAdminTemp> res = GetAll().Where(x => x.ID == ID);
            return res.FirstOrDefault();
        }

        public static CMSAdminTemp GetByCMSAdminIDandTypeDocument(long AdminID, int TypeDocument)
        {
            IQueryable<CMSAdminTemp> res = GetAll().Where(x => x.AdminID == AdminID && x.TypeDocument == TypeDocument);
            return res.FirstOrDefault();
        }
    }
}
