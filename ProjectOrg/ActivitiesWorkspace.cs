using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjectOrg
{
    internal class ActivitiesWorkspace
    {


        public List<Member> Members { get; }

        public List<Project> Projects { get; }

        public List<Activity> Activities { get; }

        public List<Folder> Folders { get; }
        public List<ProofOfDelivery> ProofOfDeliveries { get; }

        private ProjectWorkspace ProjectWorkspace { get; }

        private MembersWorkspace MembersWorkspace { get; }

        private ProofWorkspace ProofWorkspace { get; }



        private Main Main { get; }


        public ActivitiesWorkspace (Main main) : this()
        {

            this.Main = main;
            this.MembersWorkspace = MembersWorkspace;
            this.ProjectWorkspace = main.ProjectWorkspace;
            this.ProofWorkspace = main.ProofWorkspace;




        }


        public ActivitiesWorkspace ()
        {

            Folders = new List<Folder>();

            ProofOfDeliveries = new List<ProofOfDelivery>();

            Activities = new List<Activity>();

        }


        public void ActivitiesMenu ()
        {

            U04MenuTexts.ActivitiesMenuText();

            ActivitiesMenuSwitch();

        }

        private void ActivitiesMenuSwitch ()
        {
            switch (U01UserInputs.InputIntZeroAllowed("Input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "Listing activities: " + "\n");
                    ListProjectActivities();
                    ActivitiesMenu();

                    break;
                case 2:
                    Console.WriteLine("Entering new activity");
                    EnterNewActivity();


                    break;

                case 3:
                    Console.WriteLine("Edit activity");
                    UpdateActivity();
                    break;

                case 4:
                    Console.WriteLine("Activity go bye bye");
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                        DeleteActivity();
                    }
                    else
                    {
                        Console.WriteLine(U02ErrorMessages.LackOfAuthority());
                        Main.MainMenu();
                    }
                   
                    break;
                case 5:
                    ListAllActivities();
                    ActivitiesMenu();
                    break;
             
                case 6:
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


        private void DeleteActivity ()
        {
            ListProjectActivities();

            try
            {

                int index = U01UserInputs.InputInt("Delete activity: ") - 1;

                bool verification = U01UserInputs.InputBool("\n" + "Delete activity " + "\n" + Main.TestDataConstructor.Activities[index] + "\n" + "1) YES / 2) NO | ");


                if (verification == true)
                {

                    Main.TestDataConstructor.Activities.RemoveAt(index);

                }

            }
            catch
            {

                U02ErrorMessages.ErrorMessageInput();
                DeleteActivity();

            }

            ActivitiesMenu();

        }

        private void EnterNewActivity ()
        {
            Main.TestDataConstructor.Activities.Add(new Activity()
            {

                id = U01UserInputs.AutoIncrementID(Main.TestDataConstructor.Activities),
                Name = U01UserInputs.InputString("Activity name: "),
                Description = U01UserInputs.InputString("Input activity description: "),
                DateStart = U01UserInputs.InputDateTime("Start date: "),
                DateEnd = U01UserInputs.InputDateTime("Deadline: "),
                Folder = Main.TestDataConstructor.Folders[U01UserInputs.InputInt("Store activity data into folder: ") - 1],
                IsFinished = U01UserInputs.InputBool("Is finished (1) YES / 2) NO): "),
                DateAccepted = U01UserInputs.InputDateTime("Date accepted: "),
                AssociatedProject = Main.TestDataConstructor.Projects[U01UserInputs.InputInt("Activitiy is associated to project: ") - 1],
                Member = Main.TestDataConstructor.Members[U01UserInputs.InputInt("Assigned member: ") - 1]


            });
            ActivitiesMenu();
        }

        private void UpdateActivity ()
        {
            ListProjectActivities();

            Main.ActivitiesUpdater.UpdateActivities();
        }


        public void ListProjectActivities ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();

            var i = 0;

            Main.ProjectWorkspace.ListAllProjects();

           
            var pro = Main.TestDataConstructor.Projects[U01UserInputs.InputInt("Choose a project whose activities you wish to list: ") - 1];
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Main.TestDataConstructor.Activities.ForEach(a => { if (a.AssociatedProject == pro) { Console.WriteLine(++i + ") " + a); U03GraphicElements.PrintMinus(); } });
            Console.ResetColor();

        }

        public void ListAllActivities ()
        {
            var i = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Main.TestDataConstructor.Activities.ForEach(a => { Console.WriteLine(++i + ") " + a); U03GraphicElements.PrintMinus(); });
            Console.ResetColor();
        }

    }


}

