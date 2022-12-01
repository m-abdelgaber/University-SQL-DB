using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Student
{
    public partial class issuedPromoCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewPcodes = new SqlCommand("viewPromocode", conn);
            viewPcodes.CommandType = CommandType.StoredProcedure;
            viewPcodes.Parameters.Add(new SqlParameter("@sid", Session["userId"]));

            conn.Open();
            SqlDataReader rdr = viewPcodes.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable d = new DataTable();
            d.Columns.Add("code");
            d.Columns.Add("isuueDate");
            d.Columns.Add("expiryDate");
            d.Columns.Add("discount");
            while (rdr.Read())
            {
                String issue;
                String expiry, discount;
                String code = rdr.GetString(rdr.GetOrdinal("code"));
                if (!(rdr["isuueDate"] == DBNull.Value))
                    issue = "" + rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                else
                    issue = "no provided info";
                if (!(rdr["expiryDate"] == DBNull.Value))
                    expiry = "" + rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                else
                    expiry = "no provided info";
                if (!(rdr["discount"] == DBNull.Value))
                    discount = "" + rdr.GetDecimal(rdr.GetOrdinal("discount"));
                else
                    discount = "no provided info";
                d.Rows.Add(code, issue, expiry, discount);
            }
            DataView dv = new DataView(d);
            d1.DataSource = dv;
            d1.DataBind();
            form1.Controls.Add(d1);
        }
    }
}