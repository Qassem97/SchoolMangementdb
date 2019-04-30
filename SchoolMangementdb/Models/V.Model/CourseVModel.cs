using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.V.Model
{
    public class CourseVModel // CourseViewModel
    {
        public List<Teacher> Teachers = new List<Teacher>();

        public List<Student> Students = new List<Student>();

        public List<CourseAssignment> Assignments = new List<CourseAssignment>();

        public Course Course { get; set; }

        public Course Teacher { get; set; }
    }
}
