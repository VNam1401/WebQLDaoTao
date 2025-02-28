<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLMonHoc.aspx.cs" Inherits="WebQLDaoTao.QLMonHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Contents/Paging.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/css/bootstrap.min.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@3.4.1/dist/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>QUẢN LÝ MÔN HỌC</h2>
    <hr />
    <div>
        <button type="button" class="btn btn-info btn-lg" style="margin-bottom: 5px;" data-toggle="modal" data-target="#modalOpenAddButton">Thêm mới</button>
        <!-- Modal -->
        <div class="modal fade" id="modalOpenAddButton" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">THÊM MỚI MÔN HỌC</h4>
                    </div>
                    <div class="modal-body">
                        <div>
                            <div class="form-group">
                                <label>Mã môn</label>
                                <asp:TextBox ID="txtMamh" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMamh" runat="server" ControlToValidate="txtMamh"
                                    ErrorMessage="Mã môn học không được để trống" ForeColor="Red" Display="Dynamic">
                                    *</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Tên môn</label>
                                <asp:TextBox ID="txtTenmh" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTenmh" runat="server" ControlToValidate="txtTenmh"
                                    ErrorMessage="Tên môn học không được để trống" ForeColor="Red" Display="Dynamic">
                                    *</asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label>Số tiết</label>
                                <asp:TextBox ID="txtsotiet" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSotiet" runat="server" ControlToValidate="txtsotiet"
                                    ErrorMessage="Số tiết không được để trống" ForeColor="Red" Display="Dynamic">
                                    *</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revSotiet" runat="server" ControlToValidate="txtsotiet"
                                    ValidationExpression="^[0-9]+$" ErrorMessage="Số tiết phải là số nguyên dương" ForeColor="Red" Display="Dynamic">
                                    *</asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnThem" class="btn btn-success" OnClick="btnThem_Click" runat="server" Text="Thêm" />
                            </div>
                        </div>
                        <asp:ValidationSummary ID="vsKq" runat="server" ForeColor="#FF3300" Font-Size="Medium" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Huỷ</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:GridView CssClass="table table-bordered" ID="gvMonHoc" runat="server" AutoGenerateColumns="False" DataKeyNames="MaMH"
            OnRowEditing="gvMonHoc_RowEditing" OnRowCancelingEdit="gvMonHoc_RowCancelingEdit" OnRowDeleting="gvMonHoc_RowDeleting"
            OnRowUpdating="gvMonHoc_RowUpdating" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvMonHoc_PageIndexChanging">
            <columns>
                <asp:BoundField HeaderText="Mã môn học" DataField="MaMH" ReadOnly="true" />
                <asp:BoundField HeaderText="Tên môn học" DataField="TenMH" />
                <asp:BoundField HeaderText="Số tiết" DataField="SoTiet" />
                <asp:TemplateField HeaderText="Chọn tác vụ">
                    <itemtemplate>
                        <asp:Button ID="btnSua" runat="server" Text="Sửa" CommandName="Edit" CssClass="btn btn-primary" />
                        <asp:LinkButton ID="btnXoa" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa môn học này ra khỏi danh sách?')"
                            runat="server" CommandName="Delete" CssClass="btn btn-danger">
                            <i class="bi bi-trash"></i>Xóa
                        </asp:LinkButton>
                    </itemtemplate>
                    <edititemtemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn btn-success" CommandName="Update" />
                        <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-warning" CommandName="Cancel" />
                    </edititemtemplate>
                </asp:TemplateField>
            </columns>
            <headerstyle backcolor="#0066cc" forecolor="#ffffff" />
            <pagerstyle horizontalalign="Center" cssclass="pager-style" />
        </asp:GridView>
    </div>
</asp:Content>