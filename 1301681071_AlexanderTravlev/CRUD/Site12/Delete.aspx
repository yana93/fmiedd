<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Site12.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS.css" rel="stylesheet" />
    <title>Details</title>
    <style type="text/css">
        #Button2 {
            margin-left: 618px;
        }
    </style>
</head>
<body style="height: 406px">
    <form id="form1" runat="server">
    <div id="headertext"style="  font-size: 30px; font-weight: bold; font-style: normal; background-color: #C0C0C0;">
    
        Details</div>
    
    
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" style="margin-left: 123px; margin-top: 36px" Width="1088px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="Lastname" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:alexanderConnectionString %>" DeleteCommand="DELETE FROM [Users] WHERE [ID] = @original_ID AND [Username] = @original_Username AND [Firstname] = @original_Firstname AND [Lastname] = @original_Lastname AND [Email] = @original_Email AND [Address] = @original_Address" InsertCommand="INSERT INTO [Users] ([Username], [Firstname], [Lastname], [Email], [Address]) VALUES (@Username, @Firstname, @Lastname, @Email, @Address)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [Username], [Firstname], [Lastname], [Email], [Address] FROM [Users]" UpdateCommand="UPDATE [Users] SET [Username] = @Username, [Firstname] = @Firstname, [Lastname] = @Lastname, [Email] = @Email, [Address] = @Address WHERE [ID] = @original_ID AND [Username] = @original_Username AND [Firstname] = @original_Firstname AND [Lastname] = @original_Lastname AND [Email] = @original_Email AND [Address] = @original_Address">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Username" Type="String" />
                <asp:Parameter Name="original_Firstname" Type="String" />
                <asp:Parameter Name="original_Lastname" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
                <asp:Parameter Name="original_Address" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Username" Type="String" />
                <asp:Parameter Name="Firstname" Type="String" />
                <asp:Parameter Name="Lastname" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Username" Type="String" />
                <asp:Parameter Name="Firstname" Type="String" />
                <asp:Parameter Name="Lastname" Type="String" />
                <asp:Parameter Name="Email" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Username" Type="String" />
                <asp:Parameter Name="original_Firstname" Type="String" />
                <asp:Parameter Name="original_Lastname" Type="String" />
                <asp:Parameter Name="original_Email" Type="String" />
                <asp:Parameter Name="original_Address" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br /><br />
        <a href="Home.aspx">
        <input id="Button2" type="button" value="Back" /></a></form>
</body>
</html>
