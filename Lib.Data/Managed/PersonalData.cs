using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Lib.Data
{
    public partial class PersonalData
    {
        public EFResponse Insert()
        {
            EFResponse model = new EFResponse();
            try
            {
                this.CreatedDate = DateTime.Now;
                this.Save<PersonalData>();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException.ToString();
                model.ErrorMessage = e.Message;
                model.Success = false;
            }
            return model;
        }

        public static IQueryable<PersonalData> GetAll()
        {
            return DataRepositoryFactory.CurrentRepository.PersonalDatas;
        }

        public static PersonalData GetByLoanApplicationID(long ID)
        {
            IQueryable<PersonalData> res = GetAll().Where(x => x.LoanApplicationID == ID);
            return res.FirstOrDefault();
        }
        
        public static PersonalData GetByApllicationNo(string AppNo)
        {
            IQueryable<PersonalData> res = GetAll().Where(x => x.ReferenceNo == AppNo);
            return res.FirstOrDefault();
        }
        public static PersonalData GetByApllicationNoAndPhone(string AppNo, string phone)
        {
            IQueryable<PersonalData> res = GetAll().Where(x => x.ReferenceNo == AppNo && x.Handphone == phone);
            return res.FirstOrDefault();
        }

        public static PersonalData GetByPhone(string phone)
        {
            IQueryable<PersonalData> res = GetAll().Where(x => x.Handphone == phone);
            return res.FirstOrDefault();
        }

        public static PersonalData GetByPhoneAndNameAndEmail(string phone, string name, string email)
        {
            IQueryable<PersonalData> res = GetAll().Where(x => x.Handphone == phone && x.NamaLengkap.ToLower() == name.ToLower() && x.Email.ToLower() == email.ToLower());
            return res.FirstOrDefault();
        }
    }
}
