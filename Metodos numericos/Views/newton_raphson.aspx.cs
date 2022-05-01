using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metodos_numericos.Models;
using Metodos_numericos.Controllers;
using Calculus;

namespace Metodos_numericos.Views
{
    public partial class newton_raphson : System.Web.UI.Page
    {
        Calculo AnalizadorDeFunciones = new Calculo();

        string expresion;
        double fx;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.textBoxX1.ReadOnly = true;
            //this.textBoxX2.ReadOnly = true;
        }




        public double f(double x)
        {
           
            expresion = textBoxEcuacion.Text;

            if (AnalizadorDeFunciones.Sintaxis(expresion, 'x'))//pasamos la funcion a evaluar 
            {

                fx = AnalizadorDeFunciones.EvaluaFx(x);


            }
            else
            {
                Response.Write("<script> alert('error de sintaxis en el campo de la funcion recuerda colocar * para las multiplicaciones ')</script> ");//error de sintaxis 
            }
            return fx;
        }

        public double fPD(double x)
        {
           
            expresion = textBoxDerivate.Text;

            if (AnalizadorDeFunciones.Sintaxis(expresion, 'x'))//pasamos la funcion a evaluar 
            {

                fx = AnalizadorDeFunciones.EvaluaFx(x);


            }
            else
            {
                Response.Write("<script> alert('error de sintaxis en el campo de la función derivada recuerda colocar * para las multiplicaciones ')</script> ");//error de sintaxis 
            }
            return fx;
        }






        public void Calcular(object sender, EventArgs e)
        {


            list_Resultados.DataSource = Getresult();
            list_Resultados.DataBind();


        }

        public List<Mnewtton> Getresult()
        {
            List<Mnewtton> resul = new List<Mnewtton>();
            if (string.IsNullOrEmpty(textBoxX.Text) )
            {
                Response.Write("<script> alert('Campo del valor inicial vacio')</script> ");
            }
            if (string.IsNullOrEmpty(Text_error.Text))
            {

                Response.Write("<script> alert('Señor Usuario Por Favor Ingrese Un Valor Correcto')</script> ");
            }

            else
            {

               double x0 = Convert.ToDouble(value: textBoxX.Text);
               double xn = Convert.ToDouble(value: textBoxX.Text);
               double errorPedido = Convert.ToDouble(value: Text_error.Text);
               DateTime tiempo1 = DateTime.Now;
               double x1 = 0;
                if (x0 <= 0)
                {

                    Response.Write("<script> alert('X no puede ser menos que 0')</script> ");
                }

                else
                {
                    x1 = (x0 - (f(x0) / fPD(x0)));
                    
                    double x2 = x1 - (f(x1) / fPD(x1));
                    double errorObtenido = Math.Abs(x2 - x1);


                    int itera = 0;
                    while (errorObtenido > errorPedido)
                        {

                           Mnewtton a = new Mnewtton();
                           double fun = f(xn);
                           double x3 = x2 - (f(x2) / fPD(x2));
                           errorObtenido = (Math.Abs(x3 - x2));
                           x1 = x2;
                           x2 = x3;
                           
                           a.Itera = itera;
                           a.aprox = xn;
                           a.raizaproximada = x2;
                           a.fun = fun;
                           a.Error = errorObtenido;

                           resul.Add(a);
                        xn = x2;
                        itera++;
                    }
                        DateTime tiempo2 = DateTime.Now;
                        TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);



                        Ale_respuesta.InnerText = "La Solución Aproximada Es: " + x2 + "\r\n " + "-Con Un Numero De " + itera + "  iteraciones " + "\r\n  ";


                   
                }
            }



            return resul;


        }//fin metodo getresult
    }
}