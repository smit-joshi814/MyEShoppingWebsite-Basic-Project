<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="userHome.aspx.cs" Inherits="userHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="UserGreet" runat="server" CssClass="h5"></asp:Label><br />
    <asp:Label ID="lblOrderPlaced" CssClass="text-success" runat="server"></asp:Label>
</asp:Content>
