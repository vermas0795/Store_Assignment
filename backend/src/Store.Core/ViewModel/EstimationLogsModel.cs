namespace Store.Core.ViewEntity
{
    public class EstimationLogsModel: BaseEntity
    {
        public long AppUserId { get; set; }
        public string Discount { get; set; }
        public int PricePerGram { get; set; }
        public decimal Weight { get; set; }
        public int TotalPrice { get; set; }
    }
}
