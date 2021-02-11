using System;
using System.Collections.Generic;
using System.Text;

namespace modified_Student_management_System
{
    public class School
    {
        private List<Student> Students;

        public string SchoolName { get; set; }

        public School()
        {
           Students = new List<Student>();
        }

        public List<Student> Student {
            get
            {
                return Students;
            }
            set
            {
                Student = value;
            }
        }
        
    }
}

        

    

