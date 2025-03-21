namespace SalesDatePredictionApp.Models.Sales
{
    public class SalesDatePrediction
    {
        public string? CustomerName { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public DateTime? NextPredictedOrder { get; set; }
    }
}
