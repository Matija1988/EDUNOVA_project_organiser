using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal class O02Project : O01Entity
    {
        public string UniqueID { get; set; }
        public string Name { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
        public bool IsFinished { get; set; }

        public override string ToString ()
        {
            return Name + " || " + UniqueID; 

        }

    }
}
