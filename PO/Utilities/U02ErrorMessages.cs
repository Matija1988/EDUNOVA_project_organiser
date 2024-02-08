using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Utilities
{
    internal class U02ErrorMessages
    {
        internal static string ErrorMessageInput ()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n" +
                      "!!!!!!!!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!!!!!!!!" +
                      "\n");
            return sb.ToString();
        }

        internal static string ErrorMessageInputExists ()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n" +
                      "!!!!!!!!!!!!!!!!!!! INPUT ALREADY EXISTS !!!!!!!!!!!!!!!!!!!" +
                      "\n");
            return sb.ToString();
        }

        internal static string ErrorMessageCannotDeleteYourself () 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n" +
                      "!!!!!!!!!!!!!!!! USER CANNOT DELETE HIMSELF !!!!!!!!!!!!!!!!" +
                      "\n");
            return sb.ToString();

        }
        


    }
}
