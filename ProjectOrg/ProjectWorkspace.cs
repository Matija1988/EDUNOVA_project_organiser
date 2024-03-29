﻿using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class ProjectWorkspace
    {
        public List<Project> Projects { get; }

        private Main Main { get; }

        public ProjectWorkspace (Main main) : this()
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

        public void ProjectMenuSwitch ()
        {

            switch (U01UserInputs.InputIntZeroAllowed("\n" + "Project menu input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "List active projects");

                    ListActiveProjects();
                    ProjectsMenu();

                    break;

                case 2:
                    AddNewProject();
                    break;

                case 3:
                    UpdateProject();
                    break;

                case 4:
                    if (Main.LoggedInUser.Password == U01UserInputs.InputString("\n" + "Verify your indentity! Enter password: ") && Main.LoggedInUser.IsTeamLeader == true)
                    {
                        DeleteProject(); 
                    }
                    else
                    {
                        U02ErrorMessages.LackOfAuthority();
                        Main.MainMenu();
                    }
                    
                    break;

                case 5:
                    Console.WriteLine("\n" + "List finished projects");

                    ListFinishedProjects();
                    ProjectsMenu();

                    break;


                case 6:
                    Console.WriteLine("Returning to main menu");

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
        private void ListActiveProjects ()
        {
           
            U03GraphicElements.PrintStars();
           

            var i = 0;
            Main.TestDataConstructor.Projects.ForEach(p =>
            {
                if (p.IsFinished == false)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(++i + ") " + p);
                    Console.ResetColor();
                    U03GraphicElements.PrintMinus();

                }
            });


        }

        public void ListAllProjects ()
        {
            var i = 0;
            Main.TestDataConstructor.Projects.ForEach(p => 
            { 
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine(++i + ") " + p);
                Console.ResetColor();
                U03GraphicElements.PrintMinus();
            });

            Console.WriteLine("\n");

        }


        private void AddNewProject ()
        {
            ListAllProjects();

            int id = U01UserInputs.AutoIncrementID(Main.TestDataConstructor.Projects); 

            Main.TestDataConstructor.Projects.ForEach(p =>
            {

                if (p.id == id)
                {
                    id++;
                }

            });

            string name = U01UserInputs.InputString("Project name: ");


            string UniqueID = U01UserInputs.InputString("UniqueID: ");

            Main.TestDataConstructor.Projects.ForEach(p => { if (p.UniqueID == UniqueID) { U02ErrorMessages.ErrorMessageInputExists(); AddNewProject(); } });

            DateTime dateStart = U01UserInputs.InputDateTime("Start date (format dd/mm/yyyy): ");

            DateTime dateEnd = U01UserInputs.InputDateTime("End date (format dd/mm/yyyy): ");

            bool isFinished = U01UserInputs.InputBool("Is finished (1) Yes / 2) No): ");

            StringBuilder sb = new StringBuilder();

            sb.Append(id + " - " + name + " - " + UniqueID + " - " + "Start date: " + dateStart + " - " + "End date: " + dateEnd + " - " + isFinished);

            Console.WriteLine("New project: " +
                              "\n" + sb);


            if (U01UserInputs.InputBool("Accept this input (1) Yes / 2) No): "))
            {

                Main.TestDataConstructor.Projects.Add(new Project()
                {

                    id = id,
                    Name = name,
                    UniqueID = UniqueID,
                    DateStart = dateStart,
                    DateEnd = dateEnd,
                    IsFinished = isFinished


                });
            }
            ProjectsMenu();
        }


        private void DeleteProject ()
        {
            ListAllProjects();
            Main.TestDataConstructor.Projects.RemoveAt(U01UserInputs.InputInt("Select the project you wish to delete: ") - 1);

            ProjectsMenu();
        }

        private void ListFinishedProjects ()
        {
            U03GraphicElements.PrintStars();

            var i = 0;
            Main.TestDataConstructor.Projects.ForEach(p =>
              {
                  if (p.IsFinished == true)
                  {
                      Console.ForegroundColor = ConsoleColor.Cyan;
                      Console.WriteLine(++i + ") " + p);
                      Console.ResetColor();
                      U03GraphicElements.PrintMinus();
                  }

              });
        }

        private void UpdateProject ()
        {
            ListAllProjects();

            Main.ProjectsUpdate.ProjectsUpdates();

        }
                        
    }
}
