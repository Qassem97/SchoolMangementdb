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
    public class CourseController : Controller
    {
        private readonly ICourse CourseRepo;
        private readonly ITeacher TeacherRepo;
        private readonly IStudent StudentRepo;
        private readonly ICourseAssignmnet CourseAssignmentRepo;

        public CourseController(ICourse CourseRepo, ITeacher TeacherRepo, IStudent StudentRepo, ICourseAssignmnet CourseAssignmentRepo)
        {
            this.CourseRepo = CourseRepo;
            this.TeacherRepo = TeacherRepo;
            this.StudentRepo = StudentRepo;
            this.CourseAssignmentRepo = CourseAssignmentRepo;
        }
        public IActionResult Index()
        {
            var courses = CourseRepo.GetAll();
            return View(courses);
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        public IActionResult AddCourseAssignment( int CourseId)
        {
            var vm = new AssignmentVM
            {
                CourseID = CourseId
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse([Bind("Name, Discription")] Course course)
        {
            if (ModelState.IsValid)
            {
                course = CourseRepo.AddCourse(course.Name, course.Discription);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourseAssignment(CourseAssignment assignment, int CourseId)//för att skappa assig till course use class assig o course id
        {
            if (ModelState.IsValid)
            {
                CourseAssignmentRepo.AddCourseAssignment(assignment, CourseId);//samma posion som i interfase

                return RedirectToAction(nameof(Index));
            }
            return View(assignment);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = CourseRepo.FindCourse((int)id);
            if (course == null)
            {
                return NotFound();
            }
            //CourseVM will be used her in the controller
            CourseVM name = new CourseVM
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Discription,
                Teachers = TeacherRepo.GetAll(),
            };
            return View(name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseVM course)
        {
            if (ModelState.IsValid)
            {
                var teacherF = TeacherRepo.GetAll(course.TeacherId);//använda hitta teacher

                var courseToUpdate = new Course
                {
                    Name = course.Namr,
                    Discription = course.Discription,
                    Teacher = teacherF,
                    Id = course.Id
                };
                CourseRepo.UpdateCourse(courseToUpdate);
                return RedirectToAction(nameof(Index));
            }

            CourseViewModel CourseViewModel = new CourseViewModel();
           //
            return View(course);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                CourseRepo.RemovCourse((int)id);
                CourseAssignmentRepo.RemovCourseAssignment((int)id);
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
            var course = CourseRepo.FindCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }

            CourseViewModel CourseViewModel = new CourseViewModel();//först kalla vm vilket innehåller LIST dem som vill du hantera
            CourseViewModel.Course = course;

            CourseViewModel.CourseAssignments = course.CourseAssignments;//inte allAssignments 

            //++
            List<Student> studentsNotInCourse = StudentRepo.GetAll();//för att visa all dem som ej koplat till courses

            foreach (var item in course.StudentsCourses)
            {
                studentsNotInCourse.Remove(item.Student);
            }

            CourseViewModel.Students = studentsNotInCourse;// lägg till vm.alla studenter eller vad som helst
            //++
            return View(CourseViewModel);
        }


        public IActionResult AddStudentToCourseSave(int cId, int sId)
        {
            var course = CourseRepo.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            var student = StudentRepo.FindStudent(sId);
            if (student == null)
            {
                return NotFound();
            }

            foreach (var item in course.StudentsCourses)//kontrolerar om eleven redan finns
            {
                if (item.StudentId == sId)
                {
                    return RedirectToAction(nameof(Details), new { id = cId });
                }
            }

            CourseRepo.AddStudentToCourse(course, student);//koplar student course med varandra        

            return RedirectToAction(nameof(Details), new { id = cId });
        }

        public IActionResult RemoveStudentToCourse(int cId, int sId)//ybrat iz coursa
        {
            var course = CourseRepo.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            CourseRepo.RemoveStudentToCourse(course, sId);//ispolzovat method iz courseservica RemoveStudentToCourse

            return RedirectToAction(nameof(Details), new { id = cId });
        }
    }
}