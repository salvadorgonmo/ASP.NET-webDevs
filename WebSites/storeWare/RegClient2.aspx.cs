using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegClient2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        conexion.obDatosMetPago(nTarjeta);
        conexion.obDatosVenta(folioVenta);
    }

    protected void RegCliente_Click(object sender, EventArgs e)
    {
        int registros;
        registros = conexion.RCliente(idcliente.Text, nombre.Text, direccion.Text, telefono.Text, correo.Text, genero.Text, password.Text, nTarjeta.Text);
        if (registros > 0)
        {
            Response.Redirect("RegClient2.aspx");
        }
    }
}