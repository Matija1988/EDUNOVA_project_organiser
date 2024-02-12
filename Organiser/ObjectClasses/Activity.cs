using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public  class Activity : Entity, IActivity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        public Folder Folder { get; set; }
        public DateTime DateAccepted { get; set; }

        public bool IsFinished { get; set; }

        public Project AssociatedProject { get; set; }

        public Member Member { get; set; }

        //public override string ToString ()
        //{
        //    return "ID: " + id + " - " + "NAME: " + Name +
        //           "\n   " + "DESCRPITION: " + Description +
        //           //   "\n   " + "ASSOCIATED PROJECT: ID " + AssociatedProject.id + " NAME " + AssociatedProject.Name + 
        //           "\n   " + "START DATE: " + DateStart + " - DEADLINE: " + DateEnd +
        //           "\n   " + "FOLDER LOCATION: " + Folder.Location +
        //           "\n   " + "IS FINISHED: " + IsFinished +
        //           "\n   " + DateAccepted +
        //           "\n   " + "Delegated to: "; // + Member.Name;
        //}
    }
}
