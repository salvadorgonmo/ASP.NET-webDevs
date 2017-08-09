using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginaPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (conexion.encontrado && Session["NomUser"]!=null)
            NombreDeUsuario.Text = Session["NomUser"].ToString();
        else
            Response.Redirect("loguin.aspx");
    }

    protected void salir_Click(object sender, EventArgs e)
    {
        Session.Remove("NomUser");
        Session.Remove("Passwd");
        Response.Redirect("loguin.aspx");
    }
}