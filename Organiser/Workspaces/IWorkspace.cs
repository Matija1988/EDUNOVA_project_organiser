using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Workspaces
{
    public interface IWorkspace
    {

        public void Add ();
        public void List ();

        public void Update();

        public void Delete ();


    }
}
