using NUnit.Framework;
using Moq;
using SalesDatePredictionApp.Controllers;
using SalesDatePredictionApp.Services;
using SalesDatePredictionApp.Models.Production;
using Microsoft.AspNetCore.Mvc;

namespace SalesDatePredictionTest
{
    public class ProductionControllerTest
    {        
        private Mock<IProductService> _productService;

        [SetUp]
        public void Init()
        {
            _productService = new Mock<IProductService>();

            var list = new List<Product>();
            list.Add(new Product { ProductId = 12, ProductName = "Test" });
            var mockResponse = new ServiceResponse<List<Product>>{ Data = list};

            _productService.Setup(x => x.GetProductsAsync()).Returns(Task.FromResult(mockResponse));   
        }

        [Test]
        public async Task GetAllProducts_NoEmpty()
        {
            var productController = new ProductionController(_productService.Object);
                        
            ActionResult<List<Product>> actionResult = await productController.GetAllProducts();
                        
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Result, Is.Not.Null);
        }
    }
}
