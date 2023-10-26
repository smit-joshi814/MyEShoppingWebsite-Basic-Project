<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="AdminGreet" runat="server" CssClass="display-4"></asp:Label>

    <div class="container mt-5 mb-5">
        <h4 class="display-4">Purchase Details</h4>
        <asp:Repeater ID="RepeaterAdmin" runat="server">
            <HeaderTemplate>
                <table class="table-hover table">
                    <thead class="thead-dark">
                        <tr>
                            <th>#</th>
                            <th>PID-SizeID</th>
                            <th>CartAmount</th>
                            <th>CartDiscount</th>
                            <th>Total Payed</th>
                            <th>PaymentStatus</th>
                            <th>UserName</th>
                            <th>Address</th>
                            <th>Date Of Purchase</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("OrderID") %></td>
                    <td class="text-muted"><%# Eval("PIDSizeID") %></td>
                    <td class="text-primary"><%# Eval("CartAmount","{0:c}") %></td>
                    <td class="text-danger"><%# Eval("CartDiscount","{0:c}") %></td>
                    <td class="text-success"><%# Eval("TotalPayed","{0:c}") %></td>
                    <td class="text-warning"><%# Eval("PaymentStatus") %></td>
                    <td class="text-info"><%# Eval("username") %></td>
                    <td class="text-primary" title="<%# Eval("Address") %> And Zip = <%# Eval("ZIP") %>"><%# Eval("Address").ToString().Take(10).Aggregate("", (x,y) => x + y) %>...</td>
                    <td class="text-muted"><%# Eval("DateOfPurchase") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
