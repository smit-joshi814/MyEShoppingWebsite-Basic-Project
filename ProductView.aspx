<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-5">
            <div style="max-width: 480px">
                <!--Image Slider Start-->
                <div id="carouselIndicators" class="carousel slide" data-ride="carousel">
                    <ol class="carousel-indicators">
                        <li data-target="#carouselIndicators" data-slide-to="0" class="active"></li>
                        <li data-target="#carouselIndicators" data-slide-to="1"></li>
                        <li data-target="#carouselIndicators" data-slide-to="2"></li>
                        <li data-target="#carouselIndicators" data-slide-to="3"></li>
                        <li data-target="#carouselIndicators" data-slide-to="4"></li>
                    </ol>
                    <div class="carousel-inner">
                        <asp:Repeater ID="RepeaterImage" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item <%# GetActiveImageClass(Container.ItemIndex) %>">
                                    <img class="img-thumbnail bd-placeholder-img card-img-top" src="Images/ProductImages/<%# Eval("PID") %>/<%# Eval("Name") %><%# Eval("Extention") %>" alt="<%# Eval("Name") %>" onerror="this.src='Images/NoImage.jpg'" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="carousel-control-prev" href="#carouselIndicators" role="button" data-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                    </a>
                    <a class="carousel-control-next" href="#carouselIndicators" role="button" data-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                    </a>
                </div>
                <!--Image Slider End-->
            </div>
        </div>
        <div class="col-md-5">
            <asp:Repeater ID="RepeaterProductDetails" runat="server" OnItemDataBound="RepeaterProductDetails_ItemDataBound">
                <ItemTemplate>
                    <div class="divDet1">
                        <h1 class="ProNameView"><%# Eval("PName") %></h1>
                        <span class="proOgPriceView">Rs. <%# Eval("PSelPrice") %> </span><span class="proPriceDiscountView"> (<%# Eval("DiscAmount") %>off) </span>
                        <p class="proPriceView">Rs. <%# Eval("PPrice") %></p>
                    </div>
                    <div>
                        <h5 class="h5Size">SIZE</h5>
                        <div>
                            <asp:RadioButtonList ID="rblSize" RepeatDirection="Horizontal" runat="server">
                                <asp:ListItem Text="M" Value="M"></asp:ListItem>
                                <asp:ListItem Text="L" Value="L"></asp:ListItem>
                                <asp:ListItem Text="S" Value="S"></asp:ListItem>
                                <asp:ListItem Text="XL" Value="XL"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="divDet1">
                        <asp:Button ID="btnAddToCart" CssClass="mainButton" runat="server" OnClick="btnAddToCart_Click" Text="Add To Cart" />
                        <asp:Label ID="lblAddTocartMsg" runat="server"></asp:Label>
                    </div>
                    <div class="divDet1">
                        <h5 class="h5Size">Description</h5>
                        <p><%# Eval("PDescription") %></p>
                        <h5 class="h5Size">Product Details</h5>
                        <p><%# Eval("PProductDetails") %></p>
                        <h5 class="h5Size">Material & Care</h5>
                        <p><%# Eval("PMaterialCare") %></p>
                    </div>
                    <div>
                        <p><%# ((int)Eval("FreeDelivery")==1)? "Free Delivery":"" %></p>
                        <p><%# ((int)Eval("30DayRet")==1)? "30 Days Returns":"" %></p>
                        <p><%# ((int)Eval("COD")==1)? "Cash On Delivery":"" %></p>
                    </div>
                    <asp:HiddenField ID="hdnPBrandID" runat="server" Value='<%# Eval("PBrandID") %>'/>
                    <asp:HiddenField ID="hdnPCategoryID" runat="server" Value='<%# Eval("PCategoryID") %>'/>
                    <asp:HiddenField ID="hdnPSubCatID" runat="server" Value='<%# Eval("PSubCatID") %>'/>
                    <asp:HiddenField ID="hdnPGenderID" runat="server" Value='<%# Eval("PGenderID") %>'/>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

