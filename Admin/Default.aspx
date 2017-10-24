<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panel1" runat="server">
        <table class="menu">
            <tr>
                <td>
                    <asp:Button ID="btnUsers" runat="server" Text="View All Users" CssClass="myButton"
                        OnClick="btnUsers_Click" />
                </td>
                <td>
                    <asp:Button ID="btnProducts" runat="server" Text="View All Products" CssClass="myButton"
                        OnClick="btnProducts_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCategories" runat="server" Text="View All Categories" CssClass="myButton"
                        OnClick="btnCategories_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnOrder" runat="server" Text="View All Orders" 
                        CssClass="myButton" onclick="btnOrder_Click" />
                </td>
                <td>
                    <asp:Button ID="btnManufacturers" runat="server" Text="View All Manufacturers" 
                        CssClass="myButton" onclick="btnManufacturers_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCmt" runat="server" Text="View All Comment" 
                        CssClass="myButton" onclick="btnCmt_Click"  />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>
