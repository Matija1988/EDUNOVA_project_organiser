using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal class O04Member : O01Entity
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsTeamLeader { get; set; }

        public override string ToString ()
        {
            return Name + " " + LastName;
        }


    }
}
