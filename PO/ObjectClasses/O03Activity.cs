using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal class O03Activity : O01Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateFinish { get; set; }

        public int Folder { get; set; } // vanjski kljuc pretvoriti u listu

        public bool IsFinished { get; set; }
        public DateTime DateAccepted { get; set; }

        public List<O02Project> Projects { get; set; }

        public override string ToString ()
        {
            return Name + " || " + Description + " || ";
        }

    }
}
