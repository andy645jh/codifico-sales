using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public interface ICustomerOrderService
    {
        Task<ServiceResponse<List<SalesDatePrediction>>> GetSalesDatePredictionsAsync();
    }
}
