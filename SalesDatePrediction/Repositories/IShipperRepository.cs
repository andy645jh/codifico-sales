using SalesDatePredictionApp.Models.Sales;

namespace SalesDatePredictionApp.Repositories
{
    public interface IShipperRepository
    {
        Task<ICollection<Shipper>> GetShippers();
    }
}
