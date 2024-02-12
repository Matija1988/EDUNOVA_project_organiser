using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PO
{
    internal class ActivitiesWorkspace
    {


        public List<O04Member> Members { get; }

        public List<O02Project> Projects { get; }

        public List<O03Activity> Activities;
        public List<O05Folder> Folders { get; }
        public List<O06ProofOfDelivery> ProofOfDeliveries { get; }

        private ProjectWorkspace ProjectWorkspace { get; }

        private MembersWorkspace MembersWorkspace { get; }

        private ProofWorkspace ProofWorkspace { get; }



        private Main Main { get; }


        public ActivitiesWorkspace (Main main) : this()
        {

            this.Main = main;
                    
            this.ProofWorkspace = main.ProofWorkspace;

            this.ProjectWorkspace = main.ProjectWorkspace;

           

            TestData();

        }

    



        public ActivitiesWorkspace ()
        {


            Folders = new List<O05Folder>();

            ProofOfDeliveries = new List<O06ProofOfDelivery>();

            Activities = new List<O03Activity>();




        }


        public void ActivitiesMenu (O02Project SelectedProject)
        {
            Console.WriteLine("\n" + "Working on " + SelectedProject.Name + ", " + SelectedProject.UniqueID + " activities.");

            Console.WriteLine("\n" +
                              "1) List project activities");
            Console.WriteLine("2) Enter new activity");
            Console.WriteLine("3) Edit activity");
            Console.WriteLine("4) Delete activity");
            Console.WriteLine("5) Manage proof collection");
            Console.WriteLine("6) Return to previous menu");
            Console.WriteLine("7) Return to main menu");
            Console.WriteLine("0) Exit");

            ActivitiesMenuSwitch(SelectedProject);

        }

        private void ActivitiesMenuSwitch (O02Project SelectedProject)
        {
            switch (U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "Listing activities: " + "\n");
                    ListProjectActivities();
                    ActivitiesMenu(SelectedProject);

                    break;
                case 2:
                    Console.WriteLine("Entering new activity");
                    EnterNewActivity(SelectedProject);
                    ActivitiesMenu(SelectedProject);

                    break;

                case 3:
                    Console.WriteLine("Edit activity");
                    EditActivity();
                    break;

                case 4:
                    Console.WriteLine("Activity go bye bye");
                    DeleteActivity(SelectedProject);
                    break;
                case 5:
                    ProofWorkspace.ProofMenu();
                    break;

                case 6:
                    Main.ProjectWorkspace.SelectedProjectMenu(SelectedProject);

                    break;
                case 7:
                    Main.MainMenu();

                    break;
                case 0:
                    Console.WriteLine("Exiting application");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                    break;
            }
        }


        private void DeleteActivity (O02Project SelectedProject)
        {
            ListProjectActivities();

            try
            {

                int index = U01UserInputs.InputInt("Delete activity: ") - 1;

                bool verification = U01UserInputs.InputBool("\n" + "Delete activity " + "\n" + Activities[index] + "\n" + "1) YES / 2) NO | ");




                if (verification == true)
                {

                    Activities.RemoveAt(index);

                }


            }
            catch
            {

                U02ErrorMessages.ErrorMessageInput();
                DeleteActivity(SelectedProject);

            }

            ActivitiesMenu(SelectedProject);

        }

        private void EnterNewActivity (O02Project SelectedProject)
        {
            Activities.Add(new O03Activity()
            {

                id = U01UserInputs.InputInt("Input activity ID: "),
                Name = U01UserInputs.InputString("Activity name: "),
                Description = U01UserInputs.InputString("Input activity description: "),
                DateStart = U01UserInputs.InputDateTime("Start date: "),
                DateEnd = U01UserInputs.InputDateTime("Deadline: "),
                //   Folder = U01UserInputs.InputInt("Belong to the folder: "),
                IsFinished = U01UserInputs.InputBool("Is finished (1) YES / 2) NO): "),
                DateAccepted = U01UserInputs.InputDateTime("Date accepted: "),
               // Project = U01UserInputs.ReturnAssocietedProject(SelectedProject),
                //   Member = Members[U01UserInputs.InputInt("Assigned member: ") -1]



            });

        }

        private void EditActivity ()
        {
            throw new NotImplementedException();
        }


        public void ListProjectActivities ()
        {

            var i = 0;

            Activities.ForEach(a => { Console.WriteLine(++i + ") " + a); });



        }

        private void TestData ()
        {





            Folders.Add(new O05Folder()
            {
                id = 1,
                Location = "//Urbana aglomeracija zamisljeni grad//",
                ContractActivityName = "1.1. Izrada media plana",
            //      ProofOfDelivery = ProofOfDeliveries[0],


            });

            Folders.Add(new O05Folder()
            {
                id = 2,
                Location = "//Izrada interaktivne slikovnice JU PP Biokovo//",
                ContractActivityName = "1. Dizajn slikovnice",
              //   ProofOfDelivery = ProofOfDeliveries[0],


            });



            Activities.Add(new O03Activity()
            {
                id = 1,
                Name = "1.1. Izrada media plana",
                Description = "Potrebno je izraditi media plan koji obuhvaca lokalne medije",
                DateStart = DateTime.Parse("10.02.2021."),
                DateEnd = DateTime.Parse("10.03.2021."),
                Folder = Folders[0],
                IsFinished = true,
                DateAccepted = DateTime.Parse("08.03.2021"),
            //    Project = Main.ProjectWorkspace.Projects[0],
                Member = Main.MembersWorkspace.Members[0]



            });


            Activities.Add(new O03Activity()
            {
                id = 2,
                Name = "1. Dizajn slikovnice",
                Description = "Dizajn slikovnice koja ide uz pametnu olovku te prikazuje floru i faunu podrucja PP Biokovo.",
                DateStart = DateTime.Parse("11.04.2021."),
                DateEnd = DateTime.Parse("01.12.2021."),
                Folder = Folders[1],
                IsFinished = true,
                DateAccepted = DateTime.Parse("20.11.2021."),
         //       Project = Main.ProjectWorkspace.Projects[0],
                Member = Main.MembersWorkspace.Members[1]



            }); ;


        }
    }
}
