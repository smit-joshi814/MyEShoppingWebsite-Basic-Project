<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h4 class="display-4">All Products </h4>
    <div class="row">
        <asp:Repeater ID="RepeaterProducts" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <a href="ProductView.aspx?Pid=<%# Eval("PID") %>" class="text-decoration-none">
                        <div class="card mb-4 shadow-sm">
                            <img class="bd-placeholder-img card-img-top" src="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("NAME") %>" />
                            <div class="card-body">
                                <div class="ProBrand"><%# Eval("BrandName") %></div>
                                <div class="ProductName"><%# Eval("Name") %></div>
                                <div class="proPrice"><span class="proOgPrice"><%# Eval("PSelPrice")%> </span><%# Eval("PPrice") %> <span class="proPriceDiscount">(<%# Eval("DiscAmount") %> Off) </span></div>
                                <div class="d-flex justify-content-between align-items-center">
                                    <div class="btn-group">
                                        <button type="button" class="btn btn-sm btn-outline-secondary">View</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

