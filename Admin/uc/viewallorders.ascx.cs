using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_uc_viewallorders : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BindItemsList();
        }
    }
    #region Private Properties
    private int CurrentPage
    {
        get
        {
            object objPage = ViewState["_CurrentPage"];
            int _CurrentPage = 0;
            if (objPage == null)
            {
                _CurrentPage = 0;
            }
            else
            {
                _CurrentPage = (int)objPage;
            }
            return _CurrentPage;
        }
        set { ViewState["_CurrentPage"] = value; }
    }
    private int fistIndex
    {
        get
        {

            int _FirstIndex = 0;
            if (ViewState["_FirstIndex"] == null)
            {
                _FirstIndex = 0;
            }
            else
            {
                _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
            }
            return _FirstIndex;
        }
        set { ViewState["_FirstIndex"] = value; }
    }
    private int lastIndex
    {
        get
        {

            int _LastIndex = 0;
            if (ViewState["_LastIndex"] == null)
            {
                _LastIndex = 0;
            }
            else
            {
                _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
            }
            return _LastIndex;
        }
        set { ViewState["_LastIndex"] = value; }
    }
    #endregion

    #region PagedDataSource
    PagedDataSource _PageDataSource = new PagedDataSource();
    #endregion

    #region Private Methods
    /// <summary>
    /// Build DataTable to bind Main Items List
    /// </summary>
    /// <returns>DataTable</returns>
    private DataTable GetDataTable()
    {
        DataTable dt = DDatHangBUS.LayDanhSachDonDatHang();
        return dt;
    }
    /// <summary>
    /// Binding Main Items List
    /// </summary>
    private void BindItemsList()
    {
        DataTable dataTable = this.GetDataTable();
        _PageDataSource.DataSource = dataTable.DefaultView;
        _PageDataSource.AllowPaging = true;
        _PageDataSource.PageSize = 15;
        _PageDataSource.CurrentPageIndex = CurrentPage;
        ViewState["TotalPages"] = _PageDataSource.PageCount;

        this.lblPageInfo.Text = (CurrentPage + 1) + "/" + _PageDataSource.PageCount;
        this.lbtnPrevious.Enabled = !_PageDataSource.IsFirstPage;
        this.lbtnNext.Enabled = !_PageDataSource.IsLastPage;
        this.lbtnFirst.Enabled = !_PageDataSource.IsFirstPage;
        this.lbtnLast.Enabled = !_PageDataSource.IsLastPage;
        this.GridView1.DataSource = _PageDataSource;
        
        this.GridView1.DataBind();
        this.doPaging();
    }

    /// <summary>
    /// Binding Paging List
    /// </summary>
    #endregion
    #region Paging
    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");
        fistIndex = CurrentPage - 5;
        if (CurrentPage > 5)
        {
            lastIndex = CurrentPage + 5;
        }
        else
        {
            lastIndex = 10;
        }
        if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            fistIndex = lastIndex - 10;
        }
        if (fistIndex < 0)
        {
            fistIndex = 0;
        }
        for (int i = fistIndex; i < lastIndex; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        this.dlPaging.DataSource = dt;
        this.dlPaging.DataBind();
    }

    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        this.BindItemsList();
    }
    protected void lbtnPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        this.BindItemsList();
    }
    protected void lbtnLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        this.BindItemsList();
    }
    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        this.BindItemsList();
    }
    protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            this.BindItemsList();
        }
    }
    protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
        if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            lnkbtnPage.Enabled = false;
            lnkbtnPage.Style.Add("fone-size", "14px");
            lnkbtnPage.Font.Bold = true;
        }
    }
    #endregion

    #region GridView Custom
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindItemsList();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindItemsList();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridView gv = (GridView)sender;
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string sID = gv.DataKeys[e.RowIndex]["MaHD"].ToString();
            string sNewUserName = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string sNewAddress = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string sNewPhoneNumber = ((TextBox)(row.Cells[3].Controls[0])).Text;
            string sNewRecipient = ((TextBox)(row.Cells[4].Controls[0])).Text;
            string sNewDeliveryDate = ((TextBox)(row.Cells[5].Controls[0])).Text;
            string sNewTotal = ((TextBox)(row.Cells[6].Controls[0])).Text;
            string sNewOrderDay = ((TextBox)(row.Cells[7].Controls[0])).Text;


            DDatHangDTO ddhDTO = new DDatHangDTO();
            ddhDTO.MaHD = int.Parse(sID);
            ddhDTO.Username = sNewUserName;
            ddhDTO.DiaChi = sNewAddress;
            ddhDTO.SDT = sNewPhoneNumber;
            ddhDTO.TenNguoiNhan = sNewRecipient;
            ddhDTO.Newdelivery = sNewDeliveryDate;
            ddhDTO.TongTien = int.Parse(sNewTotal);
            ddhDTO.NewOrder = sNewOrderDay;
            DDatHangBUS.SuaDonDatHang(ddhDTO);
            GridView1.EditIndex = -1;
            BindItemsList();
        }
        catch (Exception ex)
        {
            Response.Write("<script type='text/javascript'>"
                           + "alert('Có lỗi xảy ra. Vui Lòng điền đúng kiểu dữ liệu yêu cầu !!!');"
                           + "</script>");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            GridView gv = (GridView)sender;
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string sID = gv.DataKeys[e.RowIndex]["MaHD"].ToString();
            DDatHangDTO ddhDTO = new DDatHangDTO();
            ddhDTO.MaHD = int.Parse(sID);
            if (gv.Rows.Count == 1)
            {
                CurrentPage--;
            }
            DDatHangBUS.XoaDonDatHang(ddhDTO);

            BindItemsList();
        }
        catch (Exception ex)
        { }
    }
    protected void GridView1_RowSelect(object sender, GridViewSelectEventArgs e)
    {
        DDatHangDTO ddhDTO = new DDatHangDTO();
        ddhDTO.MaHD = int.Parse(GridView1.DataKeys[e.NewSelectedIndex]["MaHD"].ToString());
        DataTable dt = DDatHangBUS.LayChiTietHoaDon(ddhDTO);
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }
    #endregion
    
}