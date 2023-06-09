<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="user-Tasks-To-Do.aspx.cs" Inherits="WebApplication1.user_Tasks_To_Do" %>
<%@ Import Namespace="Models.TaskModel" %> 
<%@ Import Namespace="Models.UserModel" %> 
<%@ Import Namespace="Models.StatusModel" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
  
    </center>
    <div class="task">
        <% foreach (TaskInfo task in Tasks)
            {
                DisplayTask(task);
            }
 %>
    </div>

    <% void DisplayTask(TaskInfo task)
    {
        %>
        <h2>Task name: <%= task.TaskName %></h2>
        <p>Description: <%= task.Description %></p>
        <p>Deadline: <%= task.Deadline.ToString("dd.MM.yyyy") %></p>
        <p>Status: <%= task.Status.Name %></p>
        <p>Type: <%= task.Type.Name %></p>
        <p>Manager login/ name/surname: <%= task.Manager.Login  %> &nbsp; <%= task.Manager.Name  %> &nbsp; <%= task.Manager.Surname %> </p>

        <p>User login/name/surname: <%= task.User.Login  %> &nbsp;  <%= task.User.Name  %> &nbsp; <%= task.User.Surname %></p>

       

        <% if (task.Subtasks.Count > 0) { %>
            <h3>SubTasks:</h3>
            <ul class="subtasks">
                <% foreach (TaskInfo subtask in task.Subtasks)
                {
                    DisplayTask(subtask);
                } %>
            </ul>
        <% } %>
        <%
    } %>


</asp:Content>
