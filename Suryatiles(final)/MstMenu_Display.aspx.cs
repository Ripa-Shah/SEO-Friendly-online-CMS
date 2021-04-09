using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class MstMenu_Display : System.Web.UI.Page
{
    Connection1 c = new Connection1();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlDataAdapter da1 = new SqlDataAdapter();
    SqlDataAdapter da2= new SqlDataAdapter();
    SqlDataAdapter da3= new SqlDataAdapter();
    
    DataTable dt = new DataTable();
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            id = Request.QueryString["ID"];
            //  Response.Write(id);
            fillData();
        }
        LinkButton lnk = (LinkButton)Master.FindControl("LinkButton1");  
    }
    public void fillData()
    {
        da.SelectCommand = new SqlCommand("select * from mstmenu1  where MenuSno=@Menusno", c.constr);
        da.SelectCommand.Parameters.Add("@MenuSno", SqlDbType.Int).Value = id.ToString();
        da.Fill(dt);
        int groupsmo = Convert.ToInt32(dt.Rows[0]["MstMenuGroupSno"].ToString());
        c.constr.Open();
        DataTable dt1 = new DataTable();
        da1 = new SqlDataAdapter("select MenuGroupSno,GroupName from mstmenugroup where MenuGroupSno=@menugroupsno", c.constr);
        da1.SelectCommand.Parameters.Add("@menugroupsno", SqlDbType.Int).Value = groupsmo;
        da1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            ddmgnm.DataSource = dt1;
            ddmgnm.AppendDataBoundItems = true;
            ddmgnm.DataTextField = "GroupName";
            ddmgnm.DataValueField = "MenuGroupSno";
            ddmgnm.DataBind();
            
        }
        else
        {
            lblmsg.Text="no record";
        }
        c.constr.Close();
        txtddmgnm.Text = ddmgnm.SelectedItem.ToString();
        int menusno = Convert.ToInt32(dt.Rows[0]["MstMenuSno"].ToString());
        c.constr.Open();
        DataTable dt2 = new DataTable();
        da2 = new SqlDataAdapter("select MenuName,MenuSno from mstmenu1 where MstMenuSno=@MstMenuSno", c.constr);
        da2.SelectCommand.Parameters.Add("@MstMenuSno", SqlDbType.Int).Value = menusno;
        da2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            ddlpmsno.DataSource = dt2;
            ddlpmsno.AppendDataBoundItems = true;
            ddlpmsno.DataTextField = "MenuName";
            ddlpmsno.DataValueField = "MenuSno";
            ddlpmsno.DataBind();
        }
        c.constr.Close();
        txtddlpmsno.Text = ddlpmsno.SelectedItem.ToString();
        txtmnm.Text = dt.Rows[0]["MenuName"].ToString();
        txtpr.Text = dt.Rows[0]["Priority"].ToString();


        c.constr.Open();
        int moduleno = Convert.ToInt32(dt.Rows[0]["MstModuleSno"].ToString());
       // Response.Write("sdf" + moduleno);
        DataTable dt3 = new DataTable();
        da3 = new SqlDataAdapter("select ModuleSno,ModuleName from mstmodule where ModuleSno=@ModuleSno", c.constr);
        da3.SelectCommand.Parameters.Add("@ModuleSno", SqlDbType.Int).Value = moduleno;
        da3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            ddlmnm.DataSource = dt3;

            ddlmnm.DataTextField = "ModuleName";
            ddlmnm.DataValueField = "ModuleSno";
            ddlmnm.DataBind();
        }
        c.constr.Close();

       txtddlmnm.Text = ddlmnm.SelectedItem.ToString();

        txtfpath.Text = dt.Rows[0]["FolderPath"].ToString();
        txtpname.Text = dt.Rows[0]["PageName"].ToString();
        txtfppnm.Text = dt.Rows[0]["FolderPath_PageName"].ToString();
        txtptitle.Text = dt.Rows[0]["PageTitle"].ToString();
        txtpdesc.Text = dt.Rows[0]["PageDescri"].ToString();
        txthits.Text = dt.Rows[0]["Hits"].ToString();
        txtfcode.Text = dt.Rows[0]["fLikeCode"].ToString();
        txtemailto.Text = dt.Rows[0]["EmailTo"].ToString();
        txtemailcc.Text = dt.Rows[0]["EmailCc"].ToString();
        txttitle.Text = dt.Rows[0]["Title"].ToString();
        txtkey.Text = dt.Rows[0]["Keyword"].ToString();
        txtdesc.Text = dt.Rows[0]["Descri"].ToString();
        txtmline.Text = dt.Rows[0]["OtherMetaLines"].ToString();


    }

  
  
}