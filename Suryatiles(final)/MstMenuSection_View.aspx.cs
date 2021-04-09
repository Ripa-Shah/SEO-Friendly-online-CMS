using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class MstMenuSection_View : System.Web.UI.Page
{
    SqlDataAdapter da = new SqlDataAdapter();
    Connection1 c = new Connection1();
    DataTable dt = new DataTable();
    SqlDataAdapter da1 = new SqlDataAdapter();
    SqlDataAdapter da2 = new SqlDataAdapter();
    SqlDataAdapter da3 = new SqlDataAdapter();
    
    DataTable dt1 = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    
      int no;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
            fillData();
        LinkButton lnk = (LinkButton)Master.FindControl("LinkButton1");  
    }
    public void fillData()
    {

        da = new SqlDataAdapter("select mm1.MenuName,ms1.SectionName,mms.MenuSectionSno from mstmenusection mms,mstsection ms1,mstmenu1 mm1 where mm1.MenuSno=mms.MstMenuSno and ms1.SectionSno=mms.MstSectionSno",c.constr);
        da.Fill(dt);
        gvList.DataSource = dt;
        gvList.DataBind();
    
    }
   
    public void viewMstMenuSnm(string mnm)
    {
        string menu = mnm;
        c.constr.Open();
        DataTable dt2 = new DataTable();
        da = new SqlDataAdapter("select MenuName,MenuSno from mstmenu1", c.constr);
        da.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            ddlmenuname.DataSource = dt2;
            ddlmenuname.AppendDataBoundItems = true;
            ddlmenuname.DataTextField = "MenuName";
            ddlmenuname.DataValueField = "MenuSno";

            ddlmenuname.DataBind();
            ddlmenuname.Items.FindByText(menu).Selected = true;
        }
        c.constr.Close();
    }
    public void viewSectionName(string snm)
    {
        string section= snm;
        c.constr.Open();
        DataTable dt3= new DataTable();
        da = new SqlDataAdapter("select SectionName,SectionSno from mstsection", c.constr);
        da.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            ddlsectionname.DataSource = dt3;
            ddlsectionname.AppendDataBoundItems = true;
            ddlsectionname.DataTextField = "SectionName";
            ddlsectionname.DataValueField = "SectionSno";
            ddlsectionname.DataBind();
           // ddlsectionname.Items.FindByText(snm).Selected = true;
        }
        c.constr.Close();

    }
    protected void imgRemove_Command(object sender, CommandEventArgs e)
    {
        c.constr.Open();
        ImageButton imgRemove = (ImageButton)sender;
        da.DeleteCommand = new SqlCommand("Delete from mstmenusection where MenuSectionSno=@MenuSectionSno", c.constr);
        da.DeleteCommand.Parameters.Add("@MenuSectionSno", SqlDbType.Int).Value = imgRemove.CommandArgument;
        int i;
        i = da.DeleteCommand.ExecuteNonQuery();
        if (i >= 0)
        {
            lblmsg.Text = "Data Deleted Successfully!!";
        }
        else
        {
            lblmsg.Text = "Data Not Deleted";
        }

        c.constr.Close();
        fillData();

    }
    protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewRow row = gvList.Rows[e.NewEditIndex] as GridViewRow;
        Label id = row.FindControl("Label1") as Label;
        Label menunm = row.FindControl("Label3") as Label;
        Label sectionnm = row.FindControl("Label2") as Label;
        no = Convert.ToInt32(id.Text);
        //Response.Write(no);
        //this.ModalPopupExtender1.Show();
        lblmsg.Text = id.Text;
        string menuname = menunm.Text;
        string sectionname = sectionnm.Text;
        lblsno.Text = no.ToString();
        //Response.Write(lblsno.Text);
        viewMstMenuSnm(menuname);
        viewSectionName(sectionname);
        this.ModalPopupExtender1.Show();
          gvList.EditIndex = -1;
        
          
       
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       // Response.Write("hello"+lblsno.Text);
        int msno = Convert.ToInt32(lblsno.Text);

        da.UpdateCommand = new SqlCommand("update mstmenusection set UpdatedOn=@UpdatedOn,MstMenuSno=@MstMenuSno,MstSectionSno=@MstSectionSno where MenuSectionSNo=@msno", c.constr);
        da.UpdateCommand.Parameters.Add("@UpdatedOn", SqlDbType.DateTime).Value = DateTime.Now.ToLocalTime();
        da.UpdateCommand.Parameters.Add("@MstMenuSno", SqlDbType.Int).Value = ddlmenuname.SelectedValue;
        da.UpdateCommand.Parameters.Add("@MstSectionSno", SqlDbType.Int).Value = ddlsectionname.SelectedValue;
        da.UpdateCommand.Parameters.Add("@msno", SqlDbType.Int).Value = msno;

        c.constr.Open();
        int j = da.UpdateCommand.ExecuteNonQuery();
        if (j > 0)
            lblmsg.Text = "Data Updated Successfully!!";
        else
            lblmsg.Text = "Data Not Updated";
        c.constr.Close();
        this.ModalPopupExtender1.Hide();
        fillData();
        ddlmenuname.Items.Clear() ;
        ddlsectionname.Items.Clear();
         
    }
    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        this.ModalPopupExtender2.Show();
        c.constr.Open();
        ImageButton imgView = (ImageButton)sender;
        da.SelectCommand = new SqlCommand("select * from mstmenusection where MenuSectionSno=@MenuSectionSno", c.constr);
        da.SelectCommand.Parameters.Add("@MenuSectionSno", SqlDbType.Int).Value = imgView.CommandArgument;
        da.Fill(dt);
        c.constr.Close();
        //lblmnm.Text=dt.Rows[0]["
        int menusno = Convert.ToInt32(dt.Rows[0]["MstMenuSno"].ToString());
        int sectionsno = Convert.ToInt32(dt.Rows[0]["MstSectionSno"].ToString());
       
        c.constr.Open();
        da1 = new SqlDataAdapter("select MenuSno,MenuName from mstmenu1 where MenuSno=@menusno", c.constr);
        da1.SelectCommand.Parameters.Add("@menusno", SqlDbType.Int).Value = menusno;
        da1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            lblmnm.Text = dt1.Rows[0]["MenuName"].ToString();
         
        }
        else
        {
            lblmsg.Text = "no record found";
        }
        c.constr.Close();

        c.constr.Open();
        da2 = new SqlDataAdapter("select SectionSno,SectionName from mstsection where SectionSno=@Sectionsno", c.constr);
        da2.SelectCommand.Parameters.Add("@Sectionsno", SqlDbType.Int).Value = sectionsno;
        da2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            lblsnm.Text = dt2.Rows[0]["SectionName"].ToString();

        }
        else
        {
            lblmsg.Text = "no record found";
        }
        c.constr.Close();
       
               
    }
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    ImageButton btnedit = sender as ImageButton;
    //    GridViewRow gvRow = (GridViewRow)btnedit.NamingContainer;
    //    int sid = Convert.ToInt32(gvRow.Cells[1].Text);
    //    string mnm1 = gvRow.Cells[2].Text;
    //    string snm1 = gvRow.Cells[3].Text;
    //    this.ModalPopupExtender1.Show();
    //    viewMstMenuSnm(mnm1);
    //    viewSectionName(snm1);
    
    //}
    public void displaySectionWise()
    {
        c.constr.Open();
        da3.SelectCommand = new SqlCommand("select mm1.MenuName,ms1.SectionName,mms.MenuSectionSno from mstmenusection mms,mstsection ms1,mstmenu1 mm1 where mm1.MenuSno=mms.MstMenuSno and ms1.SectionSno=mms.MstSectionSno and SectionName=@SectionName", c.constr);
        da3.SelectCommand.Parameters.AddWithValue("@SectionName", txtname.Text);
        da3.Fill(dt3);
        gvList.DataSource = dt3;
        gvList.DataBind();

    }
    public void displayMenuWise()
    {
        c.constr.Open();
        da3.SelectCommand = new SqlCommand("select mm1.MenuName,ms1.SectionName,mms.MenuSectionSno from mstmenusection mms,mstsection ms1,mstmenu1 mm1 where mm1.MenuSno=mms.MstMenuSno and ms1.SectionSno=mms.MstSectionSno and MenuName=@MenuName", c.constr);
        da3.SelectCommand.Parameters.AddWithValue("@MenuName", txtname.Text);
        da3.Fill(dt3);
        gvList.DataSource = dt3;
        gvList.DataBind();

    }
    protected void ddlsearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsearch.SelectedValue == "All Records")
        {
            txtname.Enabled = false;
        }
        else if (ddlsearch.SelectedValue == "Section Name")
        {
            txtname.Enabled = true;
        }
        else if (ddlsearch.SelectedValue == "Menu Name")
        {
            txtname.Enabled = true;
        }
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
            if (ddlsearch.SelectedValue == "Section Name")
            {
                displaySectionWise();
            }
            else if (ddlsearch.SelectedValue == "Menu Name")
            {
                displayMenuWise();
            }
            else
            {

                fillData();
             }
    
    }
}