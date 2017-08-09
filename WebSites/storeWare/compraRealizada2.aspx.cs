using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class compraRealizada2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int idCliente = Convert.ToInt32(Session["idCliente"]);
        string nombreCliente = Session["NomUser"].ToString();
        int totalFilas = conexion.cuentaFilasVentas(idCliente);
        string[][] mat = new string[totalFilas][];
        for (int i = 0; i < totalFilas; i++)
        {
            mat[i] = new string[5];
        }

        conexion.ConsultarVentas2(consultaCompraRealizada, idCliente);



        string nomProducto = "";
        mat = conexion.ConsultarVentas(consultaCompraRealizada, totalFilas, idCliente);
        for (int i = 0; i < totalFilas; i++)
        {
            for (int o = 0; o < 6; o++)
            {
                if (o == 1)
                {
                    nomProducto = conexion.traerNombreProducto(mat[i][o]);
                    consultaCompraRealizada.Rows[i].Cells[o].Text = nomProducto;

                }
                else
                {
                    if (o == 5)
                    {
                        consultaCompraRealizada.Rows[i].Cells[o].Text = nombreCliente;

                    }
                    else
                    {
                        consultaCompraRealizada.Rows[i].Cells[o].Text = mat[i][o];
                    }
                }

            }
        }
    }
}