using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public  class Member : IMember
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsTeamLeader { get; set; }

        public override string ToString ()
        {
            return Name + " " + LastName + " \n" + "USERNAME: " + Username + " \n" + "PASSWORD: " + Password + "\n" +  "IS TEAM LEADER: " + IsTeamLeader;
        }

    }
}
