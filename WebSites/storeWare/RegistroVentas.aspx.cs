using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegistroVentas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      conexion.CargarDatosVentas(codBarra);
        //Conexion.cargarDatosLibro(nombreLibro);
            
         
    }

    protected void registroVentas_Click(object sender, EventArgs e)
    {
        int registros = conexion.registroVentas(codBarra.SelectedValue.ToString(), fechaVenta.SelectedDate.ToShortDateString(), Cantidad.Text, Total.Text);
        if (registros > 0)
        {
            //Response.Redirect("ConsultaVentas.aspx");
        }
    }
}