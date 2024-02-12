using ProjectOrg.ObjectClasses;
using ProjectOrg.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg
{
    internal class ProjectsUpdate
    {
        public List<Project> Project {  get; }
        private Main Main { get; }
        public ProjectsUpdate(Main Main) : this() 
        { 
         this.Main = Main;
        }

        public ProjectsUpdate()
        {

        }

        internal void ProjectsUpdates()
        {
            try
            {

                int index = U01UserInputs.InputInt("Choose the project you wish to upadate: ") - 1;

                var pro = Main.TestDataConstructor.Projects[index];

                U04MenuTexts.UpdateProjectText();

                switch (U01UserInputs.InputInt("\n" + "Choose which attribute you wish to update: "))
                {

                    case 1:
                        string uniqueId = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                     "\n" + "Previous unique ID: " + pro.UniqueID +
                                                                      "\n" + "New unique ID: ");

                        Main.TestDataConstructor.Projects.ForEach(p =>
                        {

                            if (p.UniqueID == uniqueId)
                            {
                                Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
                                ProjectsUpdates();
                            }


                        });

                        bool validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                                       "\n" +
                                                                        "\n" + "Previous entry: " + pro.UniqueID +
                                                                         "\n" + "New entry: " + uniqueId +
                                                                          "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            pro.UniqueID = uniqueId;
                        }
                        break;

                    case 2:
                        string name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                                 "\n" + "Previous project name: " + pro.Name +
                                                                  "\n" + "New project name: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous project name: " + pro.Name +
                                                                "\n" + "New project name: " + name +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");

                        if (validation)
                        {
                            pro.Name = name;
                        }
                        break;

                    case 3:
                        DateTime dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                          "\n" + "Previous input: " + pro.DateStart +
                                                                           "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + pro.DateStart +
                                                                "\n" + "New input: " + dateStart +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            pro.DateStart = dateStart;
                        }
                        break;

                    case 4:
                        DateTime dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                        "\n" + "Previous input: " + pro.DateEnd +
                                                                         "\n" + "New input: ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous input: " + pro.DateEnd +
                                                                "\n" + "New input: " + dateEnd +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            pro.DateEnd = dateEnd;
                        }
                        break;

                    case 5:
                        bool isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                                   "\n" + "Project finished: " + pro.IsFinished +
                                                                    "\n" + "New status: 1) Finished / 2) Ongoing | ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information " +
                                                              "\n" +
                                                               "\n" + "Previous is finished: " + pro.IsFinished +
                                                                "\n" + "New is finished: " + isFinished +
                                                                 "\n" + "Accept change: 1) YES / 2) NO | ");
                        if (validation)
                        {
                            pro.IsFinished = isFinished;
                        }
                        break;

                    case 6:
                        uniqueId = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                              "\n" + "Previous unique ID: " + pro.UniqueID +
                                                               "\n" + "New unique ID: ");

                        name = U01UserInputs.InputString("\n" + "_______________________________________" +
                                                          "\n" + "Previous project name: " + pro.Name +
                                                           "\n" + "Name project name: ");

                        dateStart = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                                 "\n" + "Previous input: " + pro.DateStart +
                                                                  "\n" + "New input: ");

                        dateEnd = U01UserInputs.InputDateTime("\n" + "_______________________________________" +
                                                               "\n" + "Previous input: " + pro.DateEnd +
                                                                "\n" + "New input: ");

                        isFinished = U01UserInputs.InputBool("\n" + "_______________________________________" +
                                                              "\n" + "Previous is finished: " + pro.IsFinished +
                                                               "\n" + "New status: 1) Finished / 2) Ongoing | ");

                        validation = U01UserInputs.InputBool("\n" + "Change project information? " +
                                                              "\n" +
                                                               "\n" + "Previus input: " + pro +
                                                                "\n" + "New unique ID: " + uniqueId + " || " + "New project name: " + name + " || " + "New start date: " + dateStart +
                                                                       " || " + "New deadline: " + dateEnd + " || " + "Is finished: " + isFinished +
                                                                 "\n" +
                                                                  "\n" + "Accept changes: 1) YES / 2) NO | ");

                        if (validation)
                        {

                            pro.UniqueID = uniqueId;
                            pro.Name = name;
                            pro.DateStart = dateStart;
                            pro.DateEnd = dateEnd;
                            pro.IsFinished = isFinished;
                        }
                        break;

                    case 7:
                        Main.ProjectWorkspace.ProjectsMenu();
                        break;
                    default:
                        Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                        break;

                }

            }
            catch
            {

                Console.WriteLine(U02ErrorMessages.ErrorMessageInput());

                ProjectsUpdates();

            }

            Main.ProjectWorkspace.ProjectsMenu();

        }
    }


}
