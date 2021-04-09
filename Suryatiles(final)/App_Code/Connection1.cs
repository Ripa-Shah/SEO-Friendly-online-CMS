using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public class Connection1
{
   // public static string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\dell\Documents\cmsdb.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
    //for foreignkey reference
   // public static string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\database\cmsdb_fk.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

    //public static string con = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\cmsdb_fk1.mdf;Integrated Security=True;User Instance=True";
    public static string con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Yash\Desktop\Suryatiles(final)\App_Data\cmsdb_fk1.mdf;Integrated Security=True;Connect Timeout=30";
   public SqlConnection constr= new SqlConnection(con);

	public Connection1()
	{

       
    }
   
}
