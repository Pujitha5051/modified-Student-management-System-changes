using System;
using System.Collections.Generic;
using System.Text;

namespace modified_Student_management_System
{
   public class Student
    {
        private ProgressCard ProgressCards;
        public string StudentName { get; set; }

        public int StudentRollNumber { get; set; }

        public string StudentRollNumberString { get; set; }

        public Student()
        {
            ProgressCards = new ProgressCard();
        }

        public ProgressCard ProgressCard
        {
            get 
            {
                return ProgressCards;
            }
            set
            {
                ProgressCards = value;
            }
        }
    }
}
