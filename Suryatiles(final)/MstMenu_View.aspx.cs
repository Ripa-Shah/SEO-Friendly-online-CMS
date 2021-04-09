using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class MstMenu_View : System.Web.UI.Page
{
    
    SqlDataAdapter da = new SqlDataAdapter();
     SqlDataAdapter da1 = new SqlDataAdapter();
    SqlDataAdapter da2 = new SqlDataAdapter();
    SqlDataAdapter da3 = new SqlDataAdapter();
    SqlDataAdapter da4 = new SqlDataAdapter();
    SqlDataAdapter da5 = new SqlDataAdapter();
    DataTable dt4 = new DataTable();
    DataTable dt5 = new DataTable();
    DataTable dt = new DataTable();
    Connection1 c = new Connection1();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
      if (!IsPostBack)
          fillGrid();
      LinkButton lnk = (LinkButton)Master.FindControl("LinkButton1");  
    }
    public void fillGrid()
    {
          string qry = "select MenuSno,Priority,Active,GroupName,MenuName from mstmenu1 LEFT JOIN mstmenugroup on mstmenu1.MstMenuGroupSno=mstmenugroup.MenuGroupSno";
        //string qry = "select * from mstmenu1";
        da = new SqlDataAdapter(qry, c.constr);
        da.Fill(dt);
        gvList.DataSource = dt;
        gvList.DataBind();
    }
    
    

         
         protected void gvList_RowDeleting1(object sender, GridViewDeleteEventArgs e)
         {
             GridViewRow row = gvList.Rows[e.RowIndex] as GridViewRow;
             Label id = row.FindControl("Label1") as Label;
             da.DeleteCommand = new SqlCommand("delete from mstmenu1 where MenuSno=@MenuSno", c.constr);
             da.DeleteCommand.Parameters.Add("@MenuSno", SqlDbType.Int).Value =Convert.ToInt32(id.Text) ;
             c.constr.Open();
             int i = da.DeleteCommand.ExecuteNonQuery();
             if (i > 0)
             {
                 lblmsg.Text = "Record Deleted Successfully!!";
             }
             else
             {
                 lblmsg.Text = "Record Not Deleted!!";
             }
             c.constr.Close();
             gvList.EditIndex = -1;

             fillGrid();
  
         }
         protected void lbldetail_Click(object sender, EventArgs e)
         {
             LinkButton lnkdetail = sender as LinkButton;
             Response.Write(lnkdetail.CommandArgument);
             string no=lnkdetail.CommandArgument;

             // storing menusno to session for using it into MstMenuChild form
             Session["no"]=no.ToString();
             Response.Redirect("MstMenuChild_View.aspx");
        //     if (lnkdetail.CommandArgument == "Video")
        //     {
        //         Response.Redirect("MstMenuChild_View.aspx?id=no);
        //     }
        //     else if (lnkdetail.CommandArgument == "Inquiry")
        //     {
        //         Response.Redirect("MstMenuChild_View.aspx?name=inquiry");
        //     }
        //     else
        //     {
        //         Response.Redirect("MstMenuChild_View.aspx?name=description");
        //     }
        //}

         
         }
         protected void btnsearch_Click(object sender, EventArgs e)
         {
             if (ddlsearch.SelectedValue == "Menu Name")
             {
                 displayMenuName();
             }
             else if (ddlsearch.SelectedValue == "Active")
             {

                 displayActive();
             }
             else
             {

                 fillGrid();
             }

         }
         protected void ddlsearch_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (ddlsearch.SelectedValue == "All Records")
             {
                 txtname.Enabled = false;
             }
             else if (ddlsearch.SelectedValue == "Menu Name")
             {
                 txtname.Enabled = true;
             }
             else if (ddlsearch.SelectedValue == "Active")
             {
                 txtname.Enabled = false;
             }
         }
         public void displayMenuName()
         {
             c.constr.Open();
             da4.SelectCommand = new SqlCommand("select MenuSno,Priority,Active,GroupName,MenuName from mstmenu1 LEFT JOIN mstmenugroup on mstmenu1.MstMenuGroupSno=mstmenugroup.MenuGroupSno where MenuName=@MenuName", c.constr);
             da4.SelectCommand.Parameters.AddWithValue("@MenuName", txtname.Text);
             da4.Fill(dt4);
             gvList.DataSource = dt4;
             gvList.DataBind();
            
         }
         public void displayActive()
         {
             c.constr.Open();
             da5.SelectCommand = new SqlCommand("select MenuSno,Priority,Active,GroupName,MenuName from mstmenu1 LEFT JOIN mstmenugroup on mstmenu1.MstMenuGroupSno=mstmenugroup.MenuGroupSno where Active=@Active", c.constr);
             da5.SelectCommand.Parameters.AddWithValue("@Active", "yes");
             da5.Fill(dt5);
             gvList.DataSource = dt5;
             gvList.DataBind();
             
         }
        
    

}