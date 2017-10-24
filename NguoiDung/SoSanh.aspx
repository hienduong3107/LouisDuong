<%@ Page Title="" Language="C#" MasterPageFile="~/NguoiDung/MasterPage.master" AutoEventWireup="true"
    CodeFile="SoSanh.aspx.cs" Inherits="SoSanh" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="compare">
        <div class="compare_left">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="AccessDataSource1"
                DataTextField="TenSP" DataValueField="MaSP">
            </asp:DropDownList>
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                SelectCommand="SELECT [MaSP], [TenSP] FROM [SanPham] WHERE Active = 1 ORDER BY [TenSP] ASC"></asp:AccessDataSource>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="MaSP" DataSourceID="AccessDataSource2"
                CssClass="dl_compare">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("HinhDaiDien") %>' Height="100px"
                        Width="100px" />
                    <br />
                    <strong style="font-weight:bold;font-size:large;color:Green">
                        <asp:Label ID="TenSPLabel" runat="server" Text='<%# Eval("TenSP") %>' />
                    </strong>
                    <br />
                    <asp:Label ID="MoTaLabel" runat="server" Text='<%# Eval("MoTa") %>' />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                SelectCommand="SELECT [MaSP], [TenSP], [MoTa], [HinhDaiDien] FROM [SanPham] WHERE ([MaSP] = ?) AND Active = 1">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="MaSP" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:AccessDataSource>
            <br />
        </div>
        <%--==============================================================================================================================--%>
        <div class="compare_right">
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="AccessDataSource3"
                DataTextField="TenSP" DataValueField="MaSP">
            </asp:DropDownList>
            <asp:AccessDataSource ID="AccessDataSource3" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                SelectCommand="SELECT [MaSP], [TenSP] FROM [SanPham] WHERE Active = 1 ORDER BY [TenSP] ASC"></asp:AccessDataSource>
            <asp:DataList ID="DataList2" runat="server" DataKeyField="MaSP" DataSourceID="AccessDataSource4"
                CssClass="dl_compare">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("HinhDaiDien") %>' Height="100px"
                        Width="100px" />
                    <br />
                    <strong style="font-weight:bold;font-size:large;color:Green">
                        <asp:Label ID="TenSPLabel" runat="server" Text='<%# Eval("TenSP") %>' />
                    </strong>
                    <br />
                    <asp:Label ID="MoTaLabel" runat="server" Text='<%# Eval("MoTa") %>' />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:AccessDataSource ID="AccessDataSource4" runat="server" DataFile="~/App_Data/QLBanHang.mdb"
                SelectCommand="SELECT [MoTa], [TenSP], [MaSP], [HinhDaiDien] FROM [SanPham] WHERE ([MaSP] = ?) AND Active = 1">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" DefaultValue="0" Name="MaSP" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:AccessDataSource>
            <asp:DataList ID="DataList3" runat="server">
            </asp:DataList>
        </div>
        <div class="btnSosanh">
            <asp:Button ID="btnSosanh" runat="server" Text="So Sánh" CssClass="mybutton1" />
            <div style="clear: both">
            </div>
        </div>
    </div>
    </div>
</asp:Content>
