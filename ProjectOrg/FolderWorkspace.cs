using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class FolderWorkspace
    {
        public List<Folder> Folders { get; }

        private Main Main { get; }

        public FolderWorkspace(Main main) : this()
        {
            this.Main = main;
        }

        public FolderWorkspace() { }



    }
}
