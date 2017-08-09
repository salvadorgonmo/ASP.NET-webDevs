<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConProductos2.aspx.cs" Inherits="ConProductos2" %>

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
    margin-top:10%;
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
              <li><a href="paginaPrincipal2.aspx">Home</a></li>
              <li><a href="ConCarrito2.aspx">Ver carrito</a></li>
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

    

    <form id="form1" runat="server">

        <div class="container" style="margin-top:8%;width:90%;padding:8%;">
            <div class="panel panel-default" style="background-color:rgba(0,0,0,0.5)" >
            <div class="panel-heading">
            <div class="panel-title" >
            <h1 style="text-align:center; padding:30px;color:gray;" >~Encuentra los mejores productos en nuestro catalogo~</h1>
            </div>
            </div>
            
            
          <div class="table-responsive" style="width:90%; margin-top:2%;margin-left:5%;margin-bottom:10%;">
          <asp:GridView  CssClass=" table-bordered tabla" runat="server" ID="consultaProducto2" AutoGenerateColumns="False" OnRowCommand="consultaProducto2_RowCommand" >
            <Columns>
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="codBarra" HeaderText="Codigo de Barra" ReadOnly="true" />
                <asp:BoundField ControlStyle-BorderColor="Gray" HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Larger" DataField="Modelo" HeaderText="Modelo" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="Marca" HeaderText="Marca" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="Existencia" HeaderText="Existencia" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="Categoria" HeaderText="Categoria" />
                <asp:BoundField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" DataField="Precio" HeaderText="Precio" />
                <asp:ButtonField HeaderStyle-ForeColor="Gray" HeaderStyle-Font-Size="Large" CommandName="AgregarCarrito" Text="Agregar a carrito" HeaderText="Carrito" />
                
            </Columns>
        </asp:GridView>

              
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
