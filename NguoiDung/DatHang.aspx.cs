using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NguoiDung_DatHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i <= 31; i++)
        {
            ddlNgay.Items.Add(i.ToString());
        }
        for (int i = 1; i <= 12; i++)
        {
            ddlThang.Items.Add(i.ToString());
        }
        for (int i = 2016; i <= 2030; i++)
        {
            ddlNam.Items.Add(i.ToString());
        }
        try
        {
            lblSoLuong.Text = Session["TongSL"].ToString();
            lblTongCong.Text = Session["TongTien"].ToString() + "$";
        }
        catch
        { }
    }




   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["TenDangNhap"] == null)
            Response.Write("<script type='text/javascript'>alert('Bạn phải đăng nhập mới thực hiện được chức năng này.');</script>");
        else
        {
            try
            {
                DDatHangDTO ddhDTO = new DDatHangDTO();
                ddhDTO.Username = Session["TenDangNhap"].ToString();
                string sTongTien = lblTongCong.Text.Substring(0, lblTongCong.Text.Length - 1);
                ddhDTO.TongTien = int.Parse(sTongTien);
                ddhDTO.TenNguoiNhan = txtNguoiNhan.Text;
                ddhDTO.SDT = txtSDT.Text;
                DateTime dNgayNhapHD = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                ddhDTO.NgapNhapHD = dNgayNhapHD;
                DateTime dNgayGiao = new DateTime(int.Parse(ddlNam.SelectedItem.Value.ToString()), int.Parse(ddlThang.SelectedItem.Value.ToString()), int.Parse(ddlNgay.SelectedItem.Value.ToString()));
                ddhDTO.NgayGiao = dNgayGiao;
                ddhDTO.DiaChi = txtDiaChi.Text;
                DDatHangBUS.ThemDonDatHang(ddhDTO);
                DataTable dt = (DataTable)Session["GioHang"];
                ddhDTO.MaHD = int.Parse(DDatHangBUS.LayMaHoaDon().ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddhDTO.MaSP = int.Parse(dt.Rows[i][0].ToString());
                    ddhDTO.SoLuongSP = int.Parse(dt.Rows[i][2].ToString());
                    ddhDTO.DonGiaSP = int.Parse(dt.Rows[i][3].ToString());
                    DDatHangBUS.ThemChiTietHoaDon(ddhDTO);
                }
                lblThongBao.Text = "Đặt hàng thành công.";
            }
            catch (Exception ex)
            {
                lblThongBao.Text = "Đặt hàng thất bại.";
            }
            
        }
    }
}