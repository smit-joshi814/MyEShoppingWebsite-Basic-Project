<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeFile="AddProducts.aspx.cs" Inherits="AddProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container col-md-4 mt-5 mb-5">
        <h4 class="display-4">Add Product</h4>
        <hr />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ControlToValidate="txtProductName" ErrorMessage="*Required">Product Name Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ControlToValidate="txtPrice" ErrorMessage="*Required">Product Price Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Selling Price"></asp:Label>
            <asp:TextBox ID="txtSellPrice" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="text-danger" ControlToValidate="txtSellPrice" ErrorMessage="*Required">Selling Price Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="text-danger" ControlToValidate="ddlBrand" ErrorMessage="*Required">Please Select Brand Name</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="text-danger" ControlToValidate="ddlCategory" ErrorMessage="*Required">Please Select Category Name</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Sub Category"></asp:Label>
            <asp:DropDownList ID="ddlSubCategory" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="text-danger" ControlToValidate="ddlSubCategory" ErrorMessage="*Required">Please Select Sub Category Name</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label19" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="text-danger" ControlToValidate="ddlGender" ErrorMessage="*Required">Please Select Gender</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label7" runat="server" Text="Size"></asp:Label>
            <asp:CheckBoxList ID="cblSize" CssClass="font-weight-bold form-control form-check" RepeatDirection="Horizontal" runat="server"></asp:CheckBoxList>
        </div>
        <div class="form-group">
            <asp:Label ID="Label20" runat="server" Text="Quantity"></asp:Label>
            <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="text-danger" ControlToValidate="txtQuantity" ErrorMessage="*Required">Quantity Required</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label8" runat="server" Text="Description"></asp:Label>
            <asp:TextBox ID="txtDescription" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="text-danger" ControlToValidate="txtDescription" ErrorMessage="*Required">Please Write Product Description</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label9" runat="server" Text="Product Details"></asp:Label>
            <asp:TextBox ID="txtPDetail" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="text-danger" ControlToValidate="txtPDetail" ErrorMessage="*Required">Please Write Product Details</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="Label10" runat="server" Text="Materials & Care"></asp:Label>
            <asp:TextBox ID="txtMatCare" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="text-danger" ControlToValidate="txtMatCare" ErrorMessage="*Required">Please Write Some Words To Material & Care</asp:RequiredFieldValidator>
            
        </div>
        <div class="form-group">
            <asp:Label ID="Label11" runat="server" Text="Upload Product Image"></asp:Label>
            <asp:FileUpload ID="fuImg01" CssClass="form-control" ToolTip="Product Image 1" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="text-danger" ControlToValidate="fuImg01" ErrorMessage="*Required">At Least One Image Required</asp:RequiredFieldValidator>
            
        </div>
        <div class="form-group">
            <asp:Label ID="Label12" runat="server" Text="Upload Product Image"></asp:Label>
            <asp:FileUpload ID="fuImg02" CssClass="form-control" ToolTip="Product Image 2" runat="server" />
            
        </div>
        <div class="form-group">
            <asp:Label ID="Label13" runat="server" Text="Upload Product Image"></asp:Label>
            <asp:FileUpload ID="fuImg03" CssClass="form-control" ToolTip="Product Image 3" runat="server" />
            
        </div>
        <div class="form-group">
            <asp:Label ID="Label14" runat="server" Text="Upload Product Image"></asp:Label>
            <asp:FileUpload ID="fuImg04" CssClass="form-control" ToolTip="Product Image 4" runat="server" />
            
        </div>
        <div class="form-group">
            <asp:Label ID="Label15" runat="server" Text="Upload Product Image"></asp:Label>
            <asp:FileUpload ID="fuImg05" CssClass="form-control" ToolTip="Product Image 5" runat="server" />
            
        </div>
        <div class="col-md-6">
        <div class="form-group">
            <asp:Label ID="Label16" CssClass="col-md-5" runat="server" Text="Free Delivery"></asp:Label>
            <asp:CheckBox ID="chFD" CssClass="col-md-1" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="Label17" CssClass="col-md-5" runat="server" Text="30 Days Return"></asp:Label>
            <asp:CheckBox ID="ch30Ret" runat="server" />
        </div>
        <div class="form-group">
            <asp:Label ID="Label18" CssClass="col-md-5" runat="server" Text="CashOnDelivery"></asp:Label>
            <asp:CheckBox ID="chCOD" CssClass="col-md-1" runat="server" />
        </div>
            </div>
          <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add Product" OnClick="btnAdd_Click"/>
         <asp:Label ID="lblAddProductMsg" runat="server"  CssClass="text-success" ></asp:Label>
    </div>
</asp:Content>