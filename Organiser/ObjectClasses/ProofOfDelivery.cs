﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public  class ProofOfDelivery : Entity, IProofOfDelivery
    {
        public int id { get; set; }
        public string DocumentName { get; set; }

        public string Location { get; set; }

        public Member Member { get; set; }

        public DateTime DateCreated { get; set; }

        public Activity Activity { get; set; }

        public override string ToString ()
        {
            StringBuilder stringBuilder = new StringBuilder();



            return stringBuilder.Append("ID: " + id +
                                        "\n  " + "Document name: "+ DocumentName +
                                        "\n  " + "Document Location: " +Location +
                                        "\n  " + "Created by: "+Member.Name + " " + Member.LastName + 
                                        "\n  " + "Associated activity: " + Activity.Name +   
                                        "\n  " + "Date created: " + DateCreated).ToString();
        }


    }
}
