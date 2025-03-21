using SalesDatePredictionApp.Models.Production;

namespace SalesDatePredictionApp.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAllProducts();
    }
}
