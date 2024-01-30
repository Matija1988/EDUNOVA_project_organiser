using PO.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Utilities
{
    internal class U01UserInputs
    {
        public static string InputString (string v)
        {
            string s;

            while (true)
            {
                Console.Write(v);
                s = Console.ReadLine();
                if (s.Trim().Length == 0)
                {
                    Console.WriteLine("!!!!WRONG INPUT!!!!");
                    continue;
                }

                return s;
            }
        }

        public static int InputInt (string v)
        {
            while (true)
            {
                Console.Write(v);

                try
                {
                    int a = int.Parse(Console.ReadLine());
                    return a;
                }
                catch
                {
                    Console.WriteLine("!!!!!!!!! WRONG INPUT !!!!!!!!!!");
                }


            }
        }

        internal static DateTime InputDateTime (string v)
        {
           return DateTime.Today;
        }

        internal static bool InputBool (string v)
        {
            if (v == null)
            {
                Console.WriteLine("Unspecified input!!! Please check the validity of your input!!!");
                InputBool(v);
                return false; 
            } else if (v == "Y" || v == "y")
            {
                return true;
            } else
            {
                return false;
            }

            
        }

        internal static O02Project ReturnAssocietedProject (O02Project pro)
        {
            return pro;
        }
    }

}
