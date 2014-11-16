<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_page.aspx.cs" Inherits="StefanCRUDWebApplicationAccess.update_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to my CRUD application</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet"href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css"/>
    <!-- Optional theme -->
    <link rel="stylesheet"href="//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap-theme.min.css"/>
    <!-- Latest compiled and minified JavaScript -->
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Edit by ID</h3>
        <br />
        Choose ID: <asp:DropDownList ID="IDDropList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ID" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [ID] FROM [users]"></asp:SqlDataSource>
        <br />
        <br />
        Username: <asp:TextBox ID="username_box" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:
        <asp:TextBox ID="password_box" runat="server"></asp:TextBox>
        <br />
        <br />
        Email:
        <asp:TextBox ID="email_box" runat="server" Width="148px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="update_btn" class="btn btn-primary" runat="server" OnClick="update_btn_Click" Text="Edit" />
        <br />
        <br />
        <a href="index.aspx" class="btn btn-success">Back</a><br />
    </div>
    </form>
</body>
</html>
