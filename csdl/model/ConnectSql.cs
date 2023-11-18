using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace csdl.model
{
    class ConnectSql
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private string StrCon = null;
        private string _error;

        public ConnectSql()
        {
            StrCon = @"Data Source=SITD-LAB02-S04\SQLEXPRESS;Initial Catalog=QL_BanHang;Integrated Security=True;";
            conn = new SqlConnection(StrCon);
        }

        public string Error 
        { 
            get { return _error; } 
            set { _error = value; } 
        }
        public SqlConnection Connection
        {
            get { return conn; }
        }

        public SqlCommand Cmd
        {
            get { return cmd; }
            set { cmd = value; } 
        }
        public bool Openconn()
        {
            try
            {
                if(conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }
        public bool Closeconn()
        {
            try
            {
                if(conn.State == ConnectionState.Open ) 
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
