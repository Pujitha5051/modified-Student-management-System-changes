using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace modified_Student_management_System
{
        public class Admin
    {
        public string OnStart()
        {
            string SchoolName = Console.ReadLine();

            // School name validation .
            try
            {
                if (String.IsNullOrEmpty(SchoolName))
                {
                    throw new ExceptionClass.EmptyFieldException();
                }
                else if (SchoolName.Any(char.IsDigit))
                {
                    throw new ExceptionClass.SchoolNameCheckException();
                }
                else if (SchoolName.Length < 4)
                {
                    Console.WriteLine("School name can't have less than 4 characters.");

                    //goto onStart method.
                     return OnStart();
                }
            }
            catch (ExceptionClass.EmptyFieldException msg)
            {
                Console.WriteLine(msg.Message);

                //goto onStart method.
                return OnStart();
            }
            catch (ExceptionClass.SchoolNameCheckException msg)
            {
                Console.WriteLine(msg.Message);

                //goto onStart method.
                return OnStart();
            }
            return SchoolName;
        }
    }
}
