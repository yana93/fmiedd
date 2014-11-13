<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Site12.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title> 
    <link href="CSS.css" rel="stylesheet" />
    <style type="text/css">
        #Button1 {
            margin-left: 37px;
        }
    </style>
</head>
<body style="height: 406px">
    <form id="form1" runat="server">
    <div id="headertext"style="  font-size: 30px; font-weight: bold; font-style: normal; background-color: #C0C0C0;">
    
        User control</div>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" style="margin-top: 48px" Width="150px">
            <asp:ListItem Selected="True" Value="0">-Choose</asp:ListItem>
            <asp:ListItem Value="1">Register customer</asp:ListItem>
            <asp:ListItem Value="2">View</asp:ListItem>
            <asp:ListItem Value="3">Details</asp:ListItem>
        </asp:DropDownList>
        

        <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click" Height="25px" Width="47px"/>
        

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        

    </form>
</body>
</html>
