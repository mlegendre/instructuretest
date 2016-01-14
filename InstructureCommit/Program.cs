using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace InstructureCommit
{
    public class Program
    {
        public static void Main(string[] args)
        {


            WriteOutput();

            Console.ReadKey();

        }

        public static List<Tuple<int, string, int, string>> GetStudentData()
        {

            //C:\Users\Heather\Documents\Students.csv
            using (var sr = new StreamReader("Students.csv"))
            {
                var reader = new CsvReader(sr);
                //return reader.GetRecords<StudentDataReader>();
                IEnumerable<StudentDataReader> students = reader.GetRecords<StudentDataReader>();
                List<Tuple<int, string, int, string>> allStudents = new List<Tuple<int, string, int, string>>();
                //Dictionary<int, Tuple<int, string, string>> allStudents = new Dictionary<int, Tuple<int, string, string>>();
                //return students;
                foreach (var student in students)
                {
                    allStudents.Add(new Tuple<int, string, int, string>(
                        student.user_id,
                        student.user_name,
                        student.course_id,
                        student.state
                        ));
                }

                return allStudents;
            }

        }

        public static List<Tuple<int, string, string>> GetCourseData()
        {
            using (var sr = new StreamReader("Courses.csv"))
            {
                var reader = new CsvReader(sr);
                //return reader.GetRecords<StudentDataReader>();
                IEnumerable<CoursesDataReader> courses = reader.GetRecords<CoursesDataReader>();
                List<Tuple<int, string, string>> allCourses = new List<Tuple<int, string, string>>();
                foreach (var course in courses)
                {
                    allCourses.Add(new Tuple<int, string, string>(
                        course.course_id,
                        course.course_name,
                        course.state
                        ));
                }

                return allCourses;
            }
        }

        public static void WriteOutput()
        {
            foreach (var course in GetCourseData())
            {
                List<string> studentsInCourse = new List<string>();

                foreach (var student in GetStudentData())
                {
                    if (course.Item1 == student.Item3 && course.Item3 != "deleted")
                    {
                        //course has a student
                        studentsInCourse.Add(student.Item2);
                    }
                }

                if (studentsInCourse != null)
                {
                    Console.WriteLine(course.Item2);
                    foreach (var stu in studentsInCourse)
                    {
                        Console.WriteLine(stu);
                    }
                }
                else
                {
                    Console.WriteLine("There were no students in {0}", course.Item2);
                }

                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}
