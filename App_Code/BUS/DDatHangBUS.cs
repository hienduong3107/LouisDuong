using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DDatHangBUS
/// </summary>
public class DDatHangBUS
{
	public DDatHangBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool ThemDonDatHang(DDatHangDTO ddhDTO)
    {
        return DDatHangDAO.ThemDonDatHang(ddhDTO);
    }
    public static string LayMaHoaDon()
    {
        return DDatHangDAO.LayMaHoaDon();
    }
    public static void ThemChiTietHoaDon(DDatHangDTO ddhDTO)
    {
        DDatHangDAO.ThemChiTietHoaDon(ddhDTO);
    }
    public static DataTable LayDanhSachDonDatHang()
    {
        return DDatHangDAO.LayDanhSachDonDatHang();
    }
    public static void SuaDonDatHang(DDatHangDTO ddhDTO)
    {
        DDatHangDAO.SuaDonDatHang(ddhDTO);
    }
    public static void XoaDonDatHang(DDatHangDTO ddhDTO)
    {
        DDatHangDAO.XoaDonDatHang(ddhDTO);
    }
    public static DataTable LayChiTietHoaDon(DDatHangDTO ddhDTO)
    {
        return DDatHangDAO.LayChiTietHoaDon(ddhDTO);
    }
}