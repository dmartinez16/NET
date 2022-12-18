namespace NumerosPrimos
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnCalcularPrimos_Click(object sender, EventArgs e)
        {
            //Al presionar el boton nos envia a la ventana gestionar usuarios

            GestionUsuarios ventanaGUsuarios = new GestionUsuarios();
            ventanaGUsuarios.ShowDialog();  


          /* Calcular 100 numeros primos  string resultado = "";
            int numero = 2 , contador = 0;

            while (contador < 100)
            {
                if(esPrimo(numero))
                {
                    resultado = resultado + "," + numero;
                    contador++;
                }
                numero++;
            }

            MessageBox.Show(resultado);
            */
           
        }

      /*  private bool esPrimo(int numero)
        {
            bool primo = true;
            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    primo = false;

                }

            }

            return primo;

        }*/
    }
}