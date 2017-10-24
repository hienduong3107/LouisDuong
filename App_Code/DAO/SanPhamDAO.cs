using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for ThemSanPhamDAO
/// </summary>
public class SanPhamDAO
{
    public SanPhamDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Lay thong tin
    public static DataTable LayCamNhan()
    {
        string sQuery = "select * from SanPham where CamNhan <> '' ";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    public static bool KiemTraSanPhamTonTai(SanPhamDTO spDTO)
    {
        string sQuery = "select * from SanPham where MaSP=" + spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    public static string CamNhanCu(SanPhamDTO spDTO)
    {
        string CamNhanCu;
        string sQuery = "select CamNhan from SanPham where MaSP = " + spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        if (dt == null)
        {
            CamNhanCu = "";
        }
        else
            CamNhanCu = dt.Rows[0][0].ToString();
        return CamNhanCu;
    }
    public static DataTable LayDanhSachSanPham()
    {
        string sQuery = "select * from SanPham order by MaSP asc";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    public static DataTable LayThongTinSanPham(SanPhamDTO spDTO)
    {
        string sQuery = "";
        if (spDTO.LoaiSP == 0 && spDTO.NSX != null && spDTO.Key == null && spDTO.GiaLon == -1)
            sQuery = "select * from SanPham where NSX ='" + spDTO.NSX + "' and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.LoaiSP != 0 && spDTO.NSX == null && spDTO.Key == null && spDTO.GiaLon == -1)
            sQuery = "select * from SanPham where LoaiSP =" + spDTO.LoaiSP + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.LoaiSP != 0 && spDTO.NSX != null && spDTO.Key == null && spDTO.GiaLon == -1)
            sQuery = "select * from SanPham where LoaiSP =" + spDTO.LoaiSP + " and NSX ='" + spDTO.NSX + "' and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.LoaiSP == 0 && spDTO.NSX == null && spDTO.Key != null && spDTO.GiaLon == -1)
            sQuery = "select * from SanPham where TenSP like '%" + spDTO.Key + "%' or NSX like '%"
                + spDTO.Key + "%' or DonGia like '%" + spDTO.Key + "%' and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.LoaiSP == 0 && spDTO.NSX == null && spDTO.Key == null && spDTO.GiaLon == -1)
            sQuery = "select * from SanPham where Active = 1 ORDER BY NgayNhapHang DESC";
        if (spDTO.GiaNho >= 0 && spDTO.GiaNho > 0)
            sQuery = "select * from SanPham where DonGia >=" + spDTO.GiaNho + " and Active = 1  and DonGia <=" + spDTO.GiaLon;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }
    #endregion
    #region Them thong tin
    public static bool ThemSanPham(SanPhamDTO spDTO)
    {
        string sQuery = "insert into SanPham(TenSP,MoTa,HinhDaiDien,DonGia,SoLuongCon,LoaiSP,NSX,HinhLon,HinhTrungBinh,NgayNhapHang,SoLike,Active) values('" 
            + spDTO.Ten + "','"+ spDTO.MoTa+"','" + spDTO.DuongDanLogo + "'," + spDTO.DonGia + "," 
            + spDTO.SoLuongCon + "," + spDTO.LoaiSP + ",'" + spDTO.NSX + "','" + spDTO.HinhLon + "','" + spDTO.HinhTrungBinh 
            +  "','"+spDTO.NgayNhapHang+"',0,1)";
        OleDbConnection con = DataProvider.TaoKetNoi();
        bool ketqua = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return ketqua;
    }
    public static bool TangLike(SanPhamDTO spDTO)
    {
        string sQuery = "update SanPham set SoLike = " + spDTO.SoLike + " where MaSP =" + spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        bool ketqua = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return ketqua;
    }

   
    public static bool ThemCamNhan(SanPhamDTO spDTO)
    {
        string sQuery;
        if(CamNhanCu(spDTO) == "")
            sQuery = "update SanPham set CamNhan = '" +spDTO.CamNhan + "' where MaSP =" + spDTO.Ma;
        else
            sQuery = "update SanPham set CamNhan = '"+ spDTO.NgayCamNhan + " " + spDTO.NguoiCamNhan + " " 
                +spDTO.CamNhan +"\r\n"+ CamNhanCu(spDTO) 
                + "' where MaSP =" + spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        bool ketqua = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return ketqua;
    }

    public static void SuaThongTin(SanPhamDTO spDTO)
    { 
        string sQuery = "update SanPham set TenSP ='"+spDTO.Ten+"',HinhDaiDien = '"+spDTO.DuongDanLogo
            +"',DonGia ="+spDTO.DonGia+",SoLuongCon="+spDTO.SoLuongCon+",LoaiSP="+spDTO.LoaiSP+",NSX ='"+spDTO.NSX
            +"',SoLike ="+spDTO.SoLike+",NgayNhapHang = '"+spDTO.NgayNhapHang+"' where MaSP = " +spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static void SetOnOff(SanPhamDTO spDTO)
    {
        string sQuery = "update SanPham set Active = "+spDTO.Active+" where MaSP =" + spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static void XoaSanPham(SanPhamDTO spDTO)
    {
        string sQuery = "delete from SanPham where MaSP =" + spDTO.Ma;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static DataTable Search(SanPhamDTO spDTO)
    {
        string sQuery = "";
        if(spDTO.GiaNho != 0 && spDTO.GiaLon != 0 && spDTO.Ten != null)
            sQuery = "select * from SanPham where TenSP like '%" + spDTO.Ten + "%' and NSX ='" + spDTO.NSX
            + "' and LoaiSP = " + spDTO.LoaiSP + " and DonGia >=" + spDTO.GiaNho + " and DonGia <=" + spDTO.GiaLon + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.GiaNho != 0 && spDTO.GiaLon != 0 && spDTO.Ten == null)
            sQuery = "select * from SanPham where NSX ='" + spDTO.NSX + "' and LoaiSP = " + spDTO.LoaiSP + " and DonGia >="
                + spDTO.GiaNho + " and DonGia <=" + spDTO.GiaLon + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.GiaNho != 0 && spDTO.GiaLon == 0 && spDTO.Ten != null)
            sQuery = "select * from SanPham where TenSP like '%" + spDTO.Ten + "%' and NSX ='" + spDTO.NSX
            + "' and LoaiSP = " + spDTO.LoaiSP + " and DonGia >=" + spDTO.GiaNho + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.GiaNho == 0 && spDTO.GiaLon != 0 && spDTO.Ten != null)
            sQuery = "select * from SanPham where TenSP like '%" + spDTO.Ten + "%' and NSX ='" + spDTO.NSX
            + "' and LoaiSP = " + spDTO.LoaiSP + " and DonGia <=" + spDTO.GiaLon + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.GiaNho != 0 && spDTO.GiaLon == 0 && spDTO.Ten == null)
            sQuery = "select * from SanPham where NSX ='" + spDTO.NSX + "' and LoaiSP = " + spDTO.LoaiSP + " and DonGia >="
                + spDTO.GiaNho + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.GiaNho == 0 && spDTO.GiaLon != 0 && spDTO.Ten == null)
            sQuery = "select * from SanPham where NSX ='" + spDTO.NSX + "' and LoaiSP = " + spDTO.LoaiSP + " and DonGia <="
                + spDTO.GiaLon + " and Active = 1 order by NgayNhapHang DESC";
        if (spDTO.GiaNho == 0 && spDTO.GiaLon == 0 && spDTO.Ten != null)
            sQuery = "select * from SanPham where TenSP like '%" + spDTO.Ten + "%' and NSX ='" + spDTO.NSX
            + "' and Active = 1 and LoaiSP = " + spDTO.LoaiSP;
        if (spDTO.GiaNho == 0 && spDTO.GiaLon == 0 && spDTO.Ten == null)
            sQuery = "select * from SanPham where NSX ='" + spDTO.NSX + "' and LoaiSP = " + spDTO.LoaiSP;

        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;

    }
    #endregion
}