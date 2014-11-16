<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Task1.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Add user</h1><br />
        
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/Default.aspx">Back</asp:HyperLink><br />
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        <br />
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="usernameError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        <br />
        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="passswordError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="emailError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="addUser" runat="server" OnClick="addUser_Click" Text="Add User" />
    
    </div>
    </form>
</body>
</html>
