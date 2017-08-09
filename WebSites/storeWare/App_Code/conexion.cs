using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
/// <summary>
/// Descripción breve de conexion
/// </summary>
public class conexion
{
    public static string cadenaConexion = "Server=localhost;Database=storeware;Uid=root;Pwd=jespino1";
    public static MySqlConnection conexion1 = new MySqlConnection(cadenaConexion);
    static String dia;
    static String mes;
    static String año;
    static int diaConver;
    static int mesConver;
    static int añoConver;

    //IniciarSesion
    public static bool encontrado=false;
        public static String[] iniciarSesion(string Nombre, string Password)
    {
        String []capturarDatos = new String[3];

        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlCommand comprobar = new MySqlCommand("select Nombre,Password,idCliente from cliente where Nombre=@Nombre and Password=@Password", conexion1);
        comprobar.Parameters.AddWithValue("@Nombre", Nombre);
        comprobar.Parameters.AddWithValue("@Password", Password);
        MySqlDataReader lector = comprobar.ExecuteReader();
        if (lector.Read())
        {
            encontrado = true;
            capturarDatos[0] = lector["Nombre"].ToString();
            capturarDatos[1] = lector["Password"].ToString();
            capturarDatos[2] = lector["idCliente"].ToString();
        }

        lector.Close();
        conexion1.Close();

        return capturarDatos;
    }



    ///***********************************///////////////////
    //metodosParaLasTablasEnvios//
    ///**************************************///////////
    public static int registrarEnvios(params String[] datos)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlCommand insert = new MySqlCommand("insert into envios values(0,@folioVenta,@fechaEnvio,@fechaEntrega,@metodoEnvio,@costo)", conexion1);
        insert.Parameters.AddWithValue("@folioVenta", datos[1]);
        //2/16/2017
        //11/1/2017
        if (datos[2].Length == 9)
        {

            if (datos[2].Substring(2, 1).ToString().Equals("/"))
            {

                mes = datos[2].Substring(0, 2);
                dia = datos[2].Substring(3, 1);
                año = datos[2].Substring(5, 4);
            }
            else
            {

                mes = datos[2].Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
                dia = datos[2].Substring(2, 2);//igual que arriba
                año = datos[2].Substring(5, 4);
            }
        }
        else
        {
            //1/2/2017
            if (datos[2].Length == 8)
            {
                mes = datos[2].Substring(0, 1);
                dia = datos[2].Substring(2, 1);
                año = datos[2].Substring(4, 4);
            }
            else
            {
                //10/16/2017
                if (datos[2].Length == 10)
                {
                    mes = datos[2].Substring(0, 2);
                    dia = datos[2].Substring(3, 2);
                    año = datos[2].Substring(6, 4);
                }
            }


        }
        //descomponiendo fecha 


        diaConver = Convert.ToInt32(dia);
        mesConver = Convert.ToInt32(mes);
        añoConver = Convert.ToInt32(año);


        DateTime fecha1 = new DateTime(añoConver, mesConver, diaConver).Date;
        MessageBox.Show(fecha1.ToString());
        insert.Parameters.AddWithValue("@fechaEnvio", fecha1);
        if (datos[3].Length == 9)
        {
            mes = datos[3].Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
            dia = datos[3].Substring(2, 2);//igual que arriba
            año = datos[3].Substring(5, 4);

        }
        else
        {
            //1/2/2017
            if (datos[3].Length == 8)
            {
                mes = datos[3].Substring(0, 1);
                dia = datos[3].Substring(2, 1);
                año = datos[3].Substring(4, 4);
            }
            else
            {
                if (datos[3].Length == 10)
                {
                    mes = datos[3].Substring(0, 2);
                    dia = datos[3].Substring(3, 2);
                    año = datos[3].Substring(6, 4);
                }
            }


        }
        //descomponiendo fecha 
        //10/16/2017
        //3/16/2017
        diaConver = Convert.ToInt32(dia);
        mesConver = Convert.ToInt32(mes);
        añoConver = Convert.ToInt32(año);


        DateTime fecha2 = new DateTime(añoConver, mesConver, diaConver).Date;


        insert.Parameters.AddWithValue("@fechaEntrega", fecha2);
        insert.Parameters.AddWithValue("@metodoEnvio", datos[4]);
        insert.Parameters.AddWithValue("@costo", datos[5]);

        int completar = 0;
        try
        {
            completar = insert.ExecuteNonQuery();
        }
        catch (Exception e)
        {

        }

        return completar;
    }


        //cargar foraneas a envios
        public static void foraneasEnvios(DropDownList folioVenta)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlDataAdapter llenadoCombo = new MySqlDataAdapter("select folioVenta from ventas", conexion1);
        DataSet tablaNombres = new DataSet();
        llenadoCombo.Fill(tablaNombres);
        folioVenta.DataSource = tablaNombres.Tables[0];
        folioVenta.DataValueField = "folioVenta";
        folioVenta.DataTextField = "folioVenta";
        folioVenta.DataBind();
        conexion1.Close();
    }

    //consulta de envios

    public static void consultaEnvios(GridView ConsultaEnvios)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        //GridViewRow tupla
        MySqlCommand consulta = new MySqlCommand("select * from envios", conexion1);
        MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta);
        DataSet envios = new DataSet();
        adaptador.Fill(envios);
        ConsultaEnvios.DataSource = envios.Tables[0];
        ConsultaEnvios.DataBind();
        //MySqlDataReader lector = consulta.ExecuteReader();
        //int i = 0;
        //while (lector.Read())
        //{
        //    vec[i][0] = lector["folioEnvio"].ToString();
        //    vec[i][1] = lector["folioVenta"].ToString();
        //    vec[i][2] = lector["fechaEnvio"].ToString();
        //    vec[i][3] = lector["fechaEntrega"].ToString();
        //    vec[i][4] = lector["metodoEnvio"].ToString();
        //    vec[i][5] = lector["costo"].ToString();
        //    i++;
        //}

        //for(int o = 0; o < vec.Length; o++)
        //{
        //    for(int u = 0; u < vec.Length; u++)
        //    {
        //        MessageBox.Show("" + vec[o][u]);
        //    }
        //}


        conexion1.Close();
       
    }

    //eliminar envio
    public static void eliminarEnvio(String folioEnvio)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlCommand eliminar = new MySqlCommand("delete from envios where folioEnvio="+folioEnvio+"",conexion1);
        int eliminado;
        eliminado = eliminar.ExecuteNonQuery();

        conexion1.Close();
    }

    //modificarEnvio

    public static void modificarEnvio(String folioEnvio,String folioVenta,DateTime fechaEnvio,DateTime fechaEntrega,String metodoEnvio,String costo)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlCommand modificacion = new MySqlCommand("update envios set folioVenta=@folioVenta,fechaEnvio=@fechaEnvio,fechaEntrega=@fechaEntrega,metodoEnvio=@metodoEnvio,costo=@costo where folioEnvio="+folioEnvio+"", conexion1);
        modificacion.Parameters.AddWithValue("@folioVenta", folioVenta);
        modificacion.Parameters.AddWithValue("@fechaEnvio", fechaEnvio);
        modificacion.Parameters.AddWithValue("@fechaEntrega", fechaEntrega);
        modificacion.Parameters.AddWithValue("@metodoEnvio", metodoEnvio);
        modificacion.Parameters.AddWithValue("@costo", costo);

        try
        {
            modificacion.ExecuteNonQuery();
        }catch(Exception e)
        {

        }
        

        conexion1.Close();
        
        
    }

    ////////////////////////////////////////////////////////
    //Metodo pago todas las cosas
    ////////////////////////////////////////////////////////

    public static int RegistroTarjeta(params string[] datos)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
       
        MySqlCommand comando = new MySqlCommand("insert into metodopago values(@nTarjeta,@Empresa,@codigoSeguridad,@fechaVencimiento,@Tipo)", conexion1);
        comando.Parameters.AddWithValue("@nTarjeta", datos[0]);
        comando.Parameters.AddWithValue("@Empresa", datos[1]);
        comando.Parameters.AddWithValue("@codigoSeguridad", datos[2]);
        comando.Parameters.AddWithValue("@fechaVencimiento", datos[3]);
        comando.Parameters.AddWithValue("@Tipo", datos[4]);

        int regT = 0;
        try
        {
            regT = comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {

        }
        conexion1.Close();
        return regT;
    }

    public static string[] ConsultaMPago(GridView conMetodoPago)
    {

        MySqlCommand tabla = new MySqlCommand("select * from metodopago", conexion1);
        MySqlDataAdapter adap = new MySqlDataAdapter(tabla);
        DataSet consulta = new DataSet();
        adap.Fill(consulta);
        conMetodoPago.DataSource = consulta.Tables[0];
        conMetodoPago.DataBind();
        conexion1.Close();
        return null;
    }

    public static int eliminaMetodoPago(String nTarjeta)
    {
        int eliminaM = 0;
        conexion1.Open();

        MySqlCommand comando = new MySqlCommand("delete from metodopago where nTarjeta=" + nTarjeta, conexion1);
        eliminaM = comando.ExecuteNonQuery();

        conexion1.Close();
        return eliminaM;
    }

    public static int modificaMPago(int nTarjeta, String Empresa, String codigoSeguridad, String fechaVencimiento, String Tipo)
    {

        conexion1.Open();
        int res = 0;
        MySqlCommand comando = new MySqlCommand("update metodopago set Empresa=@Empresa, codigoSeguridad=@codigoSeguridad, fechaVencimiento=@fechaVencimiento,Tipo=@Tipo where nTarjeta=@nTarjeta", conexion1);
        comando.Parameters.AddWithValue("@Empresa", Empresa);
        comando.Parameters.AddWithValue("@codigoSeguridad", codigoSeguridad);
        comando.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
        comando.Parameters.AddWithValue("@Tipo", Tipo);
        comando.Parameters.AddWithValue("@nTarjeta", nTarjeta);

        res = comando.ExecuteNonQuery();

        conexion1.Close();
        return res;
    }

    ///////////////////////////////////////////////////////////////////
    //productosssss////

    public static int RegistroProducto(params String[] datos)
    {
        conexion1.Open();
        MySqlCommand comando = new MySqlCommand("insert into productos values(@codBarra,@Modelo,@Marca,@Existencia,@Categoria,@Precio)", conexion1);
        comando.Parameters.AddWithValue("@codBarra", datos[0]);
        comando.Parameters.AddWithValue("@Modelo", datos[1]);
        comando.Parameters.AddWithValue("@Marca", datos[2]);
        comando.Parameters.AddWithValue("@Existencia", datos[3]);
        comando.Parameters.AddWithValue("@Categoria", datos[4]);
        comando.Parameters.AddWithValue("@Precio", datos[5]);

        int reg = 0;
        try
        {
            reg = comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {

        }
        conexion1.Close();
        return reg;
    }
    /// <summary>
    /// METODO PARA CONSULTAR PRODUCTOS
    /// </summary>
    /// 
    public static string[] ConsultaProductos(GridView consultaProducto)
    {
        conexion1.Open();
        MySqlCommand tabla = new MySqlCommand("select * from productos", conexion1);
        MySqlDataAdapter adap = new MySqlDataAdapter(tabla);
        DataSet consulta = new DataSet();
        adap.Fill(consulta);
        consultaProducto.DataSource = consulta.Tables[0];
        consultaProducto.DataBind();
        conexion1.Close();
        return null;
    }

    /// <summary>
    /// Eliminacion del producto
    /// </summary>
    /// 
    public static int eliminaProducto(String codBarra)
    {
        int eliminacion = 0;
        conexion1.Open();

        MySqlCommand comando = new MySqlCommand("delete from productos where codBarra=" + codBarra, conexion1);
        eliminacion = comando.ExecuteNonQuery();

        conexion1.Close();
        return eliminacion;
    }

    public static void registrarCarrito(String codBarra, String descripcion,String marca,String cantidad,String categoriaCar,String pUnitario,string total)
    {
        conexion1.Open();
        MySqlCommand insercion = new MySqlCommand("insert into carrito values(0,@descripcion,@marca,@cantidad,@categoriaCar,@pUnitario,@codBarra,@total)", conexion1);
        insercion.Parameters.AddWithValue("@descripcion", descripcion);
        insercion.Parameters.AddWithValue("@marca", marca);
        insercion.Parameters.AddWithValue("@cantidad", cantidad);
        insercion.Parameters.AddWithValue("@categoriaCar", categoriaCar);
        insercion.Parameters.AddWithValue("@pUnitario", pUnitario);
        insercion.Parameters.AddWithValue("@codBarra", codBarra);
        insercion.Parameters.AddWithValue("@total", total);
        insercion.ExecuteNonQuery();
        conexion1.Close();

    }

    public static void ConsultaCarrito(GridView consultaCarrito)
    {
        conexion1.Open();
        MySqlCommand tabla = new MySqlCommand("select * from carrito", conexion1);
        MySqlDataAdapter adap = new MySqlDataAdapter(tabla);
        DataSet consulta = new DataSet();
        adap.Fill(consulta);
        consultaCarrito.DataSource = consulta.Tables[0];
        consultaCarrito.DataBind();
        conexion1.Close();
       
    }

    public static int totales()
    {
        conexion1.Open();
        int total = 0;

        MySqlCommand suma = new MySqlCommand("select sum(total) as total from carrito",conexion1);
        MySqlDataReader lectorsito = suma.ExecuteReader();
        
            while (lectorsito.Read())
            {
                if (!DBNull.Value.Equals(lectorsito["total"]))
                total = Convert.ToInt32(lectorsito["total"]);
            }

        lectorsito.Close();
        conexion1.Close();
        return total;
    }

    /// <summary>
    /// Modificación del producto
    /// </summary>
    /// 
    public static int modificaProducto(int codBarra, String Modelo, String Marca, int Existencia, String Categoria, float Precio)
    {
        conexion1.Open();
        int res = 0;
        MySqlCommand comando = new MySqlCommand("update productos set Modelo=@modelo,Marca=@marca,Existencia=@existencia,Categoria=@categoria,Precio=@precio where codBarra=@codBarra", conexion1);
        comando.Parameters.AddWithValue("@modelo", Modelo);
        comando.Parameters.AddWithValue("@marca", Marca);
        comando.Parameters.AddWithValue("@existencia", Existencia);
        comando.Parameters.AddWithValue("@categoria", Categoria);
        comando.Parameters.AddWithValue("@precio", Precio);
        comando.Parameters.AddWithValue("@codBarra", codBarra);
        res = comando.ExecuteNonQuery();
        conexion1.Close();
        return res;
    }

    //////////////////
    //Eliminar
    public static int EliminarVentas(String fila)
    {
        int eVentas = 0;

        conexion1.Open();


        MySqlCommand eliminar = new MySqlCommand("delete from Ventas where folioVenta='" + fila + "'", conexion1);
        eVentas = eliminar.ExecuteNonQuery();
        conexion1.Close();


        return eVentas;
    }


    //modificacion de libro

    public static void modificarVentas(int folioVenta, int codBarra, DateTime fechaVenta, int Cantidad, String total)
    {

        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlCommand actualizaVentas = new MySqlCommand("update ventas set codBarra=@codBarra,fechaVenta=@fechaVenta,Cantidad=@Cantidad,total=@Total where folioVenta=" + folioVenta + "", conexion1);
        actualizaVentas.Parameters.AddWithValue("@codBarra", codBarra);
        actualizaVentas.Parameters.AddWithValue("@FechaVenta", fechaVenta);
        actualizaVentas.Parameters.AddWithValue("@Cantidad", Cantidad);
        actualizaVentas.Parameters.AddWithValue("@Total", total);
        actualizaVentas.Parameters.AddWithValue("@folioVenta", folioVenta);

        try
        {
            actualizaVentas.ExecuteNonQuery();
        }
        catch (Exception e)
        {

        }

        conexion1.Close();
    }

    public static string traerNombreProducto(string codBarra)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        string nombre = "";
        MySqlCommand consulta = new MySqlCommand("select Modelo from productos where codBarra='" + codBarra + "'", conexion1);
        MySqlDataReader lector = consulta.ExecuteReader();
        while (lector.Read())
        {
            nombre = lector["Modelo"].ToString();
        }
        lector.Close();
        conexion1.Close();
        return nombre;
    }





    //Consultar
    public static void ConsultarVentas2(GridView ConsultarVentas,int idCliente)
    {


        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        MySqlCommand listar = new MySqlCommand("select * from ventas where idCliente='"+idCliente+"'", conexion1);
        MySqlDataAdapter Adap = new MySqlDataAdapter(listar);
        DataSet Cventas = new DataSet();
        Adap.Fill(Cventas);
        ConsultarVentas.DataSource = Cventas.Tables[0];
        ConsultarVentas.DataBind();

        conexion1.Close();
  
    }


    //Consultar
    public static string[][] ConsultarVentas(GridView ConsultarVentas,int totalFilasss,int idCliente)
    {
        MessageBox.Show(totalFilasss.ToString());
        string[][] mat = new string[totalFilasss][];
        for(int i = 0; i < totalFilasss; i++)
        {
            mat[i] = new string[5];
        }


        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        MySqlCommand listar = new MySqlCommand("select folioVenta,codBarra,fechaVenta,Cantidad,Total from ventas where idCliente='"+idCliente+"'", conexion1);
        MySqlDataReader lector = listar.ExecuteReader();
        int filasM = 0;
        while (lector.Read())
        {
            MessageBox.Show(filasM.ToString());
            mat[filasM][0] = lector["folioVenta"].ToString();
            mat[filasM][1] = lector["codBarra"].ToString();
            mat[filasM][2] = lector["fechaVenta"].ToString();
            mat[filasM][3] = lector["Cantidad"].ToString();
            mat[filasM][4] = lector["Total"].ToString();
            filasM++;
        }
        //MySqlDataAdapter Adap = new MySqlDataAdapter(listar);
        //DataSet Cventas = new DataSet();
        //Adap.Fill(Cventas);
        //ConsultarVentas.DataSource = Cventas.Tables[0];
        //ConsultarVentas.DataBind();
        lector.Close();
        conexion1.Close();
        return mat;
    }



    public static int cuentaFilasVentas(int idCliente)
    {
        int totalPCliente = 0;
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        MySqlCommand listar = new MySqlCommand("select count(idCliente) as totalPCliente from ventas where idCliente='"+idCliente+"'", conexion1);
        MySqlDataReader lector = listar.ExecuteReader();
        while (lector.Read())
        {
            if (!DBNull.Value.Equals(lector["totalPCliente"]))
            {
                totalPCliente = Convert.ToInt32(lector["totalPCliente"]);
            }
                
        }
        //MySqlDataAdapter Adap = new MySqlDataAdapter(listar);
        //DataSet Cventas = new DataSet();
        //Adap.Fill(Cventas);
        //ConsultarVentas.DataSource = Cventas.Tables[0];
        //ConsultarVentas.DataBind();
        lector.Close();
        conexion1.Close();
        return totalPCliente;
    }


    public static void CargarDatosVentas(DropDownList codBarra)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }

        MySqlDataAdapter llenadoCombo = new MySqlDataAdapter("select codBarra from productos", conexion1);
        DataSet tablaNombres = new DataSet();
        llenadoCombo.Fill(tablaNombres);
        codBarra.DataSource = tablaNombres.Tables[0];
        codBarra.DataValueField = "codBarra";
        // codBarra.DataTextField = "nombre";
        codBarra.DataBind();
        conexion1.Close();
    }

    public static string buscarProductoEnCarrito(string descripcion) {
        string encontro = "";
        conexion1.Open();
        MySqlCommand busqueda = new MySqlCommand("select descripcion from carrito where descripcion='" + descripcion + "'", conexion1);
        MySqlDataReader lector = busqueda.ExecuteReader();
        while(lector.Read())
        {
            encontro = lector["descripcion"].ToString();
        }
        lector.Close();
        conexion1.Close();
        return encontro;
    }

    public static int[] cuentaCantidadCarrito(string descripcion)
    {
        conexion1.Open();
        int []total = new int[2];

        MySqlCommand consulta = new MySqlCommand("select cantidad,pUnitario from carrito where descripcion='" + descripcion + "'", conexion1);
        MySqlDataReader lector = consulta.ExecuteReader();
        while (lector.Read())
        {
            total[0] = Convert.ToInt32(lector["cantidad"]);
            total[1] = Convert.ToInt32(lector["pUnitario"]);
        }
        lector.Close();

        conexion1.Close();

        return total;
       
    }

    public static void actualizarCantidadCarrito(string descripcion,int cantidad,int total)
    {

        conexion1.Open();
        MySqlCommand actualizar = new MySqlCommand("update carrito set cantidad=@cantidad, total=@total where descripcion='"+descripcion+"'", conexion1);
        actualizar.Parameters.AddWithValue("cantidad", cantidad);
        actualizar.Parameters.AddWithValue("total", total);
        actualizar.ExecuteNonQuery();
        conexion1.Close();
    }



    static String anio;
    static int anioConver;

    public static int registroVentas(params string[] datos)
    {

        int registrado = 0;
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        MySqlCommand registro = new MySqlCommand("insert into ventas values(0,@codBarra,@fechaVenta,@Cantidad,@Total,@idCliente)", conexion1);
        registro.Parameters.AddWithValue("@codBarra", datos[0]);

        //2/16/2017
        
        if (datos[1].Length == 9)
        {
          
            if (datos[1].Substring(2, 1).ToString().Equals("/"))
            {
                
                mes = datos[1].Substring(0, 2);
                dia = datos[1].Substring(3, 1);
                anio = datos[1].Substring(5, 4);
            }
            else
            {
                
                mes = datos[1].Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
                dia = datos[1].Substring(2, 2);//igual que arriba
                anio = datos[1].Substring(5, 4);
            }
        }
        else
        {
            //1/2/2017
            if (datos[1].Length == 8)
            {
                mes = datos[1].Substring(0, 1);
                dia = datos[1].Substring(2, 1);
                anio = datos[1].Substring(4, 4);
            }
            else
            {
                //10/16/2017
                if (datos[1].Length == 10)
                {
                    mes = datos[1].Substring(0, 2);
                    dia = datos[1].Substring(3, 2);
                    anio = datos[1].Substring(6, 4);
                }
            }


        }
        //descomponiendo fecha 

        // MessageBox.Show(diaConver.ToString());
        
        diaConver = Convert.ToInt32(dia);
        mesConver = Convert.ToInt32(mes);
        anioConver = Convert.ToInt32(anio);
        MessageBox.Show("" + diaConver);
        MessageBox.Show("" + mesConver);
        MessageBox.Show("" + anioConver);



        DateTime fecha45 = new DateTime(anioConver, mesConver, diaConver).Date;
        MessageBox.Show(fecha45.ToShortDateString());
        //String fecha=anio+"-" + mes + "-" + dia;
        ////2017-3-12
        //if (fecha.Length == 9)
        //{
        //    MessageBox.Show("entro aca");
        //    if (fecha.Substring(6, 1).ToString().Equals("-"))
        //    {
        //        MessageBox.Show("entro");
        //        fecha = anio + "-0" + mes + "-" + dia;
               
        //    }
        //    else
        //    {

        //        mes = datos[2].Substring(0, 1);//el substring ingresa en la posicion 0 al comienzo de la cadena y el 2 la cantidad de caracteres a recorrer a la izquierda
        //        dia = datos[2].Substring(2, 2);//igual que arriba
        //        anio = datos[2].Substring(5, 4);
        //    }
        //}
        //else
        //{
        //    //1/2/2017
        //    if (datos[2].Length == 8)
        //    {
        //        mes = datos[2].Substring(0, 1);
        //        dia = datos[2].Substring(2, 1);
        //        anio = datos[2].Substring(4, 4);
        //    }
        //    else
        //    {
        //        //10/16/2017
        //        if (datos[2].Length == 10)
        //        {
        //            mes = datos[2].Substring(0, 2);
        //            dia = datos[2].Substring(3, 2);
        //            anio = datos[2].Substring(6, 4);
        //        }
        //    }


        //}
        //MessageBox.Show(fecha);
        
        registro.Parameters.AddWithValue("@fechaVenta", fecha45);
        registro.Parameters.AddWithValue("@Cantidad", datos[2]);
        registro.Parameters.AddWithValue("@Total", datos[3]);
        registro.Parameters.AddWithValue("@idCliente", datos[4]);
        try
        {

            registrado = registro.ExecuteNonQuery();
           
        }
        catch (Exception e)
        {
            
        }
        conexion1.Close();
        return registrado;

    }

    //////////////////////////////////
    //clienteeeesss///

    public static int RCliente(params String[] datos)
    {
        conexion1.Open();
        MySqlCommand comando = new MySqlCommand("insert into cliente values(@idCliente,@Nombre,@Direccion,@Telefono,@Correo,@Genero,@Password,@nTarjeta)", conexion1);
        comando.Parameters.AddWithValue("@idCliente", datos[0]);
        comando.Parameters.AddWithValue("@Nombre", datos[1]);
        comando.Parameters.AddWithValue("@Direccion", datos[2]);
        comando.Parameters.AddWithValue("@Telefono", datos[3]);
        comando.Parameters.AddWithValue("@Correo", datos[4]);
        comando.Parameters.AddWithValue("@Genero", datos[5]);
        comando.Parameters.AddWithValue("@Password", datos[6]);
        comando.Parameters.AddWithValue("@nTarjeta", datos[7]);

        int reg = 0;
        try
        {
            reg = comando.ExecuteNonQuery();
        }
        catch (Exception e)
        {

        }
        conexion1.Close();
        return reg;
    }

    public static void obDatosMetPago(DropDownList nTarjeta)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        MySqlDataAdapter combonTarjeta = new MySqlDataAdapter("select nTarjeta from metodopago", conexion1);
        DataSet tablaNom = new DataSet();
        combonTarjeta.Fill(tablaNom);
        nTarjeta.DataSource = tablaNom.Tables[0];
        nTarjeta.DataValueField = "nTarjeta";
        nTarjeta.DataBind();
        
        conexion1.Close();
    }

    public static void obDatosVenta(DropDownList folioVenta)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        MySqlDataAdapter combofolioVenta = new MySqlDataAdapter("select folioVenta from ventas", conexion1);
        DataSet tablaN = new DataSet();
        combofolioVenta.Fill(tablaN);
        folioVenta.DataSource = tablaN.Tables[0];
        folioVenta.DataValueField = "folioVenta";
        folioVenta.DataBind();
        conexion1.Close();
    }

    public static string[] ConsultaCliente(GridView conCliente)
    {

        MySqlCommand tabla = new MySqlCommand("select * from cliente", conexion1);
        MySqlDataAdapter adap = new MySqlDataAdapter(tabla);
        DataSet consulta = new DataSet();
        adap.Fill(consulta);
        conCliente.DataSource = consulta.Tables[0];
        conCliente.DataBind();
        conexion1.Close();
        return null;
    }


    public static int eliminaCliente(String idCliente)
    {
        int eliminaC = 0;
        conexion1.Open();

        MySqlCommand comando = new MySqlCommand("delete from cliente where idCliente=" + idCliente, conexion1);
        eliminaC = comando.ExecuteNonQuery();

        conexion1.Close();
        return eliminaC;
    }


    public static int modificarCliente(int idcliente, string Nombre, string Direccion, string Telefono, string Correo, string Genero, string Password, int nTarjeta)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }
        
        int res = 0;
        MySqlCommand comando = new MySqlCommand("update cliente set Nombre=@nombre, Direccion=@direccion, Telefono=@telefono, Correo=@correo, Genero=@genero, Password=@password, nTarjeta=@ntarjeta where idCliente=" + idcliente, conexion1);
        comando.Parameters.AddWithValue("@nombre", Nombre);
        comando.Parameters.AddWithValue("@direccion", Direccion);
        comando.Parameters.AddWithValue("@telefono", Telefono);
        comando.Parameters.AddWithValue("@correo", Correo);
        comando.Parameters.AddWithValue("@genero", Genero);
        comando.Parameters.AddWithValue("@password", Password);
        comando.Parameters.AddWithValue("@ntarjeta", nTarjeta);
        res = comando.ExecuteNonQuery();
        return res;
    }

    public static void actualizate(string nombre,GridView conCliente)
    {
        if (conexion1.State == System.Data.ConnectionState.Closed)
        {
            conexion1.Open();
        }


        MySqlCommand consulta = new MySqlCommand("select * from cliente where Nombre = @nombre", conexion1);
        consulta.Parameters.AddWithValue("@nombre", nombre);
        MySqlDataAdapter adap = new MySqlDataAdapter(consulta);
        DataSet tablita = new DataSet();
        adap.Fill(tablita);
        conCliente.DataSource = tablita.Tables[0];
        conCliente.DataBind();
        conexion1.Close();
        
    }

    public static int eliminaCarrito()
    {
        int eliCarrito = 0;
        conexion1.Open();

        MySqlCommand comando = new MySqlCommand("delete from carrito", conexion1);
        eliCarrito = comando.ExecuteNonQuery();

        conexion1.Close();
        return eliCarrito;
    }

}