using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DoiMatKhau : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDMK_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDungDTO ndDTO = new NguoiDungDTO();
            ndDTO.Username = txtTK.Text;
            ndDTO.Pass = txtMKcu.Text;
            ndDTO.Newpass = txtMKmoi.Text;
            if (NguoiDungBUS.ktraDangNhap(ndDTO) == true)
            {
                NguoiDungBUS.DoiMatKhau(ndDTO);
                lblThongBao.Text = "Đổi thành công";
            }
            else
                lblThongBao.Text = "Đổi thất bại";
        }
        catch
        { }
    }
    //protected void btnreset_Click(object sender, EventArgs e)
    //{
    //    txtTK.Text = "";
    //    txtMKcu.Text = "";
    //    txtMKmoi.Text = "";
    //}
}