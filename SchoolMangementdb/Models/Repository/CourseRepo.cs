using Microsoft.EntityFrameworkCore;
using SchoolMangementdb.Data;
using SchoolMangementdb.Models;
using SchoolMangementdb.Models.Services;
using SchoolMangementdb.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.Repository
{
    public class CourseRepo : ICourse
    {

        private readonly SchoolContextdb context;

        public CourseRepo(SchoolContextdb contextdb)
        {
            context = contextdb;
        }

        public Course AddCourse(string name, string discription)
        {
            Course course = new Course()
            {
                Name = name,
                Description = discription
            };
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetAll()
        {
            return context.Courses.Include(c => c.Teacher)
                .Include(c => c.Teacher).Include(c => c.StudentsCourses)
                .ThenInclude(c => c.Student).Include(c => c.CourseAssignments).ToList();
        }

        public Course FindCourse(int id)
        {
            var course = context.Courses
            .Include(c => c.Teacher)//  in Details
            .Include(c => c.StudentsCourses)
            .Include("StudentsCourses.Student")
            .Include(c => c.CourseAssignments)
            .SingleOrDefault(coursen => coursen.Id == id);

            return course;
        }
        public bool RemovCourse(int id)
        {
            bool wasRemoved = false;
            Course course = context.Courses.Include(s => s.CourseAssignments)
                .SingleOrDefault(coursen => coursen.Id == id);
            if (course == null)
            {
                return wasRemoved;
            }
            context.Courses.Remove(course);
            context.SaveChanges();
            return wasRemoved;
        }

        public bool UpdateCourse(Course course)
        {

            bool isUpdate = false;

            Course oldCourse = FindCourse(course.Id);//FindCourse() to bring even teacher and student

            if (oldCourse != null)
            {
                oldCourse.Name = course.Name;
                oldCourse.Description = course.Description;

                if (course.Teacher != null)
                {
                    oldCourse.Teacher = course.Teacher;//joins teachers to courses
                }

                if (course.StudentsCourses != null)
                {
                    oldCourse.StudentsCourses = course.StudentsCourses;
                }

                if (course.CourseAssignments != null)
                {
                    oldCourse.CourseAssignments = course.CourseAssignments;
                }

                context.SaveChanges();
                isUpdate = true;
            }

            return isUpdate;
        }

        public void AddStudentToCourse(Course course, Student student)//many to many by using StudentsCourses
        {
            course.StudentsCourses.Add(new StudentsCourses() { StudentId = student.Id, CourseId = course.Id, Course = course, Student = student });

            context.SaveChanges();
        }

        public bool RemoveStudentToCourse(Course course, int studentId)
        {
            foreach (var item in course.StudentsCourses)
            {
                if (item.StudentId == studentId)
                {
                    course.StudentsCourses.Remove(item);

                    context.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
