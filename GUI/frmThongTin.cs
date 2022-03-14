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
    public partial class frmThongTin : Form
    {
        public frmThongTin()
        {
            InitializeComponent();
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtNhapLaiMatKhau.PasswordChar = '*';
            txtMatKhauCu.MaxLength = txtMatKhauMoi.MaxLength = txtNhapLaiMatKhau.MaxLength = 10;
        }

        private void btnLuuThayDoi_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMatKhauMoi, "");
            errorProvider1.SetError(txtMatKhauCu, "");
            errorProvider1.SetError(txtNhapLaiMatKhau, "");

            
            if (txtMatKhauCu.Text == "")
            {
                errorProvider1.SetError(txtMatKhauCu, "Bạn chưa nhập mật khẩu cũ");
                return;
            }
            if (txtMatKhauMoi.Text == "")
            {
                errorProvider1.SetError(txtMatKhauMoi, "Bạn chưa nhập mật khẩu mới");
                return;
            }
            if (txtMatKhauMoi.Text == "" && txtNhapLaiMatKhau.Text == "" && txtMatKhauCu.Text == "")
            {                                                
                errorProvider1.SetError(txtNhapLaiMatKhau, "Bạn chưa nhập mật khẩu");
                return;
            }          
            else
            {
                TaiKhoanBLL tkbll = new TaiKhoanBLL();

                List<TaiKhoan> dstk = tkbll.GetAllTaiKhoan();
                foreach (TaiKhoan tk in dstk)
                {
                    if (txtTaiKhoan1.Text == tk.Ten)
                    {
                        if (txtMatKhauCu.Text == tk.Matkhau)
                        {

                            if (txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
                            {

                                tk.Matkhau = txtNhapLaiMatKhau.Text;

                                bool kq = tkbll.ThayDoiMatKhau(tk);
                                MessageBox.Show("Bạn đã thay đổi mật khẩu thành công!!");
                                this.Close();
                            }
                            else
                            {
                                errorProvider1.SetError(txtNhapLaiMatKhau, "Mật khẩu chưa trùng khớp");
                                break;
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(txtMatKhauCu, "Mật khẩu cũ chưa chính xác");
                            break;
                        }
                    }
                }

            }


        }
        private void buttonX2_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát không?", "hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (ret == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked == true)
            {
                txtMatKhauMoi.PasswordChar = (char)0;
                txtNhapLaiMatKhau.PasswordChar = (char)0;
                txtMatKhauCu.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhauMoi.PasswordChar = '*';
                txtNhapLaiMatKhau.PasswordChar = '*';
                txtMatKhauCu.PasswordChar = '*';
            }
        }
    }
}
