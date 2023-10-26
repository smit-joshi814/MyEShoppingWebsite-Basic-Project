<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddSubCategory.aspx.cs" Inherits="SubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">AddSub Category</h4>
        </div>
        <div class="form-group mt-5">
            <label>Select Category</label>
            <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ControlToValidate="ddlCategory" ErrorMessage="*Required" Display="Dynamic">Please Select Category Name</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>Sub Category Name</label>
            <asp:TextBox ID="txtSubCategory" runat="server" CssClass="form-control" placeholder="Enter Sub Category Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtSubCategory" ErrorMessage="*Required" Display="Dynamic">Please Enter Sub Category Name</asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnAddSubCategory" runat="server" CssClass="btn btn-success" Text="Add Sub Category" OnClick="btnAddSubCategory_Click" />
        <asp:Label ID="lblAddSubCategoryMsg" runat="server"></asp:Label><br />
    </div>
    <div class="container mt-5 mb-5">
        <h4 class="display-4">All Sub Categories</h4>
        <asp:Repeater ID="RepeaterSubCategory" runat="server">
            <HeaderTemplate>
                <table class="table-hover table-striped table table-light">
                    <thead class="thead-dark">
                        <tr>
                            <th>#</th>
                            <th>Sub Category Name</th>
                            <th>Main Category</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("SubCatID") %></td>
                    <td><%# Eval("SubCatName") %></td>
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