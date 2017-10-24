using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_uc_viewallproducts : System.Web.UI.UserControl
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
        DataTable dt = SanPhamBUS.LayDanhSachSanPham();
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
        _PageDataSource.PageSize = 10;
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

            string sMaSP = gv.DataKeys[e.RowIndex]["MaSP"].ToString();
            string sNewName = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string sNewAvatar = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string sNewPrice = ((TextBox)(row.Cells[3].Controls[0])).Text;
            string sNewInventory = ((TextBox)(row.Cells[4].Controls[0])).Text;
            string sNewKind = ((TextBox)(row.Cells[5].Controls[0])).Text;
            string sNewManufacturers = ((TextBox)(row.Cells[6].Controls[0])).Text;
            string sNewLike = ((TextBox)(row.Cells[7].Controls[0])).Text;
            string sNewDateAdd = ((TextBox)(row.Cells[8].Controls[0])).Text;

            SanPhamDTO spDTO = new SanPhamDTO();
            spDTO.Ma = int.Parse(sMaSP);
            spDTO.Ten = sNewName;
            spDTO.DuongDanLogo = sNewAvatar;
            spDTO.DonGia = int.Parse(sNewPrice);
            spDTO.SoLuongCon = int.Parse(sNewInventory);
            spDTO.LoaiSP = int.Parse(sNewKind);
            spDTO.NSX = sNewManufacturers;
            spDTO.SoLike = int.Parse(sNewLike);
            spDTO.NgayNhapHang = DateTime.Parse(sNewDateAdd);

            SanPhamBUS.SuaThongTin(spDTO);
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

        GridView gv = (GridView)sender;
        GridViewRow row = GridView1.Rows[e.RowIndex];

        string sMaSP = gv.DataKeys[e.RowIndex]["MaSP"].ToString();
        SanPhamDTO spDTO = new SanPhamDTO();
        spDTO.Ma = int.Parse(sMaSP);
        if (gv.Rows.Count == 1)
        {
            CurrentPage--;
        }

        string sAvatar = row.Cells[2].Text;
        try
        {
            FileInfo file = new FileInfo(Server.MapPath(sAvatar));
            if (file.Exists)
            {
                File.Delete(Server.MapPath(sAvatar));
            }
        }
        catch
        {
        }
   
        SanPhamBUS.XoaSanPham(spDTO);
        
        BindItemsList();
    }
    protected void SetActiveChange(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            string sMaSP = GridView1.DataKeys[e.NewSelectedIndex]["MaSP"].ToString();
            string sAc = GridView1.Rows[e.NewSelectedIndex].Cells[GridView1.Columns.Count - 3].Text;
            SanPhamDTO spDTO = new SanPhamDTO();
            if (int.Parse(sAc) == 1)
                spDTO.Active = 0;
            else
                spDTO.Active = 1;
            spDTO.Ma = int.Parse(sMaSP);
            SanPhamBUS.SetOnOff(spDTO);
            BindItemsList();
        }
        catch(Exception ex)
        {}
    }
    #endregion
}