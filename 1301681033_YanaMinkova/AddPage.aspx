<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPage.aspx.cs" Inherits="AddPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Add item to the data base:<br />
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="add_btn" runat="server" OnClick="add_btn_Click" Text="Add" />
    
        <br />
        <br />
        <a href="RetrievePage.aspx">RetrievePage.aspx</a></div>
    </form>
</body>
</html>
