using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebQLDaoTao.Models
{
    internal interface IKetQuaDAO
    {
        List<KetQua> getByMaMH(string mamh);
        int Update(int Id, float diem);
    }

    public class KetQuaDAO : IKetQuaDAO
    {
        public List<KetQua> getByMaMH(string mamh)
        {
            List<KetQua> dsKetQua = new List<KetQua>();
            //1.Mo ket noi CSDL
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("SELECT ID, KetQua.MASV, MAMH, DIEM, HOSV, TENSV FROM KetQua INNER JOIN SinhVien ON KetQua.MASV = SinhVien.MASV where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            while (dr.Read())
            {
                //tao doi tuong ketqua
                KetQua kq = new KetQua();
                kq.Id = int.Parse(dr["Id"].ToString());
                kq.MaSV = dr["Masv"].ToString();
                kq.MaMH = dr["mamh"].ToString();
                kq.Diem = string.IsNullOrEmpty(dr["diem"].ToString()) ? 0 : float.Parse(dr["diem"].ToString());
                kq.HoTenSV = dr["hosv"] + " " + dr["tensv"];
                //add vao list
                dsKetQua.Add(kq);
            }
            return dsKetQua;
        }

        public int Update(int Id, float diem)
        {
            //1.Mo ket noi CSDL
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            //2.tao truy van
            SqlCommand cmd = new SqlCommand("update ketqua set diem=@diem where id=@id", conn);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@diem", diem);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
    }
}
