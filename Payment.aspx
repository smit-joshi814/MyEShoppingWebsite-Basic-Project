<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row mt-5 mb-5">
        <div class="col-md-4 order-md-2 mb-4">
            <h4 class="d-flex justify-content-between align-items-center mb-3">
                <span class="text-muted">Your cart</span>
                <a href="Cart.aspx">
                    <span class="bi bi-cart badge badge-primary" id="pCountBill" runat="server" title="Items In cart"></span>
                </a>

            </h4>
            <ul class="list-group mb-3">
                <asp:Repeater ID="rptrProdName" runat="server">
                    <ItemTemplate>
                        <a href="ProductView.aspx?Pid=<%# Eval("PID") %>" class="text-dark text-decoration-none">
                            <li class="list-group-item d-flex justify-content-between lh-condensed">
                                <div>
                                    <h6 class="my-0"><%# Eval("PName").ToString().Take(25).Aggregate("", (x,y) => x + y) %>..</h6>
                                    <small class="text-muted"><%# Eval("PDescription").ToString().Take(40).Aggregate("", (x,y) => x + y) %>...</small>
                                </div>
                                <span class="text-muted"><%# Eval("PSelPrice","{0:c}") %></span>
                            </li>
                        </a>
                        <asp:HiddenField ID="hdnPName" Value='<%# Eval("PName") %>' runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
                 <li class="list-group-item d-flex justify-content-between bg-light">
                    <div class="text-dark">
                        <h6 class="my-0">Total</h6>
                        <small></small>
                    </div>
                    <span class="text-danger" id="TotalAmount" runat="server"></span>
                </li>
                <li class="list-group-item d-flex justify-content-between bg-light">
                    <div class="text-success">
                        <h6 class="my-0">Discount</h6>
                        <small></small>
                    </div>
                    <span class="text-success" id="TotDiscoount" runat="server"></span>
                </li>
                <li class="list-group-item d-flex justify-content-between">
                    <span>Total (INR)</span>
                    <strong id="GrandTotal" runat="server"></strong>
                </li>
            </ul>

            <div class="card p-2">
                <div class="input-group">
                    <input type="text" class="form-control" placeholder="Promo code" />
                    <div class="input-group-append">
                        <button type="submit" class="btn btn-secondary">Redeem</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-8 order-md-1">
            <h4 class="mb-3">Billing address</h4>
            <div runat="server" id="BillingAdd">
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="firstName">First name</label>
                        <asp:TextBox ID="txtfName" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfName" CssClass="text-danger" ErrorMessage="Firt Name Required">Firt Name Required</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="lastName">Last name</label>
                        <asp:TextBox ID="txtlName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="username">Username</label>
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">@</span>
                        </div>
                        <asp:TextBox ID="txtUName" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="email">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail" CssClass="text-danger" ErrorMessage="Email Required">Email Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <label for="address">Address</label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" CssClass="text-danger" ErrorMessage="Address Required">Address Required</asp:RequiredFieldValidator>
                </div>

                <div class="mb-3">
                    <label for="address2">Address 2 <span class="text-muted">(Optional)</span></label>
                    <asp:TextBox ID="txtAddressOp" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-md-5 mb-3">
                        <label for="country">Country</label>
                        <asp:DropDownList ID="dplCountry" CssClass="custom-select d-block w-100" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dplCountry_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dplCountry" CssClass="text-danger" ErrorMessage="Select Country">Select Country</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 mb-3">
                        <label for="state">State</label>
                        <asp:DropDownList ID="dplState" CssClass="custom-select d-block w-100" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dplState" CssClass="text-danger" ErrorMessage="Select State">Select State</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label for="zip">Zip</label>
                        <asp:TextBox ID="txtZip" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtZip" CssClass="text-danger" ErrorMessage="Enter Postal Code">Enter Postal Code</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <hr class="mb-4" />
            <div>
                <asp:CheckBox ID="chbSameAdd" runat="server" OnCheckedChanged="chbSameAdd_CheckedChanged" AutoPostBack="true" Checked="true" />
                <label for="chbSameAdd">Shipping address is the same as my billing address</label>
            </div>
            <div>
                <asp:CheckBox ID="chbSaveInfo" runat="server" />
                <label for="chbSaveInfo">Save this information for next time</label>
            </div>
            <div runat="server" id="ShippingAdd" class="mt-4">
                 <h4 class="mb-3">Shipping address</h4>
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="firstName">First name</label>
                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="lastName">Last name</label>
                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3">
                    <label for="address">Address</label>
                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-md-4 mb-3">
                        <label for="state">State</label>
                        <asp:DropDownList ID="dplState1" CssClass="custom-select d-block w-100" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label for="zip">Zip</label>
                        <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <hr class="mb-4" />

            <h4 class="mb-3">Payment</h4>

            <div class="d-block my-3">
                <div>
                    <asp:RadioButtonList ID="rbPayMethod" runat="server" OnSelectedIndexChanged="rbPayMethod_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0" Enabled="false">Cradit Card</asp:ListItem>
                        <asp:ListItem Value="1" Enabled="false">Dabit Card</asp:ListItem>
                        <asp:ListItem Value="2" Enabled="false">Paypal</asp:ListItem>
                        <asp:ListItem Value="3" Selected="True">Cash On Delivery</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rbPayMethod" CssClass="text-danger" ErrorMessage="Select Payment Method">Select Payment Method</asp:RequiredFieldValidator>
                </div>
            </div>
            <div id="PaymentMethod" runat="server">
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="cc-name">Name on card</label>
                        <input type="text" class="form-control" id="cc-name" placeholder="" />
                        <small class="text-muted">Full name as displayed on card</small>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="cc-number">Credit card number</label>
                        <input type="text" class="form-control" id="cc-number" placeholder="" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 mb-3">
                        <label for="cc-expiration">Expiration</label>
                        <input type="text" class="form-control" id="cc-expiration" placeholder="" />
                    </div>
                    <div class="col-md-3 mb-3">
                        <label for="cc-cvv">CVV</label>
                        <input type="text" class="form-control" id="cc-cvv" placeholder="" />
                    </div>
                </div>
            </div>
            <hr class="mb-4" />
            <asp:Button ID="btnCheckout" runat="server" Text="Continue to checkout" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnCheckout_Click"/>
            <asp:Label ID="lblOrderPlaced" runat="server" CssClass="text-success"></asp:Label>
        </div>
    </div>

</asp:Content>

