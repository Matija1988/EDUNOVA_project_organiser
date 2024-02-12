using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg.Utilities
{
    internal class U03GraphicElements
    {
        internal static void PrintStars ()
        {
            Console.WriteLine("\n");

            for (int i = 0; i < 60; i++)

            {

                Console.Write("*");

            }

            Console.WriteLine("\n");
        }

        internal static void PrintMinus()
        {
           
            for (int i = 0; i < 60; i++)

            {

                Console.Write("-");

            }
            Console.WriteLine("\n");
        }

    }
}
