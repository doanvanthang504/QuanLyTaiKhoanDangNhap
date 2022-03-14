using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using System.ComponentModel;


namespace DAL
{
    public class TaiKhoanAccess : DataAccess
    {
        public List<TaiKhoan> GetAllTaiKhoan()
        {
            List<TaiKhoan> dstk = new List<TaiKhoan>();

            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select*from TaiKhoan";
            command.Connection = sqlConn;


            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ten = reader.GetString(0);
                string makhau = reader.GetString(1);

                TaiKhoan tk = new TaiKhoan();
                tk.Ten = ten;
                tk.Matkhau = makhau;
                dstk.Add(tk);
            }
            reader.Close();

            return dstk;
        }

        public bool ThayDoiMatKhau(TaiKhoan tk)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Update TaiKhoan set MatKhau=@matkhau where Ten=@taikhoan";
            command.Connection = sqlConn;

            command.Parameters.Add("@taikhoan", SqlDbType.NVarChar).Value = tk.Ten;
            command.Parameters.Add("@matkhau", SqlDbType.NVarChar).Value = tk.Matkhau;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }


        public bool DangKyTaiKhoan(TaiKhoan tk)
        {

            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into TaiKhoan values(@taikhoan,@matkhau)";
            command.Connection = sqlConn;

            command.Parameters.Add("@taikhoan", SqlDbType.NVarChar).Value = tk.Ten;
            command.Parameters.Add("@matkhau", SqlDbType.NVarChar).Value = tk.Matkhau;

            int kq = command.ExecuteNonQuery();
            return kq > 0;

            if (kq < 0)
            {
                try
                {

                }
                catch
                {
                    
                }
            }


        }

    }
}
