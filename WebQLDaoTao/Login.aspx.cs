﻿//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using WebQLDaoTao.Models;

//namespace WebQLDaoTao
//{
//    public partial class Login : System.Web.UI.Page
//    {
//        protected void btnLogin_Click(object sender, EventArgs e)
//        {
//            string connectionString = ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString;
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                string query = "SELECT taikhoan FROM Users WHERE Username=@Username AND Password=@Password";
//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
//                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

//                conn.Open();
//                string taikhoan = (string)cmd.ExecuteScalar();

//                if (taikhoan != null)
//                {
//                    FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
//                    Session["taikhoan"] = taikhoan;
//                    if (taikhoan == "CanBo")
//                        Response.Redirect("QLKhoa.aspx");
//                    else
//                        Response.Redirect("Logout.aspx");
//                }
//                else
//                {
//                    lblMessage.Text = "Sai thông tin đăng nhập!";
//                }
//            }
//        }
//    }
//}