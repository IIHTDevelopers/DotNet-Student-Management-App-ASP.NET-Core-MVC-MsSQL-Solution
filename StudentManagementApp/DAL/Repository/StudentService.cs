using StudentManagementApp.DAL.Interface;
using StudentManagementApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagementApp.DAL.Repository
{
    public class StudentManagementService : IStudentInterface
    {
        private IStudentRepository _repo;
        public StudentManagementService(IStudentRepository repo)
        {
            this._repo = repo;
        }

        public Student AddStudent(Student student)
        {
            return _repo.AddStudent(student);
        }

        public Student DeleteStudent(int studentId)
        {
            return _repo.DeleteStudent(studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _repo.GetAllStudents();
        }

        public Student GetStudentById(int studentId)
        {
            return _repo.GetStudentById(studentId);
        }

        public Student UpdateStudent(Student student)
        {
            return _repo.UpdateStudent(student);
        }
    }
}