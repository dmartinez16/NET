using GestionDeUsuarios.Dao;
using GestionDeUsuarios.Models;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NumerosPrimos
{
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }

        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            listaRenderizada();
        }

        private void listaRenderizada()
        {

            //Obtenemos la función de la clase DaoCliente para obtener los resultados
            DaoCliente baseDeDatos = new DaoCliente();
            List<Cliente> listaDB =  baseDeDatos.ObtenerClientes();

            listCliente.Items.Clear();

            //Recorremos todos los indices para listar todos los clientes
            for(int i=0; i< listaDB.Count; i++)
            {
                Cliente cliente = listaDB[i];
                listCliente.Items.Add(cliente);

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Verificamos si alguna casilla esta vacía 

            if (string.IsNullOrEmpty(txtNomCliente.Text) && string.IsNullOrEmpty(txtApellido.Text) && string.IsNullOrEmpty(txtTelefono.Text) && string.IsNullOrEmpty(txtTarjetaCredito.Text))
            {
                MessageBox.Show("NINGUNA CASILLA PUEDE ESTAR VACIA");
            }
            else
            {
                Cliente cliente = new Cliente();
                if (lblId.Text != "")
                {
                    cliente.Id = lblId.Text;
                }

                //Almacenamos al cliente en la clase Cliente.cs 
                
                cliente.Nombre = txtNomCliente.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.TarjetaDeCredito = txtTarjetaCredito.Text;

                //Agregamos el cliente a la lista
                DaoCliente daoCliente = new DaoCliente();
                daoCliente.Guardar(cliente);

                //Actualizamos la lista
                listaRenderizada();

                //Limpiamos las casillas con la funcion LimpiarCasillas
                LimpiarCasillas();
            }


        }

        public void LimpiarCasillas()
        {
            txtNomCliente.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtTarjetaCredito.Clear();
            lblId.Text="";
        }

        //Funcion para el evento Eliminar Cliente de la lista Clientes 
        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {//---------------------------------------------------------------
            //Seleccionamos al cliente que deseamos eliminar
            int seleccion = listCliente.SelectedIndex;
            
            //Mostramos un mensaje de confirmación para eliminar al cliente
            DialogResult respuesta = MessageBox.Show("¿Desea eliminar a este cliente?", "ADVERTENCIA", MessageBoxButtons.YesNo);

            //Utilizamos una condición para confirmar la eliminación del cliente seleccionado, si marca SI se mostrara el siguiente mensaje
            if (respuesta == DialogResult.Yes)
            {
                Cliente cliente = (Cliente)listCliente.SelectedItem; // Creamos una variable de tipo cliente para capturar lo que se encuentra en la lista

                DaoCliente daoCliente = new DaoCliente();
                daoCliente.Eliminar(cliente);
                listaRenderizada();

                listCliente.Items.Remove(seleccion);
                MessageBox.Show("Cliente eliminado");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void listCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
    

                Cliente cliente = (Cliente)listCliente.SelectedItem;

                txtNomCliente.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtTelefono.Text = cliente.Telefono;
                txtTarjetaCredito.Text = cliente.TarjetaDeCredito;
                lblId.Text = cliente.Id;
                
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarCasillas();
        }
    }
}
