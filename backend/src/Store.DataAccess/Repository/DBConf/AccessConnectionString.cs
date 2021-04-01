using Microsoft.Extensions.Options;

namespace Store.DataAccess.Repository.DBConf
{
    public class AccessConnectionString :IAccessConnectionString
    {
        private IOptions<ConnectionString> _connectionString { get; set; }
        public AccessConnectionString(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString;
        }
        public string ComposeDbConnection()
        {
            if(_connectionString.Value.Environment.Equals("Dev"))
            {
                return _connectionString.Value.Dev;

            }
            else if (_connectionString.Value.Environment.Equals("Qa"))
            {
                return _connectionString.Value.Qa;

            }
            else if (_connectionString.Value.Environment.Equals("Uat"))
            {
                return _connectionString.Value.Uat;

            }
            else if (_connectionString.Value.Environment.Equals("Prod"))
            {
                return _connectionString.Value.Prod;
            }
            else
            {
                return _connectionString.Value.Local;
            }
        }
    }
  
}
