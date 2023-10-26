<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddBrand.aspx.cs" Inherits="AddBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Add Brand</h4>
        </div>
        <div class="form-group mt-5">
            <label>Brand Name</label>
            <asp:TextBox ID="txtBrand" runat="server" CssClass="form-control" placeholder="Enter Brand Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtBrand" ErrorMessage="*Required" Display="Dynamic">Please Enter Brand Name</asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="btnAddBrand" runat="server" CssClass="btn btn-success" Text="Add Brand" OnClick="btnAddBrand_Click" />

        <asp:Label ID="lblAddBrandMsg" runat="server"></asp:Label><br />


    </div>

    <div class="container mt-5 mb-5">
        <h4 class="display-4">All Brands</h4>
        <asp:Repeater ID="RepeaterBrands" runat="server">
            <HeaderTemplate>
                <table class="table-hover table-striped table table-light">
                    <thead class="thead-dark">
                        <tr>
                            <th>#</th>
                            <th>Name</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("BrandID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td>Edit</td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
        </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

