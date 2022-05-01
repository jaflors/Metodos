<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Inicio.Master" AutoEventWireup="true" CodeBehind="Regla_falsa.aspx.cs" Inherits="Metodos_numericos.Views.Regla_falsa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        .my-custom-scrollbar {
            position: relative;
            height: 200px;
            overflow: auto;
        }

        .table-wrapper-scroll-y {
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder2" runat="server">
    <div class="col-lg-4 col-md-4 col-sm-12">

        <div class="showback">
            <h4><i class="fa fa-angle-right"></i>Regla Falsa</h4>
          

            <div class="row form-group">
                <label class="col-sm-2 col-sm-2 control-label">f(x)=</label>
                <div class="col-md-10">
                  
                    <asp:TextBox ID="textBoxEcuacion" class="form-control" runat="server"></asp:TextBox>
                    </div>
            </div>

            
            <div class="row form-group">
              <label class="col-sm-2 col-sm-2 control-label">a</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="textBoxX1" onkeypress="javascript:return onKeyDecimal(event,this)" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label class="col-sm-2 col-sm-2 control-label">b</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="textBoxX2" onkeypress="javascript:return onKeyDecimal(event,this)" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row form-group">
                <label class="col-sm-2 col-sm-2 control-label">Error</label>
                <div class="col-sm-10"> 
                    <asp:TextBox ID="Text_error" onkeypress="javascript:return onKeyDecimal(event,this)" class="form-control" runat="server"></asp:TextBox>
                </div>

            </div>
            

            <asp:Button ID="Btcalculo" runat="server" class="btn btn-primary" OnClick="Calcular" Text="Calcular" />


            
        </div>
     
    </div>

    <div class="col-lg-8 col-md-8 col-sm-12">

        <div class="showback">
            <div class="table-wrapper-scroll-y my-custom-scrollbar">

                <table class="table table-bordered table-striped mb-0">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">X1</th>
                            <th scope="col">X2</th>
                            <th scope="col">XR</th>
                            <th scope="col">ERROR</th>

                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView runat="server" ID="list_Resultados">
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%#Eval("Itera")%> </th>
                                    <td><%#Eval("X1")%> </td>
                                    <td><%#Eval("X2")%> </td>
                                    <td><%#Eval("Xr")%> </td>
                                    <td><%#Eval("Error")%> </td>
                                </tr>

                            </ItemTemplate>
                        </asp:ListView>

                    </tbody>
                </table>

            </div>
            <div id="Ale_respuesta" runat="server" class="alert alert-success" style="margin-top: 20px; margin-bottom: 0px;">
                <b>Respuesta = </b>
            </div>


        </div>
    </div>
    <div class="col-lg-12 col-md-12 col-sm-12">
        <div class="showback" style="margin-bottom: 10px;">

            <h4><i class="fa fa-angle-right"></i>Instrucciones</h4>

            <p>
                Ingresar los siguientes datos:
            F(x)= corresponde a la ecuación 
            a = Intervalo izquierdo 
            b = Intervalo derecho 
           error = criterio de parada
                <br />
                funciones admitidas
                 <br />
                1.	seno=sin(x) ó sen(x)
2.	Asen=asn(x)
3.	Acos=acs(x)
4.	Atan=atn(x)
5.	coseno= cos(x)
6.	tangente=tan(x)
7.	absoluto=abs(x)
8.	logaritmo natural=Ln=log(x)
9.	exponencial=e=exp(x)
10.	raíz cuadrada =sqr(x)
                 <br />
                Nota="es importante colocar los * para las multiplicaciones también cuando el numero es decimal ingresar con coma "

            </p>

        </div>

    </div>







</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <script>

        function onKeyDecimal(e, thix) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if (document.getElementById(thix.id).value.indexOf(',') != -1 && keynum == 44)
                return false;
            if ((keynum == 8 || keynum == 48 || keynum == 44))
                return true;
            if (keynum <= 47 || keynum >= 58) return false;
            return /\d/.test(String.fromCharCode(keynum));
        }
 
    </script>
   

</asp:Content>
