using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class MstMenuChild_Edit : System.Web.UI.Page
{
    Connection1 c = new Connection1();
    SqlDataAdapter da = new SqlDataAdapter();
    DataTable dt = new DataTable();
    string id = "";
    SqlDataReader rdr;
    static string no;
    string nm;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        id = Request.QueryString["ID"];
        //lblmnm.Text = id.ToString();
        if (!IsPostBack)
        {
            displayFields();
            displayData();
        }

        LinkButton lnk = (LinkButton)Master.FindControl("LinkButton1");  
    }
    public void displayFields()
    {
        no = Session["no"].ToString();

        txtmnm.Text = no;
        //first retrive ModuleSno from mstmenu1 table based on Menusn
        c.constr.Open();
        da.SelectCommand = new SqlCommand("select ModuleName from mstmodule where ModuleSno =(select MstModuleSno from mstmenu1 where MenuSno=@msno)", c.constr);
        //da.SelectCommand = new SqlCommand("select MenuName,MstModuleSno from mstmenu1 where MenuSno=@msno", c.constr);
        da.SelectCommand.Parameters.AddWithValue("@msno", int.Parse(no));
        rdr = da.SelectCommand.ExecuteReader();
        while (rdr.Read())
        {
            nm = rdr["ModuleName"].ToString();
        }
        rdr.Close();
        c.constr.Close();
        //  Response.Write("Name" + nm);
        if (nm == "Enquiry")
        {
            pnlcontact.Visible = true;

        }
        else if (nm == "Video")
        {
            lblheading.Visible = true;
            lblsdesc.Visible = true;
            lblimgpath.Visible = true;
            lblycode.Visible = true;
            lblvideopth.Visible = true;
            lblpr.Visible = true;
            txtheading.Visible = true;
            txtsdesc.Visible = true;
            txtimagepath.Visible = true;
            fpimage.Visible = true;
            txtycode.Visible = true;
            fpvideo.Visible = true;
            txtvideo.Visible = true;
            txtpr.Visible = true;
        }
        else if (nm == "News")
        {
            lblheading.Visible = true;
            txtheading.Visible = true;
            lbldesc.Visible = true;
            ck1.Visible = true;
            lblimgpath.Visible = true;
            fpimage.Visible = true;
            txtimagepath.Visible = true;
            lblpr.Visible = true;
            txtpr.Visible = true;
        }
        else if (nm == "PhotoGallery" || nm == "Portfolio")
        {
            lblheading.Visible = true;
            txtheading.Visible = true;
            txtimagepath.Visible = true;
            lblimgpath.Visible = true;
            fpimage.Visible = true;
            lblurl.Visible = true;
            txturl.Visible = true;
            lblpr.Visible = true;
            txtpr.Visible = true;
        }
        else if (nm == "PhotoGallery With Description" || nm == "Portfolio With Description")
        {
            lblheading.Visible = true;
            txtheading.Visible = true;
            txtimagepath.Visible = true;
            lblimgpath.Visible = true;
            fpimage.Visible = true;
            lblurl.Visible = true;
            txturl.Visible = true;
            lblpr.Visible = true;
            txtpr.Visible = true;
            lbldesc.Visible = true;
            ck1.Visible = true;
        }
        else if (nm == "Product")
        {
            lblheading.Visible = true;
            txtheading.Visible = true;
            lbldesc.Visible = true;
            ck1.Visible = true;
            txturl.Visible = true;
            lblurl.Visible = true;
            lblpr.Visible = true;
            txtpr.Visible = true;
        }
        else if (nm == "Product With Image")
        {
            lblheading.Visible = true;
            txtheading.Visible = true;
            lbldesc.Visible = true;
            ck1.Visible = true;
            txturl.Visible = true;
            lblurl.Visible = true;
            lblpr.Visible = true;
            txtpr.Visible = true;
            lblsdesc.Visible = true;
            txtsdesc.Visible = true;
            lblimgpath.Visible = true;
            fpimage.Visible = true;
            txtimagepath.Visible = true;

        }
        else if (nm == "HomePage" || nm == "Descriptive" || nm == "ExternalLink")
        {
            lblheading.Visible = true;
            txtheading.Visible = true;
            lblsdesc.Visible = true;
            txtsdesc.Visible = true;
            lbldesc.Visible = true;
            ck1.Visible = true;
            lblimgpath.Visible = true;
            txtimagepath.Visible = true;
            fpimage.Visible = true;
            lblvtype.Visible = true;
            ddlvtype.Visible = true;
            txtycode.Visible = true;
            lblycode.Visible = true;
            lblvideopth.Visible = true;
            txtvideo.Visible = true;
            fpvideo.Visible = true;
            lbledate.Visible = true;
            txtdt.Visible = true;
            lblurl.Visible = true;
            txturl.Visible = true;
            pnlcontact.Visible = true;
        }
        else if (nm == "EventCalender")
        {
            txtheading.Visible = true;
            lblheading.Visible = true;
            lbldesc.Visible = true;
            ck1.Visible = true;
            txtdt.Visible = true;
            lbledate.Visible = true;
        }


    }

    public void displayData()
    {
        no = Session["no"].ToString();


        da.SelectCommand = new SqlCommand("select * from mstmenuchild where MenuChildSno=@MenuChildsno", c.constr);
        da.SelectCommand.Parameters.Add("@MenuChildsno", SqlDbType.Int).Value = Convert.ToInt32(id.ToString());
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtmnm.Text = no.ToString();
            txtheading.Text = dt.Rows[0]["Heading"].ToString();
            txtsdesc.Text = dt.Rows[0]["ShortDescri"].ToString();
            ck1.Text = dt.Rows[0]["Descri"].ToString();
            txtimagepath.Text = dt.Rows[0]["ImagePath"].ToString();
            ddlvtype.SelectedValue = dt.Rows[0]["Vtype"].ToString();
            txtycode.Text = dt.Rows[0]["YoutubeCode"].ToString();
            txtvideo.Text = dt.Rows[0]["VideoPath"].ToString();
            txtdt.Text = dt.Rows[0]["Edate"].ToString();
            txturl.Text = dt.Rows[0]["URLLink"].ToString();
            txtpr.Text = dt.Rows[0]["Priority"].ToString();
            txtcpnm.Text = dt.Rows[0]["ContactPersonName"].ToString();
            txtcomp.Text = dt.Rows[0]["CompanyName"].ToString();
            txtadd.Text = dt.Rows[0]["Address"].ToString();
            txtct.Text = dt.Rows[0]["City"].ToString();
            txtstate.Text = dt.Rows[0]["State"].ToString();
            txtcontry.Text = dt.Rows[0]["Country"].ToString();
           // txtph.Text = dt.Rows[0]["Phone"].ToString();
            txtmob.Text = dt.Rows[0]["Mobile"].ToString();
            txtfax.Text = dt.Rows[0]["Fax"].ToString();
            txtemail.Text = dt.Rows[0]["Email"].ToString();
            txtwebsite.Text = dt.Rows[0]["Website"].ToString();
            txtcomment.Text = dt.Rows[0]["Comments"].ToString();
            
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        if (fpimage.HasFile)
        {
            string fname = fpimage.FileName;

            int size = fpimage.PostedFile.ContentLength;
            string ctype = fpimage.PostedFile.ContentType;

            string ext = Path.GetExtension(fname);
            if (((ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")) && (fpimage.PostedFile.ContentLength <= 4194304))//for 4 MB
            {
                fpimage.SaveAs(Server.MapPath("~/images/ ") + fname);
                txtimagepath.Text = fname;

            }
            else
            {
                lblmsg.Text = "Select Proper image";
            }
        }
        else
        {
            lblmsg.Text = "Choose File";
        }
        if (fpvideo.HasFile)
        {
            string fname = fpvideo.FileName;

            int size = fpvideo.PostedFile.ContentLength;
            string ctype = fpvideo.PostedFile.ContentType;

            string ext = Path.GetExtension(fname);
            if (((ext == ".mp3" || ext == ".mp4" || ext == ".vob" || ext == ".wmv")))// && (fpimage.PostedFile.ContentLength <= 4194304))//for 4 MB
            {
                fpvideo.SaveAs(Server.MapPath("~/images/ ") + fname);
                txtvideo.Text = fname;

            }
            else
            {
                lblmsg.Text = "Select Proper video";
            }
        }
        else
        {
            lblmsg.Text = "Choose File";
        }
       
       
        da.UpdateCommand = new SqlCommand("update mstmenuchild set UpdatedOn=@UpdatedOn,Heading=@Heading,ShortDescri=@ShortDescri,Descri=@Descri,ImagePath=@ImagePath,Vtype=@Vtype,YoutubeCode=@YoutubeCode,VideoPath=@VideoPath,Edate=@Edate,URLLink=@URLLink,Priority=@Priority,ContactPersonName=@ContactPersonName,CompanyName=@CompanyName,Address=@Address,City=@City,State=@State,Country=@Country,Mobile=@Mobile,Fax=@Fax,Email=@Email,Website=@Website,Comments=@Comments where MenuChildSno=@MenuChildSno", c.constr);
        da.UpdateCommand.Parameters.AddWithValue("@UpdatedOn", DateTime.Now.ToLocalTime());
        da.UpdateCommand.Parameters.AddWithValue("@Heading", txtheading.Text);
        da.UpdateCommand.Parameters.AddWithValue("@ShortDescri", txtsdesc.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Descri", ck1.Text);
        da.UpdateCommand.Parameters.AddWithValue("@ImagePath", txtimagepath.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Vtype", ddlvtype.SelectedValue);
        da.UpdateCommand.Parameters.AddWithValue("@YoutubeCode", txtycode.Text);
        da.UpdateCommand.Parameters.AddWithValue("@VideoPath", txtvideo.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Edate", txtdt.Text);
        da.UpdateCommand.Parameters.AddWithValue("@URLLink", txturl.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Priority", txtpr.Text);
        da.UpdateCommand.Parameters.AddWithValue("@ContactPersonName", txtcpnm.Text);
        da.UpdateCommand.Parameters.AddWithValue("@CompanyName", txtcomp.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Address", txtadd.Text);
        da.UpdateCommand.Parameters.AddWithValue("@City", txtct.Text);
        da.UpdateCommand.Parameters.AddWithValue("@State", txtstate.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Country", txtcontry.Text);
        //da.UpdateCommand.Parameters.AddWithValue("@Phone",txtph.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Mobile", txtmob.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Fax", txtfax.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Email", txtemail.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Website", txtwebsite.Text);
        da.UpdateCommand.Parameters.AddWithValue("@Comments", txtcomment.Text);
        da.UpdateCommand.Parameters.AddWithValue("@MenuChildSno", Convert.ToInt32(id.ToString()));
        c.constr.Open();
        int i = da.UpdateCommand.ExecuteNonQuery();
        if (i > 0)
            lblmsg.Text = "Data Updated Successfully!!";
        else
            lblmsg.Text = "Data Not Updated !!";
    }


}