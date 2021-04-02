namespace Store.Core.ViewEntity
{
    public class AppUserModel: BaseEntity
    {
        public string LoginName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Contact { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public decimal? Discount { get; set; }


    }
}
