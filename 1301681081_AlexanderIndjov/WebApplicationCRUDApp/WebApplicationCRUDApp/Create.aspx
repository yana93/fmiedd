<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebApplicationCRUDApp.Create" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet2.css" rel="stylesheet" />
    <style type="text/css">
        #Hline {
            height: -15px;
        }
        .BtnStyle:hover{
            background-color:green;
        }
    </style>
</head>
<body style="height: 400px; margin-top: 10px;">
    <form id="form1" runat="server">
    <div style="height: 404px; margin-left: 2px;">
    
     <div class="Style">
        <asp:ImageButton ID="AddNewUser" runat="server" Height="156px" Width="281px" ImageUrl="~/Images/th1.jpg" OnClick="AddNewUser_Click" style="margin-top: 8px" />
    </div>
    
        <br />
        <hr id="Hline" />
        <br />
        <asp:Label ID="LblUser" runat="server" Text="USERNAME: " Font-Bold="True" Font-Size="Larger" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="28px" Visible="False" Width="129px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddedName" runat="server" ErrorMessage="Name Required!" ControlToValidate="TextBox1" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ControlToValidate="TextBox1" ErrorMessage="Must contain numbers " ForeColor="Red" ValidationExpression="^[a-z0-9._-]{2,25}$" Visible="False"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="LblPass" runat="server" Text="PASSWORD: " Font-Bold="True" Font-Size="Larger" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Height="29px" TextMode="Password" style="margin-left: 2px" Visible="False" Width="131px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddedPass" runat="server" ErrorMessage="Password Required!" ControlToValidate="TextBox2" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ControlToValidate="TextBox2" ErrorMessage="Must contain numbers too!" ForeColor="Red" ValidationExpression="^[a-zA-Z]\w{3,14}$" Visible="False"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="LblEmail" runat="server" Text="EMAIL:" Font-Bold="True" Font-Size="Larger" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Width="156px" Height="26px" style="margin-left: 0px" Visible="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ErrorMessage="Email Required!" ControlToValidate="TextBox3" ForeColor="Red" Visible="False"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBox3" ErrorMessage="Must contain @!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Visible="False"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="BtnSave" CssClass="BtnStyle" runat="server" Height="46px" OnClick="BtnSave_Click" Text="Save" Width="137px" />
    
    </div>
    </form>
</body>
</html>
