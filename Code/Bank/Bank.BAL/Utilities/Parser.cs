using Bank.BAL.Models.DTOs;
using Bank.DAL.Models.MST;
using Bank.DAL.Models.TRN;

namespace Bank.BAL.Utilities
{
    public class Parser
    {
        public static AccountDTO ParseAccount(Account_MST data)
        {
            return new AccountDTO { 
                InternalID = data.InternalID,
                AccountNumber = data.AccountNumber,
                Type = data.Type,
                TypeDescription = "",
                FirstName = data.FirstName,
                LastName = data.LastName,
                MiddleName = data.MiddleName ?? string.Empty,
                Gender = data.Gender,
                CivilStatus = data.CivilStatus,
                Birthdate = data.Birthdate,
                Birthplace = data.Birthplace,
                CountryCode = data.CountryCode,
                PhoneNumber = data.PhoneNumber,
                EmailAddress = data.EmailAddress,
                PresentAddress = data.PresentAddress,
                PermanentAddress = data.PermanentAddress,
                ProvincialAddress = data.ProvincialAddress,
                Status = data.Status,
                StatusDescription = "",
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }
        public static Account_MST ParseAccount(AccountDTO data)
        {
            return new Account_MST
            {
                InternalID = data.InternalID,
                AccountNumber = data.AccountNumber,
                Type = data.Type,
                FirstName = data.FirstName,
                LastName = data.LastName,
                MiddleName = data.MiddleName,
                Gender = data.Gender,
                CivilStatus = data.CivilStatus,
                Birthdate = data.Birthdate,
                Birthplace = data.Birthplace,
                CountryCode = data.CountryCode,
                PhoneNumber = data.PhoneNumber,
                EmailAddress = data.EmailAddress,
                PresentAddress = data.PresentAddress,
                PermanentAddress = data.PermanentAddress,
                ProvincialAddress = data.ProvincialAddress,
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }

        public static Account_TRN ParseAccount(Account_MST data, string requestID, int number)
        {
            return new Account_TRN
            {
                RequestID = requestID,
                Number = number,
                InternalID = data.InternalID,
                AccountNumber = data.AccountNumber,
                Type = data.Type,
                FirstName = data.FirstName,
                LastName = data.LastName,
                MiddleName = data.MiddleName,
                Gender = data.Gender,
                CivilStatus = data.CivilStatus,
                Birthdate = data.Birthdate,
                Birthplace = data.Birthplace,
                CountryCode = data.CountryCode,
                PhoneNumber = data.PhoneNumber,
                EmailAddress = data.EmailAddress,
                PresentAddress = data.PresentAddress,
                PermanentAddress = data.PermanentAddress,
                ProvincialAddress = data.ProvincialAddress,
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }
    }
}
