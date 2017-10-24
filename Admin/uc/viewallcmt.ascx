<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewallcmt.ascx.cs" Inherits="Admin_uc_viewallcmt" %>
<div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="true"
        DataKeyNames="MaSP" CssClass="gridview_display_2">
        <Columns>
            <asp:BoundField DataField="MaSP" HeaderText="ID" ReadOnly="True" SortExpression="MaSP" />
            <asp:BoundField DataField="TenSP" HeaderText="Name" SortExpression="TenSP" />
            <asp:BoundField DataField="CamNhan" HeaderText="Comment" SortExpression="CamNhan" />
           
            
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
