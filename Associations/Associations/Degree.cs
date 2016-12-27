using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    class Degree
    {
        public int Code { get; set; }
        public int CreditsRequired { get; set; }
        public int SpecialCoursesRequired { get; set; }
        public string Title { get; set; }
        public Degree() { }
        public Degree(int code, int creditsrequired, int specialcoursesrequired, string title)
        {
            Code = code;
            CreditsRequired = creditsrequired;
            SpecialCoursesRequired = specialcoursesrequired;
            Title = title;
        }
        public override string ToString()
        {
            return String.Format($"{Code}.{Title}: {CreditsRequired} credit points required, {SpecialCoursesRequired} special courses require");
        }
    }
}
