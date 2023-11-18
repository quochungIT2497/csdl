using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace csdl.Model
{
    class Connection
    {

        private static string strconnect = @"Data Source=SITD-LAB02-S04\SQLEXPRESS;Initial Catalog=QL_BanHang;Integrated Security=True;";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(strconnect);
        }
    }
}
