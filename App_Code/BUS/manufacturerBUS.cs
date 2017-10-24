using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for manufacturerBUS
/// </summary>
public class manufacturerBUS
{
	public manufacturerBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataTable LayDanhSachNSX()
    {
        return manufacturerDAO.LayDanhSachNSX();
    }
    public static void SuaThongTin(manufacturerDTO mDTO)
    {
        manufacturerDAO.SuaThongTin(mDTO);
    }
    public static void XoaNSX(manufacturerDTO mDTO)
    {
        manufacturerDAO.XoaNSX(mDTO);
    }
    public static bool KTTonTai(manufacturerDTO mDTO)
    { 
        return manufacturerDAO.ktraTonTai(mDTO);
    }
    public static void ThemNSX(manufacturerDTO mDTO)
    {
        manufacturerDAO.ThemNSX(mDTO);
    }
}