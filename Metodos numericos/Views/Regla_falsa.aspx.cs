using Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Metodos_numericos.Models;

namespace Metodos_numericos.Views
{
    public partial class Regla_falsa : System.Web.UI.Page
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
            // e ^ -x  - ln(x) 


            expresion = textBoxEcuacion.Text;

            if (AnalizadorDeFunciones.Sintaxis(expresion, 'x'))//pasamos la funcion a evaluar 
            {

                fx = AnalizadorDeFunciones.EvaluaFx(x);


            }
            else
            {
                //error de sintaxis 
            }
            return fx;
        }







        public void Calcular(object sender, EventArgs e)
        {


            list_Resultados.DataSource = Getresult();
            list_Resultados.DataBind();


        }

        public List<Mregla_falsa> Getresult()
        {
            List<Mregla_falsa> resul = new List<Mregla_falsa>();
            if (string.IsNullOrEmpty(textBoxX1.Text) && string.IsNullOrEmpty(textBoxX2.Text))
            {

                Response.Write("<script> alert('Campos de intervalos vacios')</script> ");

            }

            else
            {

                double x1 = Convert.ToDouble(value: textBoxX1.Text);
                double x2 = Convert.ToDouble(value: textBoxX2.Text);
                double errorPedido = Convert.ToDouble(value: Text_error.Text);
                DateTime tiempo1 = DateTime.Now;
                if (x1 <= 0 || x2 <= 0)
                {

                    Response.Write("<script> alert('Señor Usuario X1 y X2 no pueden ser menores o iguales a 0" + "\r\n " + "Por favor cambie los valores ingresados')</script> ");
                }

                else
                {
                    double xr0 = (((f(x1) * x2) - (f(x2) * x1)) / (f(x1) - f(x2)));

                    if (f(x1) * f(x2) > 0)
                    {

                        Response.Write("<script> alert('Por Favor Cambie Los valores ingresados ya que F(X1)*F(X2)>0')</script> ");


                        foreach (Control ctrl in this.Controls)
                        {
                            if (ctrl is TextBox)
                            {
                                //ctrl.Text = "";
                            }
                        }
                    }

                    else
                    {
                        if (f(x1) * f(xr0) > 0)
                        {
                            x1 = xr0;

                        }
                        else if (f(x1) * f(xr0) < 0)
                        {
                            x2 = xr0;

                        }
                        else if (f(x1) * f(xr0) == 0)
                        {
                            Response.Write("<script> alert('-La Solución Aproximada Es: " + xr0 + "')</script> ");
                            
                            foreach (Control ctrl in this.Controls)
                            {
                                if (ctrl is TextBox)
                                {
                                    //ctrl.Text = "";
                                }
                            }
                        }
                        double xr1 = (((f(x1) * x2) - (f(x2) * x1)) / (f(x1) - f(x2)));
                        double errorObtenido = Math.Abs(xr1 - xr0);
                        int itera = 1;

                        while (errorObtenido > errorPedido)
                        {
                            Mregla_falsa a = new Mregla_falsa();
                            if (f(x1) * f(xr1) > 0)
                            {
                                x1 = xr1;
                            }
                            else if (f(x1) * f(xr1) < 0)
                            {
                                x2 = xr1;
                            }
                            else if (f(x1) * f(xr1) == 0)
                            {
                                Response.Write("<script> alert('-La Solución Aproximada Es: " + xr1 + "')</script> ");
                                foreach (Control ctrl in this.Controls)
                                {
                                    if (ctrl is TextBox)
                                    {
                                        //ctrl.Text = "";
                                    }

                                }

                            }
                            double xr2 = (((f(x1) * x2) - (f(x2) * x1)) / (f(x1) - f(x2)));
                            errorObtenido = Math.Abs(xr2 - xr1);
                            xr1 = xr2;
                            itera++;

                            a.Itera = itera;
                            a.X1 = x1;
                            a.X2 = x2;
                            a.Xr = xr1;
                            a.Error = errorObtenido;

                            resul.Add(a);


                        }
                        DateTime tiempo2 = DateTime.Now;
                        TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);


                        //Response.Write("<script> alert('-La Solución Aproximada Es: " + xr + "\r\n " + "-Con Un Numero De " + itera + "  iteraciones " + "\r\n " + "-En Un Tiempo De " + total.ToString() + "')</script> ");

                        Ale_respuesta.InnerText = "La Solución Aproximada Es: " + xr1 + "\r\n " + "-Con Un Numero De " + itera + "  iteraciones " + "\r\n  ";


                    }
                }
            }



            return resul;


        }//fin metodo getresult





    }
}