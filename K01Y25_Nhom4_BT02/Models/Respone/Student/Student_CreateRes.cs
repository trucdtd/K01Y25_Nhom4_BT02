using K01Y25_Nhom4_BT02.Models.Request.Student;

namespace K01Y25_Nhom4_BT02.Models.Respone.Student
{
    public class Student_CreateRes
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
