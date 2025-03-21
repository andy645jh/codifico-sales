using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Models.Production;

namespace SalesDatePredictionApp.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            ServiceResponse<List<Product>> response = new();

            try
            {
                var productList = await _productRepository.GetAllProducts();
                response.Success = true;
                response.Message = "ok";
                response.Data = productList.ToList();
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
