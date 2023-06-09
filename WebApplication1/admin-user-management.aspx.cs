using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class admin_user_management : System.Web.UI.Page
    {
        string connection = ConfigurationManager.AppSettings["connectinDB"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["role"] == null || Session["role"].Equals("user"))
            {
                Response.Redirect("home-page.aspx");

            }
            else
            {
                if ((!IsPostBack))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("id", typeof(string));
                    dataTable.Columns.Add("login", typeof(string));
                    dataTable.Columns.Add("password", typeof(string));
                    dataTable.Columns.Add("name", typeof(string));
                    dataTable.Columns.Add("surname", typeof(string));
                    dataTable.Columns.Add("mail", typeof(string));


                    using (MySqlConnection con = new MySqlConnection(connection))
                    {
                        try
                        {

                            if (con.State == System.Data.ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE users.roleID='1'", con);
                            MySqlDataReader dr = cmd.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {

                                    dataTable.Rows.Add(dr.GetValue(0).ToString(),
                                    dr.GetValue(1).ToString(),
                                    dr.GetValue(2).ToString(),
                                    dr.GetValue(3).ToString(),
                                    dr.GetValue(4).ToString(),
                                    dr.GetValue(5).ToString());

                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Smth wrong, try again.')</script>");
                            }

                            GridView1.DataSource = dataTable;
                            GridView1.DataBind();
                            con.Close();
                        }
                        catch
                        {
                        }
                }
            }
            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE users.id ='" + TextBox1.Text + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            TextBox2.Text = dr.GetValue(3).ToString();
                            TextBox3.Text = dr.GetValue(4).ToString();
                            TextBox4.Text = dr.GetValue(5).ToString();
                            TextBox5.Text = dr.GetValue(1).ToString();
                            TextBox6.Text = dr.GetValue(2).ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Smth wrong, try again.')</script>");
                    }
                    con.Close();
                }
                catch
                {
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand("UPDATE " +
                    "users SET login = @login, password = @password, name = @name, surname = @surname," +
                    " mail = @mail WHERE users.id ='" + TextBox1.Text + "'", con);
                    TextBox1 = new TextBox();
                    cmd.Parameters.AddWithValue("@id", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@login", TextBox5.Text);


                    if (TextBox8.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@name", TextBox8.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@name", TextBox2.Text);
                    }

                    if (TextBox9.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@surname", TextBox9.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@surname", TextBox3.Text);
                    }



                    if (TextBox10.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@mail", TextBox10.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@mail", TextBox4.Text);
                    }

                    if (TextBox7.Text.Trim().Length > 0)
                    {
                        cmd.Parameters.AddWithValue("@password", TextBox7.Text);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@password", TextBox6.Text);
                    }
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("admin-user-management.aspx");
                }
                catch
                {
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connection))
            {

                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand("DELETE from " +
                    "users WHERE users.id ='" + TextBox1.Text + "'", con);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("admin-user-management.aspx");
                }
                catch
                {
                }             
            }
        }
    }
}