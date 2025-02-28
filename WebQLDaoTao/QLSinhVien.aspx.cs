using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLSinhVien : System.Web.UI.Page
    {
        SinhVienDAO svDAO = new SinhVienDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Khoa> khoaNames = svDAO.GetAllKhoaNames();
            ddlMaKhoa.DataSource = khoaNames;
            ddlMaKhoa.DataTextField = "TenKH";
            ddlMaKhoa.DataValueField = "MaKH";
            ddlMaKhoa.DataBind();
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            gv_SinhVien.DataSource = svDAO.getAll();
            gv_SinhVien.DataBind();
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            try
            {

                string masv = txtMaSV.Text;
                if (svDAO.findById(masv) != null)
                {
                    Response.Write("<script>alert('Mã SV đã tồn tại.')</script>");
                    return;
                }
                string hosv = txtHoSv.Text;
                string tensv = txtTenSV.Text;
                Boolean gioitinh = rdNam.Checked ? true : false;
                DateTime ngaysinh = DateTime.Parse(txtNgaysinh.Text);
                string noisinh = txtNoiSinh.Text;
                string diachi = txtDiaChi.Text;
                string makh = ddlMaKhoa.SelectedValue;
                SinhVien svInsert = new SinhVien { MaSV = masv, HoSV = hosv, TenSV = tensv, GioiTinh = gioitinh, NgaySinh = ngaysinh, NoiSinh = noisinh, DiaChi = diachi, MaKH = makh };
                svDAO.Insert(svInsert);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Thêm không thành công.')</script>");
            }
            LoadData();
        }

        protected void gv_SinhVien_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_SinhVien.EditIndex = e.NewEditIndex;
            gv_SinhVien.DataSource = svDAO.getAll();
            gv_SinhVien.DataBind();
        }

        protected void gv_SinhVien_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_SinhVien.EditIndex = -1;
            gv_SinhVien.DataSource = svDAO.getAll();
            gv_SinhVien.DataBind();
        }

        protected void gv_SinhVien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string masv = gv_SinhVien.DataKeys[e.RowIndex].Value.ToString();
                SinhVien sv = svDAO.findById(masv);
                if (sv != null)
                {
                    svDAO.Delete(sv);
                    LoadData();
                }
                else
                {
                    Response.Write("<script>alert('Sinh viên không tồn tại.')</script>");
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Không thể xoá sinh viên này')</script>");
            }
        }

        protected void gv_SinhVien_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string masv = gv_SinhVien.DataKeys[e.RowIndex].Value.ToString();
            string hosv = ((TextBox)gv_SinhVien.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string tensv = ((TextBox)gv_SinhVien.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            bool gioitinh = ((CheckBox)gv_SinhVien.Rows[e.RowIndex].Cells[3].Controls[0]).Checked ? true : false;
            DateTime ngaysinh = DateTime.Parse(((TextBox)gv_SinhVien.Rows[e.RowIndex].Cells[4].Controls[0]).Text);
            string noisinh = ((TextBox)gv_SinhVien.Rows[e.RowIndex].Cells[5].Controls[0]).Text;
            string diachi = ((TextBox)gv_SinhVien.Rows[e.RowIndex].Cells[6].Controls[0]).Text;
            string makh = ((TextBox)gv_SinhVien.Rows[e.RowIndex].Cells[7].Controls[0]).Text;
            SinhVien svUpdate = new SinhVien
            {
                MaSV = masv,
                HoSV = hosv,
                TenSV = tensv,
                GioiTinh = gioitinh,
                NgaySinh = ngaysinh,
                NoiSinh = noisinh,
                DiaChi = diachi,
                MaKH = makh
            };
            svDAO.Update(svUpdate);
            gv_SinhVien.EditIndex = -1;
            LoadData();
        }

        protected void gv_SinhVien_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_SinhVien.PageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}