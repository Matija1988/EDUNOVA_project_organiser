using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Utilities
{
    internal class U03GraphicElements
    {
        internal static void PrintStars ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < 80; i++)

            {

                Console.Write("*");

            }
            Console.ResetColor();
            Console.WriteLine("");
        }

        internal static void PrintMinus ()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < 80; i++)

            {

                Console.Write("-");

            }
            Console.ResetColor();
            Console.WriteLine("");
        }

        internal static void PrintIntroGraphics ()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@" _____           _           _      ____                        _               ");
            Console.WriteLine(@"|  __ \         (_)         | |    / __ \                      (_)              ");
            Console.WriteLine(@"| |__) | __ ___  _  ___  ___| |_  | |  | |_ __ __ _  __ _ _ __  _ ___  ___ _ __ ");
            Console.WriteLine(@"|  ___/ '__/ _ \| |/ _ \/ __| __| | |  | | '__/ _` |/ _` | '_ \| / __|/ _ \ '__|");
            Console.WriteLine(@"| |   | | | (_) | |  __/ (__| |_  | |__| | | | (_| | (_| | | | | \__ \  __/ |   ");
            Console.WriteLine(@"|_|   |_|  \___/| |\___|\___|\__|  \____/|_|  \__, |\__,_|_| |_|_|___/\___|_|   ");
            Console.WriteLine(@"               _/ |                            __/ |                            ");
            Console.WriteLine(@"              |__/                            |___/                             ");
            Console.WriteLine("                                                                                ");
            Console.ResetColor();
        }


        internal static ConsoleColor RandomColorGenerator ()
        {
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            return colors[new Random().Next(1, colors.Length)];

        }
    }
}
