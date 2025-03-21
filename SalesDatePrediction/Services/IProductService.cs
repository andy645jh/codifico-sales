using SalesDatePredictionApp.Models.Production;

namespace SalesDatePredictionApp.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
    }
}
