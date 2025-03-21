using NUnit.Framework;
using Moq;
using SalesDatePredictionApp.Controllers;
using SalesDatePredictionApp.Services;
using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionTest
{
    public class SalesControllerTest
    {
        private Mock<IClientOrderService> _clientOrderService;
        private Mock<IShipperService> _shipperService;        
        private Mock<IProductOrderService> _productOrderService;
        private Mock<ICustomerOrderService> _customerOrderService;

        private SalesController _salesController;

        [SetUp]
        public void Init()
        {
            _clientOrderService = new Mock<IClientOrderService>();
            _shipperService = new Mock<IShipperService>();
            _productOrderService = new Mock<IProductOrderService>();
            _customerOrderService = new Mock<ICustomerOrderService>();

            _salesController = new SalesController(_shipperService.Object,_clientOrderService.Object, 
                _productOrderService.Object,_customerOrderService.Object);
        }

        [Test]
        public async Task GetClientOrders_ListEmpty_Success()
        {            
            ActionResult<List<ClientOrder>> actionResult = await _salesController.GetClientOrders();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Result, Is.TypeOf(typeof(OkObjectResult)));
            
        }

        [Test]
        public async Task GetShippers_ListEmpty_Success()
        {
            ActionResult<List<Shipper>> actionResult = await _salesController.GetShippers();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Result, Is.TypeOf(typeof(OkObjectResult)));

        }

        [Test]
        public async Task GetSalesDatePredition_ListEmpty_Success()
        {
            ActionResult<List<SalesDatePrediction>> actionResult = await _salesController.GetSalesDatePrediction();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Result, Is.TypeOf(typeof(OkObjectResult)));

        }

        [Test]
        public async Task AddNewOrder_ListEmpty_Success()
        {
            var mockResponse = new ServiceResponse<ProductOrder>();
            _productOrderService.Setup(x => x.AddNewOrder(It.IsAny<ProductOrder>())).Returns(Task.FromResult(mockResponse));
            
            ActionResult<ProductOrder> actionResult = await _salesController.AddNewOrder(new());
            
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Result, Is.TypeOf(typeof(OkObjectResult)));

        }
    }
}
