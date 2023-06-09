<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admin-user-management.aspx.cs" Inherits="WebApplication1.admin_user_management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
<div class="container-fluid">
    <div class="row">
             <div class="col-md-6 mx-auto">
                <div class="card">
                   <div class="card-body">
                      <div class="row">
                         <div class="col">
                            <center>
                               <img width="100" src="imgs/generaluser.png"/>
                                <br />
                                User Editor
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
                            <label>USER ID</label>
                            <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Go" OnClick="Button3_Click" />
                                    </div>
                                </div>
                        </div>
                        <div class="col-md-6">
                             <label>Login</label>
                             <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Login" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                       <center>
                           <h4>Changable</h4>

                           Write elements you want to change on the right,or leave empty
                        </center>



                        <div class="row">
                         <div class="col-md-6">
                            <label>Name</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Name" ReadOnly="True"></asp:TextBox>
                            </div>
                         </div>
                            <div class="col-md-6">
                                <label>New Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="New Name"></asp:TextBox>
                                </div>
                         </div>
                         </div>

                         <div class="row">
                        <div class="col-md-6">
                            <label>Surname</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Surname" ReadOnly="True"></asp:TextBox>
                            </div>
                            </div>

                            <div class="col-md-6">
                            <label>New Surname</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="New Surname"></asp:TextBox>
                            </div>
                         </div>
                        </div>


                              <div class="row">
                         <div class="col-md-6">
                            <label>Email</label>
                            <div class="form-group">
                               <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email" TextMode="Email" ReadOnly="True"></asp:TextBox>
                            </div>
                         </div>
                            <div class="col-md-6">
                                <label>New Email</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder=" New Email" TextMode="Email" ></asp:TextBox>
                                </div>
                         </div>
                         </div>

                       <div class="row">
                            <div class="col-md-6">
                            <label>Password</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Password" ReadOnly="True"></asp:TextBox>
                            </div>
                         </div>

                         <div class="col-md-6">
                            <label>New Password</label>
                            <div class="form-group">
                               <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="New Password"></asp:TextBox>
                            </div>
                         </div>
                         </div>

                      <div class="row">

                         <div class="col-6 mx-auto">
                            <center>

                               <div class="form-group">

                                  <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" OnClientClick="return confirmDelete();" />
                                   <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" OnClientClick="return confirmDelete();" />
                               </div>
                            </center>
                         </div>
                      </div>
                   </div>
                </div>              
             </div>
             
    </div>              
</div>


                <a href="home-page.aspx"><< Back to Home</a><br>
                <br>
            </div>
                <style>
.gridview-spacing th, .gridview-spacing td {
    border-right: 1px solid #000000; /* Цвет и стиль вертикальной черты */
    border-bottom: 1px solid #000000; /* Цвет и стиль нижней горизонтальной черты */
    padding: 8px;
}
</style>

                    <center>
                        <h4>User List</h4>

               
            <div class="row">
                <div class="col">
                    <hr>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div runat="server" id="gridViewContainer">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridview-spacing">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" />
                                <asp:BoundField DataField="login" HeaderText="login" />
                                <asp:BoundField DataField="password" HeaderText="password" />        
                                <asp:BoundField DataField="name" HeaderText="name" />
                                <asp:BoundField DataField="surname" HeaderText="surname" />
                                <asp:BoundField DataField="mail" HeaderText="mail" />
                            </Columns>
                        </asp:GridView>
                        <style>
                            .gridview-spacing td {
                                padding-right: 20px;
                                padding-left: 20px;
                            }
                        </style>
                    </div>                        
                </div>                        
            </div> 
     </center>

        <script>
            function confirmDelete()
            {
                var confirmed = confirm("To confirm press OK");
                if (confirmed)
                {
                    return true;
                }
                return false;
            }
        </script>


</asp:Content>
