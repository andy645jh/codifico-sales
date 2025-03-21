using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Data;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public interface IProductOrderRepository
    {
        Task<ProductOrder> AddNewOrder(ProductOrder productOrder);
    }
}
