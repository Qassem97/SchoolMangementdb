using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.V.Model
{
    public class StudentVModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; } //not used 
        [Required]
        public string City { get; set; }  //not used 

        public List<StudentsCourses> StudentsCourses { get; set; }

        public List<Course> Courses { get; set; }

        public List<CourseAssignment> Assignments { get; set; }
    }
}
