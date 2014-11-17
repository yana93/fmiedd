<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeletePage.aspx.cs" Inherits="DeletePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Delete item by ID from the data base:<br />
        <br />
        Pick ID:
        <asp:DropDownList ID="IDDropList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ID" DataValueField="ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT [ID] FROM [users]"></asp:SqlDataSource>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="delete_btn" runat="server" OnClick="delete_btn_Click" Text="Delete" />
        <br />
        <br />
        <a href="RetrievePage.aspx">RetrievePage.aspx</a><br />
    
    </div>
    </form>
</body>
</html>
