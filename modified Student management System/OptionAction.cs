using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace modified_Student_management_System
{
   public class OptionAction
    {
        //function to check if a student is duplicate.
        public bool StudentDuplicationCheck(string StudentRollNumberString, School schoolObject)
        {
            try
            {
                foreach (var roll in schoolObject.Student)
                {
                    int tempRoll = Convert.ToInt32(StudentRollNumberString);

                    //if roll number entered matches with the stored roll number then flag is set to true and returned.
                    if (roll.StudentRollNumber == tempRoll)
                    {
                        throw new ExceptionClass.StudentDuplicationException();                     
                    }
                }
            }
            catch (ExceptionClass.StudentDuplicationException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return true;
            }          
            return false;
        }

        public bool AddStudentRollNumber(string StudentRollNumberString)
        {
            try
            {
                //Regex to check if a string contains digit or not.
                Regex r = new Regex("^[0-9]+$");

                // check roll number field is empty or not.
                if (String.IsNullOrEmpty(StudentRollNumberString))
                {
                    throw new ExceptionClass.EmptyFieldException();
                }

                // check roll number field contains only numbers.
                else if (!r.IsMatch(StudentRollNumberString))
                {
                    throw new ExceptionClass.RollNumberCheckException();
                }

            }
            catch (ExceptionClass.EmptyFieldException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            catch (ExceptionClass.RollNumberCheckException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            return true;
        }
        public bool AddStudentName(string StudentName)
        {
            try
            {
                //declare a regex for alphabetic pattern.
                Regex ra = new Regex("^[a-zA-Z ]+$");

                // check Student Name field is empty or not.
                if (String.IsNullOrEmpty(StudentName))
                {
                    new ExceptionClass.EmptyFieldException();
                }

                // check Student Name field has only alphabets or not.
                else if (!ra.IsMatch(StudentName))
                {
                    throw new ExceptionClass.StudentNameCheckException();
                }
                else if (StudentName.Length < 4)
                {
                    Console.WriteLine("Student's name should have atleast 4 characters .");
                    return false;
                }
            }
            catch (ExceptionClass.EmptyFieldException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            catch (ExceptionClass.StudentNameCheckException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            return true;
        }

        //function to verify roll number .
        bool ValidateRollNumber(School schoolObject, string StudentRollNumberString)
        {                       
            try
            {
                //Iterate through schoolObject and check if the roll number exist or not.
                foreach(var roll in schoolObject.Student) {
                    
                    // declare a regex for digit pattern.
                    Regex r = new Regex("^[0-9]+$");

                    int tempRoll = Convert.ToInt32(StudentRollNumberString);

                    //if roll number entered matches with the stored roll number then flag is set to true and returned.
                    if (roll.StudentRollNumber== tempRoll)
                    {
                        return true;                                              
                    }
                    else if (String.IsNullOrEmpty(StudentRollNumberString))
                    {
                        throw new ExceptionClass.EmptyFieldException();
                    }
                    //check if roll number matches the regex pattern
                    else if (!r.IsMatch(StudentRollNumberString))
                    {
                        throw new ExceptionClass.RollNumberCheckException();
                    }
                }
            }
            catch (ExceptionClass.EmptyFieldException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            catch (ExceptionClass.RollNumberCheckException msg)
            {
                Console.Clear();
                Console.WriteLine(msg.Message);
                return false;
            }
            return false;
        }                          
                                          
        int AddSubjectMarks(string subject)
        {
            int marksInt;
            try
            {
                //for all the six subjects the message will be displayed.
                Console.WriteLine($"Enter marks scored in {subject} :");

                //marks is taken from the console.
                string marks = Console.ReadLine();

                // declare a regex for digit pattern.
                Regex r = new Regex("^[0-9]+$");
                if (String.IsNullOrEmpty(marks))
                {
                    throw new ExceptionClass.EmptyFieldException();
                }
                else if (!r.IsMatch(marks))
                {
                    throw new ExceptionClass.StudentMarksCheckException();
                }
                //Integer equivalent of the marks in string.
                marksInt = Convert.ToInt32(marks);

                //check if marks range is between 0 & 100.
                if (marksInt > 100 || marksInt < 0)
                {
                    Console.WriteLine("Marks should range between 0 & 100 .");
                    return AddSubjectMarks(subject);
                }                
            }
            catch (ExceptionClass.EmptyFieldException msg)
            {
                Console.WriteLine(msg.Message);
                return AddSubjectMarks(subject);
            }
            catch (ExceptionClass.StudentMarksCheckException msg)
            {
                Console.WriteLine(msg.Message);
                return AddSubjectMarks(subject);
            }
            return marksInt;
        }                          

        //method to add marks of student subject wise for the schoool whwn user enters 2.
        public bool AddStudentMarks(School schoolObject,string StudentRollNumberString)
        {
            float subjectCount = 6.0f;

            //create progress card object.
            ProgressCard progressCardObject = new ProgressCard();
            if (ValidateRollNumber(schoolObject,StudentRollNumberString))
            {
                //Add All subjects marks.
                progressCardObject.TeluguMarks =  AddSubjectMarks("Telugu");
                progressCardObject.HindiMarks =   AddSubjectMarks("Hindi");
                progressCardObject.EnglishMarks = AddSubjectMarks("English");
                progressCardObject.MathsMarks =   AddSubjectMarks("Maths");
                progressCardObject.ScienceMarks = AddSubjectMarks("Science");
                progressCardObject.SocialMarks =  AddSubjectMarks("Social");

                //assign TotalMarks to the progressCard
                progressCardObject.TotalMarks = (progressCardObject.TeluguMarks + progressCardObject.HindiMarks + progressCardObject.EnglishMarks
                                                + progressCardObject.MathsMarks + progressCardObject.ScienceMarks + progressCardObject.SocialMarks);

                //assign percentage to the progressCard.
                progressCardObject.Percentage = (float)progressCardObject.TotalMarks/subjectCount;

                //assign the progressCardObject to the School's Student property.
                schoolObject.Student.ForEach(roll =>
                {
                    if (String.Equals(roll.StudentRollNumberString, StudentRollNumberString))
                    {
                        roll.ProgressCard = progressCardObject;                        
                    }
                });
                return true;
            }
            return false;           
        }

        //method to Show progress card of the students whwn user enters 3.
        public bool ShowProgressCard(School schoolObject,string StudentRollNumberString)
        {
            //verify roll number if validation successful then return true;.
            if (ValidateRollNumber(schoolObject, StudentRollNumberString))
            {
                return true;
            }
            return false;
        }
    }
}







