using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PO.Utilities
{
    internal class U02TempInfo
    {
        public static bool TempUsername(string name)
        {
            string tempName = "test";
            if (name == tempName)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public static bool TempPassword(string password) 
        {
            string tempPassword = "test";
            if (password == tempPassword)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }

    }
}
