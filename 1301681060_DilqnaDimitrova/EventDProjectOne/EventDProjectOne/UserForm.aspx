<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="EventDProjectOne.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        User&#39;s manage programm
        <br />
        Please select curent user
        <br />
        <br />
        <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New" Width="70px" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="70px" OnClick="btnEdit_Click" />
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="70px" />
        <br />
        <br />
        there&#39;s a list with user&#39;s&nbsp; username, password and Email <br />
        <asp:ListBox ID="lbUser" runat="server" Height="106px" OnSelectedIndexChanged="lbUser_SelectedIndexChanged" Width="473px"></asp:ListBox>
    
    </div>
    </form>
</body>
</html>
