<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebFormsCrudAccess.Create" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container">

        <div class="row">
          <div class="col-sm-6">
            <div class="page-header">
                    <h1>Нов потребител</h1>
            </div>
            <form class="form-horizontal" role="form">
                <div class="form-group">
                    <asp:Label ID="LabelUsername" runat="server" AssociatedControlID="TextBoxUsername" Text="Потребител"  CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Въведете потребител!" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelEmail" runat="server" AssociatedControlID="TextEmail" Text="Имейл" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextEmail" CssClass="alert-danger" ErrorMessage="Въведете имейл!"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            runat="server" ControlToValidate="TextEmail" ErrorMessage="Невалиден имейл" CssClass="alert-danger"></asp:RegularExpressionValidator><br />
                     </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelPassword" runat="server" AssociatedControlID="TextPassword" Text="Парола" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextPassword" CssClass="alert-danger" ErrorMessage="RequiredFieldValidator">Въведете парола!</asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="LabelConfirmPassword" runat="server" AssociatedControlID="TextConfirmPassword" Text="Потвърдете паролата" CssClass="col-sm-2 control-label"></asp:Label>
                    <br />
                    <div class="col-sm-10">                        
                        <asp:TextBox ID="TextConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextConfirmPassword" CssClass="alert-danger" ErrorMessage="RequiredFieldValidator">Потвърдете паролата!</asp:RequiredFieldValidator><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextConfirmPassword" ControlToValidate="TextPassword" CssClass="alert-danger">Паролите не съвпадат!</asp:CompareValidator>
                    </div>
                </div>

                <asp:Button ID="Add" runat="server" OnClick="Button1_Click" CssClass="btn btn-primary btn-lg pull-right" Text="Създаване" ValidateRequestMode="Disabled" />

            </form>
          </div>
        </div>
    </div>
</asp:Content>
