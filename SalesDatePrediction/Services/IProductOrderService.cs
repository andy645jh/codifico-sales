
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public interface IProductOrderService
    {
        Task<ServiceResponse<ProductOrder>> AddNewOrder(ProductOrder productOrder);
    }
}
