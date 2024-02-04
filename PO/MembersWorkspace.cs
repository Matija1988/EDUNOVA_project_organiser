using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    internal class MembersWorkspace
    {
        public List<O04Member> Members;

        private Main Main {  get;  }
        
        public ActivitiesWorkspace Activities { get;  }

        public MembersWorkspace(Main Main):this()
        { 
            
            this.Main = Main;
        }

        public MembersWorkspace() 
        { 
            Members = new List<O04Member>();

            if(U01UserInputs.dev)
            {
                TestData(); 
            }
            
        
        }

       

        public void MembersMenu ()
        {
            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>> Members menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List all members ");
            Console.WriteLine("2) Add new member");
            Console.WriteLine("3) Edit member");
            Console.WriteLine("4) Delete member");

            Console.WriteLine("5) Show member activities");
            Console.WriteLine("6) Assign activity to a member");

            Console.WriteLine("7) Assign team leader");
            Console.WriteLine("8) Remove team leader");

            Console.WriteLine("9) Return to main menu");
            Console.WriteLine("0) Exit");
        }


        private void MembersMenuSwitch ()
        {
            switch (U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("Listing all members");
                    MembersMenu();
                    MembersMenuSwitch();
                    break;
                case 2:
                    Console.WriteLine("Adding new member");
                    break;
                case 3:
                    Console.WriteLine("Editing member");
                    break;
                case 4:
                    Console.WriteLine("Deleting member");
                    break;
                case 5:
                    Console.WriteLine("Member acivities");
                    break;
                case 6:
                    Console.WriteLine("Assigning activiti to a member");
                    break;
                case 7:
                    Console.WriteLine("Member promoted to team leader");
                    break;
                case 8:
                    Console.WriteLine("Team leader relegated");
                    break;
                case 9:
                    Main.MainMenu();
                    break;
                case 0:
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

        private void TestData ()
        {

            Members.Add(new O04Member()
            {
                id = 1,
                Name = "Matija",
                LastName = "Pavkovic",
                Username = "test",
                Password = "test",
                IsTeamLeader = true,

            });

            Members.Add(new O04Member()
            {
                id = 2,
                Name = "Tester",
                LastName = "Testic",
                Username = "tester",
                Password = "abcd",
                IsTeamLeader = false,

            });
        }
    }
}
