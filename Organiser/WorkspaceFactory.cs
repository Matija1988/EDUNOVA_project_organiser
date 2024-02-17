using Organiser.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    public static class WorkspaceFactory
    {

        public static IWorkspace ProjectWorkspaceFactory()
        {
            return new ProjectWorkspace();

        }



    }
}
