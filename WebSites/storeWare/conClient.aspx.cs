using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class conClient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.ConsultaCliente(conCliente);
        }
    }

    protected void conCliente_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eliminarCliente")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index > -1)
            {
                String fila = conCliente.Rows[index].Cells[0].Text;

                conexion.eliminaCliente(fila);
                conexion.ConsultaCliente(conCliente);

            }


        }
    }

    protected void conCliente_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow tupla = conCliente.Rows[e.RowIndex];
        int x;
        int idCliente = Convert.ToInt32(tupla.Cells[0].Text);
        string Nombre = ((System.Web.UI.WebControls.TextBox)tupla.Cells[1].Controls[0]).Text;
        string Direccion = ((System.Web.UI.WebControls.TextBox)tupla.Cells[2].Controls[0]).Text;
        string Telefono = (((System.Web.UI.WebControls.TextBox)tupla.Cells[3].Controls[0])).Text;
        string Correo = ((System.Web.UI.WebControls.TextBox)tupla.Cells[4].Controls[0]).Text;
        string Genero = ((System.Web.UI.WebControls.TextBox)tupla.Cells[5].Controls[0]).Text;
        string Password = ((System.Web.UI.WebControls.TextBox)tupla.Cells[6].Controls[0]).Text;
        int nTarjeta = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)tupla.Cells[7].Controls[0]).Text);
        //int folioVenta = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)tupla.Cells[8].Controls[0]).Text);

        x=conexion.modificarCliente(idCliente, Nombre, Direccion, Telefono, Correo, Genero, Password, nTarjeta);
        if (x > 0)
            Response.Redirect("conClient.aspx");
                //conexion.ConsultaCliente(conCliente);
    }

    protected void conCliente_RowEditing(object sender, GridViewEditEventArgs e)
    {
        conexion.ConsultaCliente(conCliente);
    }

    protected void conCliente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("conClient.aspx");
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        MessageBox.Show("cambio");
        string nombre = TextBox1.Text;
        conexion.actualizate(nombre,conCliente);

    }

    protected void TextBox1_DataBinding(object sender, EventArgs e)
    {
     
    }
}