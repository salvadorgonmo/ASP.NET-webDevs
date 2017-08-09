using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class ConsultaVentas : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        //conexion.ConsultarVentas(ConsultarVentas);
    }
    static int index;
    protected void ConsultarVentas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EliminarVentas")
        {
            index = Convert.ToInt32(e.CommandArgument);
            if (index > -1)
            {
                string fila = ConsultarVentas.Rows[index].Cells[0].Text;

                conexion.EliminarVentas(Convert.ToString(fila));
                //conexion.ConsultarVentas(ConsultarVentas);
            }


        }
    }

    public static String dia;
    public static String mes;
    public static String año;

    protected void ConsultarVentas_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow tupla = ConsultarVentas.Rows[e.RowIndex];
        int folioVenta = Convert.ToInt32((tupla.Cells[0]).Text);
        int codBarra = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)tupla.Cells[1].Controls[0]).Text);
        
        String fechaVenta = ((System.Web.UI.WebControls.TextBox)tupla.Cells[2].Controls[0]).Text;
        



        if (fechaVenta.Length == 21)
        {

            if (fechaVenta.Substring(2, 1).ToString().Equals("/"))
            {

                mes = fechaVenta.Substring(0, 2);
                dia = fechaVenta.Substring(3, 1);
                año = fechaVenta.Substring(5, 4);
            }
            else
            {

                mes = fechaVenta.Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
                dia = fechaVenta.Substring(2, 2);//igual que arriba
                año = fechaVenta.Substring(5, 4);
            }
        }
        else
        {
            //1/2/2017
            if (fechaVenta.Length == 20)
            {
                mes = fechaVenta.Substring(0, 1);
                dia = fechaVenta.Substring(2, 1);
                año = fechaVenta.Substring(4, 4);
            }
            else
            {
                //10/16/2017
                if (fechaVenta.Length == 22)
                {
                    mes = fechaVenta.Substring(0, 2);
                    dia = fechaVenta.Substring(3, 2);
                    año = fechaVenta.Substring(6, 4);
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


        int cantidad = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)tupla.Cells[3].Controls[0]).Text);
        
        String total = ((System.Web.UI.WebControls.TextBox)tupla.Cells[4].Controls[0]).Text;
        conexion.modificarVentas(folioVenta, codBarra, fecha1, cantidad, total);
        Response.Redirect("ConsultaVentas.aspx");





    }



    protected void ConsultarVentas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //conexion.ConsultarVentas(ConsultarVentas);
    }

    protected void ConsultarVentas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("ConsultaVentas.aspx");
    }
}