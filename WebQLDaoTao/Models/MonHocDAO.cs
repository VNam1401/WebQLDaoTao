using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class MonHocDAO
    {
        //--------doc danh sach cac môn học trong CSDL-----------------
        public List<MonHoc> getAll()
        {
            List<MonHoc> dsMonHoc = new List<MonHoc>();
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("select * from Monhoc", conn);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            while (dr.Read())
            {
                //tao doi tuong mon hoc
                MonHoc mh = new MonHoc
                {
                    MaMH = dr["MaMH"].ToString(),
                    TenMH = dr["TenMH"].ToString(),
                    SoTiet = int.Parse(dr["SoTiet"].ToString())
                };

                //add vao dsMonHoc
                dsMonHoc.Add(mh);
            }
            return dsMonHoc;
        }
        //--------phuong thuc cap nhat thong tin mon hoc-----------------
        public int Update(string mamh, string tenmh, int sotiet)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("update monhoc set tenmh=@tenmh, sotiet=@sotiet wheremamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@tenmh", tenmh);
            cmd.Parameters.AddWithValue("@sotiet", sotiet);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }

        //-----dinh nghia các phương thức thực hiện các thao tác khác -----
        //them
        //xoa
        public int Delete(string mamh)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("delete from monhoc where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        //--------phuong thuc them mon hoc vào CSDL-----------------
        public int Insert(string mamh, string tenmh, int sotiet)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("insert into monhoc (mamh, tenmh,sotiet) values (@mamh,@tenmh,@sotiet)", conn);
        cmd.Parameters.AddWithValue("@mamh", mamh);
            cmd.Parameters.AddWithValue("@tenmh", tenmh);
            cmd.Parameters.AddWithValue("@sotiet", sotiet);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        //tim mon hoc theo ma
        public MonHoc findById(string mamh)
        {
            MonHoc kq = null;
            //1.Mo ket noi CSDL
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("select * from Monhoc where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            if (dr.Read())
            {
                //tao doi tuong mon hoc
                kq = new MonHoc
                {
                    MaMH = dr["MaMH"].ToString(),
                    TenMH = dr["TenMH"].ToString(),
                    SoTiet = int.Parse(dr["SoTiet"].ToString())
                };
            }
            return kq;
        }

        //....
    }
}