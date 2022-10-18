using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class AgentTemp
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<AgentTemp>();
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
                this.UpdateSave<AgentTemp>();
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public EFResponse Delete()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.Delete<AgentTemp>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }
        public static IQueryable<AgentTemp> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.AgentTemps;
        }

        public static IQueryable<AgentTemp> GetAllExActive()
        {
            return DataRepositoryFactory.CurrentRepository.AgentTemps;
        }

        public static AgentTemp GetByReferalCode(string AgentCode)
        {
            IQueryable<AgentTemp> res = GetAll().Where(x => x.AgentCode.Trim() == AgentCode.Trim());
            return res.FirstOrDefault();
        }

        public static AgentTemp GetByReferalCodeAndDocumentType(string AgentCode, int typeStatus)
        {
            IQueryable<AgentTemp> res = GetAll().Where(x => x.AgentCode.Trim() == AgentCode.Trim() && x.TypeStatus == typeStatus);
            return res.FirstOrDefault();
        }

        public static IQueryable<AgentTemp> GetAllWithIsActive()
        {
            return DataRepositoryFactory.CurrentRepository.AgentTemps;
        }

        public static AgentTemp GetByReferalCodeIsActive(string AgentCode)
        {
            IQueryable<AgentTemp> res = GetAllWithIsActive().Where(x => x.AgentCode.ToLower().Trim() == AgentCode.ToLower().Trim());
            return res.FirstOrDefault();
        }

        public static AgentTemp GetByEmailOrCardIDWebREgister(string email, string IDCard)
        {
            IQueryable<AgentTemp> res = GetAll().Where(x => x.IsWebRegister == null ? false : ((bool)x.IsWebRegister) && (x.Email.ToLower().Trim() == email.ToLower().Trim() || IDCard.Trim() == IDCard.Trim()));
            return res.FirstOrDefault();
        }

        public static AgentTemp GetByPhoneNoAccountNoBankCodeOrCardIDWebREgister(string phoneNo, string accountNo, string bankCode, string IDCard)
        {
            IQueryable<AgentTemp> res = GetAll().Where(x => x.IsWebRegister == null ? false : ((bool)x.IsWebRegister) && (x.PhoneNo.Trim().Trim() == phoneNo.Trim().Trim() || x.IDCard.Trim() == IDCard.Trim() || (x.AccountBankCode.Trim() == bankCode.Trim() && accountNo.Trim() == x.AccountNo.Trim())));
            return res.FirstOrDefault();
        }
    }
}
