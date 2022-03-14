using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TaiKhoanBLL
    {
        TaiKhoanAccess tka = new TaiKhoanAccess();

        public List<TaiKhoan> GetAllTaiKhoan()
        {
            return tka.GetAllTaiKhoan();
        }

        public bool ThayDoiMatKhau(TaiKhoan tk)
        {
            return tka.ThayDoiMatKhau(tk);
        }

        public bool DangkyTaiKhoan(TaiKhoan tk)
        {

            return tka.DangKyTaiKhoan(tk);

        }
    }
}
