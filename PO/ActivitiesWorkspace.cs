using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace PO
{
    internal class ActivitiesWorkspace
    {
        public List<O02Project> Projects { get; }
        public List<O03Activity> Activities { get; }

        public List<O04Member> Members { get; }

        public List<O05Folder> Folders { get; }

        public List<O06ProofOfDelivery> ProofOfDeliveries { get; }
        
       
        private Main Main {  get;  }
        private ProjectWorkspace ProjectWorkspace { get; }

        private MembersWorkspace MembersWorkspace { get; }

      

        public ActivitiesWorkspace(Main Main):this()
        {
            this.Main = Main;
            this.ProjectWorkspace = Main.ProjectWorkspace;
            this.MembersWorkspace = Main.MembersWorkspace;
            
        }
              

        public ActivitiesWorkspace() 
        {
            Activities = new();
            Folders = new();
            ProofOfDeliveries = new();
            
            
            
            

            
            if(U01UserInputs.dev)
            {
                TestData();
            }

        
        }

       
        public void ActivitiesMenu (O02Project? pro)
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
                    DeleteActivity(pro);
                    break;
                case 5:
                 ProjectWorkspace.SelectedProjectMenu( pro);
                    
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

        private void DeleteActivity (O02Project pro)
        {
            ListProjectActivities(pro);

            try
            {
                
                int index = U01UserInputs.InputInt("Delete activity: ") - 1;

                bool verification = U01UserInputs.InputBool("\n" + "Delete activity " + "\n" + Activities[index] + "\n" + "1) YES / 2) NO | ");

         


                if (verification == true)
                {

                    Projects.RemoveAt(index);

                }


            }
            catch
            {

                U02ErrorMessages.ErrorMessageInput();
                DeleteActivity(pro);

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
                DateEnd = Utilities.U01UserInputs.InputDateTime("Deadline: "),
             //   Folder = Utilities.U01UserInputs.InputInt("Belong to the folder: "),
                IsFinished = Utilities.U01UserInputs.InputBool("Is finished (1) YES / 2) NO): "),
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
            ProofOfDeliveries.Add(new O06ProofOfDelivery()
            {
                id = 1,
                DocumentName = "Media plan",
                Location = "//Urbana aglomeracija zamisljeni grad//1.1. Izrada media plana//",
            //    MemberID = Main.MembersWorkspace.Members[1],
                DateCreated = DateTime.Parse("12.11.2021."),


            });


            Folders.Add(new O05Folder()
            {
                id = 1,
                Location = "//Urbana aglomeracija zamisljeni grad//",
                ContractActivityName = "1.1. Izrada media plana",
                ProofOfDelivery = ProofOfDeliveries[0],


            });

            Folders.Add(new O05Folder()
            {
                id = 1,
                Location = "//Izrada interaktivne slikovnice JU PP Biokovo//",
                ContractActivityName = "1. Dizajn slikovnice",
            //    ProofOfDelivery = ProofOfDeliveries[1],


            });



            Activities.Add(new O03Activity()
            {
                id = 1,
                Name = "1.1. Izrada media plana",
                Description = "Potrebno je izraditi media plan koji obuhvaca lokalne medije",
                DateStart = DateTime.Parse("10.02.2021."),
                DateEnd = DateTime.Parse("10.03.2021."),
        //        Folder = Folders[0],
                IsFinished = true,
                DateAccepted = DateTime.Parse("08.03.2021"),
           //     AssociatedProject = ProjectWorkspace.Projects[0],



            });

            Activities.Add(new O03Activity()
            {
                id = 2,
                Name = "1. Dizajn slikovnice",
                Description = "Dizajn slikovnice koja ide uz pametnu olovku te prikazuje floru i faunu podrucja PP Biokovo.",
                DateStart = DateTime.Parse("11.04.2021."),
                DateEnd = DateTime.Parse("01.12.2021."),
           //     Folder = Folders[1],
                IsFinished = true,
                DateAccepted = DateTime.Parse("20.11.2021."),
          //      AssociatedProject = Projects[1]


            });


        }
    }
}
