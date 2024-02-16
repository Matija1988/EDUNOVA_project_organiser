using Organiser.ObjectClasses;
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
        private Main Main;

        public Member LoggedInUser { get; }

        private DataInitialisation DataInitialisation { get; }

        public ProjectWorkspace (Main main)
        {
            this.Main = main;
        }

        public ProjectWorkspace ()
        {


        }


        public void ProjectsMenu ()
        {

            U04MenuTexts.ProjectMenuText();

            ProjectMenuSwitch();
        }

        public void ProjectMenuSwitch ()
        {

            switch (U01UserInputs.InputIntZeroAllowed("\n" + "Project menu input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "List active projects");

                    ListAllProjects();
                 //   ListActiveProjects();
                    ProjectsMenu();

                    break;

                case 2:
                  //  AddNewProject();
                    break;

                case 3:
                 //   UpdateProject();
                    break;

                case 4:
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                 //       DeleteProject();
                    }
                    else
                    {
                        Console.WriteLine(U02ErrorMessages.LackOfAuthority());
                        Main.MainMenu();
                    }

                    break;

                case 5:
                    Console.WriteLine("\n" + "List finished projects");

                //    ListFinishedProjects();
                    ProjectsMenu();

                    break;


                case 6:
                    Console.WriteLine("Returning to main menu");

                    Main.MainMenu();
                    break;

                case 0:

                    Environment.Exit(0);
                    break;

                default:
                    U02ErrorMessages.ErrorMessageInput();

                    break;

            }

        }

        private void ListAllProjects()
        {
            var i = 0;
           Main.DataInitialisation._projects.ForEach(project => { Console.WriteLine(++i + ") " +  project.id + " " +  project.Name + " " + project.UniqueID); });
        }
    }
}
