using Organiser.ObjectClasses;
using Organiser.Utilities;
using Organiser.Workspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    internal class Main
    {

        public DataInitialisation DataInitialisation { get; }

        public UpdateProjectWorkspace UpdateProjectWorkspace { get; }
        public ProjectWorkspace ProjectWorkspace { get; }

        public ActivitiesWorkspace ActivitiesWorkspace { get; }

        public UpdateActivities UpdateActivities { get; }

        public ProofsWorkspace ProofsWorkspace { get; }

        public MembersWorkspace MembersWorkspace { get; }

        public Member LoggedInUser { get; set; }

        public Main()
        {
            DataInitialisation = new DataInitialisation(this);
            UpdateProjectWorkspace = new UpdateProjectWorkspace(this);
            ProjectWorkspace = new ProjectWorkspace(this);
            ActivitiesWorkspace = new ActivitiesWorkspace(this);
            UpdateActivities = new UpdateActivities(this);  
            ProofsWorkspace = new ProofsWorkspace(this);
            MembersWorkspace = new MembersWorkspace(this);

            StartUpMessage();
            LogIn();
            MainMenu();

        }
               
        private Member LogIn()
        {
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   USER LOGIN   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

            char[] LogInName = U01UserInputs.ReturnCharArray("Username: ");

            char[] Password = U01UserInputs.ReturnCharArray("Password: ");

            string checkedLoggedIn = U01UserInputs.ReturnString(LogInName);
            string checkedPassword = U01UserInputs.ReturnString(Password);

            try
            {
                while (true)
                {
                    DataInitialisation._members.ForEach(member =>
                    {
                        if (member.Username == checkedLoggedIn && member.Password == checkedPassword)

                        {
                            Console.WriteLine("Welcome " + member.Name + " " + member.LastName);
                            var loggedInUser = member;
                            LoggedInUser = loggedInUser;
                            MainMenu();

                        }
                        
                    });
                    U02ErrorMessages.ErrorMessageInput();
                    LogIn();
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                LogIn();
            }

            return LoggedInUser;
        }


        public void MainMenu()
        {
            U04MenuTexts.MainMenuText();

            MainMenuSwitch();
        }


        private void MainMenuSwitch()
        {

            switch (U01UserInputs.InputIntZeroAllowed("Input: "))
            {
                case 1:
                    Console.WriteLine("Entering projects");
                    ProjectWorkspace.ProjectsMenu();

                    break;

                case 2:
                    Console.WriteLine("Entering members");
                    
                    if(LoggedInUser.IsTeamLeader != true)
                    {
                        U02ErrorMessages.LackOfAuthority();
                        MainMenu();
                    } else
                    {
                        MembersWorkspace.MembersMenu();
                    }
                                     

                    break;
                case 0:
                    Console.WriteLine("Exiting application");
                    Environment.Exit(0);
                    break;
                default:
                    U02ErrorMessages.ErrorMessageInput();
                    MainMenu();
                    break;
            }
        }

        private static void StartUpMessage()
        {
            U03GraphicElements.PrintIntroGraphics();

            U03GraphicElements.PrintStars();

            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!  App under development  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            U03GraphicElements.PrintMinus();


        }
    }
}
