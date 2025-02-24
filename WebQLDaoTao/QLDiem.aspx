<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLDiem.aspx.cs" Inherits="WebQLDaoTao.QLDiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>NHẬP ĐIỂM THI</h2>
        <hr />
        <div class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-sm-2">Chọn môn học</label>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlMonHoc" AutoPostBack="true" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <hr />
        <asp:GridView ID="gvKetQua" ShowFooter="true" DataKeyNames="id" runat="server"
            AutoGenerateColumns="false" CssClass="table table-bordered" Width="50%">
            <Columns>
                <asp:BoundField DataField="masv" HeaderText="Mã sinh viên" />
                <asp:BoundField DataField="hotensv" HeaderText="Họ tên sinh viên" />
                <asp:TemplateField HeaderText="Điểm">
                    <ItemTemplate>

                        <asp:TextBox ID="txtDiem" runat="server" Text='<%# Eval("diem") %>' CssClass="form-control"></asp:TextBox>

                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btLuu" runat="server" Text="Lưu điểm" CssClass="btn btn-success" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Chọn">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkChon" runat="server" CssClass="radio-inline" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btXoa" runat="server" Text="Xóa" CssClass="btn btn-danger" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
