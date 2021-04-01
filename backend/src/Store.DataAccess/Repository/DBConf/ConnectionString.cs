namespace Store.DataAccess.Repository.DBConf
{
    public class ConnectionString
    {
        public string Environment { get; set; }
        public string Dev { get; set; }
        public string Qa { get; set; }
        public string Uat { get; set; }
        public string Prod { get; set; }
        public string Local { get; set; }
    }
}
