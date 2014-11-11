<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WebApplication2.ManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-color: #00FFFF" >
    <div >
    
        <div style="text-align:center"; background-color:"#0ff" >
            <h2>Manage Users </h2>
        </div>
        <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New" Width="66px" />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" Width="66px" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="66px" />
    
    </div>
        <asp:ListBox ID="lbUsers" runat="server" Height="165px" Width="411px"></asp:ListBox>
    </form>
</body>
</html>
