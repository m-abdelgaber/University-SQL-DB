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
    public partial class myProfile : System.Web.UI.Page
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
            int id = (int)Session["userID"];
            Response.Write("ID: " + id);

            SqlCommand viewMyProf = new SqlCommand("viewMyProfile", conn);
            viewMyProf.CommandType = CommandType.StoredProcedure;

            viewMyProf.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            SqlDataReader rdr = viewMyProf.ExecuteReader(CommandBehavior.CloseConnection);
            Table info = new Table();
            while (rdr.Read())
            {
                String studentName, studentGender;
                if (rdr["firstName"] == DBNull.Value && rdr["lastName"] == DBNull.Value)
                    studentName = "no info";
                else
                {
                    if (rdr["firstName"] == DBNull.Value)
                        studentName = rdr.GetString(rdr.GetOrdinal("lastName"));
                    else if (rdr["lastName"] == DBNull.Value)
                        studentName = rdr.GetString(rdr.GetOrdinal("firstName"));
                    else
                        studentName = rdr.GetString(rdr.GetOrdinal("firstName")) + " " + rdr.GetString(rdr.GetOrdinal("lastName"));
                }
                if (rdr["gender"] == DBNull.Value)
                    studentGender = "not specified";
                else
                {
                    byte[] gen = (byte[])rdr["gender"];
                    studentGender = "Female";
                    if (gen[0] == 1)
                    {
                        studentGender = "Male";
                    }
                }
                String studentEmail, studentAddress;
                String studentGPA;
                if (rdr["email"] == DBNull.Value)
                    studentEmail = "no info";
                else
                    studentEmail = rdr.GetString(rdr.GetOrdinal("email"));
                if (rdr["address"] == DBNull.Value)
                    studentAddress = "no info";
                else
                    studentAddress = rdr.GetString(rdr.GetOrdinal("address"));
                if (rdr["gpa"] == DBNull.Value)
                    studentGPA = "no info";
                else
                    studentGPA = "" + rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                TableRow r1 = new TableRow();
                TableCell c1 = new TableCell();
                c1.Text = "Full name: " + studentName;
                r1.Cells.Add(c1);
                TableRow r2 = new TableRow();
                TableCell c2 = new TableCell();
                c2.Text = "E-mail: " + studentEmail;
                r2.Cells.Add(c2);
                TableRow r3 = new TableRow();
                TableCell c3 = new TableCell();
                c3.Text = "Address: " + studentAddress;
                r3.Cells.Add(c3);
                TableRow r4 = new TableRow();
                TableCell c4 = new TableCell();
                c4.Text = "Gender: " + studentGender;
                r4.Cells.Add(c4);
                TableRow r5 = new TableRow();
                TableCell c5 = new TableCell();
                c5.Text = "GPA: " + studentGPA;
                r5.Cells.Add(c5);
                info.Controls.Add(r1);
                info.Controls.Add(r2);
                info.Controls.Add(r3);
                info.Controls.Add(r4);
                info.Controls.Add(r5);
            }
            form1.Controls.Add(info);
        }
    }
}