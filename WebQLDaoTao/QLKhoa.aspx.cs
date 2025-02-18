using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLKhoa : System.Web.UI.Page
    {
        KhoaDAO khDAO = new KhoaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //lien ket du lieu cho gvKhoa
                gvKhoa.DataSource = khDAO.getAll();
                gvKhoa.DataBind();
            }
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            string makh = txtMaKH.Text;
            string tenkh = txtTenKH.Text;
            if (khDAO.findById(makh) != null)
            {
                lbThongBao.Text = "Mã khoa đã tồn tại. Chọn mã khác nhé";
                return;
            }
            //goi phuong thuc thêm khoa vào CSDL
            khDAO.Insert(makh, tenkh);
            lbThongBao.Text = "Đã thêm 1 khoa";
            //liên kết dữ liệu cho gvkhoa
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }

        protected void gvKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }
        protected void gvKhoa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //lấy mã khoa của dòng cần xóa cần xóa
                string makh = gvKhoa.DataKeys[e.RowIndex].Value.ToString();
                //thực hiện xóa khoa theo mã khoa
                khDAO.Delete(makh);
                //liên kết lại dữ liệu cho gvKhoa
                gvKhoa.DataSource = khDAO.getAll();
                gvKhoa.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Khoa này đã có sinh viên. Không thể xóa') </script>");
            }
        }
        protected void gvKhoa_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvKhoa.EditIndex = e.NewEditIndex;
            //liên kết lại dữ liệu cho gvKhoa
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }
        protected void gvKhoa_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvKhoa.EditIndex = -1;
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }
        protected void gvKhoa_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //lấy mã khoa của dòng cần xóa cần sửa
            string makh = gvKhoa.DataKeys[e.RowIndex].Value.ToString();
            //lay ten khoa
            string tenkh = ((TextBox)gvKhoa.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            khDAO.Update(makh, tenkh);
            gvKhoa.EditIndex = -1;
            //lien ket lai du lieu
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }
    }
}