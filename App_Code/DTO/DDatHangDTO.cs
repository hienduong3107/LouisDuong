using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DDatHangDTO
/// </summary>
public class DDatHangDTO
{
	public DDatHangDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string _Username;

    public string Username
    {
        get { return _Username; }
        set { _Username = value; }
    }
    private string _DiaChi;

    public string DiaChi
    {
        get { return _DiaChi; }
        set { _DiaChi = value; }
    }
    private string _SDT;

    public string SDT
    {
        get { return _SDT; }
        set { _SDT = value; }
    }
    private DateTime _NgayGiao;

    public DateTime NgayGiao
    {
        get { return _NgayGiao; }
        set { _NgayGiao = value; }
    }
    private string _TenNguoiNhan;

    public string TenNguoiNhan
    {
        get { return _TenNguoiNhan; }
        set { _TenNguoiNhan = value; }
    }
    private int _TongTien;

    public int TongTien
    {
        get { return _TongTien; }
        set { _TongTien = value; }
    }
    private DateTime _NgapNhapHD;

    public DateTime NgapNhapHD
    {
        get { return _NgapNhapHD; }
        set { _NgapNhapHD = value; }
    }

    private int _MaHD;

    public int MaHD
    {
        get { return _MaHD; }
        set { _MaHD = value; }
    }

    private int _MaSP;

    public int MaSP
    {
        get { return _MaSP; }
        set { _MaSP = value; }
    }
    private int _DonGiaSP;

    public int DonGiaSP
    {
        get { return _DonGiaSP; }
        set { _DonGiaSP = value; }
    }

    private int _SoLuongSP;

    public int SoLuongSP
    {
        get { return _SoLuongSP; }
        set { _SoLuongSP = value; }
    }
    private string _NewOrder;

    public string NewOrder
    {
        get { return _NewOrder; }
        set { _NewOrder = value; }
    }
    private string _Newdelivery;

    public string Newdelivery
    {
        get { return _Newdelivery; }
        set { _Newdelivery = value; }
    }
}