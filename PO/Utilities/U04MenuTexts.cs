using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Utilities
{
    internal class U04MenuTexts
    {

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


    }
}
