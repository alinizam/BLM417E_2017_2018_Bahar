using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class StudentCourses
    {
        public StudentCourses()
        {
            CoursesNotes = new HashSet<CoursesNotes>();
        }

        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        // FSMVU: Relation between Student  and Student Course  
        public Students Student { get; set; }
        // FSMVU: Relation between Student Course and Course notes
        public ICollection<CoursesNotes> CoursesNotes { get; set; }
    }
}
