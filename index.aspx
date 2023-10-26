<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="Server">
    <!--slider Start-->
    <div id="carouselCaptions" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselCaptions" data-slide-to="0" class="active"></li>
            <li data-target="#carouselCaptions" data-slide-to="1"></li>
            <li data-target="#carouselCaptions" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="icons/making-payments-the-simple-way-picture-id1309279439.jpg" class="d-block w-100" alt="..."/>
                <div class="carousel-caption d-none d-md-block">
                    <h5>First slide label</h5>
                    <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="icons/online-shopping-and-fashion-store-website-with-add-to-cart-button-in-picture-id1287186681.jpg" class="d-block w-100" alt="..."/>
                <div class="carousel-caption d-none d-md-block">
                    <h5>Second slide label</h5>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="icons/young-working-hard-to-satisfy-all-her-online-fashion-shop-customers-picture-id1303467039.jpg" class="d-block w-100" alt="..."/>
                <div class="carousel-caption d-none d-md-block">
                    <h5>Third slide label</h5>
                    <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur.</p>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselCaptions" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselCaptions" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <!--slider End-->
    <hr />
    <!--Main Body Start-->
    <div class="container text-center">
        <div class="row">
            <div class="col-md-4 mt-2">
                <img src="icons/high-angle-view-close-up-asian-woman-using-meal-delivery-service-picture-id1324465031.jpg" class="rounded-circle" height="140" width="140" />
                <h2>Item1</h2>
                <p>Description</p>
                <p><a class="btn btn-secondary" href="#" role="button">View More</a></p>
            </div>
            <div class="col-md-4 mt-2">
                <img src="icons/online-seller-close-up-hands-young-asian-woman-typing-laptop-keyboard-picture-id1322965456.jpg" class="rounded-circle" height="140" width="140" />
                <h2>Item2</h2>
                <p>Description</p>
                <p><a class="btn btn-secondary" href="#" role="button">View More</a></p>
            </div>
            <div class="col-md-4 mt-2">
                <img src="icons/young-attractive-beautiful-female-entrepreneur-fund-borrower-crazy-picture-id1319565513.jpg" class="rounded-circle" height="140" width="140" />
                <h2>Item3</h2>
                <p>Description</p>
                <p><a class="btn btn-secondary" href="#" role="button">View More</a></p>
            </div>

        </div>
    </div>
    <!--Main Body End-->
</asp:Content>
