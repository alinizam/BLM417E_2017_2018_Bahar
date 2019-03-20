using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class CoursesNotes
    {
        public int CourseNoteId { get; set; }
        public string ExamName { get; set; }
        public int StudentCourseId { get; set; }
        public int? Grade { get; set; }
        // FSMVU: Relation between Student Couse  and Course Notes

        public StudentCourses StudentCourse { get; set; }
    }
}
