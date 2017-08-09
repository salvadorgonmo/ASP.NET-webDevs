using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class conClient2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            conexion.ConsultaCliente(conCliente);
        }
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

        
        MessageBox.Show("cambio");
        string nombre = TextBox1.Text;
        conexion.actualizate(nombre, conCliente);
    }
}