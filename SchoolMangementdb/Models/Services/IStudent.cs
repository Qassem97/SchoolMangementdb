using SchoolMangementdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Services
{
    public interface IStudent
    {
       

        Student AddStudent(string name, string number, string city);
        IEnumerable<Student> GetAll();
        Student FindStudent(int id);
        bool UpdateStudent(Student student);
        bool RemovStudent(int id);

    }
}
