using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{


    internal class ActivitiesUpdater
    {
        public List<Activity> Activities { get; set; }

        private Main Main { get; }

        public ActivitiesUpdater (Main Main) : this()

        {

            this.Main = Main;

        }

        public ActivitiesUpdater ()

        {


        }

        internal void UpdateActivities ()
        {
            try
            {
                int indexID = U01UserInputs.InputInt("Enter ID of the activity you wish to edit: ");

                var activities = Main.TestDataConstructor.Activities;

                var activity = Main.TestDataConstructor.Activities[0];

                U04MenuTexts.EditActivitiesMenuText();

                activities.ForEach(a =>
                {
                    if (a.id == indexID)
                    {
                        activity = a;
                    }


                });

                switch (U01UserInputs.InputIntZeroAllowed("Choose which atribute you wish to edit: "))
                {
                    case 1:
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


                        break;

                    case 2:
                        string description = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                        "\n" + "Previous intput: " + activity.Description +
                                                                         "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.Description +
                                                                "\n" + "New entry: " + description +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            activity.Description = description;
                        }

                        break;

                    case 3:
                        DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                          "\n" + "Previous input: " + activity.DateStart +
                                                                           "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.DateStart +
                                                                "\n" + "New entry: " + dateStart +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            activity.DateStart = dateStart;
                        }
                        break;

                    case 4:
                        DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                         "\n" + "Previous input: " + activity.DateEnd +
                                                                          "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.DateEnd +
                                                                "\n" + "New entry: " + dateEnd +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            activity.DateEnd = dateEnd;
                        }
                        break;

                    case 5:
                        Folder folder = Main.TestDataConstructor.Folders[U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                                                                 "\n" + "Previous input: " + activity.DateEnd +
                                                                                                  "\n" + "New input: ") - 1];

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.Folder +
                                                                "\n" + "New entry: " + folder +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            activity.Folder = folder;
                        }



                        break;

                    case 6:
                        bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                                   "\n" + "Previous status: " + activity.IsFinished +
                                                                    "\n" + "New status: ");

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.IsFinished +
                                                                "\n" + "New entry: " + isFinished +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            activity.IsFinished = isFinished;
                        }

                        break;
                    case 7:
                        DateTime dateAccepted = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                             "\n" + "Previous input: " + activity.DateAccepted +
                                                                              "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.DateAccepted +
                                                                "\n" + "New entry: " + dateAccepted +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            activity.DateAccepted = dateAccepted;
                        }
                        break;

                    case 8:
                        Project project = Main.TestDataConstructor.Projects[U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                                                                    "\n" + "Previous input: " + activity.AssociatedProject +
                                                                                                     "\n" + "New input: ") - 1];

                        validation = U01UserInputs.InputBool("\n" + "Change activity information " +
                                                              "\n" +
                                                               "\n" + "Previous entry: " + activity.AssociatedProject +
                                                                "\n" + "New entry: " + project +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            activity.AssociatedProject = project;
                        }
                        break;
                        
                    case 9:
                        name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                          "\n" + "Previous input: " + activity.Name +
                                                           "\n" + "New input: ");

                        description = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                 "\n" + "Previous intput: " + activity.Description +
                                                                  "\n" + "New input: ");

                        dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                 "\n" + "Previous input: " + activity.DateStart +
                                                                  "\n" + "New input: ");

                        dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                               "\n" + "Previous input: " + activity.DateEnd +
                                                                "\n" + "New input: ");

                        folder = Main.TestDataConstructor.Folders[U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                                                          "\n" + "Previous input: " + activity.DateEnd +
                                                                                           "\n" + "New input: ") - 1];

                        isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                              "\n" + "Previous status: " + activity.IsFinished +
                                                               "\n" + "New status: ");

                        dateAccepted = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                    "\n" + "Previous input: " + activity.DateAccepted +
                                                                     "\n" + "New input: ");

                        project = Main.TestDataConstructor.Projects[U01UserInputs.InputInt("\n" + "_______________________________________" +
                                                                                            "\n" + "Previous input: " + activity.AssociatedProject +
                                                                                             "\n" + "New input: ") - 1];

                        validation = U01UserInputs.InputBool("\n" + "Change activity information? " +
                                                              "\n" +
                                                               "\n" + "Previus input: " + activity +
                                                                "\n" + "New name: " + name + " || " + "New description: " + description + " || " + "New start date: " + dateStart +
                                                                      " || " + "New deadline: " + dateEnd + " || " + "Is finished: " + isFinished +
                                                                 "\n" + "New folder: " + folder + " || " +
                                                                  "\n" + "Date accepted: " + dateAccepted +
                                                                   "\n" + "New associated project: " + project +
                                                                    "\n" + "Accept changes: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            activity.Name = name;
                            activity.Description = description;
                            activity.DateStart = dateStart;
                            activity.DateEnd = dateEnd;
                            activity.Folder = folder;
                            activity.IsFinished = isFinished;
                            activity.DateAccepted = dateAccepted;
                            activity.AssociatedProject = project;
                        }

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

            Main.ActivitiesWorkspace.ActivitiesMenu();
        }


    }
}
