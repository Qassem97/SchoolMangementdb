using SchoolMangementdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.Services
{
    public interface ITeacher
    {
        IEnumerable<Teacher> GetAll();

        Teacher FindTeacher(int id);
        Teacher AddTeacher(string name, string discription);
        bool RemovTeacher(int id);
        bool UpdateTeacher(Teacher teacher);


    }
}
