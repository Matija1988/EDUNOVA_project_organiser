using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Organiser.Workspaces
{
    internal class UpdateProjectWorkspace
    {
        public List<Project> _projects { get; }
        private Main Main { get; }

        private ProjectWorkspace ProjectWorkspace { get; }

        public UpdateProjectWorkspace (Main Main) : this()
        {
            this.Main = Main;
        }
        public UpdateProjectWorkspace () { }

        internal void UpdateProjectUniqueID (Project project)
        {
            try
            {
                string UniqueID = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                             "\n" + "Previous unique ID: " + project.UniqueID +
                                                              "\n" + "New unique ID: ");

                Main.DataInitialisation._projects.ForEach(p => { if (p.UniqueID == UniqueID) { U02ErrorMessages.ErrorMessageInputExists(); ProjectWorkspace.Update(); } });

                bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + project.UniqueID +
                                                             "\n" + "New entry: " + UniqueID +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    project.UniqueID = UniqueID;
                }

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                ProjectWorkspace.Update();
            }

            Main.ProjectWorkspace.ProjectsMenu();
        }

        internal void UpdateProjectName (Project project)
        {
            try
            {
                string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                "\n" + "Previous project name: " + project.Name +
                "\n" + "New project name: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                      "\n" +
                                                       "\n" + "Previous project name: " + project.Name +
                                                        "\n" + "New project name: " + name +
                                                         "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    project.Name = name;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                ProjectWorkspace.Update();
            }

        }

        internal void UpdateStartDate (Project project)
        {
            try
            {
                DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                  "\n" + "Previous input: " + project.DateStart +
                                                                   "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                           "\n" +
                                                            "\n" + "Previous input: " + project.DateStart +
                                                             "\n" + "New input: " + dateStart +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                    project.DateStart = dateStart;
                }


            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                ProjectWorkspace.Update();
            }

        }

        internal void UpdateEndDate (Project project)
        {
            try
            {
                DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                "\n" + "Previous input: " + project.DateEnd +
                                                                 "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                           "\n" +
                                                            "\n" + "Previous input: " + project.DateEnd +
                                                             "\n" + "New input: " + dateEnd +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                    project.DateEnd = dateEnd;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                ProjectWorkspace.Update();
            }
        }

        internal void UpdateIsFinished (Project project)
        {
            try
            {
                bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                           "\n" + "Project finished: " + project.IsFinished +
                                                            "\n" + "New status: 1) Finished / 2) Ongoing | ");

                bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                           "\n" +
                                                            "\n" + "Previous is finished: " + project.IsFinished +
                                                             "\n" + "New is finished: " + isFinished +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                    project.IsFinished = isFinished;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                ProjectWorkspace.Update();
            }
        }

        internal void UpdateProjectAll (Project project)
        {
            try
            {
                string uniqueId = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                             "\n" + "Previous unique ID: " + project.UniqueID +
                                                              "\n" + "New unique ID: ");

                string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                         "\n" + "Previous project name: " + project.Name +
                                                          "\n" + "Name project name: ");

                DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                  "\n" + "Previous input: " + project.DateStart +
                                                                   "\n" + "New input: ");

                DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                "\n" + "Previous input: " + project.DateEnd +
                                                                 "\n" + "New input: ");

                bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                           "\n" + "Previous is finished: " + project.IsFinished +
                                                            "\n" + "New status: 1) Finished / 2) Ongoing | ");

                bool validation = U01UserInputs.InputBool("\n" + "Change project information? " +
                                                           "\n" +
                                                            "\n" + "Previus input: " + project +
                                                             "\n" + "New unique ID: " + uniqueId + " || " + "New project name: " + name + " || " + "New start date: " + dateStart +
                                                               " || " + "New deadline: " + dateEnd + " || " + "Is finished: " + isFinished +
                                                               "\n" +
                                                                "\n" + "Accept changes: 1) YES / 2) NO | ");

                if (validation)
                {

                    project.UniqueID = uniqueId;
                    project.Name = name;
                    project.DateStart = dateStart;
                    project.DateEnd = dateEnd;
                    project.IsFinished = isFinished;
                }

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();

                ProjectWorkspace.Update();
            }
        }
        
    }
}
