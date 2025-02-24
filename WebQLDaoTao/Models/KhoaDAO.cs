using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQLDaoTao.Models
{
    public class KhoaDAO
    {
        //--------doc danh sach cac khoa trong CSDL-----------------
        public List<Khoa> getAll()
        {
            List<Khoa> dsKhoa = new List<Khoa>();
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("select * from Khoa", conn);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            while (dr.Read())
            {
                //tao doi tuong mon hoc
                Khoa kh = new Khoa
                {
                    MaKH = dr["MaKH"].ToString(),
                    TenKH = dr["TenKH"].ToString()
                };
                //add vao dsMonHoc
                dsKhoa.Add(kh);
            }
            return dsKhoa;
        }
        //--------phuong thuc cap nhat thong tin khoa-----------------
        public int Update(string makh, string tenkh)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("update khoa set tenkh=@tenkh where makh=@makh", conn);
            cmd.Parameters.AddWithValue("@tenkh", tenkh);
            cmd.Parameters.AddWithValue("@makh", makh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        //-----dinh nghia phương thức xóa khoa theo mã -----
        public int Delete(string makh)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("delete from khoa where makh=@makh", conn);
            cmd.Parameters.AddWithValue("@makh", makh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        //--------phuong thuc them 1 khoa vào CSDL-----------------
        public int Insert(string makh, string tenkh)
        {
            //1.Mo ket noi CSDL

            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("insert into khoa (makh, tenkh) values (@makh,@tenkh)", conn);
            cmd.Parameters.AddWithValue("@makh", makh);
            cmd.Parameters.AddWithValue("@tenkh", tenkh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        //tim khoa theo ma
        public Khoa findById(string makh)
        {
            Khoa kq = null;
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("select * from Khoa where makh=@makh", conn);
            cmd.Parameters.AddWithValue("@makh", makh);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            if (dr.Read())
            {
                //tao doi tuong mon hoc
                kq = new Khoa
                {
                    MaKH = dr["MaKH"].ToString(),
                    TenKH = dr["TenKH"].ToString()
                };
            }
            return kq;
        }
        //....
    }
}
