using System;
using System.Collections.Generic;

namespace Store.DataAccess.Repository.Entities
{
    public partial class EstimationLogs
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public decimal Discount { get; set; }
        public decimal PricePerGram { get; set; }
        public decimal Weight { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
