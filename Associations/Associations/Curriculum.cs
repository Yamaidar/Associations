using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    class Curriculum
    {
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public Course[] courses = new Course[0];
        public double credits = 0;
        public int specialsnumber = 0;
        public override string ToString()
        {
            string s = "";
            for (int i=0; i<courses.GetLength(0); i++)
            {
                s += "\n";
            }
            return String.Format($"Curriculum number {Code}                  created: {CreationDate}\n                                     confirmed:{ConfirmationDate}\n\n\nRequired credits:{credits}\nCourses:\n{s}");
        }
    }
}
