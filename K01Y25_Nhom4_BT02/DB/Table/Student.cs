using System;
using System.Collections.Generic;

namespace K01Y25_Nhom4_BT02.DB.Table
{
    public partial class Student
    {
        internal string lastname;
        internal DateTime enrollmentdate;
        internal string firstname;

        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Lastname { get; set; } = null!;
        public string? LastName { get; internal set; }
        public string Firstmidname { get; set; } = null!;
        public string FirstMidName { get; internal set; }
        public DateTime Enrollmentdate { get; set; }
        public DateTime? EnrollmentDate { get; internal set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public string? FirstName { get; internal set; }
    }
}
