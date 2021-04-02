namespace Store.Core.ViewEntity
{
    public class EstimationLogsModel: BaseEntity
    {
        public long AppUserId { get; set; }
        public decimal PricePerGram { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
