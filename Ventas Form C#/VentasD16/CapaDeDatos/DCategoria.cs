using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDeDatos
{
    public class DCategoria
    {
        //Para abrir la conexión
        Conexion conexion= new Conexion();
    
        //Para consultar a la base de datos
        SqlCommand consultar = new SqlCommand();

        

        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _Textobuscar;

        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value;}
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _Textobuscar; }
            set { _Textobuscar = value; }
        }

        //Constructor vacío
        public DCategoria()
        {
        }

        public DCategoria(int idcategoria, string nombre, string descripcion, string textoBuscar)
        {

            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textoBuscar;

        }

        public string Estado = "";

        //Método para insertar categoria

        public string Insertar(DCategoria Categoria)
        {
           
            try
            {
                consultar.Connection = conexion.AbrirConexion();
                consultar.CommandText = "spinsertar_categoria"; //Llamamos al procedimiento creado en el SQLServer
                consultar.CommandType = CommandType.StoredProcedure;

                //Pasamos los parametros

                SqlParameter IDparametro = new SqlParameter();

                IDparametro.ParameterName = "@idcategoria";//Indicamos la variable en la base de datos
                IDparametro.SqlDbType = SqlDbType.Int;//Indicamos el tipo de variable entera
                IDparametro.Direction = ParameterDirection.Output;//La variable es de salida por ser autoincrementable
                consultar.Parameters.Add(IDparametro);//Se envia la clase instanciada para la consulta y que la variable sea llenada desde un formulario

                SqlParameter Nombreparametro = new SqlParameter();

                Nombreparametro.ParameterName = "@nombre";
                Nombreparametro.SqlDbType = SqlDbType.VarChar;
                Nombreparametro.Size = 50;
                Nombreparametro.Value = Categoria.Nombre;
                consultar.Parameters.Add(Nombreparametro);

                SqlParameter Descripcionparametro = new SqlParameter();

                Descripcionparametro.ParameterName = "@descripcion";
                Descripcionparametro.SqlDbType = SqlDbType.VarChar;
                Descripcionparametro.Size = 250;
                Descripcionparametro.Value = Categoria.Descripcion;
                consultar.Parameters.Add(Descripcionparametro);

                Estado = consultar.ExecuteNonQuery() == 1 ? "OK" : "NO se ingreso ningún registro";
                

            }
            catch (Exception ex)
            {
                Estado = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return Estado;
            
        }

        //Método para Editar

        public string Editar(DCategoria Categoria)
        {
            try
            {
                consultar.Connection = conexion.AbrirConexion();
                consultar.CommandText = "speditar_categoria"; //Llamamos al procedimiento creado en el SQLServer
                consultar.CommandType = CommandType.StoredProcedure;

                //Pasamos los parametros

                SqlParameter IDparametro = new SqlParameter();

                IDparametro.ParameterName = "@idcategoria";//Indicamos la variable en la base de datos
                IDparametro.SqlDbType = SqlDbType.Int;//Indicamos el tipo de variable entera
                IDparametro.Value = Categoria.Idcategoria; //Deja de ser un parametro de salida y espera tomar el dato de la clase Categoria con su ID
                consultar.Parameters.Add(IDparametro);//Se envia la clase instanciada para la consulta y que la variable sea llenada desde un formulario

                SqlParameter Nombreparametro = new SqlParameter();

                Nombreparametro.ParameterName = "@nombre";
                Nombreparametro.SqlDbType = SqlDbType.VarChar;
                Nombreparametro.Size = 50;
                Nombreparametro.Value = Categoria.Nombre;
                consultar.Parameters.Add(Nombreparametro);

                SqlParameter Descripcionparametro = new SqlParameter();

                Descripcionparametro.ParameterName = "@descripcion";
                Descripcionparametro.SqlDbType = SqlDbType.VarChar;
                Descripcionparametro.Size = 250;
                Descripcionparametro.Value = Categoria.Descripcion;
                consultar.Parameters.Add(Descripcionparametro);

                Estado = consultar.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizo ningún registro";
                

            }
            catch (Exception ex)
            {
                Estado = ex.Message;
            }
            finally {
                conexion.CerrarConexion();
            }
            return Estado;
        }

        //Método para Eliminar

        public string Eliminar(DCategoria Categoria)
        {
            try
            {
                consultar.Connection = conexion.AbrirConexion();
                consultar.CommandText = "speditar_categoria"; //Llamamos al procedimiento creado en el SQLServer
                consultar.CommandType = CommandType.StoredProcedure;

                //Pasamos los parametros

                SqlParameter IDparametro = new SqlParameter();

                IDparametro.ParameterName = "@idcategoria";//Indicamos la variable en la base de datos
                IDparametro.SqlDbType = SqlDbType.Int;//Indicamos el tipo de variable entera
                IDparametro.Value = Categoria.Idcategoria; //Deja de ser un parametro de salida y espera tomar el dato de la clase Categoria con su ID
                consultar.Parameters.Add(IDparametro);//Se envia la clase instanciada para la consulta y que la variable sea llenada desde un formulario

                Estado = consultar.ExecuteNonQuery() == 1 ? "OK" : "NO se elimino ningún registro";

            }
            catch (Exception ex)
            {
                Estado = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return Estado;
        }


        //Método para Mostrar

        public DataTable Mostrar()
        {
            DataTable TablaResultado = new DataTable("categoria");
            try
            {
                consultar.Connection = conexion.AbrirConexion();
                consultar.CommandText = "spmostrar_categoria"; //Llamamos al procedimiento creado en el SQLServer
                consultar.CommandType = CommandType.StoredProcedure;

                //Pasamos los parametros

                SqlDataAdapter adaptador = new SqlDataAdapter(consultar);
                adaptador.Fill(TablaResultado);

            }
            catch (Exception ex)
            {
                TablaResultado = null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return TablaResultado;
        }

        //Método para buscar nombre
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable TablaResultado = new DataTable("categoria");
            try
            {
                consultar.Connection = conexion.AbrirConexion();
                consultar.CommandText = "spbuscar_categoria"; //Llamamos al procedimiento creado en el SQLServer
                consultar.CommandType = CommandType.StoredProcedure;


                //Creamos parametro para buscar la categoria

                SqlParameter buscar = new SqlParameter();
                buscar.ParameterName = "@textobuscar";
                buscar.SqlDbType = SqlDbType.VarChar;
                buscar.Size = 50;
                buscar.Value = Categoria.TextoBuscar;
                consultar.Parameters.Add(buscar);

                //Pasamos los parametros

                SqlDataAdapter sql = new SqlDataAdapter(consultar);
                sql.Fill(TablaResultado);


            }
            catch (Exception ex)
            {
                TablaResultado = null;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return TablaResultado;
        }


    }
}