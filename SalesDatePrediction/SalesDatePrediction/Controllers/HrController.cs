using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : ControllerBase
    {
        private readonly StoreSampleDbContext _storeSampleDb;

        public HrController(StoreSampleDbContext storeSampleDb)
        {
            _storeSampleDb = storeSampleDb;
        }        

        [HttpGet("employees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            if(_storeSampleDb.Employee is null)
            {
                return NotFound();
            }

            return await _storeSampleDb.Set<Employee>().ToListAsync();
        }
    }

}
