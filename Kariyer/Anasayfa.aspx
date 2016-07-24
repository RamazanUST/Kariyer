<%@ Page Title="Prism Akademi | Anasayfa" Language="C#" MasterPageFile="~/Master/Main.Master" CodeBehind="Anasayfa.aspx.cs" Inherits="Kariyer.Anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <div class="p-t-3 p-b-3">
        <div class="container">
            <div class="flexslider boxed-slider" style="height: 350px;">
                <ul class="slides">
                    <li>
                        <img alt="" src="/Content/images/sliders/others/1.jpg" />
                        <p class="flex-caption">It is Smarter</p>
                    </li>
                    <li>
                        <img alt="" src="/Content/images/sliders/others/2.jpg" />
                        <p class="flex-caption">Fully Customizable</p>
                    </li>
                    <li>
                        <img alt="" src="/Content/images/sliders/others/3.jpg" />
                        <p class="flex-caption">Retina Ready Template</p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="p-t-1">
        <div class="container">
            <div class="row icon-boxes-3">
                <div class="col-md-3">
                    <div class="icon-box-3 circle">
                        <div class="icon-desc main-bg">
                            <i class="fa fa-newspaper-o"></i>
                            <div class="box-number heavy white"><span class="odometer count-title" data-value="17870" data-timer="1500"></span></div>
                            <h4 class="white">Özgeçmiş</h4>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="icon-box-3 circle">
                        <div class="icon-desc dark-bg">
                            <i class="fa fa-eye"></i>
                            <div class="box-number heavy white"><span class="odometer count-title" data-value="4566" data-timer="1500"></span></div>
                            <h4 class="white">Firma</h4>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="icon-box-3 circle">
                        <div class="icon-desc red-bg">
                            <i class="fa fa-list"></i>
                            <div class="box-number heavy white"><span class="odometer count-title" data-value="1530" data-timer="1500"></span></div>
                            <h4 class="white">İlan</h4>
                        </div>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="icon-box-3 circle">
                        <div class="icon-desc pink-bg">
                            <i class="fa fa-users"></i>
                            <div class="box-number heavy white"><span class="odometer count-title" data-value="250" data-timer="1500"></span></div>
                            <h4 class="white">Aranan Eleman</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="J" runat="server">
        <link rel="stylesheet" href="/Content/css/sliders/flexslider.css" />
    <script type="text/javascript" src="/Content/js/sliders/jquery.flexslider-min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "fade"
            });
        });
    </script>
</asp:Content>
