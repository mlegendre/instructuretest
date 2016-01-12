using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace InstructureCommit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Step 1 Create a csv parser to bring in data
            foreach (var student in GetStudentData())
            {
                Console.WriteLine("");
                Console.WriteLine(student.Item1);
                Console.WriteLine(student.Item2);
                Console.WriteLine(student.Item3);
                Console.WriteLine(student.Item4);
            }


            foreach (var course in GetCourseData())
            {
                Console.WriteLine(course.Item1);
                Console.WriteLine(course.Item2);
                Console.WriteLine(course.Item3);
            }

            Console.ReadKey();
            //Step 2 Verify Csv file has correct headers and data

            //Step 3 Output list of active courses and the users in the course
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
    }
}
