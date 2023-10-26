<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Recover Password</h4>
        </div>
        <div class="form-group">
            <h6 class="h6">Please Enter Your Email Here,We Will Send You Recovery Link For Your Password</h6>
        </div>
        <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="userEmail" runat="server" CssClass="form-control" placeholder="Enter Your Email"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="userEmail" CssClass="text-danger" runat="server" ErrorMessage="Please Enter Your Email" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="userEmail" CssClass="text-danger" ErrorMessage="Invalid Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <asp:Button ID="RecoverPass" runat="server" CssClass="btn btn-warning" Text="Send" OnClick="RecoverPass_Click" />
        <asp:Label ID="lblResetPassMsg" runat="server"></asp:Label>
    </div>
</asp:Content>

