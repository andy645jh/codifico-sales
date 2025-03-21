using NUnit.Framework;
using Moq;
using SalesDatePredictionApp.Controllers;
using SalesDatePredictionApp.Services;
using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Models.HR;

namespace SalesDatePredictionTest
{
    public class HrControllerTest
    {
        private Mock<IEmployeeService> _employeeService;

        [SetUp]
        public void Init()
        {
            _employeeService = new Mock<IEmployeeService>();

            var list = new List<Employee>();
            list.Add(new Employee { EmpId = 12, FullName= "Elkin Murillo" });
            var mockResponse = new ServiceResponse<List<Employee>> { Data = list };

            _employeeService.Setup(x => x.GetEmployeesAsync()).Returns(Task.FromResult(mockResponse));
        }

        [Test]
        public async Task GetAllEmployes_NoEmpty_Success()
        {
            var hrController = new HrController(_employeeService.Object);

            ActionResult<List<Employee>> actionResult = await hrController.GetAllEmployeesAsync();

            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult.Result, Is.Not.Null);
        }
    }
}
