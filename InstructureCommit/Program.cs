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

            Console.WriteLine("Student Information");
            //Step 1 Create a csv parser to bring in data
            foreach (var student in GetStudentData())
            {
                //The formatting is off as only a place holder. The correct data is still not in place.
                Console.WriteLine("User Id\t Student Name\t Course Id\t State\t");
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t\n",student.Item1, student.Item2, student.Item3, student.Item4);
            }

            Console.WriteLine("Course Information");
            foreach (var course in GetCourseData())
            {
                //The formatting is off as only a place holder. The correct data is still not in place.
                Console.WriteLine("Course Id\t Course Name\t Course Id\t State");
                Console.WriteLine("{0}\t {1}\t {2}\n", course.Item1, course.Item2, course.Item3);
            }


            Console.WriteLine("My attempt at getting the course associated with the student");
            var coursesWithStudents = from course in GetCourseData()
                                      join student in GetStudentData()
                                      on course.Item1 equals student.Item3
                                      select course;
            //select new {
            //    course.Item2,
            //    course.Item3,
            //    student,


            //};



            foreach (var course in coursesWithStudents)
            {
                Console.WriteLine(course.Item2);
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
