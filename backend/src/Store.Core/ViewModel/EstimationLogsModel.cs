namespace Store.Core.ViewEntity
{
    public class EstimationLogsModel: BaseEntity
    {
        public long AppUserId { get; set; }
        public double PricePerGram { get; set; }
        public double Weight { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }

    }
}
