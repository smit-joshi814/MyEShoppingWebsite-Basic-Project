<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Reset Password</h4>
        </div>
        
        <div class="form-group">
            <asp:Label ID="lblnewPass" Visible="false" runat="server" Text="New Password"></asp:Label>
            <asp:TextBox ID="userPass" Visible="false" TextMode="Password" runat="server" CssClass="form-control" placeholder="Enter New Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="userPass" ErrorMessage="*Required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lblConPass" Visible="false" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="userPassCon" Visible="false" TextMode="Password" runat="server" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="userPass" ErrorMessage="*Required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Does Not Match" ControlToCompare="userPassCon" ControlToValidate="userPass" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
        </div>
        <asp:Button  ID="RecoverPass" Visible="false" runat="server" CssClass="btn btn-outline-info" Text="Reset" OnClick="RecoverPass_Click"/>
        <asp:Label ID="lblResetPassMsg" runat="server"></asp:Label>
        </div>
</asp:Content>

