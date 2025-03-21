using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ServiceResponse<List<Employee>>> GetEmployeesAsync()
        {
            ServiceResponse<List<Employee>> response = new();

            try
            {
                var employeesList = await _employeeRepository.GetAllEmployees();
                response.Success = true;
                response.Message = "ok";
                response.Data = employeesList.ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.Data = null;
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }
            return response;
        }
    }
}
