using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;


namespace CapaDeNegocios
{
    public class Ncategoria
    {

        //Llamar a metodo insertar categoria
        public static string Insertar(string nombre , string descripcion)
        {
            DCategoria Dcategoria = new DCategoria();

            Dcategoria.Nombre = nombre;
            Dcategoria.Descripcion = descripcion;
            return Dcategoria.Insertar(Dcategoria);
        }

        //Llamar a metodo editar categoria
        public static string Editar(int idcategoria,string nombre, string descripcion)
        {
            DCategoria Dcategoria = new DCategoria();

            Dcategoria.Idcategoria = idcategoria;
            Dcategoria.Nombre = nombre;
            Dcategoria.Descripcion = descripcion;
            return Dcategoria.Editar(Dcategoria);
        }

        //Llamar a metodo eliminar categoria
        public static string Eliminar(int idcategoria)
        {
            DCategoria Dcategoria = new DCategoria();

            Dcategoria.Idcategoria = idcategoria;
            return Dcategoria.Eliminar(Dcategoria);
        }

        //Llamar a metodo mostrar categoria

        public static DataTable Mostar()
        {
            DCategoria Dcategoria = new DCategoria();
            return Dcategoria.Mostrar();
        }

        //Llamar metodo buscar categoria

        public static DataTable Buscar(string textoBuscar)
        {
            DCategoria Dcategoria = new DCategoria();
            Dcategoria.TextoBuscar = textoBuscar;
            return Dcategoria.BuscarNombre(Dcategoria);
        }
    }
}
