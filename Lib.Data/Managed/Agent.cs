using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public partial class Agent
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<Agent>();
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
            EFResponse model = new EFResponse() { Success = true };
            try
            {
                this.UpdatedDate = DateTime.Now;
                this.UpdateSave<Agent>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }


        public static IQueryable<Agent> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.Agents;
        }

        public static IQueryable<Agent> GetAllExActive()
        {
            return DataRepositoryFactory.CurrentRepository.Agents;
        }

        public static Agent GetByReferalCode(string agentCode)
        {
            IQueryable<Agent> res = GetAllExActive().Where(x => x.AgentCode.Trim() == agentCode.Trim());
            return res.FirstOrDefault();
        }

        public static IQueryable<Agent> GetAllWithIsActive()
        {
            return DataRepositoryFactory.CurrentRepository.Agents;
        }

        public static Agent GetByReferalCodeIsActive(string agentCode)
        {
            IQueryable<Agent> res = GetAllWithIsActive().Where(x => x.AgentCode.ToLower().Trim() == agentCode.ToLower().Trim());
            return res.FirstOrDefault();
        }

        public static Agent GetByAgentCode(string agentCode)
        {
            IQueryable<Agent> res = GetAll().Where(x => x.AgentCode.Trim() == agentCode.Trim());
            return res.FirstOrDefault();
        }
        public static Agent GetByUsername(string agentCode)
        {
            //IQueryable<Agent> res = GetAll().Where(x => x.AgentCode.Trim() == agentCode.Trim() || x.Email.Trim() == agentCode.Trim());
            IQueryable<Agent> res = GetAll().Where(x => x.AgentCode.Trim() == agentCode.Trim());
            return res.FirstOrDefault();
        }

        //public static Agent GetByUsernameAndPassword(string agentCode, string password)
        //{
        //    IQueryable<Agent> res = GetAll().Where(x => x.IsActive && x.IsApproved && ((x.AgentCode.Trim() == agentCode.Trim() && x.Password == password) || (x.Email.Trim() == agentCode.Trim() && x.Password == password)));
        //    return res.FirstOrDefault();
        //}

        //public static Agent GetByEmailOrCardIDWebREgister(string email, string IDCard)
        //{
        //    IQueryable<Agent> res = GetAll().Where(x => x.IsWebRegister == null ? false : ((bool)x.IsWebRegister) && (x.Email.ToLower().Trim() == email.ToLower().Trim() && IDCard.Trim() == IDCard.Trim()));
        //    return res.FirstOrDefault();
        //}

        //public static Agent GetByPhoneNoAccountNoBankCodeOrCardIDWebREgister(string phoneNo, string accountNo, string bankCode, string IDCard)
        //{
        //    IQueryable<Agent> res = GetAll().Where(x => x.IsWebRegister == null ? false : ((bool)x.IsWebRegister) && (x.PhoneNo.Trim().Trim() == phoneNo.Trim().Trim() || x.IDCard.Trim() == IDCard.Trim() || (x.AccountBankCode.Trim() == bankCode.Trim() && accountNo.Trim() == x.AccountNo.Trim())));
        //    return res.FirstOrDefault();
        //}
    }
}
