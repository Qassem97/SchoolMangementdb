using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Models.V.Model
{
    public class AssignmentVModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public int CourseId { get; set; }
    }
}
