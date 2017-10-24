using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoaiSPDTO
/// </summary>
public class LoaiSPDTO
{
	public LoaiSPDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _MaLoai;

    public int MaLoai
    {
        get { return _MaLoai; }
        set { _MaLoai = value; }
    }
    private string _TenLoai;

    public string TenLoai
    {
        get { return _TenLoai; }
        set { _TenLoai = value; }
    }

}