using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rEnvios2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

        else
        {
            conexion.foraneasEnvios(folioVenta);
        }
    }

    protected void registrar_Click(object sender, EventArgs e)
    {
        int registro = conexion.registrarEnvios("0", folioVenta.SelectedValue.ToString(), Calendar1.SelectedDate.ToShortDateString(), Calendar2.SelectedDate.ToShortDateString(), metodoEnvio.SelectedValue.ToString(), costo.Text);
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar1.Visible)
        {
            Calendar1.Visible = false;
        }
        else
        {
            Calendar1.Visible = true;
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar2.Visible)
        {
            Calendar2.Visible = false;
        }
        else
        {
            Calendar2.Visible = true;
        }
    }
}