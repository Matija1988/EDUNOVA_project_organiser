﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal class O06ProofOfDelivery : O01Entity
    {
        public string DocumentName { get; set; }

        public string Location { get; set; }

        public O04Member Member { get; set; }

        public DateTime DateCreated { get; set; }

        public override string ToString ()
        {
            StringBuilder stringBuilder = new StringBuilder ();



            return stringBuilder.Append(DocumentName + 
                                       "\n   " + Location + 
                                       "\n   " + Member + 
                                       "\n   " + DateCreated).ToString();
        }

    }
}
