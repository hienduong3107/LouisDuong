<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="QuenMatKhau.aspx.cs" Inherits="QuenMatKhau" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 41%; margin: auto;">
        <table style="width: 100%; height: 144px;">
            <tr>
                <td style="width: 95px">
                    <strong style="font-size: larger">
                        <asp:Label ID="lblTK" runat="server" Text="Tài khoản"></asp:Label>
                    </strong>
                </td>
                <td>
                    <asp:TextBox ID="txtTK" runat="server" CssClass="contact_input"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTK"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <strong style="font-size: larger">
                        <asp:Label ID="lblMaPIN" runat="server" Text="Email"></asp:Label>
                    </strong>
                </td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server" CssClass="contact_input"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMail"
                        ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="btnLayMK" runat="server" Text="Lấy lại mật khẩu" CssClass="myButton"
                        OnClick="btnLayMK_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
    </div>
</asp:Content>
