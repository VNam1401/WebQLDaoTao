using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class KetQuaDAO
    {
        public List<KetQua> getByMaMH(string mamh)
        {
            List<KetQua> dsKetQua = new List<KetQua>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select id, ketqua.masv, hosv, tensv, mamh, diem" +
                " from ketqua inner join sinhvien on ketqua.masv = sinhvien.masv where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                KetQua kq = new KetQua();
                kq.Id = int.Parse(dr["id"].ToString());
                kq.MaSV = dr["masv"].ToString();
                kq.HoTenSV = dr["hosv"] + " " + dr["tensv"];
                kq.MaMH = dr["mamh"].ToString();
                if (dr["diem"] != DBNull.Value)
                {
                    kq.Diem = double.Parse(dr["diem"].ToString());
                }
                dsKetQua.Add(kq);
            }
            return dsKetQua;
        }
        public int Update(int Id, double diem)
        {
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update ketqua set diem=@diem where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@diem", diem);
            return cmd.ExecuteNonQuery();
        }
        public int Delete(int id)
        {
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from ketqua where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }
    }
}