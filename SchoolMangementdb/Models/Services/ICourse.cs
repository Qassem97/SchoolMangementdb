using SchoolMangementdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.Services
{
    public interface ICourse
    {
        Course AddCourse(string name, string discription);
        IEnumerable<Course> GetAll();
        bool RemovCourse(int id);

        bool UpdateCourse(Course Course);
        Course FindCourse(int id);

        void AddStudentToCourse(Course course, Student student);

        bool RemoveStudentToCourse(Course course, int studentId);
    }
}

