<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_1301681021_Lilyana_Ihtimanska.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style12 {
            width: 195px;
        }
        .auto-style9 {
            width: 258px;
        }
        .auto-style8 {
            width: 198px;
        }
        .auto-style11 {
            width: 247px;
        }
        .auto-style13 {
            width: 195px;
            height: 26px;
        }
        .auto-style14 {
            width: 258px;
            height: 26px;
        }
        .auto-style15 {
            width: 198px;
            height: 26px;
        }
        .auto-style16 {
            width: 247px;
            height: 26px;
        }
        .auto-style5 {
            width: 227px;
        }
        .auto-style3 {
            width: 313px;
        }
        .auto-style4 {
            width: 245px;
        }
        .auto-style6 {
            width: 300px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="text-align: center">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnShow" runat="server" BackColor="#9999FF" Font-Bold="True" Font-Italic="False" Font-Size="Medium" ForeColor="Black" Height="37px" OnClick="btnShow_Click" Text="Show Users" Width="150px" />
            &nbsp;
            <asp:Button ID="btnInsert" runat="server" BackColor="#9999FF" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Height="37px" OnClick="btnInsert_Click" Text="Insert" Width="150px" />
            &nbsp;
            <asp:Button ID="btnUpdate" runat="server" BackColor="#9999FF" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Height="37px" OnClick="btnUpdate_Click" Text="Update" Width="150px" />
            &nbsp;
            <asp:Button ID="btnDelete" runat="server" BackColor="#9999FF" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Height="37px" OnClick="btnDelete_Click" Text="Delete" Width="150px" />
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style12"><strong>User_ID</strong></td>
                    <td class="auto-style9"><strong>Username</strong></td>
                    <td class="auto-style8"><strong>Password</strong></td>
                    <td class="auto-style11"><strong>Email</strong></td>
                </tr>
                <tr>
                    <td class="auto-style13">
                        <asp:TextBox ID="TextBox1" runat="server" BackColor="#CCFFFF" BorderColor="#9999FF" style="text-align: left" Width="130px"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                        <asp:TextBox ID="TextBox2" runat="server" BackColor="#CCFFFF" BorderColor="#9999FF" Width="130px"></asp:TextBox>
                    </td>
                    <td class="auto-style15">
                        <asp:TextBox ID="TextBox3" runat="server" BackColor="#CCFFFF" BorderColor="#9999FF" Width="130px"></asp:TextBox>
                    </td>
                    <td class="auto-style16">
                        <asp:TextBox ID="TextBox4" runat="server" BackColor="#CCFFFF" BorderColor="#9999FF" Width="130px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="lblInfo" runat="server" Font-Size="Medium"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblFinish" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <br />
            <table align="center" class="auto-style1" width="250px">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblUser" runat="server" Font-Bold="True" Font-Underline="True" style="font-size: large" Text="User_ID" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblname" runat="server" Font-Bold="True" Font-Underline="True" style="font-size: large" Text="Username" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblPass" runat="server" Font-Bold="True" Font-Underline="True" style="font-size: large" Text="Password" Visible="False"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lblmail" runat="server" Font-Bold="True" Font-Underline="True" style="font-size: large" Text="Email" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lblId" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="lblUsername" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Label ID="lblPassword" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="lblemail" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    
    </div>
    </form>
</body>
</html>
