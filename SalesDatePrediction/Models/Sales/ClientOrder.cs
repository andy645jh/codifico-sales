namespace SalesDatePredictionApp.Models.Sales
{
    public class ClientOrder
    {
        public int CustId { get; set; }
        public int OrderId { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }        
    }
}
