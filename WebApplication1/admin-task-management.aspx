<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin-task-management.aspx.cs" Inherits="WebApplication1.admin_task_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container">
        <div class="row">
            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Task Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100" src="imgs/writer.png" />
                                       
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Task ID</label>

                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Task ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox18" runat="server" placeholder="Manager ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                                    </div>
                                </div>
                                 <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox19" runat="server" placeholder="Acting ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button5" runat="server" Text="Go" OnClick="Button5_Click" />
                                    </div>
                                </div>
                            </div>
                            </div>


                               <div class="row">
                            <div class="col-md-6">
                                <label>Task Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Task Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                                   <div class="col-md-6">
                                <label>New Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="New Name" OnTextChanged="TextBox10_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                              <div class="row">
                             <div class="col-md-6">
                                <label>Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Description" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                                  <div class="col-md-6">
                                <label>New Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="New Description"></asp:TextBox>
                                </div>
                            </div>
                            </div>

                        <div class="row">
                             <div class="col-md-6">
                                <label>Manager ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Manager ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                                <div class="col-md-6">
                                <label>New Manager ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="New Manager ID"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Acting ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Acting ID" OnTextChanged="TextBox5_TextChanged" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                                <div class="col-md-6">
                                <label>New Acting ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" placeholder="New Acting ID"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                          <div class="row">
                            <div class="col-md-6">
                                <label>Deadline</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Deadline" TextMode="DateTime" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>New Deadline</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" placeholder="Deadline"></asp:TextBox>
                                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                </div>
                            </div>
                            </div>
                          <div class="row">
                            <div class="col-md-6">
                                <label>Parent ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Parent ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                                <div class="col-md-6">
                                <label>New Parent ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" placeholder="New Parent ID"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                          <div class="row">
                            <div class="col-md-6">
                                <label>Status </label>&nbsp;<div class="form-group">
                                      <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server" Enabled="false">
                                          <asp:ListItem Text="created" Value="1"></asp:ListItem>
                                          <asp:ListItem Text="Taken" Value="2"></asp:ListItem>
                                          <asp:ListItem Text="Done" Value="3"></asp:ListItem>
                                      </asp:DropDownList>
                                  </div>
                            </div>
                              <div class="col-md-6">
                               <label>New Status </label>
&nbsp;<div class="form-group">
                                      <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                          <asp:ListItem Text="stay the same" Value="0"></asp:ListItem>
                                          <asp:ListItem Text="created" Value="1"></asp:ListItem>
                                          <asp:ListItem Text="Taken" Value="2"></asp:ListItem>
                                          <asp:ListItem Text="Done" Value="3"></asp:ListItem>
                                      </asp:DropDownList>
                                  </div>
                            </div>
                            </div>
                          <div class="row">
           <div class="col-md-6">
               Type <div class="form-group">
        <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server" Enabled="false">
            <asp:ListItem Text="Personal" Value="1"></asp:ListItem>
            <asp:ListItem Text="Cooperated" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
                                 <div class="col-md-6">
                               <label>New Type </label>
&nbsp;<div class="form-group">
                                      <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                           <asp:ListItem Text="stay the same" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Personal" Value="1"></asp:ListItem>
                                          <asp:ListItem Text="Cooperated" Value="2"></asp:ListItem>
                                      </asp:DropDownList>
                                  </div>
                            </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button3_Click" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>




 
    
<a href="home-page.aspx"><< Back to Home</a><br>
                <br>
  <style>
.gridview-spacing th, .gridview-spacing td {
    border-right: 1px solid #000000; /* Цвет и стиль вертикальной черты */
    border-bottom: 1px solid #000000; /* Цвет и стиль нижней горизонтальной черты */
    padding: 8px;
}
</style>
      <center>
            <h4>Task List</h4>

          
            <div class="row">

                    <div runat="server" id="gridViewContainer">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridview-spacing">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" />
                                <asp:BoundField DataField="name" HeaderText="name" />
                                <asp:BoundField DataField="description" HeaderText="description" />
                                <asp:BoundField DataField="managerID" HeaderText="managerID" />
                                <asp:BoundField DataField="manger_login" HeaderText="manger_login" />
                                <asp:BoundField DataField="manager_name,surname" HeaderText="manager_name,surname" />
                                <asp:BoundField DataField="actingID" HeaderText="actingID" />
                                <asp:BoundField DataField="acting_login" HeaderText="acting_login" />
                                <asp:BoundField DataField="acting_name,surname" HeaderText="acting_name,surname" />
                                <asp:BoundField DataField="deadline" HeaderText="deadline" DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="parentID" HeaderText="parentID" />
                                <asp:BoundField DataField="parent_task_name" HeaderText="parent_task_name" />
                                <asp:BoundField DataField="status" HeaderText="status" />
                                <asp:BoundField DataField="type" HeaderText="type" />
                            </Columns>
                        </asp:GridView>
                    </div>                        
                </div>  
           </center>
        </div>
           




</asp:Content>
