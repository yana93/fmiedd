<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="WebApplicationCRUDApp.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style_sheet.css" rel="stylesheet" />
    <style>
        .BtnColor:hover{
             background-color:red;
        }
    </style>
</head>
<body style="height: 419px">
    <form id="form1" runat="server">
    <div style="height:437px">
         <div class="Style">
        <asp:ImageButton ID="BtnDelete" runat="server" Height="145px" ImageUrl="~/Images/th.jpg" Width="255px" OnClick="BtnDelete_Click" style="margin-left: 0px" />
        <br />
             <div class="Labels">
        <br />
        <br />
             </div>
        <br />
         </div>
        <hr />
        <br />
        <asp:Label ID="LblID" runat="server" Font-Bold="True" Text="PLEASE CHOOS ID:" Visible="False"></asp:Label>
        <asp:TextBox ID="TxtID"  runat="server" Height="30px" style="margin-bottom: 0px" Width="71px" Visible="False"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtID" ForeColor="Red" Visible="False">ID Required!</asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
         <br />
         <br />
         <br />
         <br />
        <br />
   
        <asp:Button ID="ButtonDelete" cssClass="BtnColor" runat="server" Height="54px" OnClick="ButtonDelete_Click" Text="Delete" Width="144px" />
    
    </div>
    </form>
</body>
</html>
