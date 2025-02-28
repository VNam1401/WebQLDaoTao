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
                LoadData();
            }
        }

        private void LoadData()
        {
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }
        protected void gvKhoa_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvKhoa.EditIndex = e.NewEditIndex;
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }

        protected void gvKhoa_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvKhoa.EditIndex = -1;
            gvKhoa.DataSource = khDAO.getAll();
            gvKhoa.DataBind();
        }

        protected void gvKhoa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string makh = gvKhoa.DataKeys[e.RowIndex].Value.ToString();
                Khoa kh = new Khoa { MaKH = makh };
                khDAO.Delete(kh);
                LoadData();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Không thể xoá khoa này')</script>");
            }
        }

        protected void gvKhoa_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string makh = gvKhoa.DataKeys[e.RowIndex].Value.ToString();
            string tenkh = ((TextBox)gvKhoa.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            Khoa khUpdate = new Khoa { MaKH = makh, TenKH = tenkh };
            khDAO.Update(khUpdate);
            gvKhoa.EditIndex = -1;
            LoadData();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string makh = txtMakh.Text;
                string tenkh = txtTenkh.Text;
                if (khDAO.findById(makh) != null)
                {
                    Response.Write("<script>alert('Mã khoa đã tồn tại.Vui lòng nhập mã khác .')</script>");
                    return;
                }
                Khoa khInsert = new Khoa { MaKH = makh, TenKH = tenkh };
                khDAO.Insert(khInsert);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Thao tác thêm khoa không thành công.')</script>");
            }
            LoadData();
        }

        protected void gvKhoa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvKhoa.PageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}