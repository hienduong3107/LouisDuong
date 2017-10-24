using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnDN_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDungDTO ndDTO = new NguoiDungDTO();
            ndDTO.Username = txtTK.Text;
            ndDTO.Pass = txtMK.Text;
            if (NguoiDungBUS.ktraDangNhap(ndDTO) == true)
            {
                //Neu dang nhap thanh cong
                DataRow dr = NguoiDungBUS.LayTenDangNhap(ndDTO).Rows[0];
                Session["TenDangNhap"] = dr["TenDangNhap"];
            }
            kt();
        }
        catch (Exception ex)
        { }

    }
    //protected void btnreset_Click(object sender, EventArgs e)
    //{
    //    txtTK.Text = "";
    //    txtMK.Text = "";
    //}
    protected void kt()
    {
        HyperLink hplTK = (HyperLink)this.Master.FindControl("hplTK");
        Panel pnlchuadangnhap = (Panel)this.Master.FindControl("pnlchuadangnhap");
        Panel pnldadangnhap = (Panel)this.Master.FindControl("pnldadangnhap");
        if (Session["TenDangNhap"] != null)//Da dang nhap
        {
            hplTK.Text = Session["TenDangNhap"].ToString();
            pnlDangNhap.Visible = false;
            pnldadangnhap.Visible = true;
            pnlchuadangnhap.Visible = false;
            Response.Redirect("Default.aspx");
        }     
        
   }


    protected void btnreset_Click1(object sender, EventArgs e)
    {
        txtTK.Text = "";
        txtMK.Text = "";
    }
}