using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos
{
     class Conexion
    {

        static private string CadenaConexion = "Data Source=.;Initial Catalog=Ventas;Integrated Security=True";

        private SqlConnection ConexionDB = new SqlConnection(CadenaConexion);


        public SqlConnection AbrirConexion()
        {
            if (ConexionDB.State == ConnectionState.Closed)
                ConexionDB.Open();
            return ConexionDB;
            

        }

        public SqlConnection CerrarConexion()
        {
            if (ConexionDB.State == ConnectionState.Open)
                ConexionDB.Close();
            return ConexionDB;

        }

    }
}
