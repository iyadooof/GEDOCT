using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace GEDOCT.MyUtilities
{

    public enum ExceptionLevel { DAL, BL, Presentation }

    static class DataFormatValidation
    {
        public static bool ValidMail(string mail_address)
        {
            Regex myRegex = new Regex("^[a-zA-Z0-9]{1,20}[._]{0,1}[a-zA-Z0-9]{1,20}@[a-zA-Z0-9]{1,20}.[a-zA-Z]{2,3}$", RegexOptions.IgnoreCase);
            return !myRegex.IsMatch(mail_address);
        }

        public static bool isString(string val , string paramRegex)
        {
            Regex myRegex = new Regex("^"+paramRegex+"$");
            return !myRegex.IsMatch(val);
        }

        public static bool IsInteger(string val)
        {
            int result;
            return Int32.TryParse(val, out result);
        }

        public static bool IsFloat(string val)
        {
            float result;
            return Single.TryParse(val, out result);
        }
    }
}
