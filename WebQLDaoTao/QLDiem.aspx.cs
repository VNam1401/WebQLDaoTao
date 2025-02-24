using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLDiem : System.Web.UI.Page
    {
        MonHocDAO mhDao = new MonHocDAO();
        KetQuaDAO kqDAO = new KetQuaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //khoi tao du lieu cho ddlMonHoc
                ddlMonHoc.DataSource = mhDao.getAll();
                ddlMonHoc.DataTextField = "tenmh";
                ddlMonHoc.DataValueField = "mamh";
                ddlMonHoc.DataBind();
                //chèn thêm 1 item để nhắc người dùng chọn môn học
                ddlMonHoc.Items.Insert(0, new ListItem("--Chọn môn học-", ""));

            }

        }
        protected void ddlMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lay ma mon hoc duoc chon
            string mamh = ddlMonHoc.SelectedValue;
            //truy van ket qua theo ma mon hoc va lien ket cho gvKetQua de hien thi
            gvKetQua.DataSource = kqDAO.getByMaMH(mamh);
            gvKetQua.DataBind();
        }
        protected void btLuu_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                Response.Write("<script>alert('Vui lòng kiểm tra lại dữ liệu nhập.')</script>");
                return;
            }

            try
            {
                int count = gvKetQua.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                    TextBox txtDiem = (TextBox)gvKetQua.Rows[i].FindControl("txtDiem");
                    int diem; // Sử dụng int thay vì float vì yêu cầu là số nguyên
                    if (!int.TryParse(txtDiem.Text, out diem))
                    {
                        Response.Write("<script>alert('Điểm thi phải là số nguyên.')</script>");
                        return;
                    }
                    kqDAO.Update(id, diem); // Giả định Update chấp nhận int
                }
                Response.Write("<script>alert('Cập nhật thành công')</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Lỗi khi cập nhật: {ex.Message}')</script>");
            }
        }

        protected void gvKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
