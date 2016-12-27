using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 40);
            Degree[] degrees = new Degree[3];

            degrees[0] = new Degree(1, 15, 0, "Noob");
            degrees[1] = new Degree(2, 30, 2, "Medium");
            degrees[2] = new Degree(3, 50, 5, "Master");


            Course[] courses = new Course[17];

            courses[0] = new Course(01, true, true, false, 100, 80, "Algebra");

            courses[1] = new Course(02, true, true, false, 80, 70, "Geometry");

            courses[2] = new Course(03, true, true, false, 90, 60, "Mathematical analysis");

            courses[3] = new Course(04, true, true, false, 80, 60, "Discrete mathematics");

            courses[4] = new Course(05, true, true, false, 60, 120, "Information and Communications technology");

            courses[5] = new Course(06, true, true, true, 100, 80, "Physics");

            courses[6] = new Course(07, false, false, false, 10, 90, "Physical culture");

            courses[7] = new Course(08, false, true, false, 40, 30, "Foreign language");

            courses[8] = new Course(09, false, true, true, 20, 10, "Probability theory");

            courses[9] = new Course(10, false, true, true, 60, 40, "Logic and algorithms theory");
            Array.Resize(ref courses[9].prerequisities, 2);
            courses[9].prerequisities[0] = 4;
            courses[9].prerequisities[1] = 9;

            courses[10] = new Course(11, false, true, true, 40, 20, "Theory of graphs");
            Array.Resize(ref courses[10].prerequisities, 1);
            courses[10].prerequisities[0] = 4;

            courses[11] = new Course(12, false, true, true, 40, 30, "Theory of information-logical systems");
            Array.Resize(ref courses[11].prerequisities, 2);
            courses[11].prerequisities[0] = 4;
            courses[11].prerequisities[1] = 5;

            courses[12] = new Course(13, true, true, true, 60, 60, "Mathematical modeling");
            Array.Resize(ref courses[12].prerequisities, 2);
            courses[12].prerequisities[0] = 2;
            courses[12].prerequisities[1] = 5;

            courses[13] = new Course(14, false, true, true, 50, 30, "Physical problems of wrought figure's mechanics");
            Array.Resize(ref courses[13].prerequisities, 2);
            courses[13].prerequisities[0] = 2;
            courses[13].prerequisities[1] = 6;

            courses[14] = new Course(15, false, true, true, 50, 30, "Differential equations");
            Array.Resize(ref courses[14].prerequisities, 2);
            courses[14].prerequisities[0] = 1;
            courses[14].prerequisities[1] = 3;

            courses[15] = new Course(16, true, true, true, 40, 30, "Theory of control");
            Array.Resize(ref courses[15].prerequisities, 1);
            courses[15].prerequisities[0] = 3;

            courses[16] = new Course(17, true, true, true, 20, 20, "Theory of games and operations research");
            Array.Resize(ref courses[16].prerequisities, 1);
            courses[16].prerequisities[0] = 16;

            Console.WriteLine("Courses:\n");
            foreach (Course course in courses)
            {
                Console.WriteLine(course);
            }
            Console.WriteLine("\n");
            Console.WriteLine("Degrees:\n");
            foreach (Degree degree1 in degrees)
            {
                Console.WriteLine(degree1);
            }
            Console.WriteLine();

            Student student = new Student();
            Curriculum curriculum = new Curriculum();

            Console.WriteLine("Введите номер заявления");
            student.FullName = Console.ReadLine();
            Console.WriteLine("Введите ФИО студента");
            student.FullName = Console.ReadLine();
            Console.WriteLine("Введите дату рождения студента");
            student.BirthDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите дату заполнения заявления");
            curriculum.CreationDate = Convert.ToDateTime(Console.ReadLine());
            curriculum.ConfirmationDate = DateTime.Now;

            Degree degree = new Degree();
            Console.WriteLine("Введите желаемую степень");
            string s = Console.ReadLine();
            if (s == "1")
            {
                degree = degrees[0];
            }
            if (s == "2")
            {
                degree = degrees[1];
            }
            if (s == "3")
            {
                degree = degrees[2];
            }
            int i = 0;
            int j = 0;
            do
            {
                Array.Resize(ref curriculum.courses, curriculum.courses.GetLength(0) + 1);
                while (courses[j].IsSpecial) j++;
                curriculum.courses[curriculum.courses.GetLength(0)-i-1] = courses[j];
                curriculum.credits += (curriculum.courses[curriculum.courses.GetLength(0) - i - 1].LectureHours + curriculum.courses[curriculum.courses.GetLength(0) - i - 1].PracticeHours * 1.25) / 18;
                i++;
                if (j > courses.GetLength(0) - 1)
                {
                    foreach (Course course in courses)
                    {
                        if (course.IsSpecial)
                        {
                            bool log = true;
                            foreach (int prerequisite in course.prerequisities)
                            {
                                bool suitable = false;
                                foreach (Course course1 in curriculum.courses)
                                {
                                    if (course1.Code == prerequisite) suitable = true;
                                }
                                if (!suitable) log = false;
                            }
                            if (log)
                            {
                                Array.Resize(ref curriculum.courses, curriculum.courses.GetLength(0) + 1);
                                curriculum.courses[curriculum.courses.GetLength(0) - i - 1] = course;
                                curriculum.credits += (curriculum.courses[curriculum.courses.GetLength(0) - i - 1].LectureHours + curriculum.courses[curriculum.courses.GetLength(0) - i - 1].PracticeHours * 1.25) / 18;
                                curriculum.specialsnumber ++;
                                i++;
                                if (curriculum.credits < degree.CreditsRequired) break;
                            }

                        }
                    }
                }
            }
            while (curriculum.credits < degree.CreditsRequired);
            Console.WriteLine(curriculum);
        }
    }
}
