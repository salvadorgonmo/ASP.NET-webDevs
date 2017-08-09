using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loguin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void IniciarSesion_Click(object sender, EventArgs e)
    {
        String[] vecRecibeDatos = new String[3];
        if((vecRecibeDatos = conexion.iniciarSesion(nomUser.Text, passwd.Text)) != null)
        {
            String nombre = vecRecibeDatos[0];
            String password = vecRecibeDatos[1];
            String idCliente = vecRecibeDatos[2];
            if(conexion.encontrado && nombre=="admin" && password == "admin1976") { 
         
                Session["NomUser"] = nombre;
                Session["Passwd"] = password;
                Session["idCliente"] = idCliente;
                Response.Redirect("paginaPrincipal.aspx");
          
            }
            else if(conexion.encontrado && nombre != "admin" && password != "admin1976")
            {
                Session["NomUser"] = nombre;
                Session["Passwd"] = password;
                Session["idCliente"] = idCliente;
                Response.Redirect("paginaPrincipal2.aspx");
            }
            else
            {
                Response.Redirect("loguin.aspx");
            }
            
        } 

    
    }

    

    
}