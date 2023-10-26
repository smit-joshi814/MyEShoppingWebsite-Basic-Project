<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-9 mt-3">
            <h4 class="proNameViewcart" runat="server" id="NoItems"></h4>
            <asp:Repeater ID="RepeaterCartProducts" runat="server">
                <ItemTemplate>
                    <%--Show Cart Details Start --%>
                    <div class="border border-dark media">
                        <a href="ProductView.aspx?Pid=<%# Eval("PID") %>" target="_blank">
                            <img style="width: 100px;" src="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("ImageName") %><%# Eval("Extention") %>" alt="<%# Eval("ImageName") %>" onerror="this.src='Images/NoImage.jpg'" class="mr-3" />
                        </a>
                        <div class="media-body">
                            <h5 class="mt-0 proNameViewcart"><%# Eval("PName") %></h5>
                            <p class="proPriceDiscountView">Size : <%# Eval("SizeName") %></p>
                            <span class="proOgPriceView">Rs.<%# Eval("PSelPrice","{0:c}") %></span>
                            <span class="font-weight-bold ml-2">Rs.<%# Eval("PPrice","{0:00,0}") %></span>
                            <p>
                                <asp:Button ID="btnRemoveCart" CssClass="btn btn-sm btn-danger mt-2" runat="server" Text="Remove" OnClick="btnRemoveCart_Click" CommandArgument='<%# ((int)Eval("PID") != 0) ? Eval("PID").ToString()+"-"+Eval("SizeID"):"" %>'/>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%--Show Cart Details End --%>
        </div>
        <div class="col-md-3">
            <%--  Start--%>
            <div class="mt-3" runat="server" id="PriceDetails">
                <h5>Price Details</h5>
                <div class="CartPdetails">
                    <label>Cart Total</label>
                    <span class="priceGray" runat="server" id="spanCartTotal"></span>
                </div>
                <div class="CartPdetails">
                    <label>Cart Discount</label>
                    <span class="pull-right priceGreen" runat="server" id="spanDiscount"></span>
                </div>
            </div>

            <%--  End--%>
            <div>
                <div class="proPriceView CartPdetails">
                    <label>Cart Total</label>
                    <span class="pull-right text-success" runat="server" id="spanGrandTotal"></span>
                </div>
                <div>
                    <asp:Button ID="btnBuy" CssClass="btn buyNowbtn" runat="server" Text="Buy Now" OnClick="btnBuy_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

