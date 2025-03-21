using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Production;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        private readonly StoreSampleDbContext _dbContext;

        public ProductOrderRepository(StoreSampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductOrder> AddNewOrder(ProductOrder productOrder)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlRawAsync("EXEC AddNewOrder @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13",
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
                return productOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
