<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebFormsCrudLocalDb.Create" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container">
        <div class="row">
    <form role="form">
        <div class="form-group">           
            <asp:Label ID="LabelUsername" runat="server" AssociatedControlID="TextBoxUsername" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server" CssClass="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Field is required" CssClass="alert-danger"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelEmail" runat="server" AssociatedControlID="TextEmail" Text="Email"></asp:Label>                        
            <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                runat="server" ControlToValidate="TextEmail" ErrorMessage="Invalid email" CssClass="alert-danger"></asp:RegularExpressionValidator><br />           
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextEmail" CssClass="alert-danger" ErrorMessage="Field is required"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="LabelPassword" runat="server" AssociatedControlID="TextPassword" Text="Password"></asp:Label>   
        <asp:TextBox ID="TextPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextPassword" CssClass="alert-danger" ErrorMessage="RequiredFieldValidator">Field is required</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="LabelConfirmPassword" runat="server" AssociatedControlID="TextConfirmPassword" Text="Confirm password"></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextConfirmPassword" CssClass="alert-danger" ErrorMessage="RequiredFieldValidator">Field is required</asp:RequiredFieldValidator><br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextConfirmPassword" ControlToValidate="TextPassword" CssClass="alert-danger">Passwords do not match</asp:CompareValidator>
            <asp:TextBox ID="TextConfirmPassword" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
                
           <asp:Button ID="Add" runat="server" OnClick="Button1_Click" Text="Add" ValidateRequestMode="Disabled" />

    </form>  
    </div>
        </div>
</asp:Content>
