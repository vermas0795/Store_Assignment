using Store.DataAccess.Repository.Entities;
using System;

namespace Store.Core.Tests
{
    public static class DataEntity
    {
        public static AppUser AppUser = new AppUser()
        {
            Id = 1,
            Contact = string.Empty,
            UserName = "Test UserName",
            LoginName = "Test LoginName",
            EmailId = "Test Email",
            Password= "Test Password",
            Role = new AppRole() { Description = "Test Role", Discount=0.0m},
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            IsActive = true
        };


        public static EstimationLogs EstimationLogs = new EstimationLogs()
        {
            Id = 1,
            AppUserId = 1,
            PricePerGram = 1.0m,
            TotalPrice = 1.1m,
            Weight = 1.0m,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            IsActive = true
        };
    }
}
