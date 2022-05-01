using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Calculus;
using Metodos_numericos.Models;
using Metodos_numericos.Controllers;



namespace Metodos_numericos.Views
{
    public partial class biseccion : System.Web.UI.Page
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

        public List<Biseccion> Getresult()
        {
            List<Biseccion> resul = new List<Biseccion>();
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



                        double xr = (x1 + x2) / 2;
                        double errorObtenido = Math.Abs(x1 - xr);
                       
                        int itera = 0;
                       
                        while (errorObtenido > errorPedido)
                        {
                            Biseccion a = new Biseccion();
                            if (f(x1) * f(xr) < 0)
                            {
                                x2 = xr;
                            }
                            else
                            {
                                x1 = xr;
                            }

                            xr = (x1 + x2) / 2;
                            errorObtenido = Math.Abs(x1 - xr);
                            itera++;
                           
                            a.Itera = itera;
                            a.X1 = x1;
                            a.X2 = x2;
                            a.Xr = xr;
                            a.Error = errorObtenido;
                            
                            resul.Add(a);


                        }
                        DateTime tiempo2 = DateTime.Now;
                        TimeSpan total = new TimeSpan(tiempo2.Millisecond + tiempo1.Millisecond);


                        //Response.Write("<script> alert('-La Solución Aproximada Es: " + xr + "\r\n " + "-Con Un Numero De " + itera + "  iteraciones " + "\r\n " + "-En Un Tiempo De " + total.ToString() + "')</script> ");

                        Ale_respuesta.InnerText = "La Solución Aproximada Es: " + xr + "\r\n " + "-Con Un Numero De " + itera + "  iteraciones " + "\r\n  ";
                        

                    }
                }
            }



            return resul;


        }//fin metodo getresult





    }
}