using Store.Core.ViewEntity;
using System;

namespace Store.Core.Tests
{
    public static class ViewModel
    {
        public static AppUserModel AppUserModel = new AppUserModel()
        {
            Id = 1,
            Contact = string.Empty,
            UserName= "Test UserName",
            LoginName= "Test LoginName",
            Discount= 0.0m,
            EmailId= "Test Email",
            Role="Test Role",
            CreatedDate = DateTime.UtcNow,
            UpdatedDate= DateTime.UtcNow,
            IsActive= true
        };


        public static EstimationLogsModel EstimationLogsModel = new EstimationLogsModel()
        {
            Id = 1,
            AppUserId=1,
            PricePerGram= 1.0m,
            TotalPrice=1.1m,
            Weight=1.0m,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            IsActive = true
        };
    }
}
