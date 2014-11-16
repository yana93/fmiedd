<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebFormsCrudLocalDb.Create" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container">

        <div class="row">
          <div class="col-sm-6">
            <div class="page-header">
                    <h1>Create User</h1>
            </div>
            <form class="form-horizontal" role="form">
                <div class="form-group">
                    <asp:Label ID="LabelUsername" runat="server" AssociatedControlID="TextBoxUsername" Text="Username"  CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Field is required" CssClass="alert-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelEmail" runat="server" AssociatedControlID="TextEmail" Text="Email" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control"></asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextEmail" CssClass="alert-danger" ErrorMessage="Field is required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            runat="server" ControlToValidate="TextEmail" ErrorMessage="Invalid email" CssClass="alert-danger"></asp:RegularExpressionValidator><br />
                     </div>
                </div>

                <div class="form-group">
                    <asp:Label ID="LabelPassword" runat="server" AssociatedControlID="TextPassword" Text="Password" CssClass="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextPassword" CssClass="alert-danger" ErrorMessage="RequiredFieldValidator">Field is required</asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="LabelConfirmPassword" runat="server" AssociatedControlID="TextConfirmPassword" Text="Confirm password" CssClass="col-sm-2 control-label"></asp:Label>
                    <br />
                    <div class="col-sm-10">                        
                        <asp:TextBox ID="TextConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextConfirmPassword" CssClass="alert-danger" ErrorMessage="RequiredFieldValidator">Field is required</asp:RequiredFieldValidator><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextConfirmPassword" ControlToValidate="TextPassword" CssClass="alert-danger">Passwords do not match</asp:CompareValidator>
                    </div>
                </div>

                <asp:Button ID="Add" runat="server" OnClick="Button1_Click" CssClass="btn btn-primary btn-lg pull-right" Text="Add User   " ValidateRequestMode="Disabled" />

            </form>
          </div>
        </div>
    </div>
</asp:Content>
