using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.ObjectClasses
{
    public  class Folder : Entity, IFolder
    {
        public string Location { get; set; }
        public string ContractActivityName { get; set; }

        public ProofOfDelivery ProofOfDelivery { get; set; }
    }
}
