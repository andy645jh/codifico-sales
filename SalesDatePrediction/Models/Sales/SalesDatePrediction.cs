namespace SalesDatePredictionApp.Models.Sales
{
    public class SalesDatePrediction
    {
        public int CustId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}
