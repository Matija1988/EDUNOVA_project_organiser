using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal class O03Activity : O02Project
    {
        
        public string Description { get; set; }
                   

        public O05Folder Folder { get; set; } 
        public DateTime DateAccepted { get; set; }

        public O02Project AssociatedProject { get; set; }

        public override string ToString ()
        {
            return "ID: " + id + " - " + "NAME: " + Name + "DESCRPITION: " + 
                   "\n   " + Description + 
                // "\n   " + "ASSOCIETED PROJECT: ID " + AssociatedProject.id + " NAME " + AssociatedProject.Name + 
                   "\n   " + "START DATE: " + DateStart + " - DEADLINE: " + DateEnd + 
                // "\n   " + Folder.Location + 
                   "\n   " + "IS FINISHED: " + IsFinished + 
                   "\n   " + DateAccepted; 
        } 

    }
}
