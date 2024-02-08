using PO.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    internal class FoldersWorkspace
    {
        public List<O05Folder> Folders { get; set; }

        private Main Main { get; }

        private ProofWorkspace ProofWorkspace { get;  }

        public FoldersWorkspace(Main main) 
        { 
            this.Main = main;
            this.ProofWorkspace = ProofWorkspace; 
        
        
        }




    }
}
