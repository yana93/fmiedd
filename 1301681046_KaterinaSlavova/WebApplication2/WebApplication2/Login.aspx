<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 461px; width: 634px" >
    <form id="form1" runat="server">
    <div style="width: 488px; height: 228px; background-color:#0ff">
    
        Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
        <asp:TextBox ID="tbuser" runat="server" Height="16px" style="margin-top: 0px" Width="168px"></asp:TextBox>
            
    
        
            <br />
        <br />
            
    
        
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tbpass" runat="server" Width="165px"></asp:TextBox>
        
        
            <br />
        <br />
        <br />
        
        
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login " Height="39px" style="margin-left: 228px" Width="89px" />
        </div>
    </form>
</body>
    
</html>
