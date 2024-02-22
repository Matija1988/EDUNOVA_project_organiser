using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Workspaces
{
    internal class MembersWorkspace : IWorkspace
    {
        private Main Main { get; }

        public MembersWorkspace(Main Main) : this()
        {
            this.Main = Main;
        }

        public MembersWorkspace()
        {

        }
        public void MembersMenu()
        {
            U04MenuTexts.MembersMenuText();

            MembersMenuSwitch();
        }

        private void MembersMenuSwitch()
        {
            switch (U01UserInputs.InputIntZeroAllowed("Input: "))
            {
                case 1:
                    Console.WriteLine("\nListing all members\n");
                    List();
                    MembersMenu();

                    break;
                case 2:
                    Console.WriteLine("\nAdding new member \n");
                    Add();
                    break;
                case 3:
                    Console.WriteLine("\nUpdating member\n");
                    Update();
                    break;
                case 4:
                    Delete();

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

        public void Add()
        {
            List();

            int id = U01UserInputs.AutoIncrementID(Main.DataInitialisation._members);

            Main.DataInitialisation._members.ForEach(m => { if (m.id == id) { id++; } });

            IMember member = Factory.MemberFactory();
            member.Name = U01UserInputs.InputString("Input first name: ");
            member.LastName = U01UserInputs.InputString("Input last name: ");
            member.Username = U01UserInputs.InputString("Input username: ");
            member.Password = U01UserInputs.InputString("Input password: ");
            member.IsTeamLeader = U01UserInputs.InputBool("Is team leader: ");

            StringBuilder sb = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("New member:" + member.Name + " " + member.LastName + "\n" + "USERNAME: " + member.Username + "\n" + "PASSWORD: " + member.Password + "\n" + "Is team leader: " + member.IsTeamLeader);
            Console.ResetColor();

            if (U01UserInputs.InputBool("Accept this input 1) YES / 2) NO | "))
            {
                Main.DataInitialisation._members.Add((Member)member);
            }

            MembersMenu();

        }

        public void List()
        {
            Main.DataInitialisation._members.ForEach(m =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(m);
                Console.ResetColor();
                U03GraphicElements.PrintMinus();
            });
        }

        public void Update()
        {
            List();

            int id = U01UserInputs.InputInt("Choose ID of the member you wish to update: ");

            var member = Main.DataInitialisation._members[0];

            Main.DataInitialisation._members.ForEach(m => { if (m.id == id) member = m; });

            U04MenuTexts.UpdateMemberMenuText();

            switch (U01UserInputs.InputIntZeroAllowed("Choose the attribute you wish to update: "))
            {
                case 1:
                    Main.UpdateMembers.UpdateMemberName(member);
                    break;
                case 2:
                    Main.UpdateMembers.UpdateMemberLastName(member);
                    break;
                case 3:
                    Main.UpdateMembers.UpdateMemberUsername(member);
                    break;
                case 4:
                    Main.UpdateMembers.UpdateMemberPassword(member);
                    break;
                case 5:
                    Main.UpdateMembers.UpdateMemberIsTeamLeader(member);
                    break;
                case 6:
                    Main.UpdateMembers.UpdateMemberAll(member);
                    break;
                case 0:
                    MembersMenu();
                    break;
                default:
                    U02ErrorMessages.ErrorMessageInput();
                    break;
            }



        }

        public void Delete()
        {
            List();

            try
            {

                int memberToDelete = U01UserInputs.InputInt("Choose ID of the memeber you wish to delete: ");

                var deleteMember = Main.DataInitialisation._members[0];

                Main.DataInitialisation._members.ForEach(m =>
                {
                    if (m.id == memberToDelete) { deleteMember = m; }
                });

                string validateAction = U01UserInputs.InputString("Enter you password to validate action: ");

                bool validation = false;

                Main.DataInitialisation._members.ForEach((m) => { if (m.Password == validateAction && m.IsTeamLeader == true) validation = true; });

                if (Main.LoggedInUser == deleteMember)
                {
                    U02ErrorMessages.ErrorMessageCannotDeleteYourself();
                    MembersMenu();
                }
                else
                {
                    Main.DataInitialisation._members.Remove(deleteMember);
                }

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Delete();
            }

            MembersMenu();
        }
    }
}
