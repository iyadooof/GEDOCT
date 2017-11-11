using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDOCT.MyUtilities
{
    public class DataValidationException : Exception
    {
        private string _ExecptionMessage;
        public string ExceptionMessage
        {
            get
            {
                return this._ExecptionMessage;
            }
        }
        public DataValidationException(string StrExceptionMessage)
        {
            this._ExecptionMessage = StrExceptionMessage;
        }
    }
}
