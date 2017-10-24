using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        NguoiDungDTO ndDTO = new NguoiDungDTO();
        ndDTO.Username = txtUsername.Text;
        ndDTO.Pass = txtPassword.Text;
        if (NguoiDungBUS.ktraDangNhap(ndDTO) == true)
        {
            //Neu dang nhap thanh cong
            DataRow dr = NguoiDungBUS.LayTenDangNhap(ndDTO).Rows[0];
            Session["Admin"] = dr["TenDangNhap"];
            Response.Write("<script type='text/javascript'>"
                           + "alert('Đăng nhập thành công !!!');"
                           + "window.location.href = \"Default.aspx\";"
                           + "</script>");
        }
        else
            Response.Write("<script type='text/javascript'>"
                          + "alert('Đăng nhập thất bại !!!');"
                          + "</script>");
    }
}