<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Inicio.Master" AutoEventWireup="true" CodeBehind="vista1.aspx.cs" Inherits="Metodos_numericos.Views.vista1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder2" runat="server">

    <div class="form-panel" style="margin-top: 0px;">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>

            </ol>


            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">

                    <img src="../Admin/Theme/assets/img/descarga.jpg" />

                </div>

                <div class="item">
                    <img src="../Admin/Theme/assets/img/1366_2000.jpg" />
                </div>

                <div class="item">

                    <img src="../Admin/Theme/assets/img/unnamed.jpg" />
                </div>


            </div>


           
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
                <span class="sr-only">Anterior</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
                <span class="sr-only">Siguiente</span>
            </a>
        </div>

        <div class="jumbotron" style="padding-top: 10px; padding-bottom: 10px; margin-bottom: 20px;">
            <center>
        <h2>SWNUMERIC</h2>
        <p class="lead">Software Educativo como estrategia en el fortalecimiento de la materia metodos numericos.</p>
       
    </center>


        </div>
    </div>


</asp:Content>
