<%@ Page Language="C#" AutoEventWireup="true" CodeFile="consultaEnvios.aspx.cs" Inherits="consultaEnvios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Envios</title>

    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet" />

    <style>
        body {
            margin:0;
            padding:0;
            width:100%;
            height:100%;
            background-color:rgba(0,0,0,0.23);
            background-position:center center;
            background-size:cover;
        }

        h1 {
            color: white;
            text-align: center;
            padding: 20px;
        }

        .jumbotron {
            background-color: rgba(0,0,0,0.7);
            font-family: 'Raleway', sans-serif;
        }

        .cajita {
            background-color: rgba(0,0,0,0.7);
            color: white;
        }

        .calendarios {
            text-align: center;
            color: white;
            background-color: rgba(255,255,255,0.1);
        }

        .labels {
            color: white;
        }

        .combitos {
            color: black;
            background-color: rgba(255,255,255,0.6);
        }

        /*hasta aqui copiar css menu*/

          h1,aaa{
        font-family: 'OpenSans-Regular', Times, serif;
        font-size:50px;
        text-align:center;
        color:black;
    }
 
    .logo{
      padding: 0em 0 0 0;
      text-align: center;
      background:  rgba(30, 30, 30, 0.9);
    }
    .logo a{
      color: #1CD5B4;
      font-size: 3.5em;
      text-decoration: none;
      font-family: 'Norican-Regular';
      letter-spacing: 2px;
    }
    .top-nav {
      text-align: center;
      padding: 1.5em 0 1em 0;
      border-bottom: ridge 1px rgba(189, 189, 189, 0.27);
      background: rgba(30, 30, 30, 0.9);
    }
    .top-nav ul {
      padding: 0;
      margin: 0;
    }
    .top-nav ul li {
      display: inline-block;
      margin: 0 2em;
    }
    .top-nav ul li a.active {
      border-bottom: solid 2px #000000;
      color: #000000;
    }
    .top-nav ul li a {
      color: #1CD5B4;
      font-size: 1em;
      letter-spacing: 2px;
      margin: 0;
      font-weight: 600;
      text-decoration: none;
      padding: 0 0 1em 0;
    }
    .top-nav ul li a:hover{
      border-bottom: solid 2px white;
      color: white;
    }
    span.menu {
        display: block;
        padding-bottom: 1em;
        cursor: pointer;
        font-size: 1.2em;
        color: #000;
        position: relative;
    }
    span.menu {
        display: none;
    }
    .container{

        width:50%;
        margin-top:10%;
    }


    body{position:relative; }

    body::after{ content:''; display:block }
      footer {
          height:10%;
          margin-top:40%;
      
          background-color: #555;
          color: white;
          padding: 15px;
        }   


        /*aqui termina css menu*/
    </style>

</head>
<body>
   
            <%--aqui empieza el menu--%>
            <nav class="">
                <div class="banner ">
		<div class="logo">
			<a href="paginaPrincipal.aspx" class="aaa">StoreWare</a>
		</div>
               
		<div class="top-nav">
			<span class="menu pull">MENU</span>
			<ul class="nav1">
		      <li><a href="paginaPrincipal.aspx">Home</a></li>
              <li><a href="RegistroVentas.aspx">Registro de ventas</a></li>
              <li><a href="ConsultaVentas.aspx">Consulta de ventas</a></li>
              <li><a href="loguin.aspx" ><span class="octavo"><i class="icon icon-house"></i></span>Cerrar sesion</a></li>
              <li><a >Bienvenido: </a><asp:Label runat="server" style="color:white" ID="NombreDeUsuario"></asp:Label></></li>
                      
			</ul>
			<!-- script-for-menu -->
				<script>
					 $( "span.menu" ).click(function() {
					$( "ul.nav1" ).slideToggle( 300, function() {
					// Animation complete.
						});
					 });
					 $(function () {
					     var pull = $('#pull');
					     menu = $('nav ul');
					     menuHeight = menu.height();

					     $(pull).on('click', function (e) {
					         e.preventDefault();
					         menu.slideToggle();
					     });
					 });

					 $(window).resize(function () {
					     var w = $(window).width();
					     if (w > 320 && menu.is(':hidden')) {
					         menu.removeAttr('style');
					     }
					 });
				</script>
			<!-- /script-for-menu -->
		</div>
      </div>
   </nav>
     <h1></h1>
    <form id="form1" runat="server">
       
        <div>

            <%--aqui termina menu--%>

            <div class="container" style="background-color: rgba(0,0,0,0.1)">
                <div class="panel panel-default" style="background-color: rgba(0,0,0,0.4)">
                    <div class="panel panel-heading" style="background-color: rgba(255,255,255,0.3); color: white; text-align: center">
                        <h4 class="panel-title">Lista general de envios</h4>
                    </div>
                    <div class="panel-body">
                        <div class="form-group table-responsive">
                            <asp:GridView runat="server" ID="ConsultaEnvios" AutoGenerateColumns="false" OnRowCommand="ConsultaEnvios_RowCommand" OnRowEditing="ConsultaEnvios_RowEditing" OnRowUpdating="ConsultaEnvios_RowUpdating" CssClass="calendarios" OnRowCancelingEdit="ConsultaEnvios_RowCancelingEdit">
                                <Columns>
                                    <asp:BoundField DataField="folioEnvio" HeaderText="Folio de envio" ReadOnly="true" ControlStyle-CssClass="calendarios" />
                                    <asp:BoundField DataField="folioVenta" HeaderText="Folio de venta de producto" ControlStyle-CssClass="calendarios" />
                                    <asp:BoundField DataField="fechaEnvio" HeaderText="Fecha de envio de producto" ControlStyle-CssClass="calendarios" />
                                    <asp:BoundField DataField="fechaEntrega" HeaderText="Fecha de entrega de producto" ControlStyle-CssClass="calendarios" />
                                    <asp:BoundField DataField="metodoEnvio" HeaderText="Metodo de envio" ControlStyle-CssClass="calendarios" />
                                    <asp:BoundField DataField="costo" HeaderText="Costo de envio" ControlStyle-CssClass="calendarios" />
                                    <asp:ButtonField CommandName="eliminarEnvio" Text="Eliminar envio" HeaderText="Eliminar" ControlStyle-CssClass="calendarios" />
                                    <asp:CommandField HeaderText="Editar" ShowEditButton="true" ControlStyle-CssClass="calendarios" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>


        </div>
    </form>

         <footer class="container-fluid text-center">
  <p>Contactanos en:</p>
          <div class="container">
  <h2>Image Gallery</h2>
   <p>Quienes Somos:</p>
  <p>Somos una empresa que busca satisfacer las necesidades, deseos y espectativas de equipos de computo, </p>
  <p>para los diferentes grupos sociales; ofreciendo una amplia variedad de equipos convirtiendonos en </p>
  <p>su mejor opcion. </p>
  <p>Contactanos EN.</p>
  <div class="row">
    <div class="col-md-4">
      <div class="thumbnail"style="background-color:rgba(0,0,0,0.1)">
          <a type="button" href="https://www.facebook.com/juancarlos.espino.94"><img class="moverimagen1" src="../img/facebook-round.png" alt="Mountain View" style="width:25px;height:25px;"/>
        </a>
      </div>
    </div>
    <div class="col-md-4">
      <div class="thumbnail"style="background-color:rgba(0,0,0,0.1)">
       <a href="https://plus.google.com/u/0/"><img class="moverimagen1" src="../img/google.png" alt="Mountain View" style="width:25px;height:25px;"/>
          
        </a>
      </div>
    </div>
    <div class="col-md-4" >
      <div class="thumbnail" style="background-color:rgba(0,0,0,0.1)">
        <a href="https://www.twitter.com"><img class="moverimagen1" src="../img/twtter.png" alt="Mountain View" style="width:25px;height:25px;"/>
          
        </a>
      </div>
    </div>
  </div>
</div>


</footer>
</body>
</html>
