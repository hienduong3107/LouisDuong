using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
/// Summary description for DataProvider
/// </summary>
public class DataProvider
{
    public static OleDbConnection TaoKetNoi()
    {
        try
        {
            string sConString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=|DataDirectory|QLBanHang.mdb;";
            OleDbConnection con = new OleDbConnection(sConString);
            con.Open();
            return con;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static DataTable LayDataTable(string sQuery, OleDbConnection con)
    {
        try
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(sQuery, con);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static bool ExecuteNonQuery(string sQuery, OleDbConnection con)
    {
        try
        {
            OleDbCommand cmd = new OleDbCommand(sQuery, con);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public static void DongKetNoi(OleDbConnection con)
    {
        con.Close();
    }
}