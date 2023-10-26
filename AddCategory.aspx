<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Add Category</h4>
        </div>
        <div class="form-group mt-5">
            <label>Category Name</label>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" placeholder="Enter Category Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtCategory" ErrorMessage="*Required" Display="Dynamic">Please Enter Category Name</asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnAddCategory" runat="server" CssClass="btn btn-success" Text="Add Category" OnClick="btnAddCategory_Click" />
        <asp:Label ID="lblAddCategoryMsg" runat="server"></asp:Label><br />
    </div>
    <div class="container mt-5 mb-5">
        <h4 class="display-4">All Categories</h4>
        <asp:Repeater ID="RepeaterCategory" runat="server">
            <HeaderTemplate>
                <table class="table-hover table-striped table table-light">
                    <thead class="thead-dark">
                        <tr>
                            <th>#</th>
                            <th>Category Name</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("CatID") %></td>
                    <td><%# Eval("CatName") %></td>
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

