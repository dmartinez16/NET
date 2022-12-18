using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeUsuarios.Models
{
    class Cliente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string TarjetaDeCredito { get; set; }

        public string NombreCompleto //Funcion para Listar los datos del cliente en la lista de Clientes
        {
            get { return Nombre + " " + Apellido; }
        }

        public override string ToString() //Funcion para no Mostrar la ubicación del proyecto
        {
            return NombreCompleto;
        }


    }
}
