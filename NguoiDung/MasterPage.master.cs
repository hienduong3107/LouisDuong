using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
            //Hien So Luong San Pham
            if (Session["GioHang"] != null)
            {
                lblSL.Text = Session["TongSL"].ToString();
                lblTongTien.Text = Session["TongTien"].ToString();
            }

            //hien thi ten dang nhap
            if (Session["TenDangNhap"] != null)//Da dang nhap
            {
                hplTK.Text = Session["TenDangNhap"].ToString();
                pnldadangnhap.Visible = true;
                pnlchuadangnhap.Visible = false;
            }

            Session["lastUrl"] = Request.RawUrl.ToString();
        //}
        //catch (Exception ex)
        //{ 
            
        //}
    }
    protected void hplLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["TenDangNhap"] = null;
            if (Session["TenDangNhap"] == null)
            {
                pnlchuadangnhap.Visible = true;
                pnldadangnhap.Visible = false;
                Response.Redirect(Request.RawUrl, true);
            }
        }
        catch (Exception ex)
        { }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (txtSearch.Text != "")
        {
            string sKey = txtSearch.Text;
            Response.Redirect("SanPham.aspx?Key=" + sKey);
        }
        else
        {
            string lastURL = Session["lastUrl"].ToString();
            Response.Write("<script type='text/javascript'>"
                + "alert('Yêu cầu nhập thông tin vào ô tìm kiếm');"
                + "window.location.href = \"" + lastURL + "\";"
                + "</script>");
        }
    }
}