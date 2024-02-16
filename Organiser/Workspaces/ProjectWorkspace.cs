using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Workspaces
{
    internal class ProjectWorkspace
    {
        private Main main;

        public ProjectWorkspace (Main main)
        {
            this.main = main;
        }

        public ProjectWorkspace ()
        {


        }


        public void ProjectsMenu ()
        {

            U04MenuTexts.ProjectMenuText();

        //    ProjectMenuSwitch();
        }
    }
}
