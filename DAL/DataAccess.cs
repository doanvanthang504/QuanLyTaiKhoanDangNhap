using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DataAccess
    {
        public string strConn = "Server=TV-STRAIGHT; database=CSDL_QuanLyTaiKhoanDangNhap; user id=sa;pwd=123456";
        public SqlConnection sqlConn = null;

        public void OpenConnection()
        {
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection(strConn);
            }
            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
        }
        public void closeConnection()
        {
            if(sqlConn!=null && sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
        }


    }
}
