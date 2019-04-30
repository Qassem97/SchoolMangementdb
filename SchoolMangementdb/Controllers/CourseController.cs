using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolMangementdb.Models;
using SchoolMangementdb.Models.Services;
using SchoolMangementdb.Models.V.Model;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse([Bind("Name, Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                course = CourseRepo.AddCourse(course.Name, course.Description);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public IActionResult AddCourseAssignment(int courseId)
        {
            var vm = new AssignmentVModel
            {
                CourseId = courseId
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourseAssignment(CourseAssignment assignment, int CourseId)//class assignment and courseid needed, to add Assignment to course
        {
            if (ModelState.IsValid)
            {
                CourseAssignmentRepo.AddCourseAssignment(assignment, CourseId);

                return RedirectToAction("Details", new { id = CourseId });
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
            
            EditCourseVM name = new EditCourseVM 
            {
                CourseId = course.Id,
                Name = course.Name,
                Description = course.Description,
                Teachers = TeacherRepo.GetAll(),
            };
            return View(name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditCourseVM course)
        {
            if (ModelState.IsValid)
            {
                var teacherF = TeacherRepo.FindTeacher(course.TeacherId);

                var courseToUpdate = new Course
                {
                    Name = course.Name,
                    Description = course.Description,
                    Teacher = teacherF,
                    Id = course.CourseId
                };
                CourseRepo.UpdateCourse(courseToUpdate);
                return RedirectToAction(nameof(Index));
            }

            course.Teachers = TeacherRepo.GetAll();
            return View(course);
        }

        public IActionResult Delete(int? id)  // Magic here-
        {
            if (id != null)
            {
                CourseRepo.RemovCourse((int)id); /// crazy idea..! not reasonale
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

            CourseVModel CourseVModel = new CourseVModel();// LIST from VModel
            CourseVModel.Course = course;

            CourseVModel.Assignments = course.CourseAssignments;

            //++
            List<Student> studentsNotInCourse = StudentRepo.GetAll().ToList();//to show students that is NotInCourse

            foreach (var item in course.StudentsCourses)
            {
                studentsNotInCourse.Remove(item.Student);
            }

            CourseVModel.Students = studentsNotInCourse;
            //++
            return View(CourseVModel);
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

            foreach (var item in course.StudentsCourses)//is there student 
            {
                if (item.StudentId == sId)
                {
                    return RedirectToAction(nameof(Details), new { id = cId });
                }
            }

            CourseRepo.AddStudentToCourse(course, student);//relationship student + course        

            return RedirectToAction(nameof(Details), new { id = cId });
        }

        public IActionResult RemoveStudentToCourse(int cId, int sId)
        {
            var course = CourseRepo.FindCourse(cId);
            if (course == null)
            {
                return NotFound();
            }

            CourseRepo.RemoveStudentToCourse(course, sId);

            return RedirectToAction(nameof(Details), new { id = cId });
        }
    }
}