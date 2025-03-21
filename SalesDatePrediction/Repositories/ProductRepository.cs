using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Production;

namespace SalesDatePredictionApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreSampleDbContext _dbContext;

        public ProductRepository(StoreSampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            return await _dbContext.Set<Product>().ToListAsync();
        }
    }
}
