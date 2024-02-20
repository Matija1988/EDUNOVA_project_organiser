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

        public ActivitiesWorkspace(Main Main) : this()
        {
            this.Main = Main;
        }

        public ActivitiesWorkspace()
        {

        }

        public void ActivitiesMenu(Project project)
        {
            U04MenuTexts.ActivitiesMenuText();

            Console.WriteLine("Working on project: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(project.Name + "\n");
            Console.ResetColor();



            ActivitiesMenuSwitch(project);

        }

        private void ActivitiesMenuSwitch(Project project)
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
                    //ListAllActivities();
                    // ActivitiesMenu();
                    break;

                case 6:
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


        public void Add()
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
                activity.AssociatedProject = 1;
                activity.MemberID = 1;

            }
            catch
            {
                U02ErrorMessages.ErrorMessageInput();
                ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
            }
            ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
        }

        public void List()
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


        public void Update()
        {
            List();

            ActivitiesMenu(Main.ProjectWorkspace.SelectedProject);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
