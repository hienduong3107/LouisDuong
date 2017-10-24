<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="SanPham.aspx.cs" Inherits="SanPham" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sanpham_top">
        <div class="title_top">
            <asp:Label ID="lblTitle" runat="server" Text="DANH SÁCH SẢN PHẨM" CssClass="title_top"></asp:Label>
        </div>
        <div style="float: right;">
            <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm nâng cao" 
                CssClass="mybutton1" onclick="btnTimKiem_Click"/>
            <asp:Button ID="btnsosanhsp" runat="server" Text="So Sánh sản phẩm" CssClass="mybutton1"
                OnClick="btnsosanhsp_Click" />
        </div>
    </div>
    <div class="price_search">
        <asp:Label ID="lblGiaNho" runat="server" Text="Từ giá"></asp:Label>
        <asp:TextBox ID="txtGiaNho" runat="server" CssClass="price_search_drl"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtGiaNho"
            Operator="GreaterThan" Type="Integer" ValueToCompare="-1" CssClass=compare_validator></asp:CompareValidator>
        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtGiaNho"
            WatermarkText="Nhập giá">
        </asp:TextBoxWatermarkExtender>
        <asp:Label ID="lblGiaLon" runat="server" Text="Đến giá"></asp:Label>
        <asp:TextBox ID="txtGiaLon" runat="server" CssClass="price_search_drl"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtGiaLon"
            Operator="GreaterThan" Type="Integer" ValueToCompare="-1" CssClass=compare_validator></asp:CompareValidator>
        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtGiaLon"
            WatermarkText="Nhập giá">
        </asp:TextBoxWatermarkExtender>
        <asp:Button ID="btnSearch_price" runat="server" Text="Tìm" CssClass="mybutton1" 
            onclick="btnSearch_price_Click" />
    </div>
    <div style="clear:both"></div>
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
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/NguoiDung/css/images/like.png" CommandName="Like" />
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
        <table cellpadding="0" border="0" class =paging_tb>
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
</asp:Content>
