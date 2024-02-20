using Organiser.ObjectClasses;
using Organiser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Organiser.Workspaces
{
    internal class ProjectWorkspace : IWorkspace
    {
        private Main Main;

        public Project SelectedProject {  get; set; }   
        
        public ProjectWorkspace (Main main)
        {
            this.Main = main;
        }

        public ProjectWorkspace ()
        {


        }


        public void ProjectsMenu ()
        {

            U04MenuTexts.ProjectMenuText();

            ProjectMenuSwitch();
        }

        private void ProjectMenuSwitch ()
        {

            switch (U01UserInputs.InputIntZeroAllowed("\n" + "Project menu input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "List active projects");

                    ListActiveProjects();

                    ProjectsMenu();

                    break;

                case 2:
                    ManageProject();
                    break;

                case 3:
                    Add();
                    break;

                case 4:
                    Update();
                    break;

                case 5:
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                        Delete();
                    }
                    else
                    {
                        Console.WriteLine(U02ErrorMessages.LackOfAuthority());
                        Main.MainMenu();
                    }

                    break;

                case 6:
                    Console.WriteLine("\n" + "List finished projects");

                    ListFinishedProjects();
                    ProjectsMenu();

                    break;


                case 7:
                    Console.WriteLine("Returning to main menu");

                    Main.MainMenu();
                    break;

                case 0:

                    Environment.Exit(0);
                    break;

                default:
                    U02ErrorMessages.ErrorMessageInput();
                    ProjectsMenu();
                    break;

            }

        }

        private void ManageProject ()
        {
            List();

            try { 

            int projectID = U01UserInputs.InputInt("Choose the ID of the project you wish to manage: ");

            var project = Main.DataInitialisation._projects[0];

            Main.DataInitialisation._projects.ForEach(p => { if (p.id == projectID) { project = p; } });

                SelectedProject = project;

            Main.ActivitiesWorkspace.ActivitiesMenu(SelectedProject);

            } catch 
            {
                U02ErrorMessages.ErrorMessageInput();
                ProjectsMenu();
            
            }


        }

        private void ListActiveProjects ()
        {
            U03GraphicElements.PrintStars();

            Main.DataInitialisation._projects.ForEach(p => {
                if (p.IsFinished == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(p);
                    Console.ResetColor();
                    U03GraphicElements.PrintMinus();

                }
            });
        }

        private void ListFinishedProjects ()
        {
            U03GraphicElements.PrintStars();

            Main.DataInitialisation._projects.ForEach(p => { if (p.IsFinished == true) 
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(p);
                    Console.ResetColor();
                    U03GraphicElements.PrintMinus();

                } });
        }

        public void Add ()
        {
            
            List();

            int id = U01UserInputs.AutoIncrementID(Main.DataInitialisation._projects);

            Main.DataInitialisation._projects.ForEach((project) =>
            {

                if (project.id == id)
                {

                    id++;

                }
            });

            IProject project = Factory.ProjectFactory();
            project.id = id;
            project.UniqueID = U01UserInputs.InputString("Enter unique ID: ");
            project.Name = U01UserInputs.InputString("Enter project name: ");
            project.DateStart = U01UserInputs.InputDateTime("Start date (enter date format dd/MM/yyyy): ");
            project.DateEnd = U01UserInputs.InputDateTime("Deadline (enter date format dd/MM/yyyy): ");
            project.IsFinished = U01UserInputs.InputBool("Is finished 1) Finished / 2) Ongoing | ");

            StringBuilder sb = new StringBuilder();

            sb.Append(project.id + " - " + project.Name + " - " + project.UniqueID + " - " + "Start date: " + project.DateStart + " - " + "End date: " + project.DateEnd + " - " + project.IsFinished);

            Console.WriteLine("New project: " +
            "\n" + sb);

            if (U01UserInputs.InputBool("Accept this input 1) YES / 2) NO | "))
            {
                Main.DataInitialisation._projects.Add((Project)project);
            }

            ProjectsMenu();
        }

        public void List ()
        {
            U03GraphicElements.PrintStars();
            Main.DataInitialisation._projects.ForEach(project =>
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(project);
                U03GraphicElements.PrintMinus();
            });
        }

        public void Update ()
        {
            
            List();

            try
            {

                int index = U01UserInputs.InputInt("Enter the ID of the project you wish to update: ");

                var project = Main.DataInitialisation._projects[0];

                Main.DataInitialisation._projects.ForEach(p => { if (p.id == index) { project = p; } });

                U04MenuTexts.UpdateProjectText();

                switch (U01UserInputs.InputIntZeroAllowed("Choose which attribute you wish to update: "))
                {
                    case 1:
                        Main.UpdateProjectWorkspace.UpdateProjectUniqueID(project);
                        break;

                    case 2:
                        Main.UpdateProjectWorkspace.UpdateProjectName(project);
                        break;

                    case 3:
                        Main.UpdateProjectWorkspace.UpdateStartDate(project);
                        break;

                    case 4:
                        Main.UpdateProjectWorkspace.UpdateEndDate(project);
                        break;

                    case 5:
                        Main.UpdateProjectWorkspace.UpdateIsFinished(project);
                        break;

                    case 6:
                        Main.UpdateProjectWorkspace.UpdateProjectAll(project); 
                        break;

                    case 0:
                        ProjectsMenu();
                        break;

                    default:
                        U02ErrorMessages.ErrorMessageInput();
                        Update();
                        break;
                }

            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error in projects update switch " + ex);
            }

            ProjectsMenu();
        }

        public void Delete ()
        {
            
            List();

            int id = U01UserInputs.InputInt("Choose the ID of the project you wish to delete: ");

            var project = Main.DataInitialisation._projects[0];

            Main.DataInitialisation._projects.ForEach(p => { if (p.id == id) { project = p; } });

            Main.DataInitialisation._projects.Remove(project);

            ProjectsMenu();

        }
    }
}
