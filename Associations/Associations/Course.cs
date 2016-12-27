using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    class Course
    {
        public int Code { get; set; }
        public bool HascoursePaper { get; set; }
        public bool HasExam { get; set; }
        public bool IsSpecial { get; set; }
        public int LectureHours { get; set; }
        public int PracticeHours { get; set; }
        public int[] prerequisities;
        public string Title { get; set; }
        public Course(int code, bool hascoursepaper, bool hasexam, bool isspecial, int lecturehours, int practicehours, string title)
        {
            Code = code;
            HascoursePaper = hascoursepaper;
            HasExam = hasexam;
            IsSpecial = isspecial;
            LectureHours = lecturehours;
            PracticeHours = practicehours;
            Title = title;
            prerequisities = new int[0];
        }
        public override string ToString()
        {
            return String.Format($"{Code}.{Title}: Isspecial = {IsSpecial}, Lecturehours = {LectureHours}, Practicehours = {PracticeHours}");
        }
    }
}
