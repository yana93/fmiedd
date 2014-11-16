<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Task1.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>Edit User</h1><br />
        
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
        <asp:Button ID="saveUser" runat="server" OnClick="saveUser_Click" Text="Save User" />
    
    </div>
    </form>
</body>
</html>
