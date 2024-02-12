using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg.ObjectClasses
{
    internal  class ProofOfDelivery : Entity
    {

        public string DocumentName { get; set; }

        public string Location { get; set; }

        public Member Member { get; set; }

        public DateTime DateCreated { get; set; }

        public override string ToString ()
        {
            StringBuilder stringBuilder = new StringBuilder();



            return stringBuilder.Append("Document name: " + DocumentName +
                                       "\n   "  + "Document location: " + Location +
                                       "\n   " + "Created by: " + Member +
                                       "\n   " + "Date of creation: " + DateCreated).ToString();
        }

    }
}
