using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Models.HR;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {        
        private readonly ICustomerOrderRepository _customerOrderRepository;

        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository)
        {
            _customerOrderRepository = customerOrderRepository;
        }

        public async Task<ServiceResponse<List<SalesDatePrediction>>> GetSalesDatePredictionsAsync()
        {
            ServiceResponse<List<SalesDatePrediction>> response = new();

            try
            {
                var clientOrdersList = await _customerOrderRepository.GetSalesDatePredictionsAsync();
                response.Success = true;
                response.Message = "ok";
                response.Data = clientOrdersList.ToList();
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

        public async Task<ServiceResponse<List<SalesDatePrediction>>> GetSalesDatePredictionsAsync(string word)
        {
            ServiceResponse<List<SalesDatePrediction>> response = new();

            try
            {
                var clientOrdersList = await _customerOrderRepository.GetSalesDatePredictionsAsync();
                var filteredList  = clientOrdersList.Where(x => !string.IsNullOrEmpty(x.CustomerName) && x.CustomerName.Contains(word));
                response.Success = true;
                response.Message = "ok";
                response.Data = filteredList.ToList();
            }
            catch (Exception ex)
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
