using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg.Utilities
{
    internal class U04MenuTexts
    {
         
        internal static void MainMenuText()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>> Main menu <<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) Manage projects");
            Console.WriteLine("2) Manage activities");
            Console.WriteLine("3) Manage proof collection");
            Console.WriteLine("4) Manage members");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }

        internal static void ProjectMenuText()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>> Projects menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List active projects");
            Console.WriteLine("2) Add new project"); 
            Console.WriteLine("3) Update project");
            Console.WriteLine("4) Delete project");
            Console.WriteLine("5) List finished projects");
          
            Console.WriteLine("6) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }

        internal static void ActivitiecMenuText()
        {
            U03GraphicElements.PrintStars();
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>> Activities menu <<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List project activities");
            Console.WriteLine("2) Enter new activity");
            Console.WriteLine("3) Edit activity");
            Console.WriteLine("4) Delete activity");
            Console.WriteLine("5) List all activities");
            
            Console.WriteLine("6) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }


        internal static void ProofMenuText ()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>> Proofs menu <<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List proofs");
            Console.WriteLine("2) Add new proof");
            Console.WriteLine("3) Edit existing proof");
            Console.WriteLine("4) Delete proof");
            Console.WriteLine("5) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");

        }


        internal static void MembersMenuText ()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>> Members menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List all members ");
            Console.WriteLine("2) Add new member");
            Console.WriteLine("3) Edit member");
            Console.WriteLine("4) Delete member");


            Console.WriteLine("5) Return to main menu");
            Console.WriteLine("0) Exit");
            Console.WriteLine("\n");
        }

        internal static void UpdateProjectText()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine("1) Unique ID");
            Console.WriteLine("2) Name");
            Console.WriteLine("3) Date start");
            Console.WriteLine("4) Date end");
            Console.WriteLine("5) Project status");
            Console.WriteLine("6) Update all");
            Console.WriteLine("7) Return");
            Console.WriteLine("\n");
        }

        internal static void EditActivitiesMenuText ()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine("1) Name");
            Console.WriteLine("2) Description");
            Console.WriteLine("3) Date start");
            Console.WriteLine("4) Deadline");
            Console.WriteLine("5) Folder");
            Console.WriteLine("6) Status");
            Console.WriteLine("7) Date accepted");
            Console.WriteLine("8) Associeted project");
            Console.WriteLine("9) Edit all");
            Console.WriteLine("0) Return");
            Console.WriteLine("\n");
        }

        internal static void UpdateMenuText ()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine("1) Update first name");
            Console.WriteLine("2) Update last name");
            Console.WriteLine("3) Update username");
            Console.WriteLine("4) Update password");
            Console.WriteLine("5) Is team leader");
            Console.WriteLine("6) Return to members menu");
        }
    }
}
