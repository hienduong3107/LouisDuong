using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for NguoiDungBUS
/// </summary>
public class NguoiDungBUS
{
    public static bool ktraTonTai(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.ktraTonTai(ndDTO);
    }
    public static bool themNguoiDung(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.themNguoiDung(ndDTO);
    }
    public static bool ktraDangNhap(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.ktraDangNhap(ndDTO);
    }
    public static DataTable LayTenDangNhap(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.LayTenDangNhap(ndDTO);
    }
    public static bool ktraQuenMatKhau(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.ktraQuenMatKhau(ndDTO);
    }
    public static string LayMatKhau(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.LayMatKhau(ndDTO);
    }
    public static void DoiMatKhau(NguoiDungDTO ndDTO)
    {
        NguoiDungDAO.DoiMatKhau(ndDTO);
    }
    public static bool ktraAdmin(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.ktraAdmin(ndDTO);
    }
    public static DataTable LayDanhSachNguoiDung()
    {
        return NguoiDungDAO.LayDanhSachNguoiDung();
    }
    public static void SuaThongTin(NguoiDungDTO ndDTO)
    {
        NguoiDungDAO.SuaThongTin(ndDTO);
    }
    public static DataTable LayThongTinNguoiDungVuaDangKi(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.LayThongTinNguoiDungVuaDangKi(ndDTO);
    }

    public static bool AdminThemNguoiDung(NguoiDungDTO ndDTO)
    {
        return NguoiDungDAO.AdminThemNguoiDung(ndDTO);
    }
    public static void XoaNguoiDung(NguoiDungDTO ndDTO)
    {
        NguoiDungDAO.XoaNguoiDung(ndDTO);
    }
}