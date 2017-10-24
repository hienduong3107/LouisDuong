using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SanPham : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.BindItemsList();
                if (DataList1.Items.Count == 0)
                {
                    string lastURL = Session["lastUrl"].ToString();
                    Response.Write("<script type='text/javascript'>"
                        + "alert('Không tìm thấy sản phẩm yêu cầu');"
                        + "window.location.href = \"" + lastURL + "\";"
                        + "</script>");

                }
            }
        }
        catch (Exception ex)
        {

        }

    }
    #region Xu Ly
    protected void XuLy(object sender, DataListCommandEventArgs e)
    {
        try
        {
            if (Session["TenDangNhap"] != null)
            {
                if (e.CommandName == "ThemGioHang")
                    ThemGioHang(sender, e);
                if (e.CommandName == "Like")
                {
                    Like(sender, e);
                }
            }
            else
                Response.Write("<script type='text/javascript'>alert('Bạn phải đăng nhập mới thực hiện được chức năng này.');</script>");

        }
        catch (Exception ex)
        {
        }
    }
    #endregion
    #region ThemGioHang
    protected void ThemGioHang(object sender, DataListCommandEventArgs e)
    {
        try
        {
            DataList Datalist = (DataList)sender;
            //Lấy control hiển thị số lượng và tổng tiền từ Masterpage
            Label lbl = (Label)this.Master.FindControl("lblSL");
            Label lblTT = (Label)this.Master.FindControl("lblTongTien");
            DataTable dt = new DataTable();
            if (Session["GioHang"] == null)//Kiểm tra giỏ hàng đã tồn tại chưa nếu chưa thì thực hiện
            {
                //tạo datatable chứa giỏ hàng, thêm các cột vào
                dt.Columns.Add("Mã Sản Phẩm");
                dt.Columns.Add("Tên Sản Phẩm");
                dt.Columns.Add("Số Lượng");
                dt.Columns.Add("Đơn Giá");
                dt.Columns.Add("Thành Tiền");
                dt.Rows.Add();
                //Lấy Sản phẩm được chọn gán cho datatable
                dt.Rows[0][0] = Datalist.DataKeys[e.Item.ItemIndex].ToString();//MaSP
                dt.Rows[0][1] = Server.HtmlEncode(((Label)e.Item.FindControl("TenSPLabel")).Text);
                dt.Rows[0][2] = 1;//so luong
                dt.Rows[0][3] = Server.HtmlEncode(((Label)e.Item.FindControl("DonGiaLabel")).Text);
                dt.Rows[0][4] = Server.HtmlEncode(((Label)e.Item.FindControl("DonGiaLabel")).Text);
                Session["GioHang"] = dt;//Tao gio hang
                lbl.Text = dt.Rows.Count.ToString();
                Session["TongSL"] = 1;//Session tong so luong
                Session["TongTien"] = Convert.ToDouble(dt.Rows[0][4].ToString());//tao tong tien (session tong tien de khong phai tinh lai tu datatable gio hang)
                lblTT.Text = Session["TongTien"].ToString();
                return;//ket thuc viec tao gio hang
            }
            //gio hang da ton tai, tien hanh them vao gio hang
            //lay gio hang cu
            dt = (DataTable)Session["GioHang"];
            //lay tong tien hien tai(truoc khi them sp nay)
            double dTongTien = Convert.ToDouble(Session["TongTien"].ToString());
            //Lấy mã SP
            string sMaSP = Datalist.DataKeys[e.Item.ItemIndex].ToString();
            //Lặp kiểm tra nếu sản phẩm tồn tại rồi thì cộng dồn số lượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == sMaSP)
                {
                    int iSoLuong = Convert.ToInt32(dt.Rows[i][2]);
                    iSoLuong++;//cộng dồn số lượng
                    dt.Rows[i][2] = iSoLuong;
                    double iTien = Convert.ToDouble(dt.Rows[i][3]);
                    dTongTien = dTongTien + Convert.ToDouble(dt.Rows[i][3]);//Cộng dồn vào tổng tiền giỏ hàng
                    iTien = iTien + Convert.ToDouble(dt.Rows[i][3]);
                    dt.Rows[i][4] = iTien;//thay đổi thành tiền của sp này khi đã cộng dồn số lượng
                    Session["GioHang"] = dt;//gan giỏ hàng mới
                    lbl.Text = (Convert.ToInt32(Session["TongSL"]) + 1).ToString();//cộng dồn số lượng
                    Session["TongSL"] = lbl.Text;//gán lại SL mới
                    Session["TongTien"] = dTongTien;//gán tổng tiền mới
                    lblTT.Text = Session["TongTien"].ToString();//hiển thị tổng tiền
                    return;
                }
            }
            //Neu san pham chua ton tai thi tien hanh them sp vao gio hang
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1][0] = sMaSP;
            dt.Rows[dt.Rows.Count - 1][1] = Server.HtmlEncode(((Label)e.Item.FindControl("TenSPLabel")).Text);
            dt.Rows[dt.Rows.Count - 1][2] = 1;
            dt.Rows[dt.Rows.Count - 1][3] = Server.HtmlEncode(((Label)e.Item.FindControl("DonGiaLabel")).Text);
            dt.Rows[dt.Rows.Count - 1][4] = Server.HtmlEncode(((Label)e.Item.FindControl("DonGiaLabel")).Text);
            dTongTien = dTongTien + Convert.ToDouble(dt.Rows[dt.Rows.Count - 1][4].ToString());//cong don tong tien
            Session["GioHang"] = dt;//gan gio hang moi
            Session["TongTien"] = dTongTien;//gan tong tien moi
            lbl.Text = (Convert.ToInt32(Session["TongSL"]) + 1).ToString();//cộng dồn số lượng
            Session["TongSL"] = lbl.Text;//gán lại SL mới
            lblTT.Text = Session["TongTien"].ToString();
        }
        catch (Exception ex)
        { }
    }
    #endregion
    #region ThemLike
    protected void Like(object sender, DataListCommandEventArgs e)
    {
        try
        {
            DataList Datalist = (DataList)sender;
            string sMaSP = Datalist.DataKeys[e.Item.ItemIndex].ToString();
            string sLike = Server.HtmlEncode(((Label)e.Item.FindControl("lblLike")).Text);
            SanPhamDTO spDTO = new SanPhamDTO();
            spDTO.Ma = int.Parse(sMaSP);
            spDTO.SoLike = int.Parse(sLike) + 1;
            SanPhamBUS.TangLike(spDTO);
            Response.Redirect(Request.RawUrl, true);
        }
        catch (Exception ex)
        {

        }
    }
    #endregion


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
        DataTable dtItems = new DataTable();
        string sMaLoai = Server.UrlDecode(Request.QueryString["MaLoai"]);
        if (sMaLoai == null)
            sMaLoai = "0";
        string sKey = Server.UrlDecode(Request.QueryString["Key"]);
        string sMaNSX = Server.UrlDecode(Request.QueryString["MaNSX"]);
        SanPhamDTO spDTO = new SanPhamDTO();
        if (txtGiaNho.Text == "")
        {
            spDTO.GiaNho = -1;
        }
        else
            spDTO.GiaNho = int.Parse(txtGiaNho.Text);
        if (txtGiaLon.Text == "")
        {
            spDTO.GiaLon = -1;
        }
        else
            spDTO.GiaLon = int.Parse(txtGiaLon.Text);        
        spDTO.Key = sKey;
        spDTO.NSX = sMaNSX;
        spDTO.LoaiSP = int.Parse(sMaLoai);
        dtItems = SanPhamBUS.LayThongTinSanPham(spDTO);
        return dtItems;
    }

    /// <summary>
    /// Binding Main Items List
    /// </summary>
    private void BindItemsList()
    {

        DataTable dataTable = this.GetDataTable();
        _PageDataSource.DataSource = dataTable.DefaultView;
        _PageDataSource.AllowPaging = true;
        _PageDataSource.PageSize = 12;
        _PageDataSource.CurrentPageIndex = CurrentPage;
        ViewState["TotalPages"] = _PageDataSource.PageCount;

        this.lblPageInfo.Text = "Trang " + (CurrentPage + 1) + " trên " + _PageDataSource.PageCount;
        this.lbtnPrevious.Enabled = !_PageDataSource.IsFirstPage;
        this.lbtnNext.Enabled = !_PageDataSource.IsLastPage;
        this.lbtnFirst.Enabled = !_PageDataSource.IsFirstPage;
        this.lbtnLast.Enabled = !_PageDataSource.IsLastPage;

        this.DataList1.DataSource = _PageDataSource;
        this.DataList1.DataBind();
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
    protected void btnsosanhsp_Click(object sender, EventArgs e)
    {
        Response.Redirect("SoSanh.aspx");
    }

    protected void btnSearch_price_Click(object sender, EventArgs e)
    {
        fistIndex = 0;
        lastIndex = 0;
        CurrentPage = 0;
        int a, b;
        if (txtGiaNho.Text == "")
        {
            a = -1;
        }
        else
            a = int.Parse(txtGiaNho.Text);
        if (txtGiaLon.Text == "")
        {
            b = -1;
        }
        else
            b = int.Parse(txtGiaLon.Text);
        if (a == -1 || b == -1 || a > b)
        {
            string lastURL = Session["lastUrl"].ToString();
            Response.Write("<script type='text/javascript'>"
                    + "alert('Sai cú pháp khoảng giá tìm kiếm');"
                    + "window.location.href = \"" + lastURL + "\";"
                    + "</script>");
        }
        this.BindItemsList();
        if (DataList1.Items.Count == 0)
        {
            string lastURL = Session["lastUrl"].ToString();
            Response.Write("<script type='text/javascript'>"
                + "alert('Không tìm thấy sản phẩm yêu cầu');"
                + "window.location.href = \"" + lastURL + "\";"
                + "</script>");

        }
        //txtGiaLon.Text = "";
        //txtGiaNho.Text = "";
    }
    protected void btnTimKiem_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx");
    }
}