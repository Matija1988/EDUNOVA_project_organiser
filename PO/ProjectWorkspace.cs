﻿using PO.ObjectClasses;
using PO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO
{
    internal class ProjectWorkspace
    {

        public List<O02Project> Projects;

        private Main Main { get; }

        private ActivitiesWorkspace ActivitiesWorkspace { get; }

    

        public ProjectWorkspace (Main main) : this()
        {

            this.Main = main;
            this.ActivitiesWorkspace = main.ActivitiesWorkspace;

        }


        public ProjectWorkspace ()
        {
            Projects = new List<O02Project>();

            
                TestData();
            

        }

        private void TestData ()
        {
            Projects.Add(new O02Project()
            {
                id = 1,
                UniqueID = "K.K. 2711",
                Name = "Urbana aglomeracija zamisljeni grad",
                DateStart = DateTime.Parse("07.01.2021."),
                DateEnd = DateTime.Parse("12.05.2024."),
                IsFinished = false


            });

            Projects.Add(new O02Project()
            {
                id = 2,
                UniqueID = "JUPP 412",
                Name = "Izrada interaktivne slikovnice JU PP Biokovo",
                DateStart = DateTime.Parse("10.04.2021."),
                DateEnd = DateTime.Parse("10.05.2022."),
                IsFinished = false

            });

            Projects.Add(new O02Project()
            {
                id = 3,
                UniqueID = "K.K 712",
                Name = "Izrada studijsko-projektne dokumentacije",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now,
                IsFinished = true

            });
        }
        public void ProjectsMenu ()
        {

            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>> Projects menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List active projects");
            Console.WriteLine("2) Enter project");
            Console.WriteLine("3) Add new project");
            Console.WriteLine("4) Delete project");
            Console.WriteLine("5) List finished projects");
            Console.WriteLine("6) Enter finished projects");
            Console.WriteLine("7) Return to main menu");
            Console.WriteLine("8) Exit");

            ProjectMenuSwitch();
        }

        public void ProjectMenuSwitch ()
        {

            switch (U01UserInputs.InputInt("\n" + "Project menu input: "))
            {
                case 1:
                    Console.WriteLine("\n" + "List active projects");

                    U03GraphicElements.PrintStars();

                    ListActiveProjects();
                    ProjectsMenu();

                    break;
                case 2:
                    Console.WriteLine("\n" + "Enter project:");

                    U03GraphicElements.PrintStars();

                    EnterProjectsMenu();
                    break;
                case 3:
                    Console.WriteLine("Add new project");
                    AddNewProject();
                    break;
                case 4:
                    Console.WriteLine("Delete project");
                    DeleteProject();
                    break;
                case 5:
                    Console.WriteLine("\n" + "List finished projects");

                    U03GraphicElements.PrintStars();

                    ListFinishedProjects();
                    ProjectsMenu();
                    break;
                case 6:
                    Console.WriteLine("Enter finished projects");
                    EnterFinishedProjectsMenu();
                    break;
                case 7:
                    Console.WriteLine("Returning to main menu");

                    Main.MainMenu();
                    break;
                case 8:
                    Console.WriteLine("Exit");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                   
                    break;

            }

        }
        private void ListActiveProjects ()
        {
            var i = 0;
            Projects.ForEach(p => {
                if (p.IsFinished == false)
                {
                    Console.WriteLine(++i + ") " + p);

                }
            });


        }

        private void EnterProjectsMenu ()
        {
            ListActiveProjects();

            U03GraphicElements.PrintStars();

            try
            {
                var SelectedProject = Projects[U01UserInputs.InputInt("ID of the project you wish to enter: ") - 1];


                Console.WriteLine("\n" + "Entering selected project" + "\n");


                SelectedProjectMenu(SelectedProject);


            }
            catch
            {

                Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
               
                EnterProjectsMenu();
            }

        }

        private void ListAllProjects ()
        {
            var i = 0;
            Projects.ForEach(p => { Console.WriteLine(++i + ") " + p); });


        }


        private void AddNewProject ()
        {
            ListAllProjects();

            int id = U01UserInputs.InputInt("Input project id: ");

            Projects.ForEach(p => {

                if (p.id == id)
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
                    AddNewProject();
                }


            });

            string name = U01UserInputs.InputString("Project name: ");


            string UniqueID = U01UserInputs.InputString("UniqueID: ");

            Projects.ForEach(p => { if (p.UniqueID == UniqueID) { Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists()); AddNewProject(); } });

            DateTime dateStart = U01UserInputs.InputDateTime("Start date (format dd/mm/yyyy): ");

            DateTime dateEnd = U01UserInputs.InputDateTime("End date (format dd/mm/yyyy): ");

            bool isFinished = U01UserInputs.InputBool("Is finished (1) Yes / 2) No): ");

            StringBuilder sb = new StringBuilder();

            sb.Append(id + " - " + name + " - " + UniqueID + " - " + "Start date: " + dateStart + " - " + "End date: " + dateEnd + " - " + isFinished);

            Console.WriteLine("New project: " +
                              "\n" + sb);


            if (U01UserInputs.InputBool("Accept this input (1) Yes / 2) No): "))
            {

                Projects.Add(new O02Project()
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

            int indexID = U01UserInputs.InputInt("Select the project ID you wish to delete: ");

            if(Main.LoggedInUser.IsTeamLeader == true) { 

            Projects.ForEach(p =>
            {
                if (p.id == indexID)
                {
                    Projects.Remove(p);
                    ProjectsMenu();
                    
                }
            }) ;
            } else
            {
                Console.WriteLine(U02ErrorMessages.ErrorNotAuthorisedForAction());
                ProjectsMenu();
            }
           

            
            ProjectsMenu();
          
        }

        private void ListFinishedProjects ()
        {
            var i = 0;
            Projects.ForEach(p =>
            {
                if (p.IsFinished == true)
                {
                    Console.WriteLine(++i + ") " + p);
                }

            });
        }

        private void EnterFinishedProjectsMenu ()
        {
            ListFinishedProjects();

            Console.WriteLine("************************************************************");

            try
            {
                var pro = Projects[U01UserInputs.InputInt("ID of the project you wish to enter: ") - 1];
                if (pro.IsFinished == false) {
                    Console.WriteLine("\n" + "Entering selected project" + "\n");

                    SelectedProjectMenu(pro);
                }
            }
            catch
            {

                Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                Console.WriteLine("!!!!!!!!! CHECK THE VALIDITY OF YOUR INPUT !!!!!!!!!!!");

            }



        }
        public void SelectedProjectMenu (O02Project SelectedProject)
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine("Working on " + SelectedProject.Name + ", " + SelectedProject.UniqueID + " project." + "Try not to commit suicide before the final report has been accepted and signed!!!");
            Console.WriteLine("Have a good day!!!");

            Console.WriteLine("\n" +
                              "1) Manage activities");
            Console.WriteLine("2) Manage basic project information");
            Console.WriteLine("3) Return to projects menu");
            Console.WriteLine("4) Return to main menu");
            Console.WriteLine("5) Exit");

            SelectedProjectMenuSwitch(SelectedProject);
        }

        public void SelectedProjectMenuSwitch (O02Project SelectedProject)
        {
            switch (U01UserInputs.InputInt("Input: "))
            {
                case 1:
                    Console.WriteLine("Managing " + SelectedProject.Name + " activities");
                   
                    ActivitiesWorkspace.ActivitiesMenu(SelectedProject);

                    break;
                case 2:
                    Console.WriteLine("\n" + "Updating " + SelectedProject.Name + " information" + "\n");
                    U03GraphicElements.PrintStars();
                    UpdateProject(SelectedProject);
                    break;
                case 3:
                    Console.WriteLine("Returning to projects menu");
                    ProjectsMenu();
                    ProjectMenuSwitch();
                    break;
                case 4:
                    Console.WriteLine("Returning to main menu");
                    Main.MainMenu();

                    break;
                case 5:
                    Console.WriteLine("Where are you going!!! There is more work to be done!!!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                   
                    break;

            }

        }

        private void UpdateProject (O02Project SelectedProject)
        {
            Console.WriteLine("1) Unique ID");
            Console.WriteLine("2) Name");
            Console.WriteLine("3) Date start");
            Console.WriteLine("4) Date end");
            Console.WriteLine("5) Project status");
            Console.WriteLine("6) Update all");
            Console.WriteLine("7) Return");


            try
            {            



                switch (U01UserInputs.InputInt("\n" + "Chose which attribute you wish to update: "))
                {

                    case 1:
                        string uniqueId = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                     "\n" + "Previous unique ID: " + SelectedProject.UniqueID +
                                                                      "\n" + "New unique ID: ");

                        Projects.ForEach(p => {

                            if (p.UniqueID == uniqueId)
                            {
                                Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
                                UpdateProject(SelectedProject);
                            }


                        });

                        bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                                       "\n" +
                                                                        "\n" + "Previous entry: " + SelectedProject.UniqueID +
                                                                         "\n" + "New entry: " + uniqueId +
                                                                          "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            SelectedProject.UniqueID = uniqueId;
                        }
                        break;

                    case 2:
                        string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                 "\n" + "Previous project name: " + SelectedProject.Name +
                                                                  "\n" + "New project name: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous project name: " + SelectedProject.Name +
                                                                "\n" + "New project name: " + name +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            SelectedProject.Name = name;
                        }
                        break;

                    case 3:
                        DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                          "\n" + "Previous input: " + SelectedProject.DateStart +
                                                                           "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + SelectedProject.DateStart +
                                                                "\n" + "New input: " + dateStart +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            SelectedProject.DateStart = dateStart;
                        }
                        break;

                    case 4:
                        DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                        "\n" + "Previous input: " + SelectedProject.DateEnd +
                                                                         "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + SelectedProject.DateEnd +
                                                                "\n" + "New input: " + dateEnd +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            SelectedProject.DateEnd = dateEnd;
                        }
                        break;

                    case 5:
                        bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                                   "\n" + "Project finished: " + SelectedProject.IsFinished +
                                                                    "\n" + "New status: 1) Finished / 2) Ongoing | ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous is finished: " + SelectedProject.IsFinished +
                                                                "\n" + "New is finished: " + isFinished +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            SelectedProject.IsFinished = isFinished;
                        }
                        break;

                    case 6:
                        uniqueId = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                              "\n" + "Previous unique ID: " + SelectedProject.UniqueID +
                                                               "\n" + "New unique ID: ");

                        name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                          "\n" + "Previous project name: " + SelectedProject.Name +
                                                           "\n" + "Name project name: ");

                        dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                 "\n" + "Previous input: " + SelectedProject.DateStart +
                                                                  "\n" + "New input: ");

                        dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                               "\n" + "Previous input: " + SelectedProject.DateEnd +
                                                                "\n" + "New input: ");

                        isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                              "\n" + "Previous is finished: " + SelectedProject.IsFinished +
                                                               "\n" + "New status: 1) Finished / 2) Ongoing | ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information? " +
                                                              "\n" +
                                                               "\n" + "Previus input: " + SelectedProject +
                                                                "\n" + "New unique ID: " + uniqueId + " || " + "New project name: " + name + " || " + "New start date: " + dateStart +
                                                                       " || " + "New deadline: " + dateEnd + " || " + "Is finished: " + isFinished +
                                                                 "\n" +
                                                                  "\n" + "Accept changes: 1) YES / 2) NO | ");

                        if (validation)
                        {

                            SelectedProject.UniqueID = uniqueId;
                            SelectedProject.Name = name;
                            SelectedProject.DateStart = dateStart;
                            SelectedProject.DateEnd = dateEnd;
                            SelectedProject.IsFinished = isFinished;
                        }
                        break;

                    case 7:
                        EnterFinishedProjectsMenu();
                        break;
                    default:
                        Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                        break;

                }

            }
            catch
            {

                Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
               
                UpdateProject(SelectedProject);

            }

            SelectedProjectMenu(SelectedProject);
        }


      
    }
}
