using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConCarrito : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.ConsultaCarrito(consultaCarrito);
            int total = conexion.totales();
            label1.Text = ""+total;
        }
    }

    protected void regCar_Click(object sender, EventArgs e)
    {
        int rows = consultaCarrito.Rows.Count;
        string[][] mat = new string[rows][];
        for (int i = 0; i < rows; i++)
        {
            mat[i] = new string[3];
        }

        for (int i = 0; i < rows; i++)
        {

            mat[i][0] = consultaCarrito.Rows[i].Cells[3].Text;
            mat[i][1] = consultaCarrito.Rows[i].Cells[7].Text;
            mat[i][2] = consultaCarrito.Rows[i].Cells[8].Text;
        }
        DateTime fecha = new DateTime();
        fecha = DateTime.Today;
        string cantidad;
        string codBarra;
        string total;
        string idCliente = Session["idCliente"].ToString();

        for(int i =0; i < rows; i++)
        {
            cantidad = mat[i][0];
            codBarra = mat[i][1];
            total = mat[i][2];
            conexion.registroVentas(codBarra,fecha.ToShortDateString(),cantidad,total,idCliente);
        }
        conexion.eliminaCarrito();
        Response.Redirect("compraRealizada.aspx");

    }

    protected void seguirComp_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConProductos.aspx");
    }
}