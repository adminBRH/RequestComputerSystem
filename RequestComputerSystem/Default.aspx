<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RequestComputerSystem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="bd-example mb-3">
  <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
    <ol class="carousel-indicators">
      <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
      <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
      <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
      <li data-target="#carouselExampleCaptions" data-slide-to="3"></li>
      <li data-target="#carouselExampleCaptions" data-slide-to="4"></li>
    </ol>
    <div class="carousel-inner">
      <div class="carousel-item active">
        <img src="image/slide/img1.jpg" class=" w-100" alt="img1">
        <div class="carousel-caption d-none d-m">
          <h5>.</h5>
          <p>1st</p>
        </div>
      </div>
      <div class="carousel-item">
        <img src="image/slide/img2.jpg" class=" w-100" alt="img2">
        <div class="carousel-caption d-none d-m">
          <h5>.</h5>
          <p>2nd</p>
        </div>
      </div>
      <div class="carousel-item">
        <img src="image/slide/img3.jpg" class=" w-100" alt="img3">
        <div class="carousel-caption d-none d-m">
          <h5>.</h5>
          <p>3rd</p>
        </div>
      </div>
      <div class="carousel-item">
        <img src="image/slide/img4.jpg" class=" w-100" alt="img4">
        <div class="carousel-caption d-none d-m">
          <h5>.</h5>
          <p>4th</p>
        </div>
      </div>
      <div class="carousel-item">
        <img src="image/slide/img5.jpg" class=" w-100" alt="img5">
        <div class="carousel-caption d-none d-m">
          <h5>.</h5>
          <p>5th</p>
        </div>
      </div>
    </div>
    <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>

<div class="row">
    <div class="col col-12 mb-3"><center><img src="image/LogoNetwork/BDMS.png" alt="BDMS" /></center></div>
    <div class="col col-2"><img src="image/LogoNetwork/bangkok-hospital.png" class="w-50" alt="Bangkok Hospital" /></div>
    <div class="col col-2"><img src="image/LogoNetwork/samitivej.png" class="w-50" alt="Samitivej" /></div>
    <div class="col col-2"><img src="image/LogoNetwork/bnh.png" class="w-50" alt="BNH" /></div>
    <div class="col col-2"><img src="image/LogoNetwork/phyathai.png" class="w-50" alt="Phyathai" /></div>
    <div class="col col-2"><img src="image/LogoNetwork/paolo.png" class="w-50" alt="Paolo" /></div>
    <div class="col col-2"><img src="image/LogoNetwork/royal-bangkok-hospital.png" class="w-50" alt="Royal Bangkok Hospital" /></div>
</div>

</asp:Content>
