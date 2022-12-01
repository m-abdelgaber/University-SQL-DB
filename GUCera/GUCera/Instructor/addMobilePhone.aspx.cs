using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace GUCera.Instructor
{
    public partial class addMobilePhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String number;
            
           
                number = TextBox1.Text;
               
            
            
            SqlCommand add = new SqlCommand("addMobile", conn);
            add.CommandType = CommandType.StoredProcedure;
            add.Parameters.Add(new SqlParameter("@ID", Session["userId"]));
            add.Parameters.Add(new SqlParameter("@mobile_number", number));

            try
            {
                conn.Open();
                add.ExecuteNonQuery();
                conn.Close();
                Label1.Text = "Success";
            }
            catch
            {
                Label1.Text = "Already Added";
            }
        }
    }
}