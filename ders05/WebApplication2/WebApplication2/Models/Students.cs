using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentCourses = new HashSet<StudentCourses>();
        }

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // FSMVU: Relation between Student  and Student Course (one to many)
        public ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
