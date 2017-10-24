using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
/// <summary>
/// Summary description for manufacturerDAO
/// </summary>
public class manufacturerDAO
{
	public manufacturerDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region lay thong tin
    public static DataTable LayDanhSachNSX()
    {
        string sQuery = "select * from NhaSanXuat";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    public static bool ktraTonTai(manufacturerDTO mDTO)
    {
        string sQuery = "select * from NhaSanXuat where MaNSX='" + mDTO.MaNSX + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    #endregion
    #region them thong tin
    public static void SuaThongTin(manufacturerDTO mDTO)
    {
        string sQuery = "update NhaSanXuat set TenNSX = '" + mDTO.TenNSX + "',Logo ='" + mDTO.LogoNSX + "' where MaNSX = '" + mDTO.MaNSX + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static void XoaNSX(manufacturerDTO mDTO)
    {
        string sQuery = "delete from NhaSanXuat where MaNSX ='" + mDTO.MaNSX + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static void ThemNSX(manufacturerDTO mDTO)
    {
        string sQuery = "insert into NhaSanXuat(MaNSX,TenNSX,Logo) values('" + mDTO.MaNSX + "','" + mDTO.TenNSX + "','" + mDTO.LogoNSX + "')";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    #endregion
}