using System;

namespace Store.DataAccess.Repository.Entities
{
    public partial class EstimationLogs
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public double Discount { get; set; }
        public double PricePerGram { get; set; }
        public double Weight { get; set; }
        public double TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
