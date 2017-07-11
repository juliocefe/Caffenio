using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffenio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();

        }


        int nivel;
        int id;
        bool dejaloentrar = false;
        //string pista;

        Manejador_Base_Datos BD = new Manejador_Base_Datos();
        int intentos = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = "select  nivel, id_use from usuarios where cuenta = '" + textBox1.Text + "' and clave = MD5('" + textBox2.Text + "')";

            BD.AbrirConexion();
            BD.EjecutarConsulta(consulta);

            if (BD.ResultadoConsulta.Read() == true)//Si el usuario y contraseña son correctos correr el siguiente bloque de codigo
            {

                nivel = BD.ResultadoConsulta.GetInt32(0);

                id = BD.ResultadoConsulta.GetInt32(1);


                BD.CerrarConexion();


                MenuAdminstrador obj = new MenuAdminstrador();
                obj.Show();

                dejaloentrar = true;

                this.Close();

            }
            else
            {

                intentos += 1;
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();

                MessageBox.Show("Constraseña o usuario incorrectos");
                if (intentos == 3)
                {
                    dejaloentrar = false;
                    MessageBox.Show("Has exedido el limite de intentos el sistema va a cerrarse");
                    this.Close();

                }

            }

            BD.CerrarConexion();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dejaloentrar == false)
	        {
		         Application.Exit();
	        }
           
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
