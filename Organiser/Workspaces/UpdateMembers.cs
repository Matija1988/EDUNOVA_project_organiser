using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Organiser.Workspaces
{
    internal class UpdateMembers
    {
        private Main Main { get; }

        public UpdateMembers(Main Main)
        {

            this.Main = Main;

        }

        public UpdateMembers() { }

        internal void UpdateMemberName(Member member)
        {
            try
            {
                string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                         "\n" + "Previous input: " + member.Name +
                                                          "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + member.Name +
                                                             "\n" + "New entry: " + name +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    member.Name = name;
                }


            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.MembersWorkspace.MembersMenu();
            }
        }


        internal void UpdateMemberLastName(Member member)
        {
            try
            {
                string lastName = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                         "\n" + "Previous input: " + member.LastName +
                                                          "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + member.LastName +
                                                             "\n" + "New entry: " + lastName +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    member.LastName = lastName;
                }


            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.MembersWorkspace.MembersMenu();
            }
        }

        internal void UpdateMemberUsername(Member member)
        {
            try
            {
                string Username = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                         "\n" + "Previous input: " + member.Username +
                                                          "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + member.Username +
                                                             "\n" + "New entry: " + Username +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    member.Username = Username;
                }


            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.MembersWorkspace.MembersMenu();
            }
        }

        internal void UpdateMemberPassword(Member member)
        {
            try
            {
                string Password = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                             "\n" + "Previous input: " + member.Password +
                                                              "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + member.Password +
                                                             "\n" + "New entry: " + Password +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    member.Password = Password;
                }


            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.MembersWorkspace.MembersMenu();
            }
        }

        internal void UpdateMemberIsTeamLeader(Member member)
        {
            try
            {
                bool IsTeamLeader = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                           "\n" + "Project finished: " + member.IsTeamLeader +
                                                            "\n" + "New status: 1) Finished / 2) Ongoing | ");

                bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                           "\n" +
                                                            "\n" + "Previous is finished: " + member.IsTeamLeader +
                                                             "\n" + "New is finished: " + IsTeamLeader +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                   member.IsTeamLeader = IsTeamLeader;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                Main.MembersWorkspace.MembersMenu();
            }
        }

        internal void UpdateMemberAll(Member member)
        {
            try
            {
                string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                         "\n" + "Previous input: " + member.Name +
                                                          "\n" + "New input: ");


                string lastName = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                             "\n" + "Previous input: " + member.LastName +
                                                              "\n" + "New input: ");

                string Username = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                         "\n" + "Previous input: " + member.Username +
                                                          "\n" + "New input: ");

                string Password = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                             "\n" + "Previous input: " + member.Password +
                                                              "\n" + "New input: ");

                bool IsTeamLeader = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                           "\n" + "Project finished: " + member.IsTeamLeader +
                                                            "\n" + "New status: 1) Finished / 2) Ongoing | ");


                bool validation = U01UserInputs.InputBool("\n" + "Change project information? " +
                                                            "\n" +
                                                             "\n" + "Previus input: " + member +
                                                              "\n" + "New first neme: " + name + " || " + "New last name: " + lastName + " ||\n" + "Username: " + Username +
                                                                " || " + "Password: " + Password + " ||\n " + "Is team leader: " + IsTeamLeader +
                                                                "\n" +
                                                                 "\n" + "Accept changes: 1) YES / 2) NO | ");
                if (validation)
                {
                    member.Name = name;
                    member.LastName = lastName;
                    member.Username = Username;
                    member.Password = Password;
                    member.IsTeamLeader = IsTeamLeader;
                }

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.MembersWorkspace.MembersMenu();
            }
        }
    }
}
