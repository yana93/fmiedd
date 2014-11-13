<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="WebApplicationCRUDApp.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 405px">
    <form id="form1" runat="server">
    <div style="height: 400px">
    
        <asp:ImageButton ID="BtnDelete" runat="server" Height="153px" ImageUrl="~/Images/th.jpg" Width="255px" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <hr />
        <br />
        <asp:Label ID="LblID" runat="server" Font-Bold="True" Text="PLEASE CHOOS ID:"></asp:Label>
        <asp:TextBox ID="TxtID" runat="server" Height="30px" style="margin-bottom: 0px" Width="71px"></asp:TextBox>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
