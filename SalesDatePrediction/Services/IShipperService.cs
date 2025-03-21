using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Services
{
    public interface IShipperService
    {
        Task<ServiceResponse<List<Shipper>>> GetShippersAsync();
    }
}
