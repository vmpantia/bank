using Bank.Common.Constants;
using System;

namespace Bank.Common
{
    public class Globals
    {
        public static string EXEC_DATE = DateTime.Now.ToString(Format.FORMAT_DATE);
        public static string ID_PREFFIX = DateTime.Now.ToString(Format.FORMAT_ID_PREFFIX);
    }
}
