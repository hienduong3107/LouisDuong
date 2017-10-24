using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for LoaiSPDAO
/// </summary>
public class LoaiSPDAO
{
    public LoaiSPDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region lay thong tin
    public static DataTable LayThongTinLoaiSanPham()
    {
        string sQuery = "select * from   LoaiSP";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    #endregion
    #region them thong tin
    public static void SuaThongTin(LoaiSPDTO lspDTO)
    {
        string sQuery = "update LoaiSP set TenLoai='" + lspDTO.TenLoai + "' where MaLoai=" + lspDTO.MaLoai;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static bool ThemLoaiSanPham(LoaiSPDTO lspDTO)
    {
        string sQuery = "insert into LoaiSP(MaLoai,TenLoai) values(" + lspDTO.MaLoai + ",'" + lspDTO.TenLoai + "')";
        OleDbConnection con = DataProvider.TaoKetNoi();
        bool kq = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return kq;
    }
    public static void XoaLoaiSP(LoaiSPDTO lspDTO)
    {
        string sQuery = "delete from LoaiSP where MaLoai = " + lspDTO.MaLoai;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    #endregion
}