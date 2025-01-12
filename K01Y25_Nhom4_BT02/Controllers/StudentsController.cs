using K01Y25_Nhom4_BT02.DB;
using K01Y25_Nhom4_BT02.DB.Table;
using K01Y25_Nhom4_BT02.Models.Request.Student;
using K01Y25_Nhom4_BT02.Models.Respone.Student;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace K01Y25_Nhom4_BT02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor để inject DbContext vào controller
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Student_CreateReq model)
        {
            if (string.IsNullOrEmpty(model.lastname) || string.IsNullOrEmpty(model.firstname) || model.enrollmentdate == null)
            {
                return BadRequest("Thông tin không hợp lệ.");
            }

            var student = new Student
            {
                lastname = model.lastname,
                firstname = model.firstname,
                enrollmentdate = model.enrollmentdate
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var kq = new Student_CreateRes
            {
                lastname = student.lastname,
                firstname = student.firstname,
                enrollmentdate = student.enrollmentdate
            };

            return Ok(kq);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateStudents(int id, [FromBody] string value)
        {
            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudents(int id)
        {
            return Ok();
        }
    }
}
