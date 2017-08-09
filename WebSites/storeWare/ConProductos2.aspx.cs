using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ConProductos2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.ConsultaProductos(consultaProducto2);
        }
    }


protected void consultaProducto2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "AgregarCarrito")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index > -1)
            {
                String codBarra = consultaProducto2.Rows[index].Cells[0].Text;
                String descripcion = consultaProducto2.Rows[index].Cells[1].Text;
                String marca = consultaProducto2.Rows[index].Cells[2].Text;
                String categoriaCar = consultaProducto2.Rows[index].Cells[4].Text;
                String pUnitario = consultaProducto2.Rows[index].Cells[5].Text;
                String encontro = conexion.buscarProductoEnCarrito(descripcion);
             if(encontro!= "")
            {
                int[] vect = conexion.cuentaCantidadCarrito(descripcion);
                int cantidad = vect[0];
                int pUni = vect[1];
                cantidad = cantidad + 1;
                int res = cantidad * pUni;
                conexion.actualizarCantidadCarrito(descripcion, cantidad, res);

                }
                else
                {
                    conexion.registrarCarrito(codBarra, descripcion, marca, "1", categoriaCar, pUnitario, pUnitario);
                    
                }
                conexion.ConsultaProductos(consultaProducto2);
            }
        }
    }
}