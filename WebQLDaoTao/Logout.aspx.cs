//using System;
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
//            string connectionString = ConfigurationManager.ConnectionStrings["QLDaoTaoConnection"].ConnectionString;
//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                string query = "SELECT Role FROM Users WHERE Username=@Username AND Password=@Password";
//                SqlCommand cmd = new SqlCommand(query, conn);
//                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
//                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

//                conn.Open();
//                string role = (string)cmd.ExecuteScalar();

//                if (role != null)
//                {
//                    FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
//                    Session["Role"] = role;
//                    if (role == "CanBo")
//                        Response.Redirect("QLKhoa.aspx");
//                    else
//                        Response.Redirect("DK.aspx");
//                }
//                else
//                {
//                    lblMessage.Text = "Sai thông tin đăng nhập!";
//                }
//            }
//        }
//    }
//}