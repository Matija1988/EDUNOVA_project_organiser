using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Utilities
{
    internal class U04MenuTexts
    {
        internal static void MainMenuText ()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n" +
                              ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   MAIN MENU   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<" +  "\n");
            Console.ResetColor();
             Console.WriteLine("1) Manage projects");
            Console.WriteLine("2) Manage members");
            Console.WriteLine("0) Exit");
        }

        internal static void ProjectMenuText ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>   PROJECTS MENU   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.ResetColor();
            Console.WriteLine("1) List active projects");
            Console.WriteLine("2) Manage project");
            Console.WriteLine("3) Add new project");
            Console.WriteLine("4) Update project");
            Console.WriteLine("5) Delete project");
            Console.WriteLine("6) List finished projects");

            Console.WriteLine("7) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }

        internal static void UpdateProjectText ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();
            Console.WriteLine("1) Unique ID");
            Console.WriteLine("2) Name");
            Console.WriteLine("3) Date start");
            Console.WriteLine("4) Date end");
            Console.WriteLine("5) Project status");
            Console.WriteLine("6) Update all");
            Console.WriteLine("0) Return");
            Console.WriteLine("\n");
        }

        internal static void ActivitiesMenuText()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>    ACTIVITIES MENU    <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.ResetColor();
            Console.WriteLine("1) List project activities");
            Console.WriteLine("2) Enter new activity");
            Console.WriteLine("3) Edit activity");
            Console.WriteLine("4) Delete activity");
            Console.WriteLine("5) List all activities");
            Console.WriteLine("6) Manage proofs of delivery");
            Console.WriteLine("7) Return to project menu");

            Console.WriteLine("8) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }

        internal static void UpdateActivitiesMenuText ()
        {
            
            U03GraphicElements.PrintStars();
           

            Console.WriteLine("1) Name");
            Console.WriteLine("2) Description");
            Console.WriteLine("3) Date start");
            Console.WriteLine("4) Deadline");
            Console.WriteLine("5) Status");
            Console.WriteLine("6) Date accepted");
            Console.WriteLine("7) Associeted project");
            Console.WriteLine("8) Delegate to");
            Console.WriteLine("9) Edit all");
            Console.WriteLine("0) Return");
            Console.WriteLine("\n");
        }


        internal static void ProofMenuText ()
        {         
            U03GraphicElements.PrintStars();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>    PROOFS MENU    <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.ResetColor();
            Console.WriteLine("1) List proofs");
            Console.WriteLine("2) Add new proof");
            Console.WriteLine("3) Edit existing proof");
            Console.WriteLine("4) Delete proof");
            Console.WriteLine("5) Return to project menu");
            Console.WriteLine("6) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");

        }
        internal static void MembersMenuText ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>   MEMBERS MENU    <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List all members ");
            Console.WriteLine("2) Add new member");
            Console.WriteLine("3) Edit member");
            Console.WriteLine("4) Delete member");



            Console.WriteLine("5) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }

        internal static void UpdateMemberMenuText ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            U03GraphicElements.PrintStars();
            Console.ResetColor();

            Console.WriteLine("1) Update first name");
            Console.WriteLine("2) Update last name");
            Console.WriteLine("3) Update username");
            Console.WriteLine("4) Update password");
            Console.WriteLine("5) Is team leader");
            Console.WriteLine("6) Update all");
            Console.WriteLine("0) Return to members menu");
        }
    }
}
