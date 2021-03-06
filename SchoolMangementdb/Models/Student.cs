﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Number { get; set; }
        [Required]
        public string City { get; set; }

        public IList<StudentsCourses> StudentsCourses { get; set; }
            = new List<StudentsCourses>(); ///

    }
}