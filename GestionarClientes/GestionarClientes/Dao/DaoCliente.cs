using GestionDeUsuarios.Models;
using MySql.Data.MySqlClient;
using NumerosPrimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeUsuarios.Dao
{
    class DaoCliente
    {

        public MySqlConnection Conexion() {


            //Cadena de conexión
            string conexion = "server=localhost;port=3307;uid=root;pwd='';database=clientes;";


            MySqlConnection conexionDB = new MySqlConnection(conexion);
            conexionDB.Open();
            return conexionDB;

        }

        public List<Cliente> ObtenerClientes()
        {
            //Instancio una lista clientes para almacenar los datos de la base de datos
            List<Cliente> lista = new List<Cliente>();


            //Realizo la consulta y llamo al metodo Conexión para conectar con la base de datos
            string consulta = "SELECT * FROM clientes";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conexion();
            MySqlDataReader lectura = comando.ExecuteReader();

            //Mientras lectura lea los registros , registre las 4 columnas de la tabla cliente
            while (lectura.Read())
            {
                //Llenando las variables con ayuda de la base de datos
                Cliente cliente = new Cliente();
                cliente.Id = lectura.GetString("id");
                cliente.Nombre = lectura.GetString("nombre");
                cliente.Apellido = lectura.GetString("apellido");
                cliente.Telefono = lectura.GetString("telefono");
                cliente.TarjetaDeCredito = lectura.GetString("tarjeta_credito");

                //agregamos los datos a la lista 
                lista.Add(cliente);

            }
            //Retornamos los datos tipo cliente y cerramos la conexión a la base de datos  
            comando.Connection.Close();
            return lista;
        }

        public void Guardar(Cliente cliente)
        {

            if (cliente.Id == null)
            {
                Agregar(cliente);
                
            }
            else
            {
                Modificar(cliente);
            }
        }


        private void Agregar(Cliente cliente)
        {

            string consulta = "INSERT INTO clientes VALUES (NULL, '"
                + cliente.Nombre + "', '" + cliente.Apellido + "', '" + cliente.Telefono + "', '" + cliente.TarjetaDeCredito + "');";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conexion();
            comando.ExecuteNonQuery();

            comando.Connection.Close();
        }

        private void Modificar(Cliente cliente)
        {

            string consulta = "UPDATE `clientes` SET `nombre` = '" + cliente.Nombre + "', `apellido` = '" + cliente.Apellido + "', `telefono` = '"
                + cliente.Telefono + "', `tarjeta_credito` = '" + cliente.TarjetaDeCredito
                + "' WHERE `clientes`.`id` = " + cliente.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conexion();
            comando.ExecuteNonQuery();

            comando.Connection.Close();
        }


        public void Eliminar(Cliente cliente)
        {
            string consulta = "DELETE FROM clientes WHERE clientes.id = " + cliente.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conexion();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }
    }
}
