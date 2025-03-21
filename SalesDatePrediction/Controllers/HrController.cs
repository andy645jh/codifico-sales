using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Services;
using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : ControllerBase
    {        
        private readonly IEmployeeService _employeeService;

        public HrController(IEmployeeService employeeService)
        {     
            _employeeService = employeeService;
        }        

        [HttpGet("employees")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Employee>))]
        public async Task<ActionResult<List<Employee>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }
    }

}
