<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsCrudLocalDb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% if (!String.IsNullOrEmpty(Request.QueryString["ShowMessage"])) { %>
    <div class="alert alert-success" role="alert">User was added successfully</div>
     <%} %>

    <% if (!String.IsNullOrEmpty(Request.QueryString["ShowMessageUdapte"]))
       { %>
    <div class="alert alert-success" role="alert">User was updated successfully</div>
     <%} %>

    <% if (!String.IsNullOrEmpty(Request.QueryString["ShowMessageDelete"]))
       { %>
    <div class="alert alert-success" role="alert">User was deleted successfully</div>
     <%} %>
            
    <asp:ListView runat="server"
            DataKeyNames="id" ItemType="WebFormsCrudLocalDb.Models.User"
            AutoGenerateColumns="false"
            AllowPaging="true" AllowSorting="true"
            SelectMethod="GetData">
            <EmptyDataTemplate>
              
            </EmptyDataTemplate>
            <LayoutTemplate>
                <div class="page-header">
                    <h1>All Users</h1>
                </div>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Username</th>
                            <th>Email</th>
                            <th>Password</th>                            
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:DynamicControl runat="server" DataField="id" ID="id" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="username" ID="username" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="email" ID="email" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="password" ID="pass" Mode="ReadOnly" />
                    </td>                                         
                    <td>
                        <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Edit?id="+Item.Id) %>' Text="<i class='glyphicon glyphicon-edit'></i> Edit " /> /
                        <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Delete?id="+Item.Id) %>' Text="Delete <i class='glyphicon glyphicon-remove-circle'></i> " />                                                                       
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
