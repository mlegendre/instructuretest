using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InstructureCommit;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetStudentDataShouldReturnTupleWithCorrectDataTypes()
        {
            List<Tuple<int, string, int, string>> sut = Program.GetStudentData();

            Assert.IsInstanceOfType(sut,typeof(List<Tuple<int,string,int,string>>));

            foreach (var student in sut)
            {
                Assert.IsInstanceOfType(student.Item1, typeof(int));
                Assert.IsInstanceOfType(student.Item2, typeof(string));
                Assert.IsInstanceOfType(student.Item3, typeof(int));
                Assert.IsInstanceOfType(student.Item4, typeof(string));
            }
        }

        [TestMethod]
        public void GetCourseDataShouldReturnTupleWithCorrectDataTypes()
        {
            List<Tuple<int, string, string>> sut = Program.GetCourseData();

            Assert.IsInstanceOfType(sut, typeof(List<Tuple<int, string, string>>));

            foreach (var course in sut)
            {
                Assert.IsInstanceOfType(course.Item1, typeof(int));
                Assert.IsInstanceOfType(course.Item2, typeof(string));
                Assert.IsInstanceOfType(course.Item3, typeof(string));
                
            }
        }
    }
}
