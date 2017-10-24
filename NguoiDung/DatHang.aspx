<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="DatHang.aspx.cs" Inherits="NguoiDung_DatHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width:100%;margin:auto;">
        <table cellpadding="3" cellspacing="3" style="width: 50%;margin:auto;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Tên Người Nhận :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNguoiNhan" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNguoiNhan"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSDT" runat="server" Text="Số Điện Thoại :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSDT" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSDT"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Địa Chỉ :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDiaChi" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDiaChi"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Ngày Giao :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlNgay" runat="server" Width="67px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlThang" runat="server" Width="67px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlNam" runat="server" Width="67px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 25px">
                    <asp:Label ID="Label6" runat="server" Text="Số lượng sản phẩm :"></asp:Label>
                </td>
                <td style="height: 25px">
                   
                    <asp:Label ID="lblSoLuong" runat="server"></asp:Label>
                   
                </td>
                <td style="height: 25px">
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Tổng Cộng :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTongCong" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <table style="width: 100%;text-align:center;">
                        <tr>
                            <td style="width: 50%">
                                <asp:Button ID="btnSubmit" runat="server" Text="Đặt Hàng" CssClass=mybutton1 
                                    onclick="btnSubmit_Click"/>
                            </td>
                            <td style="width: 50%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblThongBao" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
