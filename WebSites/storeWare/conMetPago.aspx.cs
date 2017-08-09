using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class conMetPago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.ConsultaMPago(conMetodoPago);
        }
    }

    protected void conMetodoPago_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //if(!IsPostBack)
       // Conexion.ConsultaMPago(conMetodoPago);
    }

    protected void conMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void conMetodoPago_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eliminarMP")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index > -1)
            {
                String fila = conMetodoPago.Rows[index].Cells[0].Text;
                conexion.eliminaMetodoPago(fila);
                conexion.ConsultaMPago(conMetodoPago);
                
            }


        }
    }

    protected void conMetodoPago_RowEditing(object sender, GridViewEditEventArgs e)
    {
        conexion.ConsultaMPago(conMetodoPago);
    }

    protected void conMetodoPago_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        int y;
        GridViewRow tupla = conMetodoPago.Rows[e.RowIndex];

        int nTarjeta = Convert.ToInt32(tupla.Cells[0].Text);
        string Empresa = ((TextBox)tupla.Cells[1].Controls[0]).Text;
        string codigoSeguridad = ((TextBox)tupla.Cells[2].Controls[0]).Text;
        String fechaVencimiento = (((TextBox)tupla.Cells[3].Controls[0])).Text;
        string Tipo = ((TextBox)tupla.Cells[4].Controls[0]).Text;
        conexion.modificaMPago(nTarjeta, Empresa, codigoSeguridad, fechaVencimiento, Tipo);
        y = conexion.modificaMPago(nTarjeta, Empresa, codigoSeguridad, fechaVencimiento,Tipo);
        if (y > 0)
            Response.Redirect("conMetPago.aspx");
       
    }


    protected void conMetodoPago_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("conMetPago.aspx");
    }
}