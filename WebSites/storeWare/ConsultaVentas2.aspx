<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaVentas2.aspx.cs" Inherits="ConsultaVentas2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Ventas</title>
     <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet"/>
    <style>


        body {
            margin: 0;
            padding: 0;
            background-image: url("images2.jpg");
            background-attachment: fixed;
            background-position: center center;
            background-repeat: no-repeat;
            background-size: cover;
            color: white;
        }

     .jumbotron{
            background-color: rgba(0,0,0,0.7);
            font-family: 'Raleway', sans-serif;
        }

          /*hasta aqui copiar css menu*/
        
        div div nav{
            text-align:center;
        }

        div div nav ul{
             list-style:none;
        }

        div div nav ul li{
           display:inline;
           
        }

        div div nav ul li a{
            color:white;
            padding:2%;
            border-radius:10%;
           text-align:center;
           font-size:100%;
            
           font-family: 'Raleway', sans-serif;

        }

        div div nav ul li a:hover{
            text-decoration:none;
            background-color:rgba(0,0,0,0.6);
        }
        
        /*aqui termina css menu*/

        .calendarios {
            text-align: center;
            color: white;
            background-color: rgba(255,255,255,0.1);
        }

        
        
       
    </style>
</head>
<body>
   
     <h1></h1>
    <div class="container-fluid">
        <div class="jumbotron">
            <h2 style="color: white">StoreWare Ventas</h2>
            <h3 style="color: white">Registro de ventas</h3>
        </div>
    </div>

    <div class="container-fluid">
        <div class="jumbotron">
            <nav>
                <ul>
                    <li><a href="paginaPrincipal2.aspx">Home</a></li>
                    <li><a href="RegistroVentas2.aspx">Registro de ventas</a></li>
                 </ul>
            </nav>
        </div>
    </div>

    <form id="form1" runat="server">
        
      <div>
                <div class="container" style="background-color:rgba(0,0,0,0.1)">
            <div class="panel panel-default" style="background-color:rgba(0,0,0,0.4)">
                <div class="panel panel-heading" style="background-color:rgba(0, 0, 0, 0.39); color:white; text-align:center">
                    <h4 class="panel-title">Lista general de envios</h4>
                 </div>
                        <div class="panel-body">
                            <div class="form-group">
                    <asp:GridView runat="server" CssClass="table table-bordered " ID="ConsultarVentas" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:BoundField DataField="folioVenta" HeaderText="Folio De ventas" ReadOnly="true" ControlStyle-CssClass="calendarios" />
                            <asp:BoundField DataField="codBarra" HeaderText="Codigo de Barras" ControlStyle-CssClass="calendarios" />
                            <asp:BoundField DataField="fechaVenta" HeaderText="Fecha de ventas" ControlStyle-CssClass="calendarios" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de ventas" ControlStyle-CssClass="calendarios" />
                            <asp:BoundField DataField="Total" HeaderText="Total de ventas" ControlStyle-CssClass="calendarios" />
                            <asp:CommandField HeaderText="Editar" ShowEditButton="true"  />
                        </Columns>
                    </asp:GridView>
                
                            </div>
                        </div>
                 </div>
            </div>

      </div>
    </form>
</body>
</html>
