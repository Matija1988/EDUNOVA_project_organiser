using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class Main
    {


        public ProjectWorkspace ProjectWorkspace { get; }
        public MembersWorkspace MembersWorkspace { get; }
        public ActivitiesWorkspace ActivitiesWorkspace { get; }

        public ProofWorkspace ProofWorkspace { get; }

        public TestDataConstructor TestDataConstructor { get; }

        public MembersUpdates MembersUpdates { get; }

        public ProjectsUpdate ProjectsUpdate { get; }

        public ActivitiesUpdater ActivitiesUpdater { get; }

        //    public FoldersWorkspace FoldersWorkspace { get; }

        public Member LoggedInUser { get; set; }

        public Main ()
        {
            U01UserInputs.dev = true;

            TestDataConstructor = new TestDataConstructor(this);

            MembersWorkspace = new MembersWorkspace(this);
            MembersUpdates = new MembersUpdates(this);

            //    FoldersWorkspace = new FoldersWorkspace(this);

            ActivitiesWorkspace = new ActivitiesWorkspace(this);
            ActivitiesUpdater = new ActivitiesUpdater(this);

            ProjectWorkspace = new ProjectWorkspace(this);
            ProjectsUpdate = new ProjectsUpdate(this);

            ProofWorkspace = new ProofWorkspace(this);

            StartUpMessage();
            LogIn();

        }
        private Member LogIn ()
        {

            string LogInName = U01UserInputs.InputString("Username: ");

            string Password = U01UserInputs.InputString("Password: ");

            var p = TestDataConstructor.Members.Count;

            try
            {

                TestDataConstructor.Members.ForEach(member =>
                {
                    if (member.Username == LogInName && member.Password == Password)

                    {
                        Console.WriteLine("Welcome " + member.Name + " " + member.LastName);
                        var loggedInUser = member;
                        LoggedInUser = loggedInUser;
                        MainMenu();

                    }
                });
            }
            catch
            {
                Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
            }

            return LoggedInUser;
        }



        public void MainMenu ()
        {
            U04MenuTexts.MainMenuText();

            MainMenuSwitch();
        }


        private void MainMenuSwitch ()
        {

            switch (U01UserInputs.InputIntZeroAllowed("Input: "))
            {
                case 1:
                    ProjectWorkspace.ProjectsMenu();

                    break;
                case 2:
                    ActivitiesWorkspace.ActivitiesMenu();

                    break;
                case 3:
                    ProofWorkspace.ProofMenu();

                    break;
                case 4:

                    if (LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && LoggedInUser.IsTeamLeader == true)
                    {
                        MembersWorkspace.MembersMenu();
                    } else
                    {
                        Console.WriteLine(U02ErrorMessages.LackOfAuthority());
                        MainMenu();
                    }



                    break;
                case 0:
                    Environment.Exit(0);

                    break;

                default:
                    Console.WriteLine("\n" + U02ErrorMessages.ErrorMessageInput());

                    break;

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
