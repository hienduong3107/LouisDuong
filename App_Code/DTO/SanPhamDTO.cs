using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThemSanPhamDTO
/// </summary>
public class SanPhamDTO
{
	public SanPhamDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _Active;

    public int Active
    {
        get { return _Active; }
        set { _Active = value; }
    }
    private string _Ten;

    
    public string Ten
    {
        get { return _Ten; }
        set { _Ten = value; }
    }
    private int _Ma;

    public int Ma
    {
        get { return _Ma; }
        set { _Ma = value; }
    }

    private string _DuongDanLogo;

    public string DuongDanLogo
    {
        get { return _DuongDanLogo; }
        set { _DuongDanLogo = value; }
    }
    private int _DonGia;

    public int DonGia
    {
        get { return _DonGia; }
        set { _DonGia = value; }
    }
    private int _SoLuongCon;

    public int SoLuongCon
    {
        get { return _SoLuongCon; }
        set { _SoLuongCon = value; }
    }
    private int _LoaiSP;

    public int LoaiSP
    {
        get { return _LoaiSP; }
        set { _LoaiSP = value; }
    }
    private string _NSX;

    public string NSX
    {
        get { return _NSX; }
        set { _NSX = value; }
    }

    private int _SoLike;

    public int SoLike
    {
        get { return _SoLike; }
        set { _SoLike = value; }
    }

    private string _Key;

    public string Key
    {
        get { return _Key; }
        set { _Key = value; }
    }

    private int _GiaNho;

    public int GiaNho
    {
        get { return _GiaNho; }
        set { _GiaNho = value; }
    }

    private int _GiaLon;

    public int GiaLon
    {
        get { return _GiaLon; }
        set { _GiaLon = value; }
    }
    private string _CamNhan;

    public string CamNhan
    {
        get { return _CamNhan; }
        set { _CamNhan = value; }
    }
    private string _NgayCamNhan;

    public string NgayCamNhan
    {
        get { return _NgayCamNhan; }
        set { _NgayCamNhan = value; }
    }
    private string _NguoiCamNhan;

    public string NguoiCamNhan
    {
        get { return _NguoiCamNhan; }
        set { _NguoiCamNhan = value; }
    }
    private DateTime _NgayNhapHang;

    public DateTime NgayNhapHang
    {
        get { return _NgayNhapHang; }
        set { _NgayNhapHang = value; }
    }
    private string _HinhLon;

    public string HinhLon
    {
        get { return _HinhLon; }
        set { _HinhLon = value; }
    }
    private string _HinhTrungBinh;

    public string HinhTrungBinh
    {
        get { return _HinhTrungBinh; }
        set { _HinhTrungBinh = value; }
    }

    private string _MoTa;

    public string MoTa
    {
        get { return _MoTa; }
        set { _MoTa = value; }
    }
}