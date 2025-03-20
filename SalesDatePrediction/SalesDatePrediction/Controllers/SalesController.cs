using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Models.Sales;
using SalesDatePredictionApp.Data;

namespace SalesDatePredictionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly StoreSampleDbContext _storeSampleDb;

        public SalesController(StoreSampleDbContext storeSampleDb)
        {
            _storeSampleDb = storeSampleDb;
        }

        [HttpGet("clientorders")]
        public async Task<ActionResult<List<ClientOrder>>> GetClientOrders()
        {
            if (_storeSampleDb.ClientOrder is null)
            {
                return NotFound();
            }

            return await _storeSampleDb.Set<ClientOrder>().ToListAsync();
        }

        [HttpGet("shippers")]
        public async Task<ActionResult<List<Shipper>>> GetShippers()
        {
            if (_storeSampleDb.Shipper is null)
            {
                return NotFound();
            }

            return await _storeSampleDb.Set<Shipper>().ToListAsync();
        }

        [HttpGet("sales-date-prediction")]
        public async Task<ActionResult<List<SalesDatePrediction>>> GetSalesDatePrediction()
        {
            if (_storeSampleDb.SalesDatePrediction is null)
            {
                return NotFound();
            }

            return await _storeSampleDb.Set<SalesDatePrediction>().ToListAsync();
        }

        [HttpPost("sales-date-prediction")]
        public async Task<ActionResult<bool>> AddNewOrder([FromBody] ProductOrder productOrder)
        {
            try
            {                
                await _storeSampleDb.Database.ExecuteSqlRawAsync("EXEC AddNewOrder @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13", 
                    new object[] { 
                        productOrder.EmpId,
                        productOrder.ShipperId,
                        productOrder.ShipName,
                        productOrder.ShipAddress,
                        productOrder.ShipCity,
                        productOrder.OrderDate,
                        productOrder.RequiredDate,
                        productOrder.ShippedDate,
                        productOrder.Freight,
                        productOrder.ShipCountry,
                        productOrder.ProductId,
                        productOrder.UnitPrice,
                        productOrder.Qty,
                        productOrder.Discount,   
                    });
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }            
        }
    }
}
