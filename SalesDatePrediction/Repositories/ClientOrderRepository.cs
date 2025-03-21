using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public class ClientOrderRepository : IClientOrderRepository
    {
        private readonly StoreSampleDbContext _dbContext;

        public ClientOrderRepository(StoreSampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<ClientOrder>> GetClientOrders()
        {
            return await _dbContext.Set<ClientOrder>().ToListAsync();
        }
    }
}
