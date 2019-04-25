using Microsoft.AspNetCore.Mvc;
using SchoolMangementdb.Models;
using SchoolMangementdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent studentService;

        public StudentController(IStudent studentService)
        {
            this.studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = studentService.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent([Bind("Name,Number,City")]Student student)
        {
            if (ModelState.IsValid)
            {
                student = studentService.AddStudent(student.Name, student.Number, student.City);
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int? id)// id
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = studentService.FindStudent((int)id);//to edit student must FindStudent
            if (student == null)
            {
                return NotFound();
            }



            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            {
                studentService.UpdateStudent(student);
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                studentService.RemovStudent((int)id);
                return RedirectToAction(nameof(Index));
            }
            return Content("");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = studentService.FindStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

    }
}
