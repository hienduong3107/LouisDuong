<%@ Control Language="C#" AutoEventWireup="true" CodeFile="addproduct.ascx.cs" Inherits="Admin_uc_addproduct" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!-- start id-form -->

<table border="0" cellpadding="0" cellspacing="0" id="id-form">
    
    <tr>
        <th valign="top">
            Product name:
        </th>
        <td>
            <asp:TextBox ID="txtName" runat="server" CssClass="inp-form"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <th valign="top">
            Category:
        </th>
        <td>
            <asp:DropDownList ID="drlCategory" runat="server" 
                DataSourceID="AccessDataSource1" DataTextField="TenLoai" 
                DataValueField="MaLoai">
               
            </asp:DropDownList>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                DataFile="~/App_Data/QLBanHang.mdb" SelectCommand="SELECT * FROM [LoaiSP]">
            </asp:AccessDataSource>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <th valign="top">
            Price:
        </th>
        <td>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="inp-form"></asp:TextBox>
        </td>
        <td>
        </td>
    </tr>
        <tr>
            <th valign="top">
                Manufacturers :
            </th>
            <td>
                <asp:DropDownList ID="drlManufacturers" runat="server" 
                    DataSourceID="AccessDataSource2" DataTextField="TenNSX" 
                    DataValueField="MaNSX">
                </asp:DropDownList>
                <asp:AccessDataSource ID="AccessDataSource2" runat="server" 
                    DataFile="~/App_Data/QLBanHang.mdb" 
                    SelectCommand="SELECT [MaNSX], [TenNSX] FROM [NhaSanXuat]">
                </asp:AccessDataSource>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <th valign="top">
                Amount :
                                </th>
            <td>
                <asp:TextBox ID="txtAmount" runat="server" CssClass="inp-form"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <th valign=top>
            Select a date:
        </th>
        <td class="noheight">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr valign="top">
                    <td>
                        <asp:DropDownList ID="drlDay" runat="server" CssClass="styledselect-day">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="drlMonth" runat="server" CssClass="styledselect-month">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="drlYear" runat="server" CssClass="styledselect-year">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <th>
            Avatar:
        
        
        </th>
        <td>
            <asp:FileUpload ID="FileUploadAvatar" runat="server" CssClass="file_1" />
        </td>
    </tr>
    <tr>
        <th>
            Big Image:
        </th>
        <td>
            <asp:FileUpload ID="FileUploadBigImage" runat="server" CssClass="file_1" />
        </td>
    </tr>
    <tr>
        <th>
            Medium Image:
        </th>
        <td>
            <asp:FileUpload ID="FileUploadMediumImage" runat="server" CssClass="file_1" />
        </td>
    </tr>
    <tr>
        <th valign="top">
            Description:
        </th>
        <td>
            <CKEditor:CKEditorControl ID="Ck1" runat="server"></CKEditor:CKEditorControl>
        </td>
        <td>
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
            &nbsp;</td>
    </tr>
    </table>
<!-- end id-form  -->
