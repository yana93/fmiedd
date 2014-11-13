<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsCrudAccess._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% if (!String.IsNullOrEmpty(Request.QueryString["ShowMessage"])) { %>
    <div class="alert alert-success" role="alert">Потребителят е добавен успешно!</div>
     <%} %>

    <% if (!String.IsNullOrEmpty(Request.QueryString["ShowMessageUdapte"]))
       { %>
    <div class="alert alert-success" role="alert">Потребителят е обновен успешно!</div>
     <%} %>

    <% if (!String.IsNullOrEmpty(Request.QueryString["ShowMessageDelete"]))
       { %>
    <div class="alert alert-success" role="alert">Потребителят е изтрит успешно!</div>
     <%} %>
            
    <asp:ListView runat="server"
            DataKeyNames="id" ItemType="WebFormsCrudAccess.Models.User"
            AutoGenerateColumns="false"
            AllowPaging="true" AllowSorting="true"
            SelectMethod="GetData">
            <EmptyDataTemplate>
              
            </EmptyDataTemplate>
            <LayoutTemplate>
                <div class="page-header">
                    <h1>Всички потребители</h1>
                </div>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>ИД</th>
                            <th>Потребител</th>
                            <th>Имейл</th>
                            <th>Парола</th>                            
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
                        <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Edit?id="+Item.Id) %>' Text="<i class='glyphicon glyphicon-edit'></i> Редактирай " /> /
                        <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Delete?id="+Item.Id) %>' Text="Изтрии <i class='glyphicon glyphicon-remove-circle'></i> " />                                                                       
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
</asp:Content>
