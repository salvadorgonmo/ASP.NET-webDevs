<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loguin.aspx.cs" Inherits="loguin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>StoreWare</title>
        <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Raleway" rel="stylesheet"/>
    <style>
        body{
              height:100%;
    width:100%;
    background-image:url(img/imagen181.png);
    background-size:cover;
    background-attachment:fixed;
    background-position:center center;
    background-color:rgba(0,0,0,0.5);
    background-repeat:no-repeat;
        }

        h1{
            font-family: 'Raleway', sans-serif;
        }

        form div .img{
            display:block;
            margin:auto;
            width:180px;
        }

        .cajita{
            background-color: rgba(0,0,0,0.7);
            color:white;
             font-family: 'Raleway', sans-serif;
          
        }

        .calendarios{
            text-align:center;
            color:white;
            background-color: rgba(255,255,255,0.3);
        }

        .container{
            width:35%;
        }

        .labels{
            color:white;
             font-family: 'Raleway', sans-serif;
        }

        .boton{
            background-color:rgba(62, 62, 62, 0.89);
            display:block;
            margin:auto;
        }

    </style>
</head>
<body>
      <form id="form1" runat="server">
    <div>
        <h1 style="color:white;text-align:center">StoreWare</h1>
        <br />
        <asp:Image runat="server" CssClass="img"  ImageUrl="~/incioSesion.png" />
        <br />
       <div class="container" style="background-color:rgba(0,0,0,0.1); height: 81px;">
        <div class="panel panel-default" style="background-color:rgba(0,0,0,0.1)">
            <div class="panel-body" style=" height: 281px;">
                <div class="form-group">
        <asp:Label runat="server" CssClass="labels">Nombre de usuario</asp:Label>
        <asp:TextBox runat="server" ID="nomUser" placeholder="Nombre de usuario" CssClass="form-control cajita" />
        <br />
        <asp:Label runat="server" CssClass="labels">Contraseña</asp:Label>
        <asp:TextBox runat="server" CssClass="form-control cajita" ID="passwd" placeholder="Contraseña" TextMode="Password" />
        <br />
        <asp:Button runat="server" ID="IniciarSesion" OnClick="IniciarSesion_Click" Text="Iniciar sesion" CssClass="btn cajita boton"/>
                </div>
            </div>
        </div>
    </div>
    </div>
    </form>

</body>
</html>
