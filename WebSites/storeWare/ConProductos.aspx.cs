using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ConProductos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.ConsultaProductos(consultaProducto);
        }
    }

    protected void consultaProducto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eliminarProducto")
        {
           int index = Convert.ToInt32(e.CommandArgument);
            if (index > -1)
            {
                String fila = consultaProducto.Rows[index].Cells[0].Text;
                conexion.eliminaProducto(fila);
                conexion.ConsultaProductos(consultaProducto);
            }
            
        }
        else
        {
            if(e.CommandName == "AgregarCarrito")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (index > -1)
                {
                    String codBarra = consultaProducto.Rows[index].Cells[0].Text;
                    String descripcion = consultaProducto.Rows[index].Cells[1].Text;
                    String marca = consultaProducto.Rows[index].Cells[2].Text;
                    //String cantidad = consultaProducto.Rows[index].Cells[3].Text;
                    String categoriaCar = consultaProducto.Rows[index].Cells[4].Text;
                    String pUnitario = consultaProducto.Rows[index].Cells[5].Text;
                    string encontro= conexion.buscarProductoEnCarrito(descripcion);
                    if (encontro != "")
                    {
                        int[] vect = conexion.cuentaCantidadCarrito(descripcion);
                        int cantidad = vect[0];
                        int pUni = vect[1];
                        cantidad = cantidad + 1;
                        int res = cantidad * pUni;
                        conexion.actualizarCantidadCarrito(descripcion, cantidad,res);

                    }

                     else
                    {

                        conexion.registrarCarrito(codBarra, descripcion, marca, "1", categoriaCar, pUnitario,pUnitario);

                    }

                    //conexion.eliminaProducto(fila);
                    conexion.ConsultaProductos(consultaProducto);
                }

            }
        }
        
    }



    protected void consultaProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow tuplas = consultaProducto.Rows[e.RowIndex];

        int codBarra =Convert.ToInt32( tuplas.Cells[0].Text);
        string Modelo = ((TextBox)tuplas.Cells[1].Controls[0]).Text;
        string Marca = ((TextBox)tuplas.Cells[2].Controls[0]).Text;
        int Existencia = Convert.ToInt32(((TextBox)tuplas.Cells[3].Controls[0]).Text);
        string Categoria = ((TextBox)tuplas.Cells[4].Controls[0]).Text;
        float Precio = Convert.ToInt32(((TextBox)tuplas.Cells[5].Controls[0]).Text);

        conexion.modificaProducto(codBarra, Modelo, Marca, Existencia, Categoria, Precio);
        Response.Redirect("ConProductos.aspx");
    }

    protected void consultaProducto_RowEditing(object sender, GridViewEditEventArgs e)
    {
        conexion.ConsultaProductos(consultaProducto);
    }

    protected void consultaProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Response.Redirect("ConProductos.aspx");
    }
}