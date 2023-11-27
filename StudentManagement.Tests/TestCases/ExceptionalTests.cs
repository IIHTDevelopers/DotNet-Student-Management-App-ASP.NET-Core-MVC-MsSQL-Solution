
using StudentManagementApp.DAL;
using StudentManagementApp.DAL.Interface;
using StudentManagementApp.DAL.Repository;
using StudentManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace StudentManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IStudentInterface _studentService;
        public readonly Mock<IStudentRepository> studentservice = new Mock<IStudentRepository>();
        private readonly Student _Student;
        private readonly IEnumerable<Student> StudentList;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _studentService = new StudentManagementService(studentservice.Object);
            _output = output;
            _Student = new Student
            {
                StudentId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            };
            StudentList = new List<Student>
        {
            new Student
            {
               StudentId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            },
            new Student
            {
              StudentId = 1,
                FirstName = "Vicky",
                LastName = "Patel",
                DateOfBirth = DateTime.Now.Date,
                Email = "V@gmail.cm"
            },
            // Add more Student instances as needed
        };

        }

        [Fact]
        public async Task<bool> Testfor_Get_Studentt_ById_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 studentservice.Setup(repos => repos.GetStudentById(_Student.StudentId)).Returns(_Student);
                var result =  _studentService.GetStudentById(_Student.StudentId);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Student_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                 studentservice.Setup(repos => repos.UpdateStudent(_Student)).Returns(_Student);
                var result =  _studentService.UpdateStudent(_Student);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}