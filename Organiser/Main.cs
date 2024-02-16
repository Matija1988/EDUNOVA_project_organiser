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
        public List<Project> _projects { get;}

        public List<Member> _members { get;}

        public DataInitialisation DataInitialisation { get; }

        private ProjectWorkspace ProjectWorkspace { get; }

        public Member LoggedInUser { get; set; }

        public Main() 
        {
            DataInitialisation = new DataInitialisation(this);
            ProjectWorkspace = new ProjectWorkspace(this); 

           
            StartUpMessage();
            LogIn();
            MainMenu();

           TestPrint();
        }

        private void TestPrint ()
        {
           
            DataInitialisation._members.ForEach(member => { Console.WriteLine(member.Name + " " + member.LastName); }); 

        }

        private Member LogIn ()
        {

            char[] LogInName = U01UserInputs.ReturnCharArray("Username: ");

            char[] Password = U01UserInputs.ReturnCharArray("Password: ");

            string checkedLoggedIn = U01UserInputs.ReturnString(LogInName);
            string checkedPassword = U01UserInputs.ReturnString(Password);
                       
            try
            {
               
                DataInitialisation._members.ForEach(member =>
                {
                    if (member.Username == checkedLoggedIn && member.Password == checkedPassword)

                    {
                        Console.WriteLine("Welcome " + member.Name + " " + member.LastName);
                        var loggedInUser = member;
                        LoggedInUser = loggedInUser;
                        MainMenu();

                    } else
                    {
                        U02ErrorMessages.ErrorMessageInput();
                        LogIn();
                    }
                });
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                LogIn();
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
                    Console.WriteLine("Entering projects");
                    ProjectWorkspace.ProjectsMenu();

                    break;
            
                case 2:
                    Console.WriteLine("Entering members");
                  //  MembersWorkspace.MembersMenu();

                    break;
                case 0:
                    Console.WriteLine("Exiting application");
                    Environment.Exit(0);
                    break;
                default:
                    U02ErrorMessages.ErrorMessageInput();
                  
                    break;
            }
        }

        private static void StartUpMessage ()
        {
            U03GraphicElements.PrintIntroGraphics();

            U03GraphicElements.PrintStars();
            
            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!  App under development  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            U03GraphicElements.PrintMinus();

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   USER LOGIN   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }
    }
}
