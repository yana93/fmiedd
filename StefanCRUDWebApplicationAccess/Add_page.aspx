<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_page.aspx.cs" Inherits="StefanCRUDWebApplicationAccess.Add_page" %>

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
    
        <h3>Add user</h3>
        <br />
        Username:<asp:TextBox ID="username_box" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:<asp:TextBox ID="password_box" runat="server"></asp:TextBox>
        <br />
        <br />
        Email:
        <asp:TextBox ID="email_box" runat="server" Width="143px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="add_btn" class="btn btn-primary" runat="server" OnClick="add_btn_Click" Text="Add" />
        <br />
        <br />
        <a href="index.aspx" class="btn btn-success">Back</a></div>
    </form>
</body>
</html>
