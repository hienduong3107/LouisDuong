using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_uc_addmanu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            manufacturerDTO mDTO = new manufacturerDTO();
            mDTO.MaNSX = txtID.Text;
            mDTO.TenNSX = txtName.Text;
            mDTO.LogoNSX = "~/NguoiDung/images/NSX/" + FileUploadAvatar.FileName;
            if (manufacturerBUS.KTTonTai(mDTO) == false)
            {
                manufacturerBUS.ThemNSX(mDTO);
                UpAnh();
                lblThongBao.Text = "Thêm thành công";
            }
            else
                lblThongBao.Text = "Thêm thất bại";
        }
        catch (Exception ex)
        { }
    }
    protected void UpAnh()
    {
        HttpPostedFile avatar = FileUploadAvatar.PostedFile;
        
        if (FileUploadAvatar.HasFile == false && avatar.ContentLength > 500000 )
            
        {
            return;

        }
        else
        {
            try
            {
                if (FileUploadAvatar.FileName != "")
                {
                    string sAvatar = Server.MapPath("~/NguoiDung/images/NSX/" + FileUploadAvatar.FileName);
                    FileUploadAvatar.SaveAs(sAvatar);
                }
               
            }
            catch
            {

            }
        }
    }
}