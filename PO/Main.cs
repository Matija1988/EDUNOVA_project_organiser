﻿using PO.ObjectClasses;
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
  

    internal class Main
    {
        public List<O04Member> Members { get; }


        public ProjectWorkspace ProjectWorkspace { get; }
        public MembersWorkspace MembersWorkspace { get; }
        public ActivitiesWorkspace ActivitiesWorkspace { get; }
        public ProofWorkspace ProofWorkspace { get; }
        public FoldersWorkspace FoldersWorkspace { get; }

       


        public O04Member LoggedInUser { get; set; }

        public Main()
        {
            U01UserInputs.dev = true;

            MembersWorkspace = new MembersWorkspace(this);

            FoldersWorkspace = new FoldersWorkspace(this);
            ProofWorkspace = new ProofWorkspace(this);

            ActivitiesWorkspace = new ActivitiesWorkspace(this);
            ProjectWorkspace = new ProjectWorkspace(this);

            FoldersWorkspace = new FoldersWorkspace(this);


            LoggedInUser = new O04Member(); 
           
        
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
                            
                            
                            var loggedInUser = MembersWorkspace.Members[i];
                            LoggedInUser = loggedInUser;
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
            U04MenuTexts.MainMenuText();

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
                    Console.WriteLine("Entering projects");
                    ActivitiesWorkspace.ActivitiesMenu();
                    
                    break;
                case 3:
                    Console.WriteLine("Entering projects");
                    ProofWorkspace.ProofMenu();

                    break;
                case 4:
                    Console.WriteLine("Entering members");
                   MembersWorkspace.MembersMenu();
                 
                    break;
                case 5:
                    Console.WriteLine("Exiting application");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\n" + U02ErrorMessages.ErrorMessageInput());
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
