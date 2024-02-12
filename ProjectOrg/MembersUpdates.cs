using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class MembersUpdates
    {
        public List<Member> Members { get; set; }

        private Main Main { get;  }

    

        public MembersUpdates(Main main) : this()
        
        { 
         this.Main = main;
        
        }

        public MembersUpdates() 
        {

        }

        internal void UpdateMember ()
        {
            U03GraphicElements.PrintStars();

            int chooseMember = U01UserInputs.InputInt("Choose a member you wish to update: ");
            var member = Main.TestDataConstructor.Members[chooseMember - 1];

            U04MenuTexts.UpdateMenuText();

            int choice = U01UserInputs.InputInt("\n" + "Choose which element you wish to change: ");


            try
            {
                switch (choice)
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

                        Main.TestDataConstructor.Members.ForEach(member =>
                        {
                            if (member.Password == password)
                            {
                                Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
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
                        Main.MembersWorkspace.MembersMenu();
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
    }
}
