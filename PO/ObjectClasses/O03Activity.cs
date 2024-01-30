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

       
        public DateTime DateFinish { get; set; }

        public int Folder { get; set; } // vanjski kljuc pretvoriti u listu

        public DateTime DateAccepted { get; set; }

        public O02Project AssociatedProject { get; set; }

        public override string ToString ()
        {
            return Name + " || " + Description + " || "  + AssociatedProject + " || " + id;
        }

    }
}
