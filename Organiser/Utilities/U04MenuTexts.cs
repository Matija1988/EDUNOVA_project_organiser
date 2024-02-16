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
            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>>>> Main menu <<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
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
            Console.WriteLine("2) Add new project");
            Console.WriteLine("3) Update project");
            Console.WriteLine("4) Delete project");
            Console.WriteLine("5) List finished projects");

            Console.WriteLine("6) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }
    }
}
