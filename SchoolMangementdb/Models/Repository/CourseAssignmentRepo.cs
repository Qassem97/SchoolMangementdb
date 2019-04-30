using Microsoft.EntityFrameworkCore;
using SchoolMangementdb.Data;
using SchoolMangementdb.Models;
using SchoolMangementdb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Repository
{
    public class CourseAssignmentRepo : ICourseAssignmnet
    {
        private readonly SchoolContextdb context;

        public CourseAssignmentRepo(SchoolContextdb context)
        {
            this.context = context;
        }

        // to do GetAll? 
        public CourseAssignment AddCourseAssignment(CourseAssignment assignment, int CourseId)
        {
            var course = context.Courses
                 .Include(c => c.CourseAssignments)
                 .SingleOrDefault(Course => Course.Id == CourseId);
            course.CourseAssignments.Add(assignment);
            context.SaveChanges();
            return assignment;
        }

        public List<CourseAssignment> GetAll( int courseId)
        {
            var course = context.Courses
            .Include(c => c.CourseAssignments)
            .SingleOrDefault(coursen => coursen.Id == courseId);

            return course.CourseAssignments;
        }

        public CourseAssignment FindCourseAssignment(int id)
        {
            return context.CourseAssignments.SingleOrDefault(dd => dd.Id == id);
        }

        public bool RemovCourseAssignment(int id)
        {
            bool wasRemoved = false;
            CourseAssignment courseAssignment = context.CourseAssignments.SingleOrDefault(aa => aa.Id == id);
            if (courseAssignment ==  null)
            {
                return wasRemoved;
            }
            context.CourseAssignments.Remove(courseAssignment);
            context.SaveChanges();
            return wasRemoved;
        }

        public bool UpdateCourseAssignment(CourseAssignment assignment)
        {
            bool isUpdate = false;
            CourseAssignment uCourseAssignment = context.CourseAssignments.SingleOrDefault(u => u.Id == assignment.Id);

            if (uCourseAssignment != null)
            {
                return isUpdate;
            }
            context.CourseAssignments.Remove(uCourseAssignment);
            context.SaveChanges();
            return isUpdate;
        }

    }
}









