using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly StoreSampleDbContext _dbContext;

        public CustomerOrderRepository(StoreSampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<SalesDatePrediction>> GetSalesDatePredictionsAsync()
        {
            return await _dbContext.Set<SalesDatePrediction>().ToListAsync();
        }
    }
}
