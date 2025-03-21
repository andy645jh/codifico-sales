using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public interface IClientOrderRepository
    {
        Task<ICollection<ClientOrder>> GetClientOrders();        
    }
}
