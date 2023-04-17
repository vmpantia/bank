using Bank.Common.Constants;

namespace Bank.BAL.Utilities
{
    public  class Converter
    {
        public static string ConvertAccountType(int type)
        {
            switch (type)
            {
                case AccountType.TYPE_INT_INDIVIDUAL:
                    return AccountType.TYPE_STRING_INDIVIDUAL;
                case AccountType.TYPE_INT_JOINT:
                    return AccountType.TYPE_STRING_JOINT;
                default:
                    return AccountType.TYPE_STRING_PAYROLL;
            }
        }

        public static int ConvertAccountType(string type)
        {
            switch (type)
            {
                case AccountType.TYPE_STRING_INDIVIDUAL:
                    return AccountType.TYPE_INT_INDIVIDUAL;
                case AccountType.TYPE_STRING_JOINT:
                    return AccountType.TYPE_INT_JOINT;
                default:
                    return AccountType.TYPE_INT_PAYROLL;
            }
        }

        public static string ConvertStatus(int status)
        {
            switch (status)
            {
                case Status.STATUS_INT_ENABLED:
                    return Status.STATUS_STRING_ENABLED;
                case Status.STATUS_INT_DISABLED:
                    return Status.STATUS_STRING_DISABLED;
                default:
                    return Status.STATUS_STRING_DELETION;
            }
        }

        public static int ConvertStatus(string status)
        {
            switch (status)
            {
                case Status.STATUS_STRING_ENABLED:
                    return Status.STATUS_INT_ENABLED;
                case Status.STATUS_STRING_DISABLED:
                    return Status.STATUS_INT_DISABLED;
                default:
                    return Status.STATUS_INT_DELETION;
            }
        }
    }
}
