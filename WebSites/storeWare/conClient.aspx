<%@ Page Language="C#" AutoEventWireup="true" CodeFile="conClient.aspx.cs" Inherits="conClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consulta de Clientes.</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet"/>

    
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
        .tabla{
            height:90%;
            background-color:rgba(0,0,0,0.5);
            color:white;
            font:15px;
            margin-bottom:20%;
        }

        .jumbotron{
            background-color: rgba(0,0,0,0.7);
            font-family: 'Raleway', sans-serif;
        }

         .calendarios{
            text-align:center;
            color:white;
            background-color: rgba(255,255,255,0.3);
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

        .cajas2{
            background-color:rgba(255,255,255,0.6);
            color: black;

             font-family: 'Raleway', sans-serif;
             font-size: 100%;
             margin-left:0%;
        }
    </style>

    
    <script>
        function actualizar(){
            alert("cambio");
        }
    </script>  
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
                    <li><a href="RegClient.aspx">Registro de clientes</a></li>
                    <li><a href="conClient.aspx">Consulta de clientes</a></li>
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
                    <h1 style="color:lightgray">StoreWare</h1>
                </div>
            </div>
            <div class="panel-body">
                <div class="panel panel-title" style="background-color:rgba(0,0,0,0.5)">
                    <h3 style="color:lightgray; text-align:center">Clientes</h3>
                    <asp:TextBox ID="TextBox1" runat="server" OnDataBinding="TextBox1_DataBinding" OnTextChanged="TextBox1_TextChanged" Width="237px" AutoPostBack="true" onChange="actualizar()" CssClass="cajas2"></asp:TextBox>
                </div>
                <div class="table-responsive"> 
                <asp:GridView CssClass="table-bordered table tabla" runat="server" ID="conCliente" AutoGenerateColumns="False" OnRowCommand="conCliente_RowCommand" OnRowUpdating="conCliente_RowUpdating1" OnRowEditing="conCliente_RowEditing" OnRowCancelingEdit="conCliente_RowCancelingEdit">
            <Columns>
                <asp:BoundField HeaderStyle-ForeColor="Gray"  DataField="idCliente" HeaderText="Numero de Cliente" ReadOnly="true" ControlStyle-CssClass="calendarios"/>
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="Nombre" HeaderText="Nombre" ControlStyle-CssClass="calendarios" />
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="Direccion" HeaderText="Direccion" ControlStyle-CssClass="calendarios" />
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="Telefono" HeaderText="Numero Telefonico" ControlStyle-CssClass="calendarios"/>
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="Correo" HeaderText="@mail" ControlStyle-CssClass="calendarios" />
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="Genero" HeaderText="Genero" ControlStyle-CssClass="calendarios"/>
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="Password" HeaderText="contraseña" ControlStyle-CssClass="calendarios" />
                <asp:BoundField  HeaderStyle-ForeColor="Gray" DataField="nTarjeta" HeaderText="Numero de Tarjeta" ControlStyle-CssClass="calendarios" />
                 <asp:ButtonField  HeaderStyle-ForeColor="Gray" CommandName="eliminarCliente" Text="Eliminar" HeaderText="Eliminación" ControlStyle-CssClass="calendarios" />
                <asp:CommandField  HeaderStyle-ForeColor="Gray" HeaderText="Modificación" ShowEditButton="true" />
            </Columns>
        </asp:GridView>
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
