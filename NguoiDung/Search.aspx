<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="NguoiDung_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server">
        <div style="width: 80%; margin: auto;">
            <table style="width: 50%; text-align: left; vertical-align: top; margin: auto">
                <tr>
                    <td>
                        <asp:Label ID="lblTen" runat="server" Text="Tên"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTen" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTuGia" runat="server" Text="Từ Giá"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTuGia" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbldenGia" runat="server" Text="Đến Giá"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDenGia" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHang" runat="server" Text="Hãng"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlNSX" runat="server" DataSourceID="AccessDataSource1"
                            DataTextField="TenNSX" DataValueField="MaNSX" Width="200px">
                        </asp:DropDownList>
                        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                            SelectCommand="SELECT [MaNSX], [TenNSX] FROM [NhaSanXuat]"></asp:AccessDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLoai" runat="server" Text="Loại"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLoai" runat="server" DataSourceID="AccessDataSource2"
                            DataTextField="TenLoai" DataValueField="MaLoai" Width="200px">
                        </asp:DropDownList>
                        <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                            SelectCommand="SELECT * FROM [LoaiSP]"></asp:AccessDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" CssClass="mybutton1" Text="Tìm" 
                            onclick="btnSubmit_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" CssClass="mybutton1" Text="Reset" 
                            onclick="btnReset_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False">
        <div class="sanpham_main">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="MaSP" RepeatColumns="4"
                OnItemCommand="XuLy" CssClass="sanpham">
                <ItemTemplate>
                    <div class="prod_box">
                        <div class="top_prod_box">
                        </div>
                        <div class="center_prod_box">
                            <div class="product_img">
                                <asp:Image ID="Image2" runat="server" Height="110px" ImageUrl='<%# Eval("HinhDaiDien", "{0}") %>'
                                    Width="110px" CssClass="product_img" />
                            </div>
                            <div class="product_title">
                                <span>
                                    <asp:Label ID="TenSPLabel" runat="server" Text='<%# Eval("TenSP") %>' /></span>
                            </div>
                            <div class="prod_price">
                                <span class="price">
                                    <asp:Label ID="DonGiaLabel" runat="server" Text='<%# Eval("DonGia") %>' />
                                    USD</span>
                            </div>
                        </div>
                        <div class="prod_details_tab" align="center">
                            <asp:Label ID="lblLike" runat="server" Text='<%# Eval("SoLike") %>' CssClass="like"></asp:Label>
                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/NguoiDung/css/images/like.png"
                                CommandName="Like" />
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/cart.png" CommandName="ThemGioHang" />
                            <strong>
                                <a href=ChiTiet.aspx?MaSP=<%#Eval("MaSP") %>>Chi tiết</a>
                            </strong>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="paging">
            <table cellpadding="0" border="0" class="paging_tb">
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" OnClick="lbtnFirst_Click">Trang đầu</asp:LinkButton>
                        &nbsp;
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" OnClick="lbtnPrevious_Click">&lt;</asp:LinkButton>&nbsp;&nbsp;
                    </td>
                    <td align="center" valign="middle">
                        <asp:DataList ID="dlPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlPaging_ItemCommand"
                            OnItemDataBound="dlPaging_ItemDataBound">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                    CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>&nbsp;
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                    <td align="left">
                        &nbsp;&nbsp;<asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false"
                            OnClick="lbtnNext_Click">&gt;</asp:LinkButton>
                    </td>
                    <td align="left">
                        &nbsp;
                        <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" OnClick="lbtnLast_Click">Trang cuối</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center" style="height: 30px" valign="middle">
                        <strong>
                            <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                        </strong>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
