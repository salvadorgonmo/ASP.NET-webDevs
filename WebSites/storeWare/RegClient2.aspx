<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegClient2.aspx.cs" Inherits="RegClient2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Registro de Clientes</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet"/>

     <script type="text/javascript" src="js/validacion.js"></script>
    <style>
        body{
            margin:0;
            padding:0;
            width:100%;
            height:100%;
            background-color:rgba(0,0,0,0.23);
            background-position:center center;
            background-size:cover;

        }
        .tex{
            background-color:rgba(255,255,255,0.5);
        }
        .label{
            font: 15px arial;
            color:white;
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
    
    <nav class="">
                <div class="banner ">
		<div class="logo">
			<a href="paginaPrincipal.aspx" class="aaa">StoreWare</a>
		</div>
               
		<div class="top-nav">
			<span class="menu pull">MENU</span>
			<ul class="nav1">
				 <li><a href="paginaPrincipal2.aspx">Home</a></li>
                    <li><a href="conClient2.aspx">Consulta de clientes</a></li>
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
    <div class="container" style="margin-top:8%">
        <div class="panel panel-default" style="background-color:rgba(0,0,0,0.5)">
            <div class="panel-heading">
            <div class="panel-title">
                <h1>Se parte de nuestra tienda en linea    S t o r e    W a r e</h1>
            </div>
        </div>
        <div class="panel-body">

        
         <asp:Label CssClass="label" runat="server" >Numero de cliente:</asp:Label>
        <asp:TextBox CssClass="form-control tex" runat="server" ID="idcliente" MaxLength="11" ></asp:TextBox>
        <br /><br />
        <asp:Label CssClass="label" runat="server">Nombre: </asp:Label>
        <asp:TextBox CssClass="form-control tex" runat="server" ID="nombre" MaxLength="20"></asp:TextBox>
        <br /> <br />
        <asp:Label CssClass="label" runat="server" >Direccion:</asp:Label>
        <asp:TextBox CssClass="form-control tex" runat="server" ID="direccion" MaxLength="35" ></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" >Numero de telefono:</asp:Label>
        <asp:TextBox CssClass="form-control tex" runat="server" ID="telefono" MaxLength="15" ></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" >@mail:</asp:Label>
        <asp:TextBox CssClass="form-control tex" runat="server" ID="correo" MaxLength="30" ></asp:TextBox>
        <br />
        <asp:Label CssClass="label" runat="server" >Genero:</asp:Label> <br />
        <asp:DropdownList  CssClass="btn btn-default dropdown-toggle" runat="server" ID="genero" >
            <asp:ListItem Text="seleccione una opcion" value="0" />
            <asp:ListItem Text="F" value="1" />
            <asp:ListItem Text="M" value="2" />
        </asp:DropdownList>
        <br />
        <asp:Label CssClass="label" runat="server" >Contraseña:</asp:Label>
        <asp:TextBox CssClass="form-control tex" runat="server" ID="password" MaxLength="20" ></asp:TextBox>
        <br />
         <asp:Label CssClass="label" runat="server" >Numero de Tarjeta:</asp:Label> <br />
        <asp:DropdownList  CssClass="btn btn-default dropdown-toggle" runat="server" ID="nTarjeta" >
            <asp:ListItem Text="seleccione una opcion" value="0" />
        </asp:DropdownList>
        <br />
        
         <asp:Label CssClass="label" runat="server" >Folio de Venta:</asp:Label> <br />
        <asp:DropdownList  CssClass="btn btn-default dropdown-toggle" runat="server" ID="folioVenta" >
            <asp:ListItem Text="seleccione una opcion" value="0" />
        </asp:DropdownList>
        <br />
            <br />
        <asp:Button CssClass="btn btn-default" runat="server" ID="RegCliente" Text="Enviar Datos" OnClick="RegCliente_Click" />
        <br />
         </div>
        </div>
      </div>
    </form>


     <br /><br /> <br /><br /><br /><br /><br />
   <footer class="container-fluid text-center">
  <p>Contactanos en:</p>
          <div class="container">
  <h2>Image Gallery</h2>
  <p>The .thumbnail class can be used to display an image gallery.</p>
  <p>The .caption class adds proper padding and a dark grey color to text inside thumbnails.</p>
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
