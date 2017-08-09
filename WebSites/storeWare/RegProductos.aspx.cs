using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegProductos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RegProducto_Click(object sender, EventArgs e)
    {
        conexion.RegistroProducto(codBarra.Text,modelo.Text,marca.Text,existencia.Text,categoria.Text,precio.Text);
    }
}