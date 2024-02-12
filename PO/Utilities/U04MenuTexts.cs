using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Utilities
{
    internal class U04MenuTexts
    {

        internal static void MainMenuText()
        {
            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>>>> Main menu <<<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) Manage projects");
            Console.WriteLine("2) Manage activities");
            Console.WriteLine("3) Manage proof collection");
            Console.WriteLine("4) Manage members");
            Console.WriteLine("5) Exit");
        }

        internal static void ProofMenuText()
        {
            U03GraphicElements.PrintStars();

            Console.WriteLine("\n" +
                              ">>>>>>>>>>>>>>>>>>>>>> Proofs menu <<<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List proofs");
            Console.WriteLine("2) Add new proof");
            Console.WriteLine("3) Edit existing proof");
            Console.WriteLine("4) Delete proof");
            Console.WriteLine("5) Return to previous menu");
            Console.WriteLine("6) Return to main menu");
            Console.WriteLine("0) Exit");

        }


        internal static void MembersMenuText()
        {
            Console.WriteLine("\n" +
               ">>>>>>>>>>>>>>>>>>>>> Members menu <<<<<<<<<<<<<<<<<<<<<<<<" + "\n");
            Console.WriteLine("1) List all members ");
            Console.WriteLine("2) Add new member");
            Console.WriteLine("3) Edit member");
            Console.WriteLine("4) Delete member");


            Console.WriteLine("5) Return to main menu");
            Console.WriteLine("0) Exit");
        }

        internal static void UpdateMemberMenu()
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
