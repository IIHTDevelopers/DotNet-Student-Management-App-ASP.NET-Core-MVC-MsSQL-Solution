using StudentManagementApp.DAL.Interface;
using StudentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagementApp.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDbContext _context;
        public StudentRepository(StudentDbContext Context)
        {
            this._context = Context;
        }
      
        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student AddStudent(Student student)
        {
            if (student != null)
            {
                _context.Students.Add(student);
                _context.SaveChanges(); // Save changes to the database
                return student; // Return the added student with the updated Id
            }
            else
            {
                // Handle the case where the input student is null
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
        }


        public Student UpdateStudent(Student updatedStudent)
        {
            if (updatedStudent != null)
            {
                var existingStudent = _context.Students.Find(updatedStudent.StudentId);

                if (existingStudent != null)
                {
                    // Update properties of the existing student with the new values
                    _context.Entry(existingStudent).CurrentValues.SetValues(updatedStudent);
                    _context.SaveChanges(); // Save changes to the database
                    return existingStudent;
                }
                else
                {
                    // Handle the case where the student with the given Id is not found
                    throw new ArgumentException($"Student with Id {updatedStudent.StudentId} not found", nameof(updatedStudent));
                }
            }
            else
            {
                // Handle the case where the input student is null
                throw new ArgumentNullException(nameof(updatedStudent), "Updated student object cannot be null");
            }
        }

        public Student DeleteStudent(int studentId)
        {
            var studentToDelete = _context.Students.Find(studentId);

            if (studentToDelete != null)
            {
                _context.Students.Remove(studentToDelete);
                _context.SaveChanges(); // Save changes to the database
                return studentToDelete;
            }
            else
            {
                // Handle the case where the student with the given Id is not found
                throw new ArgumentException($"Student with Id {studentId} not found", nameof(studentId));
            }
        }
    }
}
