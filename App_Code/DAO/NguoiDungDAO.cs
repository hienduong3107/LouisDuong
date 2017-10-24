using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for NguoiDungDAO
/// </summary>
public class NguoiDungDAO
{
    #region laythongTin
    public static DataTable LayThongTinNguoiDungVuaDangKi(NguoiDungDTO ndDTO)
    { 
        string sQuery = "select * from NguoiDung where TenDangNhap ='"+ndDTO.Username+"'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        string s = GiaiMa(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
        dt.Rows[0][1] = s;
        return dt;
    }
    public static DataTable LayDanhSachNguoiDung()
    {
        string sQuery = "select * from NguoiDung";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string s = GiaiMa(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
            dt.Rows[i][1] = s;
        }
        return dt;
    }
    public static bool ktraTonTai(NguoiDungDTO ndDTO)
    {
            string sQuery = "select * from NguoiDung where TenDangNhap='" + ndDTO.Username + "'";            
            OleDbConnection con = DataProvider.TaoKetNoi();
            DataTable dt = DataProvider.LayDataTable(sQuery, con);
            DataProvider.DongKetNoi(con);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
    }
    public static bool ktraDangNhap(NguoiDungDTO ndDTO)
    {
        string sQuery = "select * from NguoiDung where TenDangNhap='" + ndDTO.Username + "' and MatKhau='"
            +MaHoa(ndDTO.Username,ndDTO.Pass)+"'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    public static bool ktraAdmin(NguoiDungDTO ndDTO)
    {
        string sQuery = "select * from NguoiDung where TenDangNhap='" + ndDTO.Username + "' and MatKhau='"
            + MaHoa(ndDTO.Username, ndDTO.Pass) + "' and LoaiNguoiDung = "+ 1 ;
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    public static bool ktraQuenMatKhau(NguoiDungDTO ndDTO)
    {
        string sQuery = "select * from NguoiDung where TenDangNhap='" + ndDTO.Username + "' and DiaChiMail='" + ndDTO.Mail + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
    public static string LayMatKhau(NguoiDungDTO ndDTO)
    {
        string ketqua;
        string sQuery = " select MatKhau from NguoiDung where TenDangNhap='" + ndDTO.Username + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        ketqua = dt.Rows[0][0].ToString();
        ketqua = GiaiMa(ndDTO.Username, ketqua);
        return ketqua;
    }
    public static DataTable LayTenDangNhap(NguoiDungDTO ndDTO)
    {
        string sQuery = "select * from NguoiDung where TenDangNhap='" + ndDTO.Username + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataTable dt = DataProvider.LayDataTable(sQuery, con);
        DataProvider.DongKetNoi(con);
        return dt;
    }

    #endregion
    #region themThongTin
    public static string MaHoa(string key, string toEn)
    {
        byte[] keyArray;
        byte[] toEndcry = UTF8Encoding.UTF8.GetBytes(toEn);
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        keyArray = md5.ComputeHash(UTF32Encoding.UTF8.GetBytes(key));
        TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider();
        trip.Key = keyArray;
        trip.Mode = CipherMode.ECB;
        trip.Padding = PaddingMode.PKCS7;
        ICryptoTransform tranform = trip.CreateEncryptor();
        byte[] resualArray = tranform.TransformFinalBlock(toEndcry, 0, toEndcry.Length);
        return Convert.ToBase64String(resualArray, 0, resualArray.Length);
    }
    public static string GiaiMa(string key, string toDe)
    {
        byte[] keyArray = null;
        byte[] toEndArray = Convert.FromBase64String(toDe);
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        keyArray = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        TripleDESCryptoServiceProvider trip = new TripleDESCryptoServiceProvider();
        trip.Key = keyArray;
        trip.Mode = CipherMode.ECB;
        trip.Padding = PaddingMode.PKCS7;
        ICryptoTransform tranfrom = trip.CreateDecryptor();
        byte[] resualArray = tranfrom.TransformFinalBlock(toEndArray, 0,toEndArray.Length);
        return UTF32Encoding.UTF8.GetString(resualArray);

    }
    public static bool themNguoiDung(NguoiDungDTO ndDTO)
    {
        string sPassEncode = MaHoa(ndDTO.Username,ndDTO.Pass);
        string sQuery = "insert into NguoiDung(TenDangNhap,MatKhau,LoaiNguoiDung,DiaChiMail) values('" + ndDTO.Username + "','" +
            sPassEncode + "',2,'"+ndDTO.Mail+"')";
        OleDbConnection con=DataProvider.TaoKetNoi();
        bool ketqua = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return ketqua;
    }
    public static bool AdminThemNguoiDung(NguoiDungDTO ndDTO)
    {
        string sPassEncode = MaHoa(ndDTO.Username, ndDTO.Pass);
        string sQuery = "insert into NguoiDung(TenDangNhap,MatKhau,LoaiNguoiDung,DiaChiMail) values('" + ndDTO.Username + "','" +
            sPassEncode + "',"+ndDTO.LoaiND+",'" + ndDTO.Mail + "')";
        OleDbConnection con = DataProvider.TaoKetNoi();
        bool ketqua = DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        return ketqua;
    }
    public static void DoiMatKhau(NguoiDungDTO ndDTO)
    {
        string sNewPassEncode = MaHoa(ndDTO.Username,ndDTO.Newpass);
        string sQuery = "UPDATE NguoiDung SET MatKhau='" + sNewPassEncode + "'WHERE TenDangNhap='" + ndDTO.Username + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
        
    }

    public static void SuaThongTin(NguoiDungDTO ndDTO)
    {
        string sNewPassEncode = MaHoa(ndDTO.Username, ndDTO.Newpass);
        string sQuery = "update NguoiDung set MatKhau ='"+ sNewPassEncode +"',LoaiNguoiDung ="+ ndDTO.LoaiND +",DiaChiMail ='"+ ndDTO.Mail +"' where TenDangNhap ='"+ndDTO.Username+ "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    public static void XoaNguoiDung(NguoiDungDTO ndDTO)
    {
        string sQuery = "delete from NguoiDung where TenDangNhap ='" + ndDTO.Username + "'";
        OleDbConnection con = DataProvider.TaoKetNoi();
        DataProvider.ExecuteNonQuery(sQuery, con);
        DataProvider.DongKetNoi(con);
    }
    #endregion
}