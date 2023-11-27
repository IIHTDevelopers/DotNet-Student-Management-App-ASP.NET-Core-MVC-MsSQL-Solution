using StudentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp.Models;

namespace StudentManagementApp.DAL.Interface
{
    public interface IStudentInterface 
    {
        Student GetStudentById(int studentId);
        IEnumerable<Student> GetAllStudents();
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        Student DeleteStudent(int studentId);
    }
}