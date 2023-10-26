<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddSize.aspx.cs" Inherits="AddSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Add Size</h4>
        </div>
        <div class="form-group mt-5">
            <label>Size</label>
            <asp:TextBox ID="txtSize" runat="server" CssClass="form-control" ToolTip="Enter Size"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtSize" ErrorMessage="*Required" Display="Dynamic">Please Enter Size</asp:RequiredFieldValidator>
        </div>
         <div class="form-group">
            <label>Select Brand</label>
            <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server" ></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ControlToValidate="ddlBrand" ErrorMessage="*Required" Display="Dynamic">Please Select Brand</asp:RequiredFieldValidator>
        </div>
         <div class="form-group">
            <label>Select Category</label>
            <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ControlToValidate="ddlCategory" ErrorMessage="*Required" Display="Dynamic">Please Select Category</asp:RequiredFieldValidator>
        </div>
         <div class="form-group">
            <label>Select Sub Category</label>
            <asp:DropDownList ID="ddlSubcategory" CssClass="form-control" runat="server" ></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ControlToValidate="ddlSubCategory" ErrorMessage="*Required" Display="Dynamic">Please Select Sub Category</asp:RequiredFieldValidator>
        </div>
         <div class="form-group">
            <label>Select Gender</label>
            <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server" ></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ControlToValidate="ddlGender" ErrorMessage="*Required" Display="Dynamic">Please Select Gender</asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnAddSize" runat="server" CssClass="btn btn-success" Text="Add Size" OnClick="btnAddSize_Click" />
        <asp:Label ID="lblAddSizeMsg" runat="server"></asp:Label><br />
    </div>
    <div class="container mt-5 mb-5">
        <h4 class="display-4">All Sizes</h4>
        <asp:Repeater ID="RepeaterSizes" runat="server">
            <HeaderTemplate>
                <table class="table-hover table-striped table table-light">
                    <thead class="thead-dark">
                        <tr>
                            <th>#</th>
                            <th>Size</th>
                            <th>Brand</th>
                            <th>Category</th>
                            <th>Sub Category</th>
                            <th>Gender</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("SizeID") %></td>
                    <td><%# Eval("SizeName") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("CatName") %></td>
                    <td><%# Eval("SubCatName") %></td>
                    <td><%# Eval("GenderName") %></td>
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

