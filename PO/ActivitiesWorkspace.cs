using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    internal class ActivitiesWorkspace
    {
        public List<O03Activity> Activities { get; }
        
        public List<O02Project> Projects { get; }


        private Main Main {  get;  }
        private ProjectWorkspace ProjectWork { get; }

        public ActivitiesWorkspace(Main Main, ProjectWorkspace ProjectWorkspace):this()
        {
            this.Main = Main;
            this.ProjectWork = ProjectWorkspace;
        }

        public ActivitiesWorkspace() 
        { 
            Activities = new List<O03Activity>();

            if(U01UserInputs.dev)
            {
                TestData();
            }

        
        }

       

        public void ActivitiesMenu (O02Project pro)
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
            switch (Utilities.U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "Listing activities: " + "\n");
                    ListProjectActivities(pro);
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
                 ProjectWork.SelectedProjectMenu( pro);
                    
                    break;
                case 6:
                    Main.MainMenu();
                    
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
                AssociatedProject = Utilities.U01UserInputs.ReturnAssocietedProject(pro)



            });

        }

        private void ListProjectActivities (O02Project pro)
        {

            var i = 0;

            Activities.ForEach(a => { Console.WriteLine(++i + ") " + a); });

        }

        private void TestData ()
        {
            //Activities.Add(new O03Activity()
            //{
            //    id = 1,
            //    Name = "1.1. Izrada media plana",
            //    Description = "Potrebno je izraditi media plan koji obuhvaca lokalne medije",
            //    Folder = 1,
            //    AssociatedProject = Projects[0]


            //});

            //Activities.Add(new O03Activity()
            //{
            //    id = 2,
            //    Name = "1. Dizajn slikovnice",
            //    Description = "Dizajn slikovnice koja ide uz pametnu olovku te prikazuje floru i faunu podrucja PP Biokovo.",
            //    Folder = 2,
            //    AssociatedProject = Projects[1]


            //});
        }
    }
}
