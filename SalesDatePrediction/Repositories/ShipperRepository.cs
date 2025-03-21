using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreSampleDbContext _dbContext;

        public ShipperRepository(StoreSampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Shipper>> GetShippers()
        {            
            return await _dbContext.Set<Shipper>().ToListAsync();
        }
    }
}
