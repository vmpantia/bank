using Bank.BAL.Models.DTOs;
using Bank.DAL.Models.MST;
using Bank.DAL.Models.TRN;

namespace Bank.BAL.Utilities
{
    public class Parser
    {
        public static List<TransactionDTO> ParseTransactions(List<Transaction_MST> transactions)
        {
            decimal runningBalance = 0;
            var result = new List<TransactionDTO>();
            foreach(var transaction in transactions)
            {
                runningBalance += Math.Round(transaction.Amount + transaction.Fee);
                result.Add(ParseTransaction(transaction, runningBalance));
            }
            return result;
        }

        private static TransactionDTO ParseTransaction(Transaction_MST data, decimal runningBalance = 0)
        {
            return new TransactionDTO
            {
                InternalID = data.InternalID,
                Account_InternalID = data.Account_InternalID,
                Code = data.Code,
                Made = data.Made,
                Amount = data.Amount,
                Fee = data.Fee,
                RunningBalance = runningBalance,
                Location = data.Location,
                Remarks = data.Remarks,
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }
        public static Transaction_MST ParseTransaction(TransactionDTO data)
        {
            return new Transaction_MST
            {
                InternalID = data.InternalID,
                Account_InternalID = data.Account_InternalID,
                Code = data.Code,
                Made = data.Made,
                Amount = data.Amount,
                Fee = data.Fee,
                Location = data.Location,
                Remarks = data.Remarks,
                Status = data.Status,
                CreatedDate = data.CreatedDate,
                ModifiedDate = data.ModifiedDate
            };
        }

        public static AccountDTO ParseAccount(Account_MST data)
        {
            return new AccountDTO { 
                InternalID = data.InternalID,
                AccountNumber = data.AccountNumber,
                Type = data.Type,
                TypeDescription = Converter.ConvertAccountType(data.Type),
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
                StatusDescription = Converter.ConvertStatus(data.Status),
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
