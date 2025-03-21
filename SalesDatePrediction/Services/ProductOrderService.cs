using Azure;
using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Models.HR;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IProductOrderRepository _productOrderRepository;

        public ProductOrderService(IProductOrderRepository employeeRepository)
        {     
            _productOrderRepository = employeeRepository;
        }

        public async Task<ServiceResponse<ProductOrder>> AddNewOrder(ProductOrder productOrder)
        {
            ServiceResponse<ProductOrder> response = new();

            try
            {
                var newProductOrder = await _productOrderRepository.AddNewOrder(productOrder);
                response.Success = true;
                response.Message = "Created";
                response.Data = newProductOrder;
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
