using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.ObjectClasses
{
    internal class O05Folder : O01Entity
    {
        public string Location { get; set; }
        public string ContractActivityName { get; set; }

        public O06ProofOfDelivery ProofOfDelivery { get; set; }


    }
}
