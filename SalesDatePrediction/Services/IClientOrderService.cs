using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public interface IClientOrderService
    {
        Task<ServiceResponse<List<ClientOrder>>> GetClientOrdersAsync();
        Task<ServiceResponse<List<ClientOrder>>> GetClientOrdersAsync(int customerId);
    }
}
