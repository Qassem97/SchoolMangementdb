using Microsoft.EntityFrameworkCore;
using SchoolMangementdb.Data;
using SchoolMangementdb.Models;
using SchoolMangementdb.Models.Services;
using SchoolMangementdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.Repository
{
    public class TeacherRepo : ITeacher
    {
        /*private*/
        readonly SchoolContextdb context;

        public TeacherRepo(SchoolContextdb context)
        {
            this.context = context;
        }
        public Teacher AddTeacher(string name, string discription)
        {
            Teacher teacher = new Teacher() { Name = name, Description = discription };
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return teacher;
        }

        public List<Teacher> GetAll()
        {
            return context.Teachers
                .Include(t => t.Courses)
                .ToList();
        }

        public Teacher FindTeacher(int id)
        {
            return context.Teachers
            .Include(f => f.Courses).SingleOrDefault(ft => ft.Id == id);
        }
        public bool UpdateTeacher(Teacher teacher)
        {
            bool isUpdate = false;
            Teacher teacheren = context.Teachers.Include(c => c.Courses)
                .SingleOrDefault(ft => ft.Id == teacher.Id);
            {
                if (teacheren != null)
                {
                    teacheren.Name = teacher.Name;
                    teacheren.Description = teacher.Description;

                    if (teacher.Courses != null)
                    {
                        teacheren.Courses = teacher.Courses;
                    }

                    context.SaveChanges();
                    isUpdate = true;
                }
            }
            return isUpdate;
        }
        public bool RemovTeacher(int id)
        {
            bool wasRemoved = false;
            Teacher teacher = context.Teachers.SingleOrDefault(l => l.Id == id);
            if (teacher == null)
            {
                return wasRemoved;
            }
            context.Teachers.Remove(teacher);
            context.SaveChanges();
            return wasRemoved;
        }

    }
}
