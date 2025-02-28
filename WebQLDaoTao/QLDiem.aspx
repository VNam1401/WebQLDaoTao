<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLDiem.aspx.cs" Inherits="WebQLDaoTao.QLDiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>QUẢN LÝ ĐIỂM THI</h2>
    <hr />

    <asp:ObjectDataSource ID="odsKetQua" runat="server"
        SelectMethod="getByMaMH" TypeName="WebQLDaoTao.Models.KetQuaDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlMonHoc" Name="mamh" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMonHoc" runat="server" SelectMethod="getAll" TypeName="WebQLDaoTao.Models.MonHocDAO"></asp:ObjectDataSource>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 10px">
                Chọn môn học
        <asp:DropDownList ID="ddlMonHoc" runat="server" DataSourceID="odsMonHoc" CssClass="form-control"
            DataTextField="TenMH" DataValueField="MaMH" AutoPostBack="true">
        </asp:DropDownList>
            </div>

            <asp:GridView ID="gvKetQua" ShowFooter="true" DataKeyNames="id" runat="server" DataSourceID="odsKetQua"
                AutoGenerateColumns="false" CssClass="table table-bordered" Width="70%">
                <Columns>
                    <asp:BoundField DataField="MaSV" HeaderText="MaSV" />
                    <asp:BoundField DataField="HoTenSV" HeaderText="Họ tên sinh viên" />
                    <asp:TemplateField HeaderText="Điểm thi">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDiem" runat="server" Text='<%# Eval("Diem") %>' CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="btLuu" runat="server" Text="Lưu điểm" CssClass="btn btn-success" OnClick="btLuu_Click">
                        
                            </asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Chọn xoá" ItemStyle-HorizontalAlign="Center">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" Text="Chọn tất cả" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="cbxChon" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="btXoa" OnClientClick="return confirm('Bạn có muốn xóa điểm này không?')" runat="server" Text="Xoá" CssClass="btn btn-success" OnClick="btXoa_Click">
                        
                            </asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-warning">
                        Không có sinh viên 
                    </div>
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
