<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddGender.aspx.cs" Inherits="AddGender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <div class="form-group">
            <h4 class="display-4">Add Gender</h4>
        </div>
        <div class="form-group mt-5">
            <label>Gender</label>
            <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="Enter Gender"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtGender" ErrorMessage="*Required" Display="Dynamic">Please Enter Gender</asp:RequiredFieldValidator>
        </div>        
        <asp:Button ID="btnAddGender" runat="server" CssClass="btn btn-success" Text="Add Gender" OnClick="btnAddGender_Click" />
        <asp:Label ID="lblAddGenderMsg" runat="server"></asp:Label><br/>
    </div>
  <div class="container mt-5 mb-5">
        <h4 class="display-4">Genders</h4>
        <asp:Repeater ID="RepeaterGender" runat="server">
            <HeaderTemplate>
                <table class="table-hover table-striped table table-light">
                    <thead class="thead-dark">
                        <tr>
                            <th>#</th>
                            <th>Gender Name</th>
                            <th>Edit</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("GenderID") %></td>
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

