<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compraRealizada.aspx.cs" Inherits="compraRealizada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consulta de productos</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet"/>
    
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
.tabla {
    margin-top:1%;
    height:80%;
    width:80%;
    margin-left:10%;
    background: rgba(0,0,0,0.5);
    text-align:center;
    color:white;

}
.header {
    font: bold 20px arial;
}

.titulo{

    height:137px;
    width:97%;
    background-color:rgba(255,255,255,0.5);
        }

.otro{

    height:100%;
    margin-left:5%;
     margin-right:5%;
    background-color:rgba(255,255,255,0.5);
}

    .jumbotron{
            background-color: rgba(0,0,0,0.7);
            font-family: 'Raleway', sans-serif;
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

        width:80%;
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

    <nav class="">
                <div class="banner ">
		<div class="logo">
			<a href="paginaPrincipal.aspx" class="aaa">StoreWare</a>
		</div>
               
		<div class="top-nav">
			<span class="menu pull">MENU</span>
			<ul class="nav1">
            <li><a href="paginaPrincipal.aspx">Home</a></li>
                    <li><a href="RegProductos.aspx">Registro de productos</a></li>
                    <li><a href="ConProductos.aspx">Consulta de productos</a></li>
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
    <div class="container-fluid">
        <div class="jumbotron">
            <h2 style="color: white">Gracias por tu compra!</h2>
            <h3 style="color: white">Te proporcionamos tus datos de compra:</h3>
        </div>
    </div>

    
        

    <form id="form1" runat="server">

        <%--<div class="container" style="margin-top:8%">
            <div class="panel panel-default" style="background-color:rgba(0,0,0,0.5)" >--%>

          <div class=" panel-body" style="width:100%; margin-top:1%;margin-bottom:10%;">
          <asp:GridView  CssClass=" table-bordered tabla" runat="server" ID="consultaCompraRealizada" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="folioVenta" HeaderText="Folio de compra" ReadOnly="true" />
                <asp:BoundField ControlStyle-BorderColor="Gray" HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Larger" DataField="codBarra" HeaderText="Nombre del producto" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="fechaVenta" HeaderText="Fecha de compra" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="Total" HeaderText="Total" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="idCliente" HeaderText="Se entregará a" />
                 </Columns>
        </asp:GridView> 
             <%-- <div class="form-group" style="text-align:center">
                    <br />
                   <br />
                    <asp:Button runat="server" ID="regCar" Text="Comprar"  CssClass="btn btn-success cajita" OnClick="regCar_Click" />
                   <asp:Button runat="server" ID="seguirComp" Text="Seguir comprando" CssClass="btn btn-danger" OnClick="seguirComp_Click" />
                </div>--%>
             </div>
               
            <%--</div>
            </div>--%>
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