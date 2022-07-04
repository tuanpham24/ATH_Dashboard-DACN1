using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ATH_Dashboard.Connection
{
    public class ConnectDB
    {
        string connStr = "";
        public string getConnect()
        {
            connStr = @"Data Source=ANHTUAN\SQLEXPRESS;Initial Catalog=QL_ATH;Integrated Security=True";
            return connStr;
        }

        public SqlConnection connect()
        {
            return new SqlConnection(getConnect());
        }
    }
}
