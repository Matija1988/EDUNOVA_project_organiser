using PO.ObjectClasses;
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

        

        public static bool TempUsername(string name, string password)
        {
            O04Member Admin = new O04Member();
            Admin.Name = "Matija";
            Admin.LastName = "Pavkovic";
            Admin.UserName = "test";
            Admin.Password = "test";
            Admin.IsTeamLeader = true;

            O04Member Member = new O04Member();
            Member.Name = "Tester";
            Member.LastName = "Testic";
            Member.UserName = "1234";
            Member.Password = "1234";
            Member.IsTeamLeader = false;




            if (name == Admin.UserName && password == Admin.Password || name == Member.UserName && password == Member.Password) 
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
