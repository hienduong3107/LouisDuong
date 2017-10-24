using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_uc_addproduct : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i <= 31; i++)
        {
            if (i == 0)
            {
                drlDay.Items.Add("Day");
            }
            else
                drlDay.Items.Add(i.ToString());
        }
        for (int i = 0; i <= 12; i++)
        {
            if (i == 0)
            {
                drlMonth.Items.Add("Month");
            }
            else
                drlMonth.Items.Add(i.ToString());
        }
        for (int i = 2000; i <= 2013; i++)
        {
            if (i == 2000)
            {
                drlYear.Items.Add("Year");
            }
            else
                drlYear.Items.Add(i.ToString());
        }

     
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            SanPhamDTO spDTO = new SanPhamDTO();

            spDTO.Ten = txtName.Text;
            spDTO.NSX = drlManufacturers.SelectedItem.Value.ToString();
            spDTO.LoaiSP = int.Parse(drlCategory.SelectedItem.Value.ToString());
            spDTO.DonGia = int.Parse(txtPrice.Text);
            DateTime d = new DateTime(int.Parse(drlYear.SelectedItem.Value), int.Parse(drlMonth.SelectedItem.Value), int.Parse(drlDay.SelectedItem.Value));
            spDTO.NgayNhapHang = d;
            spDTO.SoLuongCon = int.Parse(txtAmount.Text);
            spDTO.MoTa = Ck1.Text;
            if (FileUploadAvatar.FileName != "")
            {
                spDTO.DuongDanLogo = "~/NguoiDung/images/" + FileUploadAvatar.FileName;
            }
            if (FileUploadBigImage.FileName != "")
            {
                spDTO.HinhLon = "~/NguoiDung/images/" + FileUploadBigImage.FileName;
            }
          
            if (FileUploadMediumImage.FileName != "")
            {
                spDTO.HinhTrungBinh = "~/NguoiDung/images/" + FileUploadMediumImage.FileName;
            }
           
            UpAnh();
            SanPhamBUS.ThemSanPham(spDTO);
            lblThongBao.Text = "Thêm thành công";
        }
        catch (Exception ex)
        {
            lblThongBao.Text = "Có lỗi xảy ra. Vui lòng điền đúng kiểu dữ liệu yêu cầu";
        }
    }

    protected void UpAnh()
    {
        HttpPostedFile avatar = FileUploadAvatar.PostedFile;
        HttpPostedFile bigImage = FileUploadBigImage.PostedFile;
        HttpPostedFile mediumImage = FileUploadMediumImage.PostedFile;
        if (FileUploadAvatar.HasFile == false && avatar.ContentLength > 500000 ||
            FileUploadBigImage.HasFile == false && bigImage.ContentLength > 500000 ||
            FileUploadMediumImage.HasFile == false && mediumImage.ContentLength > 500000)
        {
            return;

        }
        else
        {
            try
            {
                if (FileUploadAvatar.FileName != "")
                {
                    string sAvatar = Server.MapPath("~/NguoiDung/images/" + FileUploadAvatar.FileName);
                    FileUploadAvatar.SaveAs(sAvatar);
                }
                if (FileUploadBigImage.FileName != "")
                {
                    string sBigImage = Server.MapPath("~/NguoiDung/images/" + FileUploadBigImage.FileName);
                    FileUploadBigImage.SaveAs(sBigImage);
                }
                if (FileUploadMediumImage.FileName != "")
                {
                    string sMediumImage = Server.MapPath("~/NguoiDung/images/" + FileUploadMediumImage.FileName);
                    FileUploadMediumImage.SaveAs(sMediumImage);
                }
            }
            catch
            {

            }
        }
    }

}