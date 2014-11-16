<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete_page.aspx.cs" Inherits="StefanCRUDWebApplicationAccess.delete_page" %>

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
        <h3>Delete by ID</h3>
        <br />
        Choose ID:
        <asp:DropDownList ID="IDDropList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ID" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT [ID] FROM [users]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Delete" OnClick="Button1_Click" />
        <br />
        <br />
        <a href="index.aspx" class="btn btn-success">Back</a><br />
    </div>
    </form>
</body>
</html>
