using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIX.IRepository;
using WebAPIX.Model;

namespace WebAPIX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var emp = await _employeeRepo.GetEmployee();

                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateCompanies([FromBody] Employee employee)
        {
            try
            {
                var emp = await this._employeeRepo.CreateEmployee(employee);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateCompanies([FromBody] Employee employee, int Id)
        {
            try
            {
                var emp = await this._employeeRepo.UpdateEmployee(employee, Id);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteCompanies([FromBody] int Id)
        {
            try
            {
                var emp = await this._employeeRepo.DeleteEmployee(Id);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
