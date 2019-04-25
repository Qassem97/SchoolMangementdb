using SchoolMangementdb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMangementdb.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContextdb context)
        {
            context.Database.EnsureCreated();

            if (context.Courses.Any())
            {
                return;
            }

            // Intialize 5 students
            var students = new[]
            {
                new Student { Name = "Alle" },
                new Student { Name = "Hanna" },
                new Student { Name = "Sara" },
                new Student { Name = "lala" },
                new Student { Name = "Tala" }
            };

            // Intialize 9 courses with the assignments for each course
            var courses = new[]
            {
                new Course
                {
                    Name = "C# Fundamentals",
                    Description = "The course covers the basic in c#.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "LABA - Laboratory Work" },
                        new CourseAssignment() { Name = "TENA - Examination" }
                    }
                },
                new Course
                {
                    Name = "JavaScript Basic",
                    Description = "Number System and Codes. Binary Arithmetic. Booolean algebra and Booolean functions. Logic operations. Logic gates. Optimisation methods. Combinational function blocks. Digital arithmetic. Design of combinational circuits. Latches and Flips-Flops. Counters. Sequential circuits. Finite state diagrams. Finite state machine of Mealy and Moore type. Asynchronous sequential circuits. Design of synchronous and asynchronous sequential circuits. Programmable logic. Introduction to VHDL. Memory. Fundamental MOS-technology.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                        new CourseAssignment() { Name = "Assignment 3" },
                        new CourseAssignment() { Name = "Assignment 4" },
                    }
                },
                new Course
                {
                    Name = "HTML",
                    Description = "This course provides basic knowledge of creating a part of webpages .It also provides knowledge of how this is supposed to be used.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                    }
                },
                new Course
                {
                    Name = "CSS",
                    Description = "This course provides basic knowledge of creating a part of webpages .It also provides knowledge of how this is supposed to be used.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                    }
                },
                new Course
                {
                    Name = "Bootstrap",
                    Description = "This course provides basic knowledge of creating a part of webpages .It also provides knowledge of how this is supposed to be used.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                        new CourseAssignment() { Name = "Assignment 3" },
                        new CourseAssignment() { Name = "Assignment 4" },
                        new CourseAssignment() { Name = "Assignment 5" },
                        new CourseAssignment() { Name = "Assignment 6" },
                    }
                },
                new Course
                {
                    Name = "MVC",
                    Description = "TThe fundamental theorem of arithmetics, the Euclidian algorithm and a Diophantine equation. Modular arithmetics, Fermat's theorem and RSA. Sets, functions, infinite sets and cardinal numbers, the pigeonhole principle. Proof by induction and recursions. Elementary group theory as the theorem of Lagrange and in particular the symmetrical group. Boolean algebra. Error correcting codes and in particular Hamming codes. Combinatorics, binomial and multinomial numbers, Stirling numbers, the sieve principle. Elementary graph theory, Eulerian and Hamiltonian graphs, matchings in bipartite graphs, planar graphs.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                    }
                },
                new Course
                {
                    Name = "Security",
                    Description = "Function, function graph, domain, range. Increasing and decreasing functions, odd and even functions. Inverse functions. The class of elementary functions. Unit circle, trigonometric formulas and equations, exponential and logarithmic functions, power laws, logarithms. Limits, rules for calculating limits, standard limits. Continuity, theorems on continuous functions. Derivative, rules of differentiation and applications: rate of change, linear approximation, tangent, extreme value problems, sketching the graph of a function, inequalities etc.Taylor's formula with error estimates. Linear differential equations with constant coefficients and their applications. Riemann integral, primitive functions, variable substitution, integration by parts, partial fractions. Riemann sums, geometric and other applications of integrals, improper integrals. Something about sequences and series. Something about numerical methods (eg Newton's method).",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                        new CourseAssignment() { Name = "Assignment 3" },
                        new CourseAssignment() { Name = "Assignment 4" },
                        new CourseAssignment() { Name = "Assignment 5" },
                    }
                },
                new Course
                {
                    Name = "Algorithem",
                    Description = "The trigonometric functions and their inverses, power, exponential and logarithmic functions, absolute value function, properties of functions, complex numbers, vectors, scalar and cross product, projections and linear combination.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                        new CourseAssignment() { Name = "Assignment 3" },
                        new CourseAssignment() { Name = "Assignment 4" },
                    }
                },
                new Course
                {
                    Name = "Identity",
                    Description = "The course runs over a KTH period.",
                    CourseAssignments = new List<CourseAssignment>
                    {
                        new CourseAssignment() { Name = "Assignment 1" },
                        new CourseAssignment() { Name = "Assignment 2" },
                        new CourseAssignment() { Name = "Assignment 3" },
                        new CourseAssignment() { Name = "Assignment 4" },
                        new CourseAssignment() { Name = "Assignment 5" },
                        new CourseAssignment() { Name = "Assignment 6" },
                        new CourseAssignment() { Name = "Assignment 7" },
                        new CourseAssignment() { Name = "Assignment 8" },
                    }
                },
            };

            // Intialize 5 teachers
            var teachers = new Teacher[]
            {
                new Teacher { Name = "Hlima Gomes" },
                new Teacher { Name = "Taylor Dani" },
                new Teacher { Name = "Ali Grande" },
                new Teacher { Name = "Abdi Abbas" },
                new Teacher { Name = "Simon Walter" },
            };

            // Contect course to its teacher
            courses[0].Teacher = teachers[0];
            courses[1].Teacher = teachers[0];
            courses[2].Teacher = teachers[1];
            courses[3].Teacher = teachers[1];
            courses[4].Teacher = teachers[2];
            courses[5].Teacher = teachers[2];
            courses[6].Teacher = teachers[3];
            courses[7].Teacher = teachers[3];
            courses[8].Teacher = teachers[4];

            // Intialize student to coresponding courses
            var studentsToCourses = new StudentsCourses[]
            {
                new StudentsCourses { Student = students[0], Course = courses[0] },
                new StudentsCourses { Student = students[0], Course = courses[1] },
                new StudentsCourses { Student = students[0], Course = courses[2] },
                new StudentsCourses { Student = students[0], Course = courses[3] },
                new StudentsCourses { Student = students[0], Course = courses[4] },
                new StudentsCourses { Student = students[0], Course = courses[5] },
                new StudentsCourses { Student = students[0], Course = courses[6] },
                new StudentsCourses { Student = students[0], Course = courses[7] },
                  
                new StudentsCourses { Student = students[1], Course = courses[0] },
                new StudentsCourses { Student = students[1], Course = courses[1] },
                new StudentsCourses { Student = students[1], Course = courses[2] },
                new StudentsCourses { Student = students[1], Course = courses[3] },
                new StudentsCourses { Student = students[1], Course = courses[4] },
                new StudentsCourses { Student = students[1], Course = courses[5] },
                 
                new StudentsCourses { Student = students[2], Course = courses[0] },
                new StudentsCourses { Student = students[2], Course = courses[1] },
                new StudentsCourses { Student = students[2], Course = courses[2] },
                new StudentsCourses { Student = students[2], Course = courses[4] },
                  
                new StudentsCourses { Student = students[3], Course = courses[3] },
                new StudentsCourses { Student = students[3], Course = courses[4] },
                new StudentsCourses { Student = students[3], Course = courses[5] },
                new StudentsCourses { Student = students[3], Course = courses[6] },
                 
                new StudentsCourses { Student = students[4], Course = courses[5] },
                new StudentsCourses { Student = students[4], Course = courses[6] },
                new StudentsCourses { Student = students[4], Course = courses[7] },
                new StudentsCourses { Student = students[4], Course = courses[8] }
            };

            // Contect students to courses
            context.AddRange(studentsToCourses);
            context.SaveChanges();
        }
    }
}
