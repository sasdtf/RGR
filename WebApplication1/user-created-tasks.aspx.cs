using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Created_tasks : System.Web.UI.Page
    {

            string connection = ConfigurationManager.AppSettings["connectinDB"];
            protected void AddDropDownListSearchUser()
            {

                using (MySqlConnection con = new MySqlConnection(connection))
                {
                    con.Open();
                    string query = "SELECT id, name, surname FROM `users`";
                    MySqlCommand command = new MySqlCommand(query, con);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        DropDownList1.Items.Clear();
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? string.Empty : reader.GetString(reader.GetOrdinal("name"));
                            string surname = reader.IsDBNull(reader.GetOrdinal("surname")) ? string.Empty : reader.GetString(reader.GetOrdinal("surname"));
                            DropDownList1.Items.Add(new ListItem(id + "- " + name + " " + surname, id.ToString()));


                        }
                    }

                    // Закрытие соединения
                    con.Close();
                }
            }
            protected void AddDropDownListSearchTask()
            {

                using (MySqlConnection con = new MySqlConnection(connection))
                {
                    // Открытие соединения
                    con.Open();

                    // Создание SQL-запроса
                    string query = "SELECT id, name FROM `tasks` WHERE managerID ="+Session["id"];

                    // Создание команды
                    MySqlCommand command = new MySqlCommand(query, con);

                    // Выполнение запроса и получение результата
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Очистка существующих вариантов выбора
                        DropDownList2.Items.Clear();

                        DropDownList2.Items.Add(new ListItem("new", null));
                        // Добавление вариантов выбора из результата запроса
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.IsDBNull(reader.GetOrdinal("name")) ? string.Empty : reader.GetString(reader.GetOrdinal("name"));


                            // Добавление варианта выбора с текстовым значением "name surname" и целочисленным значением "id"
                            DropDownList2.Items.Add(new ListItem(id + "- " + name, id.ToString()));


                        }

                    }

                    // Закрытие соединения
                    con.Close();
                }
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                AddDropDownListSearchUser();
                AddDropDownListSearchTask();
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                MySqlConnection con = new MySqlConnection(connection);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tasks (name, description, managerID, actingID, Deadline, parentID, typeID) VALUES" +
                        " (@name , @description, @managerID, @actingID, @Deadline, @parentID, @typeID) ", con);
                if (TextBox1.Text.Trim().Length > 0)
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                else
                    Response.Write("<script>alert('название не может быть пустым')</script>");

                if (TextBox2.Text.Trim().Length > 0)
                    cmd.Parameters.AddWithValue("@description", TextBox2.Text);
                else
                    cmd.Parameters.AddWithValue("@description", null);


            cmd.Parameters.AddWithValue("@managerID", (int)Session["id"]);

            string selectedValue = DropDownList1.SelectedValue;

                // Преобразовать значение в int

                if (DropDownList1.SelectedValue != null)
                    cmd.Parameters.AddWithValue("@actingID", DropDownList1.SelectedValue);
                else
                    cmd.Parameters.AddWithValue("@actingID", null);


                string selectedValueTask = DropDownList2.SelectedValue;
                if (selectedValueTask != "new")
                    cmd.Parameters.AddWithValue("@parentID", Convert.ToInt32(selectedValueTask));
                else
                    cmd.Parameters.AddWithValue("@parentID", null);




                if (TextBox3.Text.Trim().Length > 0)
                {
                    cmd.Parameters.AddWithValue("@Deadline", Convert.ToDateTime(TextBox3.Text));
                }
                else
                    cmd.Parameters.AddWithValue("@Deadline", null);


                cmd.Parameters.AddWithValue("@typeID", Convert.ToInt32(DropDownListType1.SelectedValue));

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("home-page.aspx");

            }

            protected void TextBox1_TextChanged(object sender, EventArgs e)
            {

            }

            protected void TextBox2_TextChanged(object sender, EventArgs e)
            {

            }
            protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
            }

            protected void Calendar1_SelectionChanged(object sender, EventArgs e)
            {
                TextBox3.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            }

        }
    }