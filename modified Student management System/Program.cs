using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace modified_Student_management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter School Name :");

            //create an object of Admin class
            Admin adminObject = new Admin();

            //trigger onStart method of Admin class and return a school name.
            string schoolName = adminObject.OnStart();

            //Create School object and pass school name to the schoolObject.
            School schoolObject = new School();

            //set the schoolName to the SchoolName property of School class.
            schoolObject.SchoolName = schoolName;

            //clear the console screen.
            Console.Clear();

            //Menu function to display option Menu.
            void Menu(string SchoolName)
            {
                Console.WriteLine($"\nWelcome to {SchoolName} Student information management\n");
                Console.WriteLine("1. Add Student.");
                Console.WriteLine("2. Add marks for student.");
                Console.WriteLine("3. Show student's progress card.\n");
                Console.WriteLine("Please provide valid input from menu options :");

                //Option from the option menu is taken in optionString .
                string optionString = Console.ReadLine();

                //trigger menu function of the OptionMenu class by creating the optionMenuObject ,and return the option value.          
                OptionMenu optionMenuObject = new OptionMenu();

                //an option integer value is thrown by the OptionValidate function.
                if (optionMenuObject.OptionValidate(optionString))
                {
                    //convert the string to its int equivalent.
                    int option = Convert.ToInt32(optionString);

                    // If option 1 is selected from the menu following code will run.
                    if (option == 1)
                    {
                        //create an object of Student class.
                        Student studentObject = new Student();

                        //create an object of OptionAction class to perform "Add student" opeartion by triggering AddStudent method.
                        OptionAction optionActionObject = new OptionAction();

                        //input student's roll number.
                        Console.WriteLine("Enter Student's Roll Number ");
                        string StudentRollNumberString = Console.ReadLine();

                        //check for student duplication.
                        if (!optionActionObject.StudentDuplicationCheck(StudentRollNumberString, schoolObject))
                        {
                            //roll number addition
                            if (optionActionObject.AddStudentRollNumber(StudentRollNumberString))
                            {
                                //input student's name.
                                Console.WriteLine("Enter Student's Name");
                                string StudentName = Console.ReadLine();
                                if (optionActionObject.AddStudentName(StudentName))
                                {
                                    //if all cases pass succesfully add the value to the studentObject.
                                    studentObject.StudentRollNumberString = StudentRollNumberString;
                                    studentObject.StudentRollNumber = Convert.ToInt32(StudentRollNumberString);
                                    studentObject.StudentName = StudentName;

                                    //Add the student object to the Student list property.
                                    schoolObject.Student.Add(studentObject);
                                    Console.Clear();
                                }
                            }
                        }
                        //display the Menu again
                        Menu(SchoolName);
                    }

                    // If option 2 is selected from the menu following code will run.
                    else if (option == 2)
                    {
                        //verify roll number.
                        Console.WriteLine("Enter Student's roll number :");

                        //making a rollNumber variable to perform operation for that student.
                        string StudentRollNumberString; 
                        StudentRollNumberString = Console.ReadLine();

                        //create an optionActionObject to call AddStudentMarks method.
                        OptionAction optionActionObject = new OptionAction();

                        if (optionActionObject.AddStudentMarks(schoolObject, StudentRollNumberString))
                        {
                            Console.Clear();
                            //display the Menu again
                            Menu(SchoolName);
                        }
                        else
                        {
                            Console.WriteLine("No such student roll number exists");
                            Menu(SchoolName);
                        }
                    }

                    // If option 3 is selected from the menu following code will run.
                    else if (option == 3)
                    {

                        //create an OptionAction object to display progress card.
                        OptionAction optionActionObject = new OptionAction();

                        //verify roll number.
                        Console.WriteLine("Enter Student's roll number :");

                        //making a StudentRollNumberString variable to perform operation for that student.
                        string StudentRollNumberString;
                        StudentRollNumberString = Console.ReadLine();

                        if (optionActionObject.ShowProgressCard(schoolObject, StudentRollNumberString))
                        {
                            schoolObject.Student.ForEach(roll =>
                            {
                                int tempRoll = Convert.ToInt32(StudentRollNumberString);

                                //if roll number entered matches with the stored roll number then flag is set to true and returned.
                                if (roll.StudentRollNumber == tempRoll)
                                {
                                    Console.WriteLine("Student's Roll Number : " + roll.StudentRollNumber);
                                    Console.WriteLine("Student's Name : " + roll.StudentName + "\n");
                                    Console.WriteLine("Student's Marks");

                                //display telugu marks.
                                Console.WriteLine("Telugu :" + roll.ProgressCard.TeluguMarks);

                                //display telugu marks.
                                Console.WriteLine("Hindi :" + roll.ProgressCard.HindiMarks);

                                //display english marks.
                                Console.WriteLine("English :" + roll.ProgressCard.EnglishMarks);

                                //display maths marks.
                                Console.WriteLine("Maths :" + roll.ProgressCard.MathsMarks);

                                //display Science marks.
                                Console.WriteLine("Science :" + roll.ProgressCard.ScienceMarks);

                                //display Social marks.
                                Console.WriteLine("Social :" + roll.ProgressCard.SocialMarks + "\n");

                                //display total marks.

                                Console.WriteLine("Total Marks :" + roll.ProgressCard.TotalMarks);

                                //display Percentage upto 2 decimal points.
                                Console.WriteLine("Percentage :" + Math.Round(roll.ProgressCard.Percentage,2) + " %");
                                }
                            });
                            Menu(SchoolName);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("No such student roll number exists");

                            //Display the Menu again
                            Menu(SchoolName);
                        }
                    }
                }
                //Display the option Menu
                Menu(schoolName);
            }
            //Display the option Menu
            Menu(schoolName);
        }   
    }
 }
