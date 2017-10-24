using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_uc_adduser : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDungDTO ndDTO = new NguoiDungDTO();
            ndDTO.Username = txtID.Text;
            Session["Username"] = txtID.Text;
            ndDTO.Pass = txtPassword.Text;
            ndDTO.Mail = txtEmail.Text;
            ndDTO.LoaiND = int.Parse(DropDownList1.SelectedItem.Value.ToString());
            bool ktra = NguoiDungBUS.ktraTonTai(ndDTO);
            if (ktra == false)
            {
                NguoiDungBUS.AdminThemNguoiDung(ndDTO);
                lblThongBao.Text = "Thêm thành công";

            }
            else
            {
                lblThongBao.Text = "Tài khoản đã tồn tại";
            }
            BindItemsList();
        }
        catch (Exception ex)
        { }
    }
    private void BindItemsList()
    {
        NguoiDungDTO ndDTO = new NguoiDungDTO();
        ndDTO.Username = Session["Username"].ToString();
        GridView1.DataSource = NguoiDungBUS.LayThongTinNguoiDungVuaDangKi(ndDTO);
        GridView1.DataBind();
    }
    #region GridView Custom
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindItemsList();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindItemsList();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            
            GridView gv = (GridView)sender;
            GridViewRow row = GridView1.Rows[e.RowIndex];

            string sUserName = gv.DataKeys[e.RowIndex]["TenDangNhap"].ToString();
            string sNewPass = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string sNewType = ((TextBox)(row.Cells[2].Controls[0])).Text;
            string sNewMail = ((TextBox)(row.Cells[3].Controls[0])).Text;
            NguoiDungDTO ndDTO = new NguoiDungDTO();
            ndDTO.Username = sUserName;
            ndDTO.Newpass = sNewPass;
            ndDTO.LoaiND = int.Parse(sNewType);
            ndDTO.Mail = sNewMail;
            NguoiDungBUS.SuaThongTin(ndDTO);
            GridView1.EditIndex = -1;
            BindItemsList();
        }
        catch (Exception ex)
        {
            Response.Write("<script type='text/javascript'>"
                           + "alert('Có lỗi xảy ra. Vui Lòng điền đúng kiểu dữ liệu yêu cầu !!!');"
                           + "</script>");
        }
    }
    
    #endregion
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtID.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
    }
}