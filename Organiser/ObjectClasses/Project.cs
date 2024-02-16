using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public  class Project : Entity, IProject
    {
        [Required]
        public string UniqueID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        public bool IsFinished { get; set; }

        public override string ToString ()
        {
            return "ID:" + id + " - " + Name + " - " + UniqueID + " -  \n" + "   Date start: " + DateStart.ToString() + "\n" + "   Date end: " + DateEnd.ToString() + "\n" + "   Project finished: " + IsFinished;

        }
    }
}
