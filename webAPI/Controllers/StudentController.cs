using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using Microsoft.AspNetCore.Authorization;


namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] // Requires authentication for all endpoints
    public class StudentController : ControllerBase
    {
        private readonly StudentManagementContext context;

        public StudentController(StudentManagementContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var students = await context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id,Student std)
        {
            if (id != std.Id)
            {
                return BadRequest("Invalid request or ID mismatch");
            }
            context.Entry(std).State = EntityState.Modified; // it will update the state of same field
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var students = await context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            context.Students.Remove(students);
            await context.SaveChangesAsync();
            return Ok(students);
        }
    }
}
