using NUnit.Framework.Internal.Execution;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public interface ICustomerOrderService
    {
        Task<ServiceResponse<List<SalesDatePrediction>>> GetSalesDatePredictionsAsync();
        Task<ServiceResponse<List<SalesDatePrediction>>> GetSalesDatePredictionsAsync(string word);
    }
}
