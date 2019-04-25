﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models
{
    public class Teacher
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Discription { get; set; }

        public ICollection<Course> Courses { get; set; } // public List<Course> Courses { get; set; }
            = new List<Course>();

    }
}
