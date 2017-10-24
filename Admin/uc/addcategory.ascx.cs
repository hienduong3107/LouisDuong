using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_uc_addcategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            LoaiSPDTO lspDTO = new LoaiSPDTO();
            lspDTO.MaLoai = int.Parse(txtID.Text);
            lspDTO.TenLoai = txtName.Text;
            if (LoaiSPBUS.ThemLoaiSanPham(lspDTO) == true)
                lblThongBao.Text = "Thêm thành công";
            else
                lblThongBao.Text = "Thêm thất bại";
        }
        catch (Exception ex)
        { }

    }
}