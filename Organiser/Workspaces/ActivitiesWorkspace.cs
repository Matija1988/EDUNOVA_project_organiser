using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Workspaces
{

    internal class ActivitiesWorkspace : IWorkspace
    {

        private Main Main { get; }

        public Project SelectedProject { get; }

        public ActivitiesWorkspace (Main Main) : this()
        {
            this.Main = Main;
        }

        public ActivitiesWorkspace ()
        {

        }

        public void ActivitiesMenu (Project project)
        {
            U04MenuTexts.ActivitiesMenuText();

            Console.WriteLine("Working on project: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(project.Name + "\n");
            Console.ResetColor();



            ActivitiesMenuSwitch(project);

        }

        private void ActivitiesMenuSwitch (Project project)
        {
            switch (U01UserInputs.InputIntZeroAllowed("Input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "Listing activities: " + "\n");
                    List();
                    ActivitiesMenu(project);

                    break;
                case 2:
                    Console.WriteLine("Entering new activity");
                    Add();


                    break;

                case 3:
                    Console.WriteLine("Edit activity");
                    Update();
                    break;

                case 4:
                    Console.WriteLine("Activity go bye bye");
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                        Delete();
                    }
                    else
                    {
                        U02ErrorMessages.LackOfAuthority();
                        Main.MainMenu();
                    }

                    break;
                case 5:
                    ListAllActivities();
                    ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
                    break;
                case 6:

                    break;
                case 7:
                    Main.ProjectWorkspace.ProjectsMenu();
                    break;
                case 8:
                    Main.MainMenu();

                    break;
                case 0:

                    Environment.Exit(0);

                    break;
                default:
                    U02ErrorMessages.ErrorMessageInput();
                    break;
            }
        }

        private void ListAllActivities ()
        {
            Main.DataInitialisation._activities.ForEach(a =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(a);
                U03GraphicElements.PrintMinus();
            });
        }

        public void Add ()
        {
            List();


            try
            {

                int id = U01UserInputs.AutoIncrementID(Main.DataInitialisation._activities);

                Main.DataInitialisation._activities.ForEach(a => { if (a.id == id) { id++; } });

                IActivity activity = Factory.ActivityFactory();
                activity.id = id;
                activity.Name = U01UserInputs.InputString("Enter activity name (please follow contract naming convention): ");
                activity.Description = U01UserInputs.InputString("Enter activity description: ");
                activity.DateStart = U01UserInputs.InputDateTime("Input activity start date (enter date format dd/MM/yyyy): ");
                activity.DateEnd = U01UserInputs.InputDateTime("Input activity end date (enter date format dd/MM/yyyy): ");

                //   activity.ProofOfDelivery = null;
                // Add this later

                activity.IsFinished = U01UserInputs.InputBool("Activity status: 1) Finished / 2) Ongoing : ");
                activity.DateAccepted = U01UserInputs.InputDateTime("Activity accepted as finished on (enter date format dd/MM/yyyy): ");
                activity.AssociatedProject = Main.ProjectWorkspace.SelectedProject.id;
                activity.MemberID = 1;



                if (U01UserInputs.InputBool("Accept this input 1) YES / 2) NO | "))
                {
                    Main.DataInitialisation._activities.Add((ObjectClasses.Activity)activity);
                }
            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
            }
            ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
        }

        public void List ()
        {
            Main.DataInitialisation._activities.ForEach(a =>
            {
                if (a.AssociatedProject == Main.ProjectWorkspace.SelectedProject.id)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(a);
                    Console.ResetColor();
                    U03GraphicElements.PrintMinus();
                }
            });
        }


        public void Update ()
        {
            List();

            U04MenuTexts.UpdateActivitiesMenuText();

            var activity = Main.DataInitialisation._activities[0];

            int index = U01UserInputs.InputInt("Choose the ID of the activity you wish to update: ");

            Main.DataInitialisation._activities.ForEach(a => { if (a.id == index) { activity = a; } });

            switch (U01UserInputs.InputInt("Choose the attribute you wish to update: "))
            {
                case 1:
                    Main.UpdateActivities.UpdateActivityName(activity);
                    break;
                case 2:
                    Main.UpdateActivities.UpdateActivityDescription(activity);
                    break;
                case 3:
                    Main.UpdateActivities.UpdateActivityDateStart(activity);
                    break;
                case 4:
                    Main.UpdateActivities.UpdateActivityDateEnd(activity);
                    break;
                case 5:
                    Main.UpdateActivities.UpdateActivityProofOfDelivery(activity);
                    break;
                case 6:
                    Main.UpdateActivities.UpdateActivityIsFinished(activity);
                    break;
                case 7:
                    Main.UpdateActivities.UpdateActivityDateAccepted(activity);
                    break;
                case 8:
                    Main.UpdateActivities.UpdateActivityAssociatedProject(activity);
                    break;
                case 9:
                    Main.UpdateActivities.UpdateActivityDelegateTo(activity);
                    break;
                case 10:
                    Main.UpdateActivities.UpdateActivityAll(activity);
                    break;
                case 0:
                    ActivitiesMenu(SelectedProject);
                    break;
                default:
                    U02ErrorMessages.ErrorMessageInput();
                    Update();
                    break;


            }


            ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
        }

        public void Delete ()
        {
            List();

            int index = U01UserInputs.InputInt("Choose the ID of the activity you wish to delete: ");

            var activity = Main.DataInitialisation._activities[0];

            Main.DataInitialisation._activities.ForEach(a => { if (a.id == index) { activity = a; } });
            Main.DataInitialisation._activities.Remove(activity);

            ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
        }
    }
}
