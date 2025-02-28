using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLMonHoc : System.Web.UI.Page
    {
        MonHocDAO mhDAO = new MonHocDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMonHoc.EditIndex = e.NewEditIndex;
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMonHoc.EditIndex = -1;
            gvMonHoc.DataSource = mhDAO.getAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string mamh = gvMonHoc.DataKeys[e.RowIndex].Value.ToString();
                mhDAO.Delete(mamh);
                LoadData();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Xóa thất bại')</script>");
            }


        }

        protected void gvMonHoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string mamh = gvMonHoc.DataKeys[e.RowIndex].Value.ToString();
            string tenmh = ((TextBox)gvMonHoc.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int sotiet = int.Parse(((TextBox)gvMonHoc.Rows[e.RowIndex].Cells[2].Controls[0]).Text);
            MonHoc mhUpdate = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
            mhDAO.Update(mamh, mhUpdate);
            gvMonHoc.EditIndex = -1;
            LoadData();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string mamh = txtMamh.Text;
                string tenmh = txtTenmh.Text;
                int sotiet = int.Parse(txtsotiet.Text);
                if (mhDAO.findById(mamh) != null)
                {
                    Response.Write("<script>alert('Mã môn học đã tồn tại. .')</script>");
                    return;
                }
                MonHoc mhInsert = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
                mhDAO.Insert(mhInsert);

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Thêm môn học không thành công.')</script>");
            }
            LoadData();
        }

        protected void gvMonHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMonHoc.PageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}