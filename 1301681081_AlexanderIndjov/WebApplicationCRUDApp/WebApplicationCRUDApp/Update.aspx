<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="WebApplicationCRUDApp.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 446px">
    <form id="form1" runat="server">
    <div style="height: 441px">
    
        <br />
        <asp:ImageButton ID="BtnID" runat="server" Height="129px" ImageUrl="~/Images/th3.jpg" OnClick="BtnID_Click" Width="260px" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="LblID"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="LblName"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="LblPass"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="LblEmail"></asp:Label>
        <br />
        <hr />
        <br />
        <asp:Label ID="LblID" runat="server" Font-Bold="True" Text="PLEASE CHOOSE ID:" Visible="False"></asp:Label>
        <asp:TextBox ID="TxtID" runat="server" Height="23px" OnTextChanged="TxtID_TextChanged" Visible="False" Width="63px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ErrorMessage="ID Required!" ForeColor="Red" ControlToValidate="TxtID" Visible="False"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblPass" runat="server" Font-Bold="True" Text="PLEASE ENTER NEW PASSWORD: "></asp:Label>
        <asp:TextBox ID="TxtPass" runat="server" Height="24px" TextMode="Password" Width="129px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ErrorMessage="Enter Password!" ForeColor="Red" ControlToValidate="TxtPass" Visible="False"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblEmail" runat="server" Font-Bold="True" Text="PLEASE ENTER NEW EMAIL:"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" Height="19px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Enter Email!" ForeColor="Red" ControlToValidate="TxtEmail" Visible="False"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="BtnUpdate" runat="server" Height="57px" OnClick="BtnUpdate_Click" Text="Update" Width="157px" />
        <br />
        <asp:Label ID="LblState" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
