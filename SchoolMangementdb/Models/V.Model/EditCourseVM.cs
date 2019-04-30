using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.V.Model
{
    public class EditCourseVM
    {
       
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int TeacherId { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
