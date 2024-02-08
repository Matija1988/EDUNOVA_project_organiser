using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    internal class MembersWorkspace
    {
        public List<O04Member> Members;
        private Main Main {  get;  }

        public ActivitiesWorkspace ActivitiesWorkspace { get;  }
             
        public MembersWorkspace(Main Main):this()
        { 
            
            this.Main = Main;

        
        }

        public MembersWorkspace ()
        {

            Members = new List<O04Member>();
                     
                TestData();
           
        }



        public void MembersMenu ()
        {
            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>> Members menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List all members ");
            Console.WriteLine("2) Add new member");
            Console.WriteLine("3) Edit member");
            Console.WriteLine("4) Delete member");
                     

            Console.WriteLine("5) Return to main menu");
            Console.WriteLine("0) Exit");

            MembersMenuSwitch();
        }


        private void MembersMenuSwitch ()
        {
            switch (U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("\nListing all members\n");
                    ListAllMembers();
                    MembersMenu();
                    
                    break;
                case 2:
                    Console.WriteLine("\nAdding new member \n");
                    AddNewMember();
                    break;
                case 3:
                    Console.WriteLine("\nUpdating member\n");
                    UpdateMember();
                    break;
                case 4:
                    Console.WriteLine("\nDeleting member\n");
                    DeleteMember();
                    break;
                
                case 5:
                    Main.MainMenu();
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

        private void ListAllMembers ()
        {
            int index = 0;
            Members.ForEach(member => { Console.WriteLine(++index + ") " + member); });
        }

        private void AddNewMember ()
        {
            ListAllMembers ();

            int id = U01UserInputs.InputInt("Enter new member ID: ");

            Members.ForEach(member => {

                if (member.id == id)
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
                    AddNewMember();
                }

            });


            string name = U01UserInputs.InputString("Name: ");
            string lastName = U01UserInputs.InputString("Last name: ");
            string userName = U01UserInputs.InputString("Username: ");
            string password = U01UserInputs.InputString ("Password: ");

            Members.ForEach(member => { if (member.Password == password)
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
                    AddNewMember();
                }
            });
          
            bool isTeamLeader = U01UserInputs.InputBool("Is team leader: 1) YES / 2) NO ");

            Members.Add(new O04Member()
            {
                id = id,
                Name = name,
                LastName = lastName,
                Username = userName,
                Password = password,
                IsTeamLeader = isTeamLeader

            }) ;

            MembersMenu();

        }


     

        private void UpdateMember ()
        {
            ListAllMembers();

            U03GraphicElements.PrintStars();

            int chooseMember = U01UserInputs.InputInt("Choose a member you wish to update: ");
            var member = Members[chooseMember - 1];

            Console.WriteLine("1) Update first name");
            Console.WriteLine("2) Update last name");
            Console.WriteLine("3) Update username");
            Console.WriteLine("4) Update password");
            Console.WriteLine("5) Is team leader");
            Console.WriteLine("6) Return to members menu");



            try
            {
                switch (U01UserInputs.InputInt("\n" + "Choose which element you wish to change: "))
                {
                    case 1:
                        string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                 "\n" + "Previous input: " + member.Name +
                                                                  "\n" + "New input: ");

                     
                        bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                                       "\n" +
                                                                        "\n" + "Previous entry: " + member.Name +
                                                                         "\n" + "New entry: " + name +
                                                                          "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            member.Name = name;
                        }
                        break;

                    case 2:
                        string lastName = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                     "\n" + "Previous input: " + member.LastName +
                                                                      "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + member.LastName +
                                                                "\n" + "New input: " + lastName +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            member.LastName = lastName;
                        }
                        break;

                    case 3:
                        string username = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                     "\n" + "Previous input: " + member.Username +
                                                                      "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + member.Username +
                                                                "\n" + "New input: " + username +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            member.Username = username;
                        }
                        break;

                    case 4:
                        string password = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                     "\n" + "Previous input: " + member.Password +
                                                                      "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + member.Password +
                                                                "\n" + "New input: " + password +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        Members.ForEach(member => {
                            if (member.Password == password)
                            {
                                U02ErrorMessages.ErrorMessageInputExists();
                                UpdateMember();
                            }
                        });


                        if (validation)
                        {
                            member.Password = password;
                        }
                        break;

                    case 5:
                        bool isTeamLeader = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                                     "\n" + "Previous status: " + member.IsTeamLeader +
                                                                      "\n" + "New status: 1) Finished / 2) Ongoing | ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous status: " + member.IsTeamLeader +
                                                                "\n" + "New status: " + isTeamLeader +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            member.IsTeamLeader = isTeamLeader;
                        }
                        break;
                    case 6:
                        MembersMenu();
                        break;
                    default:
                        U02ErrorMessages.ErrorMessageInput();
                        break;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
            }
            UpdateMember();
        }
        private void DeleteMember ()
        {
            U03GraphicElements.PrintStars();
          
            ListAllMembers();

            U03GraphicElements.PrintStars();

            try { 

            int index = U01UserInputs.InputInt("Choose member you wish to delete: ");

                var member = Members[index - 1];

                string validationPassword = U01UserInputs.InputString("Enter your password to validate action: ");

                bool validation = false;
                                
                Members.ForEach(member => { if (member.Password == validationPassword && member.IsTeamLeader == true) validation = true;  });

                if(Main.LoggedInUser == member)
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageCannotDeleteYourself());
                    MembersMenu();
                }
            
                if(validation != true) 
                {
                    U02ErrorMessages.ErrorMessageInput();
                                 
                }                
                else
                {
                    Members.Remove(member);
                }
            } 
            catch {

                U02ErrorMessages.ErrorMessageInput();
            }
            MembersMenu();
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
