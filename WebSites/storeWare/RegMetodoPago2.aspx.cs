using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegMetodoPago2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RegTarjeta_Click(object sender, EventArgs e)
    {
        conexion.RegistroTarjeta(NTarjeta.Text, empresa.Text, CodigoSeguridad.Text, FechaVencimiento.Text, tipo.Text);
    }

    protected void RegCard_Click(object sender, EventArgs e)
    {

        conexion.RegistroTarjeta(NTarjeta.Text,empresa.Text,CodigoSeguridad.Text,FechaVencimiento.Text,tipo.Text);
    }
}