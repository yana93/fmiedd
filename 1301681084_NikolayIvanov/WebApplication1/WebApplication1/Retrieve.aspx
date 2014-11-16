<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Retrieve.aspx.cs" Inherits="WebApplication1.Retrieve" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:TemplateField HeaderText="Operation">
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" CommandName="Edit" Text="Edit" Width="63px" />
                        <asp:Button ID="btndelete" runat="server" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
    </form>
</body>
</html>
