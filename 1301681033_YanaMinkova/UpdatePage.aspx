<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePage.aspx.cs" Inherits="UpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Update an existing item in the data base:
        <br />
        <br />
        Pick ID: <asp:DropDownList ID="IDDropList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ID" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [ID] FROM [users]"></asp:SqlDataSource>
        <br />
        <br />
        Username: <asp:TextBox ID="username_box" runat="server"></asp:TextBox>
        <br />
        <br />
        Password:
        <asp:TextBox ID="password_box" runat="server"></asp:TextBox>
        <br />
        <br />
        Email:
        <asp:TextBox ID="email_box" runat="server" Width="148px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="update_btn" runat="server" OnClick="update_btn_Click" Text="Update" />
        <br />
        <br />
        <br />
        <a href="RetrievePage.aspx">RetrievePage.aspx</a><br />
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
