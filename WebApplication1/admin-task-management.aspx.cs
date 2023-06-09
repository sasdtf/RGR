using Models.StatusModel;
using Models.TaskModel;
using Models.UserModel;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{

    public partial class admin_task_management : System.Web.UI.Page
    {
        string connection = ConfigurationManager.AppSettings["connectinDB"];
        protected void Page_Load(object sender, EventArgs e)
        {

            ChangeTable("SELECT * FROM tasks ");
        }

        public void FillUserFromDatabase(UserInfo user, string connectionString)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE id = " + user.ID, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    user.ID = dr.GetInt32(0);
                    user.Login = dr.GetString(1);
                    user.Name = dr.GetString(3);
                    user.Surname = dr.GetString(4);
                }


                con.Close();
            }
        }

        public void FillTypeFromDatabase(TaskType type, string connectionString)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM type WHERE id = " + type.Id, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    type.Name = dr.GetString(1);
                }
                con.Close();
            }

        }
        public void FillStatusFromDatabase(StatusInfo status, string connectionString)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM status WHERE id = " + status.Id, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    status.Name = dr.GetString(1);
                }
                con.Close();
            }

        }

        public string SelectTaskName(int TaskId, string connectionString)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tasks WHERE parentId = " + TaskId, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr.GetString(1);
                }
                con.Close();
                return string.Empty;
            }

        }
        public void ChangeTable(string qqq)
        {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(int));
                dataTable.Columns.Add("name", typeof(string));
                dataTable.Columns.Add("description", typeof(string));
                dataTable.Columns.Add("managerID", typeof(int));
                dataTable.Columns.Add("manger_login", typeof(string));
                dataTable.Columns.Add("manager_name,surname", typeof(string));
                dataTable.Columns.Add("actingID", typeof(int));
                dataTable.Columns.Add("acting_login", typeof(string));
                dataTable.Columns.Add("acting_name,surname", typeof(string));
                dataTable.Columns.Add("deadline", typeof(DateTime));
                dataTable.Columns.Add("parentID", typeof(int));
                dataTable.Columns.Add("parent_task_name", typeof(string));
                dataTable.Columns.Add("status", typeof(string));
                dataTable.Columns.Add("type", typeof(string));


                using (MySqlConnection con = new MySqlConnection(connection))
                {
                    try
                    {

                        if (con.State == System.Data.ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        MySqlCommand cmd = new MySqlCommand(qqq, con);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                UserInfo manager = new UserInfo();
                                manager.ID = dr.GetInt32(3);
                                FillUserFromDatabase(manager, connection);
                                string managerFullName = manager.Name + " " + manager.Surname;

                                UserInfo user = new UserInfo();
                                if(dr.IsDBNull(4))
                                {
                                    user.ID = null;
                                   user.Name = null;
                                    user.Surname = null;
                                }
                                else
                                {
                                    user.ID = dr.GetInt32(4);
                                    FillUserFromDatabase(user, connection);
                                  

                                }
                                string userFullName = user.Name + " "+ user.Surname;

                                TaskType type = new TaskType();
                                type.Id = dr.GetInt32(8);
                                FillTypeFromDatabase(type, connection);

                                StatusInfo status = new StatusInfo();
                                status.Id = dr.GetInt32(7);
                                FillStatusFromDatabase(status, connection);

                                dataTable.Rows.Add(
                                dr.GetInt32(0),
                                dr.IsDBNull(1) ? string.Empty : dr.GetString(1),
                                dr.IsDBNull(2) ? string.Empty : dr.GetString(2),
                                manager.ID,
                                manager.Login,
                                managerFullName,
                                user.ID,
                                user.Login,
                                userFullName,
                                dr.GetDateTime(5),
                                dr.IsDBNull(6) ? (int?)null : dr.GetInt32(6),
                                dr.IsDBNull(6) ? (string)null : SelectTaskName(dr.GetInt32(6), connection),
                                status.Name,
                                type.Name);
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
        protected void Button2_Click(object sender, EventArgs e)
        {           
            MySqlConnection con = new MySqlConnection(connection);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE `tasks` SET `name` =@name , `description` = @description," +
                " `managerID` = @managerID, `actingID` = @actingID, `Deadline` = @Deadline, `parentID` = @parentID, " +
                "`statusID` = @statusID, `typeID` = @typeID WHERE `tasks`.`id` ='" + TextBox1.Text + "'", con);

            if (TextBox10.Text.Trim().Length > 0)
            {
                cmd.Parameters.AddWithValue("@name",TextBox10.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
            }
            if (TextBox11.Text.Trim().Length > 0)
            {
                cmd.Parameters.AddWithValue("@description",TextBox13.Text.Trim());
            }
            else
            {
                if (TextBox3.Text.Trim().Length > 0)
                    cmd.Parameters.AddWithValue("@description",TextBox3.Text.Trim());
                else
                    cmd.Parameters.AddWithValue("@description", null);
            }
            if (TextBox12.Text.Trim().Length > 0)
            {
                cmd.Parameters.AddWithValue("@managerID", Convert.ToInt32(TextBox12.Text.Trim()));
            }
            else
            {
                cmd.Parameters.AddWithValue("@managerID", Convert.ToInt32(TextBox4.Text.Trim()));
            }
            if (TextBox13.Text.Trim().Length > 0)
            {
                cmd.Parameters.AddWithValue("@actingID", Convert.ToInt32(TextBox13.Text.Trim()));
            }
            else
            {
                if (TextBox5.Text.Trim().Length > 0)
                    cmd.Parameters.AddWithValue("@actingID", Convert.ToInt32(TextBox5.Text.Trim()));
                else
                    cmd.Parameters.AddWithValue("@actingID", null);
            }

            if (TextBox14.Text.Trim().Length > 0)
            {
                cmd.Parameters.AddWithValue("@Deadline", Convert.ToDateTime(TextBox14.Text));
            }
            else
            {
                if (TextBox6.Text.Trim().Length > 0)
                    cmd.Parameters.AddWithValue("@Deadline", Convert.ToDateTime(TextBox6.Text));
                else
                    cmd.Parameters.AddWithValue("@Deadline", null);
            }

            if (TextBox15.Text.Trim().Length > 0)
            {
                cmd.Parameters.AddWithValue("@parentID", Convert.ToInt32(TextBox15.Text.Trim()));
            }
            else
            {
                if (TextBox7.Text.Trim().Length > 0)
                    cmd.Parameters.AddWithValue("@parentID", Convert.ToInt32(TextBox7.Text.Trim()));
                else
                    cmd.Parameters.AddWithValue("@parentID", null);
            }


            if (Convert.ToInt32(DropDownList1.SelectedValue) == 0)
            {
                cmd.Parameters.AddWithValue("@statusID", Convert.ToInt32(DropDownList2.SelectedValue));
            }
            else
            {
                cmd.Parameters.AddWithValue("@statusID", Convert.ToInt32(DropDownList1.SelectedValue));
            }



            if (Convert.ToInt32(DropDownList3.SelectedValue) == 0)
            {
                cmd.Parameters.AddWithValue("@typeID", Convert.ToInt32(DropDownList4.SelectedValue));
            }
            else
            {
                cmd.Parameters.AddWithValue("@typeID", Convert.ToInt32(DropDownList3.SelectedValue));
            }
            cmd.ExecuteNonQuery();
            con.Close();


        }
        protected void Button3_Click(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)//
        {
            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tasks WHERE tasks.id ='" + TextBox1.Text + "'", con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            TextBox1.Text = dr.GetValue(0).ToString();
                            TextBox2.Text = dr.GetValue(1).ToString();
                            TextBox3.Text = dr.GetValue(2).ToString();
                            TextBox4.Text = dr.GetValue(3).ToString();
                            TextBox5.Text = dr.GetValue(4).ToString();
                            TextBox6.Text = dr.GetValue(5).ToString();
                            TextBox7.Text = dr.GetValue(6).ToString();
                            DropDownList2.Text = dr.GetValue(7).ToString();
                            DropDownList1.Text = dr.GetValue(8).ToString();
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

        protected void Button4_Click(object sender, EventArgs e)//
        {
            ChangeTable("SELECT * FROM tasks WHERE tasks.managerID = '" + TextBox18.Text + "'");
        }

        protected void Button5_Click(object sender, EventArgs e)//
        { 
            ChangeTable("SELECT * FROM tasks WHERE tasks.actingID = '" + TextBox19.Text + "'");
        }





        protected void TextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox14.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}