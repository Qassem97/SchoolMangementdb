﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models
{
    public class Course
    {
        public int Id { get; set; } //CourseId

        public string Name { get; set; } 
        public string Description { get; set; }

        public int? TeacherId { get; set; } // not exsist
        public Teacher Teacher { get; set; }

        //StudentsCourses
        public List<CourseAssignment> CourseAssignments { get; set; }
            //= new List<CourseAssignment>();

        //Assignmnets
        public List<StudentsCourses> StudentsCourses { get; set; }
            //= new List<StudentsCourses>();

    }
}
