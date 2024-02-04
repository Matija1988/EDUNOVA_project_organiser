using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    internal class ProjectWorkspace
    {

        public List<O02Project> Projects;

        private Main Main {  get; }

        private ActivitiesWorkspace ActivitiesWork { get; }
        public ProjectWorkspace(Main main):this()
        { 
            
            this.Main = main;
            
        }

        public ProjectWorkspace(ActivitiesWorkspace activitiesWork) : this()
        {
            this.ActivitiesWork = activitiesWork;
        }

        public ProjectWorkspace() 
        { 
            Projects = new List<O02Project>();

            if(U01UserInputs.dev)
            {
                TestData();
            }
            
        
        }


        public void ProjectsMenu ()
        {

            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>> Projects menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List active projects");
            Console.WriteLine("2) Enter project");
            Console.WriteLine("3) Add new project");
            Console.WriteLine("4) Delete project");
            Console.WriteLine("5) List finished projects");
            Console.WriteLine("6) Enter finished projects");
            Console.WriteLine("7) Return to main menu");
            Console.WriteLine("8) Exit");

            ProjectMenuSwitch();
        }

        public void ProjectMenuSwitch ()
        {

            switch (U01UserInputs.InputInt("\n" + "Project menu input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "List active projects" + "\n" +
                                      "************************************************************");
                    ListActiveProjects();
                    ProjectsMenu();
                    ProjectMenuSwitch();
                    break;
                case 2:
                    Console.WriteLine("Enter project:");
                    EnterProjectsMenu();
                    break;
                case 3:
                    Console.WriteLine("Add new project");
                    AddNewProject();
                    ProjectsMenu();
                    ProjectMenuSwitch();
                    break;
                case 4:
                    Console.WriteLine("Delete project");
                    break;
                case 5:
                    Console.WriteLine("List finished projects");
                    break;
                case 6:
                    Console.WriteLine("Enter finished projects");
                    break;
                case 7:
                    Console.WriteLine("Returning to main menu");
                    Main.MainMenu();
                    break;
                case 8:
                    Console.WriteLine("Exit");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n" +
                                      "!!!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!!!");
                    break;

            }



        }

        private void EnterProjectsMenu ()
        {
            ListActiveProjects();

            try
            {
                var pro = Projects[Utilities.U01UserInputs.InputInt("ID of the project you wish to enter: ") - 1];

                Console.WriteLine("\n" + "Entering selected project" + "\n");
                SelectedProjectMenu(pro);

            }
            catch
            {

                Console.WriteLine("!!!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!!!");

            }

        }
        public void SelectedProjectMenu (O02Project pro)
        {
            Console.WriteLine("Working on " + pro.Name + ", " + pro.UniqueID + " project." + "Try not to commit suicide before the final report has been accepted and signed!!!");
            Console.WriteLine("Have a good day!!!");

            Console.WriteLine("\n" +
                              "1) Manage activities");
            Console.WriteLine("2) Manage basic project information");
            Console.WriteLine("3) Return to projects menu");
            Console.WriteLine("4) Return to main menu");
            Console.WriteLine("5) Exit");

            SelectedProjectMenuSwitch(pro);
        }

        public void SelectedProjectMenuSwitch (O02Project pro)
        {
            switch (Utilities.U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("Managing " + pro.Name + " activities");
                   ActivitiesWork.ActivitiesMenu(pro);
                    break;
                case 2:
                    Console.WriteLine("Updating " + pro.Name + " information");
                    break;
                case 3:
                    Console.WriteLine("Returning to projects menu");
                    ProjectsMenu();
                    ProjectMenuSwitch();
                    break;
                case 4:
                    Console.WriteLine("Returning to main menu");
                    Main.MainMenu();
                   
                    break;
                case 5:
                    Console.WriteLine("Where are you going!!! There is more work to be done!!!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n" +
                                      "!!!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!!!");
                    break;

            }

        }
            private void AddNewProject ()
            {
                Projects.Add(new O02Project()
                {

                    id = Utilities.U01UserInputs.InputInt("Input project id: "),
                    Name = Utilities.U01UserInputs.InputString("Project name: "),
                    UniqueID = Utilities.U01UserInputs.InputString("UniqueID: "),
                    DateStart = Utilities.U01UserInputs.InputDateTime("Start date: "),
                    DateEnd = Utilities.U01UserInputs.InputDateTime("Date end: "),
                    IsFinished = Utilities.U01UserInputs.InputBool("Is finished (Y / N): ")


                });
            }

            private void ListActiveProjects ()
            {
                var i = 0;
                Projects.ForEach(p => { Console.WriteLine(++i + ") " + p); });
            }
        private void TestData ()
        {
            Projects.Add(new O02Project()
            {
                id = 1,
                UniqueID = "K.K. 2711",
                Name = "Urbana aglomeracija zamisljeni grad",


            });

            Projects.Add(new O02Project()
            {
                id = 2,
                UniqueID = "JUPP 412",
                Name = "Izrada interaktivne slikovnice JU PP Biokovo"


            });
        }
    }
}
