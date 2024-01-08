using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.DAL.Interface;
using StudentManagementApp.Models;

namespace StudentManagementApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentInterface _studentRepository;

        public StudentController(IStudentInterface studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: /Student/Index
        public IActionResult Index()
        {
            var students = _studentRepository.GetAllStudents();
            return View(students);
        }

        // GET: /Student/Details/{id}
        public IActionResult Details(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(student);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.AddStudent(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: /Student/Edit/{id}
        public IActionResult Edit(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(student);
        }

        // POST: /Student/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student updatedStudent)
        {
            if (id != updatedStudent.StudentId)
            {
                return BadRequest(); // 400 Bad Request
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentRepository.UpdateStudent(updatedStudent);
                }
                catch (ArgumentException)
                {
                    return NotFound(); // 404 Not Found
                }

                return RedirectToAction("Index");
            }

            return View(updatedStudent);
        }

        // GET: /Student/Delete/{id}
        public IActionResult Delete(int id)
        {
            var student = _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound(); // 404 Not Found
            }

            return View(student);
        }

        // POST: /Student/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deletedStudent = _studentRepository.DeleteStudent(id);

            if (deletedStudent == null)
            {
                return NotFound(); // 404 Not Found
            }

            return RedirectToAction("Index");
        }
    }
}
