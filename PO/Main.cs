using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace PO
{
  //  public List<O04Member> Members { get;  }

    internal class Main
    {
        public ProjectWorkspace ProjectWorkspace { get;  }
        public MembersWorkspace MembersWorkspace { get; }
        public ActivitiesWorkspace ActivitiesWorkspace { get; }

        public Main()
        {
            U01UserInputs.dev = true;
            ProjectWorkspace = new ProjectWorkspace();
            MembersWorkspace = new MembersWorkspace();  
            ActivitiesWorkspace = new ActivitiesWorkspace();

            StartUpMessage();
            LogIn();
        
        }
        private void LogIn ()
        {

            string LogInName = U01UserInputs.InputString("Username: ");

            string Password = U01UserInputs.InputString("Password: ");

            var p = MembersWorkspace.Members.Count;


            for (int i = 0; i <= p; i++)
            {

                try
                {
                    if (MembersWorkspace.Members[i].Username == LogInName && MembersWorkspace.Members[i].Password == Password)

                    {


                        Console.WriteLine("Welcome " + MembersWorkspace.Members[i].ToString());
                        if (MembersWorkspace.Members[i].IsTeamLeader == true)
                        {

                            MainMenu();

                        }
                        else
                        {

                            ProjectWorkspace.ProjectsMenu();

                        }

                    }
                }
                catch
                {

                    Console.WriteLine("!!!!!!!!!! INVALID USERNAME OR PASSWORD !!!!!!!!!!");
                    LogIn();


                }



            }

        }


        public  void MainMenu ()
        {
            Console.WriteLine("\n" +
                ">>>>>>>>>>>>>>>>>>>>>>> Main menu <<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) Manage projects");
            Console.WriteLine("2) Manage members");
            Console.WriteLine("3) Exit");

            MainMenuSwitch();
        }

       
        private  void MainMenuSwitch ()
        {

            switch (U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("Entering projects");
                  ProjectWorkspace.ProjectsMenu();
                    
                    break;
                case 2:
                    Console.WriteLine("Entering members");
                   MembersWorkspace.MembersMenu();
                 
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
