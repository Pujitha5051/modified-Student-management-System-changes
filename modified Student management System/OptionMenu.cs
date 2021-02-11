using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace modified_Student_management_System
{
    class OptionMenu
    {
        public bool OptionValidate(string optionString)
        {
            //Regex to check if a string contains digit or not.
            Regex r = new Regex("^[0-9]+$");
            try
            {
                //check if the optionString is empty or not,if empty throw EmptyFieldException.
                if (String.IsNullOrEmpty(optionString))
                {
                    throw new ExceptionClass.EmptyFieldException();
                }

                //check if the optionString has only numbers or not,if not show Invalid option type.
                if (!r.IsMatch(optionString))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid option type");
                    return false;
                }
            }
            catch (ExceptionClass.EmptyFieldException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false; ;
            }

            //optionString is converted to its int equivalent.
            int option = Convert.ToInt32(optionString);

            try
            {
                if (option != 1 && option != 2 && option != 3)
                {
                    throw new ExceptionClass.OptionCheckException();
                }
            }
            catch (ExceptionClass.OptionCheckException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            return true; ;
        }
    }
}
