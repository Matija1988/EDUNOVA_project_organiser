﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.Utilities
{
    internal class U02ErrorMessages
    {
        internal static void ErrorMessageInput()
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n" +
                              "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!   WRONG INPUT    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                              "\n");
            Console.ResetColor();
        }

        internal static void ErrorMessageInputExists()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" +
                              "!!!!!!!!!!!!!!!!!!!!!!!!    INPUT ALREADY EXISTS     !!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                              "\n");
            Console.ResetColor();

        }

        internal static void ErrorMessageCannotDeleteYourself()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" +
                              "!!!!!!!!!!!!!!!!!!!!!!!    USER CANNOT DELETE HIMSELF    !!!!!!!!!!!!!!!!!!!!!!!" +
                              "\n");
            Console.ResetColor();

        }

        internal static void TheSelectedIndexIsNotAssociatedToObject()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" +
                              "!!!!!!!!!!!!!    THE SELECTED INDEX IS NOT ASSOCIATED TO OBJECT    !!!!!!!!!!!!!" +
                              "\n");
            Console.ResetColor();
        }

        internal static string ErrorMessageUnexpectedBehaviourInAutoIncrementID()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n" +
                      "!!!!!!!! UNEXPECTED BEHAVIOUR IN AUTOINCREMENT ID !!!!!!!!" +
                      "\n");
            return sb.ToString();
        }

        internal static void LackOfAuthority()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" +
                              "!!!!!!!!!!!!    USER IS NOT AUTHORISED TO PERFORM THIS ACTION    !!!!!!!!!!" +
                              "\n");
            Console.ResetColor();

        }

        internal static string YourInputContainsUnwantedCharacters()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n" +
                      "!!!!!!!! YOUR INPUT CONTAINS UNWANTED CHARACTERS !!!!!!!!!" +
                      "\n" +
                      "!!!!!!!!!!!!! CHARS: [ AND { ARE NOT ALLOWED !!!!!!!!!!!!!" +
                      "\n");
            return sb.ToString();
        }

        internal static void ErrorStartDateIsLatterThenEndDate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" +
                              "!!!!!!!!!!!!!!!!!!!    START / END DATE MISMATCH     !!!!!!!!!!!!!!!!!!!!!!" +
                              "\n");
            Console.ResetColor();
        }
    }
}
