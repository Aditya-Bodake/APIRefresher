using APIRefresher.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRefresher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("id")]
        
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var emp =  await _context.Employees.FindAsync(id);
            if(emp == null) return NotFound();
            return Ok(emp);

        }

        [HttpPost("add")]
        public async Task<ActionResult<Employee>> AddEmployee(Employee emp)
        {
            var employee = new Employee{
                LastName = emp.LastName,
                FirstName = emp.FirstName,
                BirthDate = emp.BirthDate,
                Notes = emp.Notes
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);


        }

         
    }
}
