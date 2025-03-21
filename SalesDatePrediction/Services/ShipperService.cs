using SalesDatePredictionApp.Repositories;
using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {            
            _shipperRepository = shipperRepository;
        }

        public async Task<ServiceResponse<List<Shipper>>> GetShippersAsync()
        {
            ServiceResponse<List<Shipper>> response = new();

            try
            {
                var employeesList = await _shipperRepository.GetShippers();
                response.Success = true;
                response.Message = "ok";
                response.Data = employeesList.ToList();
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
