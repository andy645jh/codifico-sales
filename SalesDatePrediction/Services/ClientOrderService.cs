using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Models.HR;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public class ClientOrderService : IClientOrderService
    {        
        private readonly IClientOrderRepository _clientOrderRepository;

        public ClientOrderService(IClientOrderRepository clientOrderRepository)
        {
            _clientOrderRepository = clientOrderRepository;
        }

        public async Task<ServiceResponse<List<ClientOrder>>> GetClientOrdersAsync()
        {
            ServiceResponse<List<ClientOrder>> response = new();

            try
            {
                var clientOrdersList = await _clientOrderRepository.GetClientOrders();
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
    }
}
