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
            Discount= 0.0d,
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
            PricePerGram= 1.0d,
            TotalPrice=1.1d,
            Weight=1.0d,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            IsActive = true
        };
    }
}
