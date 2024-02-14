using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class MembersWorkspace
    {
        public List<Member> Members { get; set; }

        public Member LoggedInUser { get; }
        private Main Main { get; }

        public MembersWorkspace (Main Main) : this()
        {

            this.Main = Main;

        }

        public MembersWorkspace ()
        {


        }



        public void MembersMenu ()
        {
            U04MenuTexts.MembersMenuText();

            MembersMenuSwitch();
        }


        private void MembersMenuSwitch ()
        {
            switch (U01UserInputs.InputIntZeroAllowed("Input: "))
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
                    MembersMenu();
                    break;
            }


        }

        private void ListAllMembers ()
        {
            int index = 0;
            Main.TestDataConstructor.Members.ForEach(member => { Console.WriteLine(++index + ") " + member); });
        }

        private void AddNewMember ()
        {


            int id = U01UserInputs.AutoIncrementID(Main.TestDataConstructor.Members);

            Main.TestDataConstructor.Members.ForEach(member =>
           {

               if (member.id == id)
               {                                     
                   id++;
               }
               
           });

            string name = U01UserInputs.InputString("Name: ");
            string lastName = U01UserInputs.InputString("Last name: ");
            string userName = U01UserInputs.InputString("Username: ");
            string password = U01UserInputs.InputString("Password: ");
            
            Main.TestDataConstructor.Members.ForEach(member =>
              {
                  if (member.Password == password)
                  {
                        U02ErrorMessages.ErrorMessageInputExists();
                      AddNewMember();
                  }
              });

            bool isTeamLeader = U01UserInputs.InputBool("Is team leader: 1) YES / 2) NO ");

            Main.TestDataConstructor.Members.Add(new Member()
            {
                id = id,
                Name = name,
                LastName = lastName,
                Username = userName,
                Password = password,
                IsTeamLeader = isTeamLeader

            });

            MembersMenu();

        }

        private void UpdateMember ()
        {
            ListAllMembers();

            Main.MembersUpdates.UpdateMember();
            
        }
        private void DeleteMember ()
        {
            U03GraphicElements.PrintStars();

            ListAllMembers();

            U03GraphicElements.PrintStars();

            try
            {

                int index = U01UserInputs.InputInt("Choose member you wish to delete: ");

                var member = Main.TestDataConstructor.Members[index - 1];

                string validationPassword = U01UserInputs.InputString("Enter your password to validate action: ");

                bool validation = false;

                Main.TestDataConstructor.Members.ForEach(member => { if (member.Password == validationPassword && member.IsTeamLeader == true) validation = true; });

                if (Main.LoggedInUser == member)
                {
                    U02ErrorMessages.ErrorMessageCannotDeleteYourself();
                    
                    MembersMenu();
                }

                if (validation != true)
                {
                    U02ErrorMessages.ErrorMessageInput();

                }
                else
                {
                  Main.TestDataConstructor.Members.Remove(member);
                }
            }
            catch
            {

                U02ErrorMessages.ErrorMessageInput();
            }
            MembersMenu();
        }


    }
}
