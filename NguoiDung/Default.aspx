<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="default_main">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="MaSP" DataSourceID="AccessDataSource1"
            OnItemCommand="XuLy">
            <ItemTemplate>
                <div class="default_post_left">
                    <asp:Image ID="Image3" runat="server" 
                        ImageUrl='<%# Eval("HinhLon")%>' />
                </div>
                <div class="default_post_right">
                    <h2>
                        <asp:Label ID="TenSPLabel" runat="server" Text='<%# Eval("TenSP") %>' /></h2>
                    <h4>
                        <asp:Label ID="lblMoTa" runat="server" Text='<%# Eval("MoTa") %>'></asp:Label>
                    </h4>
                    <br />
                    <span class="giabanle_bold">Giá bán lẻ: </span><span class="prod_price">
                        <asp:Label ID="DonGiaLabel" runat="server" Text='<%# Eval("DonGia") %>' />
                        USD</span>
                    <br />
                    <div class=prod_details_tab_default>
                        <strong>
                            <asp:Label ID="lblLike" runat="server" Text='<%# Eval("SoLike") %>' CssClass="like"></asp:Label>
                            <asp:ImageButton ID="imgbtnLike" runat="server" ImageUrl="css/images/like.png" CommandName=Like />
                            <asp:ImageButton ID="imgbtnThemGioHang" runat="server" ImageUrl="images/cart.png" CommandName=ThemGioHang/>
                            <a href=ChiTiet.aspx?MaSP=<%# Eval("MaSP") %>>Chi tiết</a>
                        </strong>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
            SelectCommand="SELECT TOP 1 * FROM SanPham WHERE Active = 1 ORDER BY NgayNhapHang DESC">
        </asp:AccessDataSource>
        <div style="clear: both">
        </div>
        
    </div>

    <%--=============================================================================================================================--%>

    <div style="height: 50px; float: left; width: 250px; margin-top: 50px; font-size: x-large;
        color: Green; position: relative;">
        <strong style="position: absolute; top: 10px;">SẢN PHẨM MỚI </strong>
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="css/images/news-button.png" PostBackUrl="SanPham.aspx" CssClass=newbutton/>
    </div>
    <div style="clear:both"></div>
    <div style="width:auto;margin:auto;">
        <asp:DataList ID="DataList2" runat="server" DataKeyField="MaSP" 
            DataSourceID="AccessDataSource2" OnItemCommand="XuLy" RepeatColumns="4" CssClass=sanpham_main >
            <ItemTemplate>
                <div class="prod_box" style="float:left";>
                    <div class="top_prod_box">
                    </div>
                    <div class="center_prod_box">
                        <div class="product_title">
                            <span>
                                <asp:Label ID="TenSPLabel" runat="server" Text='<%# Eval("TenSP") %>' /></span>
                        </div>
                        <div class="product_img">
                            <asp:Image ID="Image2" runat="server" Height="110px" ImageUrl='<%# Eval("HinhDaiDien", "{0}") %>'
                                Width="110px" CssClass="product_img" />
                        </div>
                        
                        <div class="prod_price">
                            <span class="price">
                                <asp:Label ID="DonGiaLabel" runat="server" Text='<%# Eval("DonGia") %>' /> USD</span>
                        </div>
                    </div>
                    <div class="bottom_prod_box">
                    </div>
                    <div class="prod_details_tab" align="center">
                        <asp:Label ID="lblLike" runat="server" Text=<%# Eval("SoLike") %> CssClass=like></asp:Label>
                        <asp:ImageButton ID="imgbtnLike" runat="server" ImageUrl="css/images/like.png" CommandName=Like />
                        <asp:ImageButton ID="imgbtnThemGioHang" runat="server" ImageUrl="images/cart.png" CommandName=ThemGioHang />
                        <a href=ChiTiet.aspx?MaSP=<%#Eval("MaSP") %>>Chi tiết</a>
                    </div>
                    <div style="clear:both"></div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
            SelectCommand="SELECT TOP 4 * FROM SanPham WHERE Active = 1 ORDER BY NgayNhapHang DESC">
        </asp:AccessDataSource>
    </div>

    <%--=============================================================================================================================--%>

</asp:Content>
