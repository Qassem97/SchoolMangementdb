using SchoolMangementdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Services
{
    public interface ICourseAssignmnet
    {
        List<CourseAssignment> AllCourseAssignmnet();
        CourseAssignment AddCourseAssignment(CourseAssignment assignment, int CourseId);
        bool RemovCourseAssignment(int id);
        bool UpdateCourseAssignment(CourseAssignment assignment);
        CourseAssignment FindCourseAssignment(int  id);
    }
}
