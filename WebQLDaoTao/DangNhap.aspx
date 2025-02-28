<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebQLDaoTao.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>

    </title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-info">
            <div class="panel-heading">
                ĐĂNG NHẬP HỆ THỐNG
   
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="control-label col-sm-3" for="email">Tên đăng nhập:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="control-label col-sm-3" for="pwd">Mật khẩu:</label>
                        <div class="col-sm-9">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" CssClass="btn btn-success" OnClick="btnDangNhap_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Label ID="lblThongBao" runat="server" Text="" ForeColor="#cc3300"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
