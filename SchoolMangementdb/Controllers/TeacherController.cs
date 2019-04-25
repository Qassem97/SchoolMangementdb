using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolMangementdb.Models;
using SchoolMangementdb.Models.Services;
using SchoolMangementdb.Services;

namespace SchoolMangementdb.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacher teacherService;

        public TeacherController(ITeacher teacherService)
        {
            this.teacherService = teacherService;
        }
        public IActionResult Index()
        {
            var teachers = teacherService.GetAll();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTeacher([Bind("Name,Discription")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher = teacherService.AddTeacher(teacher.Name, teacher.Discription);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var teacher = teacherService.FindTeacher((int)id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {

            if (ModelState.IsValid)
            {
                teacherService.UpdateTeacher(teacher);
                return RedirectToAction(nameof(Index));

            }
            return View(teacher);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                teacherService.RemovTeacher((int)id);
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
            var teacher = teacherService.FindTeacher((int)id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }
    }
}