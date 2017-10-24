using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
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
}