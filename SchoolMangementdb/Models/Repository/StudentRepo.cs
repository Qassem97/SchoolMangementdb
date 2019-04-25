using Microsoft.EntityFrameworkCore;
using SchoolMangementdb.Data;
using SchoolMangementdb.Models;
using SchoolMangementdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Repository
{
    public class StudentRepo : IStudent
    {
        /*private*/
        readonly SchoolContextdb context;

        public StudentRepo(SchoolContextdb context)
        {
            this.context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return context.Students
                 .Include(c => c.StudentsCourses)
                 .ToList();
        }

        public Student FindStudent(int id)
        {
            return context.Students
                .Include(f => f.StudentsCourses).Include("StudentsCourses.Course")
                .Include("StudentsCourses.Course.CourseAssignments").SingleOrDefault(f => f.Id == id);
        }
        public Student AddStudent(string name, string number, string city)
        {
            Student student = new Student() { Name = name, Number = number, City = city };
            context.Students.Add(student);
            context.SaveChanges();
            return student;
        }

        public bool RemovStudent(int id)
        {
            bool wasRemoved = false;
            Student student = context.Students.SingleOrDefault(s => s.Id == id);
            if (student == null)
            {
                return wasRemoved;
            }
            context.Students.Remove(student);
            context.SaveChanges();
            return wasRemoved;
        }
        public bool UpdateStudent(Student student)
        {
            bool isUpdate = false;
            Student studenten = context.Students.SingleOrDefault(item => item.Id == student.Id);
            {
                if (studenten != null)
                {
                    studenten.Name = student.Name;
                    studenten.Number = student.Number;
                    studenten.City = student.City;
                    context.SaveChanges();
                }
            }
            return isUpdate;
        }
    }
}
