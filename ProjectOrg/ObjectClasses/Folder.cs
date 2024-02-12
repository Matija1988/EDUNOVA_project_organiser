using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg.ObjectClasses
{
    internal  class Folder : Entity
    {
        public string Location { get; set; }
        public string ContractActivityName { get; set; }

        public ProofOfDelivery ProofOfDelivery { get; set; }

    }
}
