using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class SinhVienDAO
    {
        public List<SinhVien> getAll()
        {
            List<SinhVien> dsSinhVien = new List<SinhVien>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhVien", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                SinhVien sv = new SinhVien { MaSV = dr["MaSV"].ToString(), HoSV = dr["HoSV"].ToString(), TenSV = dr["TenSV"].ToString(), GioiTinh = Boolean.Parse(dr["GioiTinh"].ToString()), NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()), NoiSinh = dr["NoiSinh"].ToString(), DiaChi = dr["DiaChi"].ToString(), MaKH = dr["MaKH"].ToString() };
                dsSinhVien.Add(sv);
            }
            return dsSinhVien;

        }
        public int Update(SinhVien sv)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update sinhvien set hosv=@hosv, tensv=@tensv, gioitinh=@gioitinh, ngaysinh = @ngaysinh, noisinh = @noisinh, diachi = @diachi, makh = @makh where masv = @masv", conn);
            cmd.Parameters.AddWithValue("@masv", sv.MaSV);
            cmd.Parameters.AddWithValue("@hosv", sv.HoSV);
            cmd.Parameters.AddWithValue("@tensv", sv.TenSV);
            cmd.Parameters.AddWithValue("@gioitinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@ngaysinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@noisinh", sv.NoiSinh);
            cmd.Parameters.AddWithValue("@diachi", sv.DiaChi);
            cmd.Parameters.AddWithValue("@makh", sv.MaKH);
            return cmd.ExecuteNonQuery();
        }
        public int Delete(SinhVien sv)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from SinhVien where masv=@masv", conn);
            cmd.Parameters.AddWithValue("@masv", sv.MaSV);
            return cmd.ExecuteNonQuery();
        }
        public int Insert(SinhVien sv)
        {
            SqlConnection conn = new
            SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into sinhvien (masv, hosv, tensv, gioitinh, ngaysinh, noisinh, diachi, makh) values(@masv, @hosv, @tensv, @gioitinh, @ngaysinh, @noisinh, @diachi, @makh)", conn);
            cmd.Parameters.AddWithValue("@masv", sv.MaSV);
            cmd.Parameters.AddWithValue("@hosv", sv.HoSV);
            cmd.Parameters.AddWithValue("@tensv", sv.TenSV);
            cmd.Parameters.AddWithValue("@gioitinh", sv.GioiTinh);
            cmd.Parameters.AddWithValue("@ngaysinh", sv.NgaySinh);
            cmd.Parameters.AddWithValue("@noisinh", sv.NoiSinh);
            cmd.Parameters.AddWithValue("@diachi", sv.DiaChi);
            cmd.Parameters.AddWithValue("@makh", sv.MaKH);
            return cmd.ExecuteNonQuery();
        }
        public SinhVien findById(string masv)
        {
            SinhVien kq = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from SinhVien where masv=@masv", conn);
            cmd.Parameters.AddWithValue("@masv", masv);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                kq = new SinhVien { MaSV = dr["MaSV"].ToString(), HoSV = dr["HoSV"].ToString(), TenSV = dr["TenSV"].ToString(), GioiTinh = Boolean.Parse(dr["GioiTinh"].ToString()), NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString()), NoiSinh = dr["NoiSinh"].ToString(), DiaChi = dr["DiaChi"].ToString(), MaKH = dr["MaKH"].ToString() };
            }
            return kq;
        }
        public List<Khoa> GetAllKhoaNames()
        {
            List<Khoa> khoaList = new List<Khoa>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebQLDaoTao_ConStr"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MaKH, TenKH FROM Khoa", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Khoa khoa = new Khoa
                {
                    MaKH = dr["MaKH"].ToString(),
                    TenKH = dr["TenKH"].ToString()
                };
                khoaList.Add(khoa);
            }
            return khoaList;
        }
    }
}