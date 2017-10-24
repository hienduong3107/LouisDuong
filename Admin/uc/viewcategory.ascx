<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewcategory.ascx.cs" Inherits="Admin_uc_addcategory" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
        DataKeyNames="MaLoai" CssClass="gridview_display" OnRowEditing="GridView1_RowEditing"
        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating"
        OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="MaLoai" HeaderText="ID" ReadOnly="True" SortExpression="MaLoai" />
            <asp:BoundField DataField="TenLoai" HeaderText="Name" SortExpression="TenLoai" />
            <asp:CommandField ShowEditButton="true" ButtonType="Button" HeaderText="Edit" ShowDeleteButton="true" />
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
</div>
