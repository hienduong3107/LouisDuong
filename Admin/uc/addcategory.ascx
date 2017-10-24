<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addcategory.ascx.cs" Inherits="Admin_uc_addcategory" %>

<!-- start id-form -->
<table border="0" cellpadding="0" cellspacing="0" id="id-form">
    <tr>
        <th valign="top">
            &nbsp;ID:
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
            Name:
        </th>
        <td>
            <asp:TextBox ID="txtName" runat="server" CssClass="inp-form"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <th>
            &nbsp;
        </th>
        <td valign="top">
            <asp:Button ID="btnSubmit" runat="server" Text="Button" CssClass="form-submit" OnClick="btnSubmit_Click" />
            <input type="reset" value="" class="form-reset" />
        </td>
        <td>

        </td>
        
    </tr>
    <tr>
        <th colspan="2">
            <asp:Label ID="lblThongBao" runat="server"></asp:Label>
        </th>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<!-- end id-form  -->
