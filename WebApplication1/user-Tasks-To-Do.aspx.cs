using Models.StatusModel;
using Models.TaskModel;
using Models.UserModel;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WebApplication1.Models.RoleModel;

namespace WebApplication1
{

    public partial class user_Tasks_To_Do : System.Web.UI.Page
    {
        public List<TaskInfo> Tasks { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

                List<TaskInfo> tasks = new List<TaskInfo>();
                string connection = ConfigurationManager.AppSettings["connectinDB"];
                GetTasksWithEmptyParentId(tasks, connection);

                foreach (TaskInfo task in tasks)
                {
                    FillTaskDetailsFromDatabase(task, connection);
                    FillSubtasksFromDatabase(task, connection);
                }
                Tasks = tasks;

              
        }

        private void GetTasksWithEmptyParentId(List<TaskInfo> tasks, string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM tasks WHERE parentId IS NULL", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TaskInfo task = new TaskInfo();
                            task.TaskId = reader.GetInt32(0);
                            tasks.Add(task);
                        }
                    }
                }
            }
        }

        private void FillTaskDetailsFromDatabase(TaskInfo task, string connectionString)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tasks WHERE id = "+task.TaskId, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        task.TaskId = dr.GetInt32(0);
                        task.TaskName = dr.IsDBNull(1) ? null : dr.GetString(1);
                        task.Description = dr.IsDBNull(2) ? null : dr.GetString(2);
                        task.Manager.ID = dr.GetInt32(3);
                        FillUserFromDatabase(task.Manager, connectionString);

                        if (dr.IsDBNull(4))
                        {
                            task.User.ID = (int?)null;
                        }
                        else
                        {
                            task.User.ID = dr.GetInt32(4);
                            FillUserFromDatabase(task.User, connectionString);
                        }
                        task.Deadline  = dr.GetDateTime(5);
                        task.ParentId  = dr.IsDBNull(6) ? (int?)null : dr.GetInt32(6);
                        task.Status.Id = dr.GetInt32(7);
                        FillStatusFromDatabase(task.Status, connectionString);
                        task.Type.Id = dr.GetInt32(8);
                        FillTypeFromDatabase(task.Type, connectionString);
                    }
                }
                else
                {
                    Response.Write("<script>alert('Smth wrong, try again.')</script>");
                }

                con.Close();
             
            }
        }
        public void FillSubtasksFromDatabase(TaskInfo task, string connectionString)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tasks WHERE parentId = "+ task.TaskId, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TaskInfo subtask = new TaskInfo();
                        subtask.TaskId = dr.GetInt32(0);
                        subtask.TaskName = dr.IsDBNull(1) ? null : dr.GetString(1);
                        subtask.Description = dr.IsDBNull(2) ? null : dr.GetString(2);
                        subtask.Manager.ID = dr.GetInt32(3);
                        FillUserFromDatabase(subtask.Manager, connectionString);                  
                       
                        if(dr.IsDBNull(4))
                        {
                            subtask.User.ID = (int?)null;
                        }
                        else
                        {
                            subtask.User.ID = dr.GetInt32(4);
                            FillUserFromDatabase(subtask.User, connectionString);
                        }
                        subtask.Deadline = dr.GetDateTime(5);
                        if(dr.IsDBNull(6))
                        {
                            subtask.ParentId = (int?)null;
                        }
                        else
                        {
                            subtask.ParentId = dr.GetInt32(6);
                            FillSubtasksFromDatabase(subtask, connectionString);
                        }
                           
                        subtask.Status.Id = dr.GetInt32(7);
                        FillStatusFromDatabase(subtask.Status, connectionString);
                        subtask.Type.Id = dr.GetInt32(8);
                        FillTypeFromDatabase(subtask.Type, connectionString);
                        task.Subtasks.Add(subtask);
                    }

                }


                con.Close();
            }

        }



        public void FillUserFromDatabase(UserInfo user, string connectionString)
        {

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE id = " +user.ID, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        user.ID= dr.GetInt32(0);
                        user.Login = dr.GetString(1);
                        user.Name = dr.GetString(3);
                        user.Surname = dr.GetString(4);
                        user.Email = dr.GetString(5);                 
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
    }
   
}