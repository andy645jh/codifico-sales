using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionApp.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResponse<List<Employee>>> GetEmployeesAsync();
    }
}
