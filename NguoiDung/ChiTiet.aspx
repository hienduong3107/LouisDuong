<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChiTiet.aspx.cs" Inherits="ChiTiet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="position:static; margin-bottom:50px;">
        <div id="chitiet_main">
            <asp:DataList ID="DataList1" runat="server" DataKeyField="MaSP" DataSourceID="AccessDataSource1"
                OnItemCommand="XuLy">
                <ItemTemplate>
                    <div class="prod_box" style="float: left">
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
                                    <asp:Label ID="DonGiaLabel" runat="server" Text='<%# Eval("DonGia") %>' />
                                    USD</span>
                            </div>
                        </div>
                        <div class="bottom_prod_box">
                        </div>
                        <div class="prod_details_tab" align="center">
                            <asp:Label ID="lblLike" runat="server" Text='<%# Eval("SoLike") %>' CssClass="like"></asp:Label>
                            <asp:ImageButton ID="imgbtnLike" runat="server" ImageUrl="~/NguoiDung/css/images/like.png"
                                CommandName="Like" />
                            <asp:ImageButton ID="imgbtnThemGioHang" runat="server" ImageUrl="images/cart.png"
                                CommandName="ThemGioHang" />
                            <a href="Default.aspx"><strong>Home</strong></a>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div class="mota_chitiet">
                        <asp:Label ID="lblMoTa" runat="server" Text='<%# Eval("MoTa") %>' /></span>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                SelectCommand="SELECT * FROM [SanPham] WHERE ([MaSP] = ?) AND Active = 1">
                <SelectParameters>
                    <asp:QueryStringParameter Name="MaSP" QueryStringField="MaSP" Type="String" />
                </SelectParameters>
            </asp:AccessDataSource>
        </div>
        <div>
            <p style="font-size: large; color: Green">
                CẢM NHẬN CỦA BẠN VỀ SẢN PHẨM</p>
            <CKEditor:CKEditorControl ID="CKE1" runat="server" EnterMode="BR"></CKEditor:CKEditorControl>
            <table style="float: left; margin: 10px 0px 10px 10px;">
                <tr>
                    <td>
                        <asp:Button ID="btnGui" runat="server" Text="Gửi" CssClass="mybutton1" OnClick="btnGui_Click" />
                    </td>
                    <td style="padding-left: 10px">
                        <asp:Button ID="btnReset" runat="server" Text="Làm mới" CssClass="mybutton1" OnClick="btnReset_Click" />
                    </td>
                </tr>
            </table>
           
        </div>
        
    </div>
</asp:Content>
