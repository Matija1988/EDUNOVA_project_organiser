using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Workspaces
{
    
    internal class ActivitiesWorkspace : IWorkspace
    {
        public List<Activity> _activities { get; set; }
        private Main Main { get; }

        private ProjectWorkspace ProjectWorkspace { get; }


        public ActivitiesWorkspace (Main Main) : this()
        {
            Main = Main;
        }

        public ActivitiesWorkspace()
        {

        }

        public void Add ()
        {
            throw new NotImplementedException();
        }

        public void List ()
        {
            throw new NotImplementedException();
        }

        public void Update ()
        {
            throw new NotImplementedException();
        }

        public void Delete ()
        {
            throw new NotImplementedException();
        }
    }
}
