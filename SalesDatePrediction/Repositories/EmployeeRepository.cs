using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreSampleDbContext _dbContext;

        public EmployeeRepository(StoreSampleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Employee>> GetAllEmployees()
        {            
            return await _dbContext.Set<Employee>().ToListAsync();
        }
    }
}
