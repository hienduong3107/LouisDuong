<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adduser.ascx.cs" Inherits="Admin_uc_adduser" %>
<div style="width: 100%;">
    <div style="float: left; width: 25%">
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <tr valign="top">
                <td>
                    <!-- start id-form -->
                    <table border="0" cellpadding="0" cellspacing="0" id="id-form">
                        <tr>
                            <th valign="top">
                                User ID:
                            </th>
                            <td>
                                <asp:TextBox ID="txtID" runat="server" CssClass="inp-form"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtID" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th valign="top">
                                Password :
                            </th>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" onfocus="this.value=''"
                                    CssClass="inp-form"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th valign="top">
                                Category:
                            </th>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Selected="True" Value="0">N/A</asp:ListItem>
                                    <asp:ListItem Value="1">Admin</asp:ListItem>
                                    <asp:ListItem Value="2">Users</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th valign="top">
                                Email :
                            </th>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="inp-form"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td valign="top">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="form-submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Button" CssClass="form-reset" 
                                    onclick="btnReset_Click"/>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="3">
                             <asp:Label ID="lblThongBao" runat="server" Text=""></asp:Label>
                                &nbsp;</th>
                        </tr>
                    </table>
                    <!-- end id-form  -->
                </td>
        </table>
    </div>
    <div style="clear: both">
    </div>
    <div style="width: 75%;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
            DataKeyNames="TenDangNhap" CssClass="gridview_display" OnRowEditing="GridView1_RowEditing"
            OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="TenDangNhap" HeaderText="ID" ReadOnly="True" SortExpression="TenDangNhap" />
                <asp:BoundField DataField="MatKhau" HeaderText="Password" SortExpression="MatKhau" />
                <asp:BoundField DataField="LoaiNguoiDung" HeaderText="Kind" SortExpression="LoaiNguoiDung" />
                <asp:BoundField DataField="DiaChiMail" HeaderText="Email Address" SortExpression="DiaChiMail" />
                <asp:CommandField ShowEditButton="true" ButtonType="Button" HeaderText="Edit" />
            </Columns>
        </asp:GridView>
    </div>
</div>
