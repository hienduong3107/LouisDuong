using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SanPhamBUS
/// </summary>
public class SanPhamBUS
{
	public SanPhamBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static bool KiemTraSPTonTai(SanPhamDTO spDTO)
    {
        return SanPhamDAO.KiemTraSanPhamTonTai(spDTO);
    }
    public static bool ThemSanPham(SanPhamDTO spDTO)
    {
        return SanPhamDAO.ThemSanPham(spDTO);
    }
    public static bool TangLike(SanPhamDTO spDTO)
    {
        return SanPhamDAO.TangLike(spDTO);
    }
    public static DataTable LayThongTinSanPham(SanPhamDTO spDTO)
    {
        return SanPhamDAO.LayThongTinSanPham(spDTO);
    }
    public static bool ThemCamNhan(SanPhamDTO spDTO)
    {
        return SanPhamDAO.ThemCamNhan(spDTO);
    }
    public static DataTable LayDanhSachSanPham()
    {
        return SanPhamDAO.LayDanhSachSanPham();
    }
    public static void SuaThongTin(SanPhamDTO spDTO)
    {
        SanPhamDAO.SuaThongTin(spDTO);
    }
    public static void XoaSanPham(SanPhamDTO spDTO)
    {
        SanPhamDAO.XoaSanPham(spDTO);
    }
    public static DataTable Search(SanPhamDTO spDTO)
    {
        return SanPhamDAO.Search(spDTO);
    }
    public static DataTable LayCamNhan()
    {
        return SanPhamDAO.LayCamNhan();
    }
    public static void SetOnOff(SanPhamDTO spDTO)
    {
        SanPhamDAO.SetOnOff(spDTO);
    }
}