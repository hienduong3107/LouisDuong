<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewallorders.ascx.cs"
    Inherits="Admin_uc_viewallorders" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        DataKeyNames="MaHD" CssClass="gridview_display_2" OnRowEditing="GridView1_RowEditing"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating"
        OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_RowSelect">
        <Columns>
            <asp:BoundField DataField="MaHD" HeaderText="ID" ReadOnly="True" SortExpression="MaHD" />
            <asp:BoundField DataField="TenDangNhap" HeaderText="Username" SortExpression="TenDangNhap" />
            <asp:BoundField DataField="DiaDiemGiaoHang" HeaderText="Address" SortExpression="DiaDiemGiaoHang" />
            <asp:BoundField DataField="SDT" HeaderText="Phone Number" SortExpression="SDT" />
            <asp:BoundField DataField="TenNguoiNhan" HeaderText="Recipient" SortExpression="TenNguoiNhan" />
            <asp:BoundField DataField="NgayGiao" HeaderText="Delivery date" SortExpression="NgayGiao" />
            <asp:BoundField DataField="TongTien" HeaderText="Total" SortExpression="TongTien" />
            <asp:BoundField DataField="NgayNhapHD" HeaderText="Order date" SortExpression="NgayNhapHD" />
            <asp:CommandField ShowEditButton="true" ButtonType="Button" HeaderText="Edit" ShowDeleteButton="true" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Order Details"
                ShowHeader="True" Text="Details" />
        </Columns>
    </asp:GridView>
    <div class="paging">
        <table cellpadding="0" border="0" class="paging_tb">
            <tr>
                <td align="right">
                    <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" OnClick="lbtnFirst_Click">First</asp:LinkButton>
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
                    <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" OnClick="lbtnLast_Click">Last</asp:LinkButton>
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
    <div style='clear: both'>
    </div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="True"
        DataKeyNames="MaHD" CssClass="gridview_display_2" EmptyDataText="Chọn chi tiết hóa đơn">
        <Columns>
            <asp:BoundField DataField="MaHD" HeaderText="OrdersID" ReadOnly="True" SortExpression="MaHD" />
            <asp:BoundField DataField="MaSP" HeaderText="ProductsID" SortExpression="MaSP" />
            <asp:BoundField DataField="DonGia" HeaderText="Price" SortExpression="DonGia" />
            <asp:BoundField DataField="SoLuong" HeaderText="Amount" SortExpression="SoLuong" />
        </Columns>
    </asp:GridView>
</div>
