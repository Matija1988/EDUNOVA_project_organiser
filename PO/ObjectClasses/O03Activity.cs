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
            return id + " || " + Name + " || \n" + Description + " || \n"  + AssociatedProject + " || " + id + " || \n" + DateStart + " || " + DateEnd + " || \n" + Folder + " || " + IsFinished + " || " + DateAccepted; 
        } 

    }
}
