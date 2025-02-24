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
            //duyet qua cac dong cua gv
            int count = gvKetQua.Rows.Count; //lay so dong cua gvKetQua
                                             //duyet qua cac dong cua gv
            for (int i = 0; i < count; i++)
            {
                //lay id (key) cua dong thu i
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                //lay diem thi dong thi i
                float diem = float.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                //cap nhat vao CSDL

                kqDAO.Update(id, diem);
            }
            //thông báo trạng thái cập nhật;
            Response.Write("<script>alert('Cập nhật thành công')</script>");
        }
    }
}
