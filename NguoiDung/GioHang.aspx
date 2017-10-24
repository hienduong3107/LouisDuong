<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="GioHang.aspx.cs" Inherits="GioHang" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content_gridview">
        <asp:GridView DataKeyNames="Mã Sản Phẩm" ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting"
            CssClass="cart_shoping_display" AutoGenerateColumns="false" EmptyDataText="KHÔNG CÓ SẢN PHẨM TRONG GIỎ HÀNG">
            <Columns>
                <asp:BoundField DataField="Mã Sản Phẩm" HeaderText="Mã Sản Phẩm" />
                <asp:BoundField DataField="Tên Sản Phẩm" HeaderText="Tên Sản Phẩm" />
                <asp:TemplateField HeaderText="Số Lượng">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSoLuong" runat="server" Text='<%# Eval("Số Lượng") %>' Width="70px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSoLuong"
                            ErrorMessage="Lỗi Số Lượng" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                    </ItemTemplate>
                    <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:BoundField DataField="Đơn Giá" HeaderText="Đơn Giá" />
                <asp:BoundField DataField="Thành Tiền" HeaderText="Thành Tiền" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblTongCong" runat="server" Text="" CssClass="lblTongTien"></asp:Label>
        <table style="margin-top: 10px; border-style: none">
            <tr>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                        CssClass="mybutton1" />
                </td>
                <td style="padding-left: 30px">
                    <asp:Button ID="btnDatHang" runat="server" Text="Đặt hàng" CssClass="mybutton1" OnClick="btnDatHang_Click" />
                </td>
                <td style="padding-left: 30px">
                    <asp:Button ID="btnXoa" runat="server" Text="Xóa Giỏ Hàng" CssClass="mybutton1" OnClick="btnXoa_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
