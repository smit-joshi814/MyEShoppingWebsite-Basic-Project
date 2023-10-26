<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="Server">
    <!--SignUp start-->
    <div class="container col-md-5 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Signup Here</h4>
        </div>
        <div class="form-group mt-5">
            <label>Your Full Name</label>
            <asp:TextBox ID="FullName" runat="server" CssClass="form-control" placeholder="Enter Your Name"></asp:TextBox><asp:RequiredFieldValidator ID="Isvalidname" runat="server" ErrorMessage="Please Enter Your Name" ControlToValidate="FullName" CssClass="text-danger">*Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Username</label>
            <asp:TextBox ID="txtUname" runat="server" CssClass="form-control" placeholder="EnterUsername"></asp:TextBox><asp:RequiredFieldValidator ID="IsValidUname" runat="server" ErrorMessage="Please Choose Username" ControlToValidate="txtUname" CssClass="text-danger">*Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox><asp:RequiredFieldValidator runat="server" ErrorMessage="Enter Email" ControlToValidate="email" CssClass="text-danger">*Required</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="Isvalidemail" runat="server" ControlToValidate="email" CssClass="text-danger" ErrorMessage="Enter Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email</asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="pass" type="password" runat="server" CssClass="form-control" placeholder="Enter Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Choose Password" CssClass="text-danger" ControlToValidate="pass">*Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Confirm Password</label>
            <asp:TextBox ID="ConPass" type="password" runat="server" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox><asp:CompareValidator ID="IsPassvalid" runat="server" ErrorMessage="Password Does Not match" ControlToCompare="pass" ControlToValidate="ConPass" CssClass="text-danger">Password Does Not match</asp:CompareValidator>
        </div>
        <asp:Button ID="signUp" runat="server" CssClass="btn btn-success" Text="Sign Up" OnClick="signUp_Click" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignIn.aspx" CssClass="btn btn-outline-primary">Sign In</asp:HyperLink>
        <asp:Label ID="suMsg" runat="server" CssClass="text-success"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger mt-3" />
    </div>
    <!--SignUp End-->
</asp:Content>

