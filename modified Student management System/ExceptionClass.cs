using System;
using System.Collections.Generic;
using System.Text;

namespace modified_Student_management_System
{
   public class ExceptionClass
    {
        public class StudentDuplicationException :Exception
        {
            public override String Message
            {
                get
                {
                    return "A student with same credential exists already.";
                }
            }
        }
        public class OptionCheckException : Exception
        {
            public override String Message
            {
                get
                {
                    return "Please select a valid option from the menu.";
                }
            }
        }
        public class EmptyFieldException : Exception
        {
            public override String Message
            {
                get
                {
                    return "Field can't be left blank.";
                }
            }
        }
        public class RollNumberCheckException : Exception
        {
            public override String Message
            {
                get
                {
                    return "Roll number can be a numeric value only";
                }
            }
        }

        public class StudentNameCheckException : Exception
        {
            public override String Message
            {
                get
                {
                    return "Student's name can only contain alphabets";
                }
            }
        }
        public class StudentMarksCheckException : Exception
        {
            public override string Message
            {
                get
                {
                    return "Marks can be a number only.";
                }
            }
        }
        public class SchoolNameCheckException : Exception
        {
            public override String Message
            {
                get
                {
                    return "School name can contain only alphabets";
                }
            }
        }
    }
}
