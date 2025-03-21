using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public interface ICustomerOrderRepository
    {
        Task<ICollection<SalesDatePrediction>> GetSalesDatePredictionsAsync();        
    }
}
