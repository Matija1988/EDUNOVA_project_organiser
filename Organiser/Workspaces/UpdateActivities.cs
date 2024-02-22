using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Organiser.Workspaces
{
    internal class UpdateActivities
    {
        private Main Main { get; }

        public UpdateActivities (Main Main) : this()

        {
            this.Main = Main;

        }

        public UpdateActivities () { }

        internal void UpdateActivityName (ObjectClasses.Activity activity)
        {
            try
            {

                string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                 "\n" + "Previous input: " + activity.Name +
                                                                  "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                "\n" +
                                                            "\n" + "Previous entry: " + activity.Name +
                                                             "\n" + "New entry: " + name +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    activity.Name = name;
                }


            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

        internal void UpdateActivityDescription (ObjectClasses.Activity activity)
        {
            try
            {
                string description = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                "\n" + "Previous intput: " + activity.Description +
                                                                 "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + activity.Description +
                                                             "\n" + "New entry: " + description +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    activity.Description = description;
                }

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();

            }

        }

        internal void UpdateActivityDateStart (ObjectClasses.Activity activity)
        {
            try
            {
                DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                  "\n" + "Previous input: " + activity.DateStart +
                                                                   "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                           "\n" +
                                                            "\n" + "Previous entry: " + activity.DateStart +
                                                             "\n" + "New entry: " + dateStart +
                                                              "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    activity.DateStart = dateStart;
                }

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

        internal void UpdateActivityDateEnd (ObjectClasses.Activity activity)
        {
            try
            {
                DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                "\n" + "Previous input: " + activity.DateEnd +
                                                                 "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                      "\n" +
                                                       "\n" + "Previous entry: " + activity.DateEnd +
                                                        "\n" + "New entry: " + dateEnd +
                                                         "\n" + "Accept change: 1) YES / 2) NO | ");

                if (validation)
                {
                    activity.DateEnd = dateEnd;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

     

        internal void UpdateActivityIsFinished (ObjectClasses.Activity activity)
        {
            try
            {
                bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                                   "\n" + "Previous status: " + activity.IsFinished +
                                                                    "\n" + "New status: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                      "\n" +
                                                       "\n" + "Previous entry: " + activity.IsFinished +
                                                        "\n" + "New entry: " + isFinished +
                                                         "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                    activity.IsFinished = isFinished;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

        internal void UpdateActivityDateAccepted (ObjectClasses.Activity activity)
        {
            try
            {
                DateTime dateAccepted = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                     "\n" + "Previous input: " + activity.DateAccepted +
                                                                      "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                      "\n" +
                                                       "\n" + "Previous entry: " + activity.DateAccepted +
                                                        "\n" + "New entry: " + dateAccepted +
                                                         "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                    activity.DateAccepted = dateAccepted;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

        internal void UpdateActivityAssociatedProject (ObjectClasses.Activity activity)
        {
            try
            {
                int project = U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                      "\n" + "Previous input: " + activity.AssociatedProject +
                                                       "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                       "\n" +
                                                        "\n" + "Previous entry: " + activity.AssociatedProject +
                                                         "\n" + "New entry: " + project +
                                                          "\n" + "Accept change: 1) YES / 2) NO | ");
                if (validation)
                {
                    var associatedProject = Main.DataInitialisation._projects[project];
                    activity.AssociatedProject = associatedProject;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

        internal void UpdateActivityDelegateTo (ObjectClasses.Activity activity)
        {
            try
            {
                int member = U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                   "\n" + "Previous input: " + activity.MemberID +
                                                    "\n" + "New input: ");
                bool validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                      "\n" +
                                                       "\n" + "Previous entry: " + activity.MemberID +
                                                        "\n" + "New entry: " + member +
                                                         "\n" + "Accept change: 1) YES / 2) NO | ");

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }

        internal void UpdateActivityAll (ObjectClasses.Activity activity)
        {
            try
            {
                string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                          "\n" + "Previous input: " + activity.Name +
                                                           "\n" + "New input: ");

                string description = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                           "\n" + "Previous intput: " + activity.Description +
                                                            "\n" + "New input: ");

                DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                           "\n" + "Previous input: " + activity.DateStart +
                                                            "\n" + "New input: ");

                DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                         "\n" + "Previous input: " + activity.DateEnd +
                                                          "\n" + "New input: ");

                //folder = Main.TestDataConstructor.Folders[U01UserInputs.InputInt("\n" + "_______________________________________" +
                //                                                                  "\n" + "Previous input: " + activity.DateEnd +
                //                                                                   "\n" + "New input: ") - 1];

               bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                      "\n" + "Previous status: " + activity.IsFinished +
                                                       "\n" + "New status: ");

               DateTime dateAccepted = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                            "\n" + "Previous input: " + activity.DateAccepted +
                                                             "\n" + "New input: ");

                int project = U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                       "\n" + "Previous input: " + activity.AssociatedProject +
                                                        "\n" + "New input: ");

                bool validation = U01UserInputs.InputBool("\n" + "Change activity information? " +
                                                      "\n" +
                                                       "\n" + "Previus input: " + activity +
                                                        "\n" + "New name: " + name + " || " + "New description: " + description + " || " + "New start date: " + dateStart +
                                                              " || " + "New deadline: " + dateEnd + " || " + "Is finished: " + isFinished +
                                                         "\n" + "New folder: " + " proofOfDelivery " + " || " +
                                                          "\n" + "Date accepted: " + dateAccepted +
                                                           "\n" + "New associated project: " + project +
                                                            "\n" + "Accept changes: 1) YES / 2) NO | ");

                if (validation)
                {
                    var associatedProject = Main.DataInitialisation._projects[project];
                    activity.Name = name;
                    activity.Description = description;
                    activity.DateStart = dateStart;
                    activity.DateEnd = dateEnd;
                   // activity.Folder = folder;
                    activity.IsFinished = isFinished;
                    activity.DateAccepted = dateAccepted;
                    activity.AssociatedProject = associatedProject;
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                Main.ActivitiesWorkspace.Update();
            }
        }
    }
}
