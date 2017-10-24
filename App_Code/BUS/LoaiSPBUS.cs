using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for LoaiSPBUS
/// </summary>
public class LoaiSPBUS
{
	public LoaiSPBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable LayThongTinLoaiSanPham()
    {
        return LoaiSPDAO.LayThongTinLoaiSanPham();
    }
    public static bool ThemLoaiSanPham(LoaiSPDTO lspDTO)
    {
        return LoaiSPDAO.ThemLoaiSanPham(lspDTO);
    }
    public static void SuaThongTin(LoaiSPDTO lspDTO)
    {
        LoaiSPDAO.SuaThongTin(lspDTO);
    }
    public static void XoaLoaiSP(LoaiSPDTO lspDTO)
    {
        LoaiSPDAO.XoaLoaiSP(lspDTO);
    }
}