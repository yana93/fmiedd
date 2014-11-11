<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="WebApplication2.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div style ="text-align:center">
            <h2> Registration Form </h2>
            </div>

    <div style="height: 452px; color: #000000; background-color: #00FFFF;"; background-color:"#0ff">
        <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbUserName" runat="server" Height="20px" Width="200px"></asp:TextBox>

        <p>
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtbPassword" runat="server" Height="20px" Width="200px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblemail" runat="server" Text="Email:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtbEmail" runat="server" Height="20px" Width="200px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblFirstName" runat="server" Text="Firstname"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtbFirstname" runat="server" Height="20px" Width="200px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblLastName" runat="server" Text="Lastname:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtbLastname" runat="server" Height="20px" Width="200px"></asp:TextBox>
        </p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Height="35px" OnClick="btnSave_Click" style="margin-left: 161px" Text="Save" Width="133px" BackColor="White" Font-Bold="True" />
        </div>
    </form>
</body>
</html>
