using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Data;
using System.Linq;

namespace PostgreSQL.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeApi
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        // GET: api/EmployeeApi/{mobileNumber}
        [HttpGet("mobile/{mobileNumber}")]
        public IActionResult GetEmployeeByMobileNumber(string mobileNumber)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.MobileNumber == mobileNumber);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
