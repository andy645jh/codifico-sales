using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Models.Sales;
using SalesDatePredictionApp.Services;

namespace SalesDatePredictionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        private readonly IClientOrderService _clientOrderService;
        private readonly IProductOrderService _productOrderService;
        private readonly ICustomerOrderService _customerOrderService;

        public SalesController(IShipperService shipperService, IClientOrderService clientOrderService, IProductOrderService productOrderService, ICustomerOrderService customerOrderService )
        {
            _shipperService = shipperService;
            _clientOrderService = clientOrderService;
            _productOrderService = productOrderService;
            _customerOrderService = customerOrderService;
        }

        [HttpGet("clientorders")]
        public async Task<ActionResult<List<ClientOrder>>> GetClientOrders()
        {
            var clientOrders = await _clientOrderService.GetClientOrdersAsync();
            return Ok(clientOrders);            
        }

        [HttpGet("shippers")]
        public async Task<ActionResult<List<Shipper>>> GetShippers()
        {
            var shippers = await _shipperService.GetShippersAsync();
            return Ok(shippers);
        }

        [HttpGet("sales-date-prediction")]
        public async Task<ActionResult<List<SalesDatePrediction>>> GetSalesDatePrediction()
        {
            var salesPredictions = await _customerOrderService.GetSalesDatePredictionsAsync();
            return Ok(salesPredictions);           
        }

        [HttpGet("sales-date-prediction/{word}")]
        public async Task<ActionResult<List<SalesDatePrediction>>> GetSalesDatePrediction(string word)
        {
            var salesPredictions = await _customerOrderService.GetSalesDatePredictionsAsync(word);
            return Ok(salesPredictions);
        }

        [HttpPost("add-new-order")]
        public async Task<ActionResult<ProductOrder>> AddNewOrder([FromBody] ProductOrder productOrder)
        {
            var newProductOrder = await _productOrderService.AddNewOrder(productOrder);
            return Ok(newProductOrder);
        }
    }
}
