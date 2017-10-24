using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuenMatKhau : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnLayMK_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDungDTO ndDTO = new NguoiDungDTO();
            ndDTO.Username = txtTK.Text;
            ndDTO.Mail = txtMail.Text;
            if (NguoiDungBUS.ktraQuenMatKhau(ndDTO) == true)
            {
                lblThongBao.Text = "Mật khẩu của bạn là : " + NguoiDungBUS.LayMatKhau(ndDTO);
            }
            else
                lblThongBao.Text = "Sai tài khoản hoặc địa chỉ Email đăng kí";
        }
        catch (Exception ex)
        { }
    }
}