using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Production;

namespace SalesDatePredictionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly StoreSampleDbContext _storeSampleDb;

        public ProductionController(StoreSampleDbContext storeSampleDb)
        {
            _storeSampleDb = storeSampleDb;
        }    

        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            if (_storeSampleDb.Product is null)
            {
                return NotFound();
            }

            return await _storeSampleDb.Set<Product>().ToListAsync();
        }
    }
}
