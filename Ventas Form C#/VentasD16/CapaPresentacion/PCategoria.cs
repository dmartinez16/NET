using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;

namespace CapaPresentacion
{
    public partial class PCategoria : Form
    {
        private bool Nuevo = false;
        private bool Editar = false;
        public PCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la categoria");
        }

        private void PCategoria_Load(object sender, EventArgs e)
        {
            Mostrar();
            Habilitar(false);
            Botones();
        }

        //Mensaje de Confirmación
        private void Confirmacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Software de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Mensaje de Error
        private void Error(string mensaje)
        {
            MessageBox.Show(mensaje, "Software de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar casillas

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        //Habiliar controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtCodigo.ReadOnly = !valor;
        }


        //habilitar botones del formulario
        private void Botones()
        {
            if (this.Nuevo || this.Editar)
            {
                this.Habilitar(true);
                this.btnBuscar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnBuscar.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }


        //Ocultar columnas 
        private void OcultarColumnas()
        {
            this.dataListadoCategorias.Columns[0].Visible = false;
            this.dataListadoCategorias.Columns[1].Visible = false;
        }

        //Mostrar categorias
        private void Mostrar()
        {
            this.dataListadoCategorias.DataSource = Ncategoria.Mostar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoCategorias.Rows.Count);
        }

        //Buscar Categoria por Nombre
        private void BuscarNombre()
        {
            this.dataListadoCategorias.DataSource = Ncategoria.Buscar(txtNombreCategoria.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoCategorias.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tabListado_Click(object sender, EventArgs e)
        {

        }
    }
}
