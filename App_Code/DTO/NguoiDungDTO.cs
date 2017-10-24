using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NguoiDungDTO
/// </summary>
public class NguoiDungDTO
{
    string _Username;

    public string Username
    {
        get { return _Username; }
        set { _Username = value; }
    }
    string _Pass;

    public string Pass
    {
        get { return _Pass; }
        set { _Pass = value; }
    }

    private string _Mail;

    public string Mail
    {
        get { return _Mail; }
        set { _Mail = value; }
    }

    private string _Newpass;

    public string Newpass
    {
        get { return _Newpass; }
        set { _Newpass = value; }
    }
	public NguoiDungDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int _LoaiND;

    public int LoaiND
    {
        get { return _LoaiND; }
        set { _LoaiND = value; }
    }
}