using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class TaiKhoanDAO
    {
        SqlCommand cmd;
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            return conn;
        }
        //hàm kiểm tra tra tồn tại
        public bool checkLogin(string username, string password)
        {
            bool kq = false;
            var conn = Connect();
            conn.Open();
            cmd = new SqlCommand("select* from taikhoan where tendangnhap = @tendangnhap and matkhau = @matkhau", conn);
            cmd.Parameters.AddWithValue("@tendangnhap", username);
            cmd.Parameters.AddWithValue("@matkhau", password);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
                kq = true; //success
            return kq;
        }
    }
}