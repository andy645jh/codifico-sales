using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetAllEmployees();
    }
}
