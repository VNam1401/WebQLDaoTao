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
        KetQuaDAO kqDAO = new KetQuaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int Count()
        {
            int count = gvKetQua.Rows.Count;
            return count;
        }
        protected void btLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Count(); i++)
            {
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                double diem = double.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                kqDAO.Update(id, diem);
            }
            Response.Write("<script> alert('Lưu điểm thành công') </script>");
        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            bool check = ((CheckBox)gvKetQua.HeaderRow.FindControl("chkAll")).Checked;
            for (int i = 0; i < Count(); i++)
            {
                ((CheckBox)gvKetQua.Rows[i].FindControl("cbxChon")).Checked = check;
            }
        }

        protected void btXoa_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < Count(); i++)
            {
                bool check = ((CheckBox)gvKetQua.Rows[i].FindControl("cbxChon")).Checked;
                if (check)
                {
                    int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                    kqDAO.Delete(id);
                    count++;
                }
            }

            gvKetQua.DataBind();
            Response.Write("<script> alert('Xoá thành công') </script>");
        }

    }
}