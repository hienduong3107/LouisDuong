using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DangKi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDK_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDungDTO ndDTO = new NguoiDungDTO();
            ndDTO.Username = txtTK.Text;
            ndDTO.Pass = txtMK.Text;
            ndDTO.Mail = txtMail.Text;
            bool ktra = NguoiDungBUS.ktraTonTai(ndDTO);
            if (ktra == false)
            {
                NguoiDungBUS.themNguoiDung(ndDTO);
                lblThongBao.Text = "Đăng kí thành công";

            }
            else
            {
                lblThongBao.Text = "Tài khoản đã tồn tại";
            }
        }
        catch (Exception ex)
        { }
    }
    //protected void btnreset_Click(object sender, EventArgs e)
    //{
    //    txtTK.Text = "";
    //    txtMK.Text = "";
    //    txtMail.Text = "";
    //}
}