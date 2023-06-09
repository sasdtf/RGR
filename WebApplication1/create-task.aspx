<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="create-task.aspx.cs" Inherits="WebApplication1.create_task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
                 <div class="col-md-6 mx-auto">
                <div class="card">
                   <div class="card-body">
                      <div class="row">
<div class="form-group">
<label>Task name</label>
<asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Name" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</div>
<div class="form-group">
<label>Description</label>
<asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Description" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
</div>
<div class="form-group">
<label>Who will do it</label>
<asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class="form-group">
<label>Deadline</label>
<asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Deadline" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
</div>
<div class="form-group">
<label>Is subtask for task</label>
<asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
</div>
<div class="form-group">
<label>Type</label>
<asp:DropDownList CssClass="form-control" ID="DropDownListType1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
<asp:ListItem Text="Personal" Value="1"></asp:ListItem>
<asp:ListItem Text="Cooperated" Value="2"></asp:ListItem>
</asp:DropDownList>
</div>
<p>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Create" />
</p>
</div>
</div>
</div>
</div>
</div>

</asp:Content>