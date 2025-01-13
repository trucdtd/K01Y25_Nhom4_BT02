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
            // Kiểm tra đầu vào không cho phép null
            if (string.IsNullOrEmpty(model.LastName) || string.IsNullOrEmpty(model.FirstName))
            {
                return BadRequest("Thông tin không hợp lệ.");
            }

            // Tạo mới đối tượng sinh viên
            var student = new Student
            {
                Lastname = model.LastName,
                Firstmidname = model.FirstName,
                Enrollmentdate = model.EnrollmentDate, // Không cần kiểm tra EnrollmentDate nữa
            };

            try
            {
                // Thêm vào cơ sở dữ liệu
                _context.Students.Add(student);

                // Lưu thay đổi vào cơ sở dữ liệu
                await _context.SaveChangesAsync();

                // Trả về kết quả
                return Ok($"Sinh viên {model.FirstName} {model.LastName} đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                // Ghi log lỗi vào console hoặc file log
                Console.WriteLine($"Error: {ex.Message}"); // Log lỗi ở đây
                return StatusCode(500, $"Đã xảy ra lỗi trong quá trình xử lý yêu cầu: {ex.Message}");
            }
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
