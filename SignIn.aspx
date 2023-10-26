<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>


<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="Server">
    <!--SignIn Start-->
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Sign In Here</h4>
        </div>
        <div class="form-group mt-5">
            <label>UserName</label>
            <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Enter Your Name"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Pasword</label>
            <asp:TextBox ID="password" type="password" runat="server" CssClass="form-control" placeholder="Enter Your Name"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:CheckBox ID="remember" runat="server" />
            <label>Remember Me</label>
        </div>
        <asp:Button ID="signIn" runat="server" CssClass="btn btn-success" Text="Sign In" OnClick="signIn_Click"/>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/SignUp.aspx" CssClass="btn btn-link" runat="server">Sign Up</asp:HyperLink>
        <asp:Label ID="siMsg" runat="server"></asp:Label><br/>
        <asp:HyperLink ID="HyperLink2" NavigateUrl="~/ForgetPassword.aspx" CssClass="mt-2 btn btn-link" runat="server">Forget Password ?</asp:HyperLink>
    </div>
    <!--SignIn End-->
</asp:Content>
