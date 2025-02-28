using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class DangNhap : System.Web.UI.Page
    {
        TaiKhoanDAO tkDAO = new TaiKhoanDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (tkDAO.checkLogin(username, password)) //thanh cong
            {
                Session[" username "] = username;
                Response.Redirect(" Default.aspx");
            }
            else //that bai
            {
                lblThongBao.Text =" Đăng nhập thất bại do sai tên hoặc mật khẩu." ;
            }
        }
    }
}