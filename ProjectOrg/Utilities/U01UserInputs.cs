using ProjectOrg.ObjectClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrg.Utilities
{
    internal class U01UserInputs
    {
        public static bool dev;
        public static string InputString (string v)
        {
            string s;

            while (true)
            {
                Console.Write(v);
                s = Console.ReadLine();
                if (s.Trim().Length == 0)
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());

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

                    if (a == 0) { a++; } // This prevents entering 0 as a value when this method is called. Blokira unosenje nule kao vrijednosti u .npr Sifre.
                    // Ovo sluzi ako netko u odabiru indexa liste ne odabere 0 / - 1 i dobije array index out of bounds exception

                    if (a <= -1)
                    {
                        Console.WriteLine("\n" + "!!!!!!!!!! INCORRECT INPUT - USE POSITIVE NUMBERS !!!!!!!!!!" + "\n");
                        continue;

                    }
                    if (a > 0) return a;
                }
                catch
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                }

            }
        }

        public static int InputIntZeroAllowed (string v)
        {
            while (true)
            {
                Console.Write(v);

                try
                {
                    int a = int.Parse(Console.ReadLine());
                                    

                    if (a <= -1)
                    {
                        Console.WriteLine("\n" + "!!!!!!!!!! INCORRECT INPUT - USE POSITIVE NUMBERS !!!!!!!!!!" + "\n");
                        continue;

                    }
                    if (a >= 0) return a;
                }
                catch
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                }

            }
        }
        // napomena DateTime ovisi o postavkama OS-a
        internal static DateTime InputDateTime (string v)
        {

            while (true)
            {
                try
                {
                    Console.Write(v);
                    return DateTime.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                }
            }
        }

        internal static bool InputBool (string v)
        {
            while (true)
            {
                Console.Write(v);

                try
                {
                    int a = int.Parse(Console.ReadLine());

                    switch (a)
                    {
                        case 1:
                            return true;

                        case 2:
                            return false;

                        default:
                            Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                            break;
                    }

                }
                catch
                {
                    Console.WriteLine(U02ErrorMessages.ErrorMessageInput());
                }

            }

        }

        // Celiceva metoda 
        public static int CheckID<T> (List<T> entity, Func<T, int> catchID)
        {
            int entry;

            while (true)
            {
                entry = InputInt("Enter id: ");

                if (!entity.Any(entity => catchID(entity) == entry))
                {
                    return entry;
                }

                Console.WriteLine(U02ErrorMessages.ErrorMessageInputExists());
            }

        }
        
        public static int AutoIncrementID<T> (List<T> myList)
                    
        {           
            int arraySize = myList.Count;
            int newArraySize = arraySize + 1;
                       
            return newArraySize; 
        }
           
        public static Project ReturnAssocietedProject (Project pro)
        {
            return pro;
        }
    }
}
