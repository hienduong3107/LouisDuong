using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for DDatHangDAO
/// </summary>
public class DDatHangDAO
{
	public DDatHangDAO()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region lay thong tin
    public static DataTable LayChiTietHoaDon(DDatHangDTO ddhDTO)
    {
        string sQuery = "select * from ChiTietHoaDon where MaHD =" + ddhDTO.MaHD;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    public static string LayMaHoaDon()
    {
        string sQuery = "select top 1 MaHD from HoaDon order by MaHD desc";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        string kq = dt.Rows[0][0].ToString();
        return kq;
    }
    public static DataTable LayDanhSachDonDatHang()
    {
        string sQuery = "select * from HoaDon order by MaHD asc";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    #endregion
    #region them thong tin
    public static bool ThemDonDatHang(DDatHangDTO ddhDTO)
    {
        string sQuery = "insert into HoaDon(TenDangNhap,DiaDiemGiaoHang,SDT,TenNguoiNhan,NgayGiao,TongTien,NgayNhapHD) values('"
            + ddhDTO.Username + "','" + ddhDTO.DiaChi + "','" + ddhDTO.SDT + "','" + ddhDTO.TenNguoiNhan + "','"
            + ddhDTO.NgayGiao + "'," + ddhDTO.TongTien + ",'"+ddhDTO.NgapNhapHD+"')";
        OleDbConnection con = DataProvider.TaoKetNoi();
        bool kq = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return kq;
    }
    public static void ThemChiTietHoaDon(DDatHangDTO ddhDTO)
    {
        string sQuery = "insert into ChiTietHoaDon(MaHD,MaSP,DonGia,SoLuong) values(" + ddhDTO.MaHD
            + "," + ddhDTO.MaSP + "," + ddhDTO.DonGiaSP + "," + ddhDTO.SoLuongSP + ")";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }

    public static void SuaDonDatHang(DDatHangDTO ddhDTO)
    {
        string sQuery = "update HoaDon set TenDangNhap = '" + ddhDTO.Username + "',DiaDiemGiaoHang ='"
            + ddhDTO.DiaChi + "',SDT ='" + ddhDTO.SDT + "',TenNguoiNhan='" + ddhDTO.TenNguoiNhan + "',NgayGiao='"
            + ddhDTO.Newdelivery + "',TongTien=" + ddhDTO.TongTien + ",NgayNhapHD='" + ddhDTO.NewOrder + "' where MaHD =" + ddhDTO.MaHD;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static void XoaDonDatHang(DDatHangDTO ddhDTO)
    {
        string sQuery = "delete from HoaDon where MaHD =" + ddhDTO.MaHD;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
  
    #endregion
}