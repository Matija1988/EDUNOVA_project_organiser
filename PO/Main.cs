using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PO
{
    

    internal class Main
    {


        private List<O02Project> Projects;
        private List<O03Activity> Activities;


        public Main() 
        
        {


            Projects = new List<O02Project>();
            Activities = new List<O03Activity>();

            StartUpMessage();
            LogIn();
        
        }

        private  void MainMenu ()
        {
            Console.WriteLine("\n" +
                ">>>>>>>>>>>>>>>>>>>>>>> Main menu <<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) Manage projects");
            Console.WriteLine("2) Manage members");
            Console.WriteLine("3) Exit");

            MainMenuSwitch();
        }

        private  void ProjectsMenu ()
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
        public  void MainMenuSwitch ()
        {

            switch (U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("Entering projects");
                    ProjectsMenu();
                    ProjectMenuSwitch();
                    break;
                case 2:
                    Console.WriteLine("Entering members");

                    break;
                case 3:
                    Console.WriteLine("Exiting application");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n" + "!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!");
                    break;

            }


        }

        public  void ProjectMenuSwitch ()
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
                    MainMenu();
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

            } catch 
            {

                Console.WriteLine("!!!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!!!");

            }

        }

        private void SelectedProjectMenu (O02Project pro)
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

        private void SelectedProjectMenuSwitch (O02Project pro)
        {
            switch(Utilities.U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("Managing " + pro.Name + " activities");
                    ActivitiesMenu(pro); 
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
                    MainMenu();
                    MainMenuSwitch();
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

        private void ActivitiesMenu (O02Project pro)
        {
            Console.WriteLine("\n" + "Working on " + pro.Name + ", " + pro.UniqueID + " activities.");
            
            Console.WriteLine("\n" +
                              "1) List project activities");
            Console.WriteLine("2) Select activity");
            Console.WriteLine("3) Enter new activity");
            Console.WriteLine("4) Delete activity");
            Console.WriteLine("5) Return to previous menu");
            Console.WriteLine("6) Return to main menu");
            Console.WriteLine("7) Exit");

            ActivitiesMenuSwitch(pro); 
        }

        private void ActivitiesMenuSwitch (O02Project pro)
        {
            switch(Utilities.U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "Listing activities: " + "\n");
                    ListProjectActivities();
                    ActivitiesMenu(pro);
                    ActivitiesMenuSwitch(pro);
                    break;
                    case 2:
                    Console.WriteLine("Selecting activity");
                    break;
                    case 3:
                    Console.WriteLine("Entering new activity");
                    EnterNewActivity(pro);
                    ActivitiesMenu(pro);
                    
                    break;
                    case 4:
                    Console.WriteLine("Activity go bye bye");
                    break; 
                case 5:
                    SelectedProjectMenu(pro);
                    SelectedProjectMenuSwitch(pro);
                    break;
                    case 6:
                    MainMenu();
                    MainMenuSwitch();
                    break;
                    case 7:
                    Console.WriteLine("Exiting application");
                    Environment.Exit(0);    
                    break; 
                default:
                    Console.WriteLine("\n" +
                                      "!!!!!!!!!!!!!!!!!!! WRONG INPUT !!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!!!");
                    break;
            }
        }

        private void EnterNewActivity (O02Project pro)
        {
            Activities.Add(new O03Activity()
            {

                id = Utilities.U01UserInputs.InputInt("Input activity ID: "),
                Name = Utilities.U01UserInputs.InputString("Activity name: "),
                Description = Utilities.U01UserInputs.InputString("Input activity description: "),
                DateStart = Utilities.U01UserInputs.InputDateTime("Start date: "),
                DateFinish = Utilities.U01UserInputs.InputDateTime("Deadline: "),
                Folder = Utilities.U01UserInputs.InputInt("Belong to the folder: "),
                IsFinished = Utilities.U01UserInputs.InputBool("Is finished (Y / N): 0"),
                DateAccepted = Utilities.U01UserInputs.InputDateTime("Date accepted: "),
                


            });
             
        }

        private void ListProjectActivities ()
        {
           
            var i = 0;
            Activities.ForEach(a => { Console.WriteLine(++i + ") " + a); });


        }

        private  void AddNewProject ()
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

        private void ListActiveProjects()
        {
            var i = 0;
            Projects.ForEach(p => { Console.WriteLine(++i + ") " + p); }); 
        }

        private  void LogIn ()
        {


            if (U02TempInfo.TempUsername(U01UserInputs.InputString("Username: ")) == true && U02TempInfo.TempUsername(U01UserInputs.InputString("Password: ")) == true)
            {
                Console.WriteLine("Username accepted");
                MainMenu();
            }
            else
            {

                Console.WriteLine("!!!!!!!!!! INVALID USERNAME OR PASSWORD !!!!!!!!!!");
                LogIn();

            }

        }

        private static void StartUpMessage ()
        {
            Console.WriteLine("************************************************************");
            Console.WriteLine("*         Console application - Project organiser          *");
            Console.WriteLine("************************************************************");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!App under development!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Final exam - certified course C# web programing in EDUNOVA  ");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("                                    Author: Matija Pavković");
            Console.WriteLine("                                    Mentor: Tomislav Jakopec");
            Console.WriteLine("************************************************************"
                                    + "\n");

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>> User Login <<<<<<<<<<<<<<<<<<<<<<<<<");
        }
    }
}
