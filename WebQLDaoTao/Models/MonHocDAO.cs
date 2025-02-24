using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace WebQLDaoTao.Models
{
    public class MonHocDAO
    {
        public List<MonHoc> getAll()
        {
            //Khai báo sql
            List<MonHoc> dsMonHoc = new List<MonHoc>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Monhoc", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MonHoc mh = new MonHoc
                {
                    MaMH = dr["MaMH"].ToString(),
                    TenMH = dr["TenMH"].ToString(),
                    SoTiet = int.Parse(dr["SoTiet"].ToString())
                };
                dsMonHoc.Add(mh);
            }
            conn.Close();
            return dsMonHoc;
        }

        public int Update(string mamh, string tenmh, int sotiet)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update monhoc set tenmh = @tenmh, sotiet = @sotiet where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@tenmh", tenmh);
            cmd.Parameters.AddWithValue("@sotiet", sotiet);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int Insert(string mamh, string tenmh, int sotiet)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into monhoc (mamh, tenmh, sotiet) values (@mamh, @tenmh, @sotiet)", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            cmd.Parameters.AddWithValue("@tenmh", tenmh);
            cmd.Parameters.AddWithValue("@sotiet", sotiet);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public int Delete(string mamh)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from monhoc where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        public MonHoc findById(string mamh)
        {
            MonHoc mh = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Monhoc where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mh = new MonHoc
                {
                    MaMH = dr["MaMH"].ToString(),
                    TenMH = dr["TenMH"].ToString(),
                    SoTiet = int.Parse(dr["SoTiet"].ToString())
                };
            }
            conn.Close();
            return mh;
        }
    }
}