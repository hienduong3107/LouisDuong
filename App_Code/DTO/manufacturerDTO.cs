using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for manufacturer
/// </summary>
public class manufacturerDTO
{
    public manufacturerDTO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string _MaNSX;

    public string MaNSX
    {
        get { return _MaNSX; }
        set { _MaNSX = value; }
    }
    private string _TenNSX;

    public string TenNSX
    {
        get { return _TenNSX; }
        set { _TenNSX = value; }
    }
    private string _LogoNSX;

    public string LogoNSX
    {
        get { return _LogoNSX; }
        set { _LogoNSX = value; }
    }
}