using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class consultaEnvios : System.Web.UI.Page
{
    static int index;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.consultaEnvios(ConsultaEnvios);
        }
       
        
       
    }

    protected void ConsultaEnvios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eliminarEnvio")
        {
            index = Convert.ToInt32(e.CommandArgument);
            if (index > -1)
            {
                string fila = ConsultaEnvios.Rows[index].Cells[0].Text;

                conexion.eliminarEnvio(Convert.ToString(fila));
                conexion.consultaEnvios(ConsultaEnvios);
            }


        }
    }

    protected void ConsultaEnvios_RowEditing(object sender, GridViewEditEventArgs e)
    {
        conexion.consultaEnvios(ConsultaEnvios);
    }
    public static String dia;
    public static String mes;
    public static String año;
    

    protected void ConsultaEnvios_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {
        
        
        GridViewRow tupla=  ConsultaEnvios.Rows[e.RowIndex];
        String folioEnvio = tupla.Cells[0].Text;
        
        String folioVenta = ((System.Web.UI.WebControls.TextBox)tupla.Cells[1].Controls[0]).Text;
        String fechaEnvio = ((System.Web.UI.WebControls.TextBox)tupla.Cells[2].Controls[0]).Text;
        

        //2/16/2017
        //11/1/2017

        if (fechaEnvio.Length == 21)
        {

            if (fechaEnvio.Substring(2, 1).ToString().Equals("/"))
            {

                mes = fechaEnvio.Substring(0, 2);
                dia = fechaEnvio.Substring(3, 1);
                año = fechaEnvio.Substring(5, 4);
            }
            else
            {

                mes = fechaEnvio.Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
                dia = fechaEnvio.Substring(2, 2);//igual que arriba
                año = fechaEnvio.Substring(5, 4);
            }
        }
        else
        {
            //1/2/2017
            if (fechaEnvio.Length == 20)
            {
                mes = fechaEnvio.Substring(0, 1);
                dia = fechaEnvio.Substring(2, 1);
                año = fechaEnvio.Substring(4, 4);
            }
            else
            {
                //10/16/2017
                if (fechaEnvio.Length == 22)
                {
                    mes = fechaEnvio.Substring(0, 2);
                    dia = fechaEnvio.Substring(3, 2);
                    año = fechaEnvio.Substring(6, 4);
                }
            }


        }
        //descomponiendo fecha 

        int diaConver;
        int mesConver;
        int añoConver;

        diaConver = Convert.ToInt32(dia);
        mesConver = Convert.ToInt32(mes);
        añoConver = Convert.ToInt32(año);


        DateTime fecha1 = new DateTime(añoConver, mesConver, diaConver).Date;


        String fechaEntrega = ((System.Web.UI.WebControls.TextBox)tupla.Cells[3].Controls[0]).Text;

        if (fechaEntrega.Length == 21)
        {

            if (fechaEntrega.Substring(2, 1).ToString().Equals("/"))
            {

                mes = fechaEntrega.Substring(0, 2);
                dia = fechaEntrega.Substring(3, 1);
                año = fechaEntrega.Substring(5, 4);
            }
            else
            {

                mes = fechaEntrega.Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
                dia = fechaEntrega.Substring(2, 2);//igual que arriba
                año = fechaEntrega.Substring(5, 4);
            }
        }
        else
        {
            //1/2/2017
            if (fechaEntrega.Length == 20)
            {
                mes = fechaEntrega.Substring(0, 1);
                dia = fechaEntrega.Substring(2, 1);
                año = fechaEntrega.Substring(4, 4);
            }
            else
            {
                //10/16/2017
                if (fechaEntrega.Length == 22)
                {
                    mes = fechaEntrega.Substring(0, 2);
                    dia = fechaEntrega.Substring(3, 2);
                    año = fechaEntrega.Substring(6, 4);
                }
            }


        }
        //descomponiendo fecha 

       

        diaConver = Convert.ToInt32(dia);
        mesConver = Convert.ToInt32(mes);
        añoConver = Convert.ToInt32(año);


        DateTime fecha2 = new DateTime(añoConver, mesConver, diaConver).Date;
        String metodoEnvio = ((System.Web.UI.WebControls.TextBox)tupla.Cells[4].Controls[0]).Text;
        String costo = ((System.Web.UI.WebControls.TextBox)tupla.Cells[5].Controls[0]).Text;
        
        conexion.modificarEnvio(folioEnvio,folioVenta, fecha1, fecha2, metodoEnvio, costo);
        Response.Redirect("consultaEnvios.aspx");
    }

    protected void ConsultaEnvios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("consultaEnvios.aspx");
    }
}