using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;

namespace _1301681021_Lilyana_Ihtimanska
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Server=.\\SQLEXPRESS;Database=WebApplicationDB;Integrated Security=true");

        private void Clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            lblId.Text = string.Empty;
            lblUsername.Text = string.Empty;
            lblPassword.Text = string.Empty;
            lblemail.Text = string.Empty;
            lblFinish.Text = string.Empty;
            lblInfo.Text = string.Empty;
            lblUser.Visible = true;
            lblname.Visible = true;
            lblPass.Visible = true;
            lblmail.Visible = true;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select user_id,username,password,email from [dbo].[Users]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lblId.Text += reader.GetValue(0) + "<br />";
                lblUsername.Text += reader.GetString(1) + "<br />";
                lblPassword.Text += reader.GetString(2) + "<br />";
                lblemail.Text += reader.GetString(3) + "<br />";
            }
            reader.Close();
            conn.Close();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Users (user_id,username,password,email) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblFinish.Text = "Record inserted! To see the changes, press Show Users!";
                    Clear();
                }
                catch (Exception ex)
                {
                    lblInfo.Text = ex.Message;
                }
            } 
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Users set username='" + TextBox2.Text + "',password='" + TextBox3.Text + "',email='" + TextBox4.Text + "' where user_id='" + TextBox1.Text + "'", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblFinish.Text = "Record updated! To see the changes, press Show Users!";
                    Clear();
                }
                catch (Exception ex)
                {
                    lblInfo.Text = ex.Message;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "";
            if (TextBox1.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Users where user_id='" + TextBox1.Text + "'", conn);
                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblFinish.Text = "Record deleted! To see the changes, press Show Users!";
                    Clear();
                }
                catch (Exception ex)
                {
                    lblInfo.Text = ex.Message;
                }
            }
        }
    }
}