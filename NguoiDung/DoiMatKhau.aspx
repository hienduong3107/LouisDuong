<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true" CodeFile="DoiMatKhau.aspx.cs" Inherits="DoiMatKhau" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:41%; margin:auto;">
        <asp:Panel ID="pnlDangNhap" runat="server">
            <table style="width: 100%; height: 144px;">
                <tr>
                    <td style="width: 95px">
                        <strong style="font-size: larger">
                            <asp:Label ID="lblTK" runat="server" Text="Tài khoản"></asp:Label>
                        </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTK" runat="server" CssClass="contact_input" >
                         </asp:TextBox>
                    </td>
                    <td>
                        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtTK" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 95px">
                        <strong style="font-size: larger">
                            <asp:Label ID="lblMKcu" runat="server" Text="Mật khẩu cũ"></asp:Label>
                        </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMKcu" runat="server" CssClass="contact_input" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtMKcu" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 95px">
                        <strong style="font-size: larger">
                        <asp:Label ID="lblMKmoi" runat="server" Text="Mật khẩu mới"></asp:Label>
                        </strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMKmoi" runat="server" CssClass="contact_input" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtMKmoi" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnDMK" runat="server" Text="Đổi Mật Khẩu" CssClass="myButton" 
                            OnClick="btnDMK_Click"/>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnReset" type="reset" value="Làm mới" class=myButton />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" class="td_left">
                        <asp:Label ID="lblThongBao" runat="server"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

