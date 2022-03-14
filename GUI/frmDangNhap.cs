using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.MaxLength = 10;

        }
        TaiKhoanBLL tkbll = new TaiKhoanBLL();

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                List<TaiKhoan> dstk = tkbll.GetAllTaiKhoan();

                foreach (TaiKhoan tk in dstk)
                {
                    if (tk.Ten == txtTaiKhoan.Text && tk.Matkhau == txtMatKhau.Text)
                    {

                        frmThongTin frmthongtin = new frmThongTin();
                        frmthongtin.Text = txtTaiKhoan.Text;
                        frmthongtin.txtTaiKhoan1.Text = txtTaiKhoan.Text;

                        frmthongtin.ShowDialog();
                        break;

                    }
                }
            }
            

        }

        
        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == true)
            {
                txtTaiKhoan.Text = txtTaiKhoan.Text;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool KiemTra()
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                return false;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu");
                return false;
            }
            return true;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                List<TaiKhoan> dstk = new List<TaiKhoan>();
                TaiKhoan tk = new TaiKhoan();
                tk.Ten = txtTaiKhoan.Text;
                tk.Matkhau = txtMatKhau.Text;
                dstk.Add(tk);
                try
                {
                    bool kq = tkbll.DangkyTaiKhoan(tk);
                    MessageBox.Show("Đăng ký thành công.");
                    /*dstk = tkbll.GetAllTaiKhoan();*/
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                }
                catch
                {
                    MessageBox.Show("Tên Tài Khoản Đã Tồn Tại");
                }
            }


        }
    }
}
