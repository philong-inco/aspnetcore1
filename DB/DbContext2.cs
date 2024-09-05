using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace NetCrud2.DB
{
    public class DbContext2
    {
        private OracleConnection _cn;
        private readonly string _connectString;

        public DbContext2(IConfiguration configuration)
        {
            _connectString = configuration.GetConnectionString("OracleDbContext");
        }

        public OracleConnection GetConnection()
        {
            if (null == _cn)
                _cn = new OracleConnection(_connectString);
            return _cn;
        }

        public void Open()
        {
            if (_cn.State != ConnectionState.Open)
                _cn.Open();
        }

        public void Close()
        {
            if (_cn.State != ConnectionState.Closed)
                _cn.Close();
        }
    }
}
