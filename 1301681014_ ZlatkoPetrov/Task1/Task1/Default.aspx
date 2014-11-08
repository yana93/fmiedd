<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Task1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Users list</h1><br />
        <asp:HyperLink ID="addUser" runat="server" NavigateUrl="/add.aspx">Add new user</asp:HyperLink>
        <br />
        <asp:Table ID="UsersTable" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell ID="username" runat="server" EnableTheming="False">Username</asp:TableCell>
                <asp:TableCell ID="passwrod" runat="server">Password</asp:TableCell>
                <asp:TableCell ID="email" runat="server">Email</asp:TableCell>
                <asp:TableCell ID="actions" runat="server">Actions</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        
    </div>
    </form>
</body>
</html>
