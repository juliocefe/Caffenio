using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Caffenio
{
    public partial class Ingredientes : Form
    {
        public Ingredientes()
        {
            InitializeComponent();
        }

        public Ingredientes(string nombre, double precio)
        {
            InitializeComponent();

            this.nombre2 = nombre;

            this.precio2 = precio;
        }


        string nombre2;
        double precio2;


        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        Manejador_Ingredientes obj = new Manejador_Ingredientes();
        private void Ingredientes_Load(object sender, EventArgs e)
        {


            foreach (var item in obj.MostrarIngredientes())
            {
                dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            }

           
       }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      

      

        private void button2_Click(object sender, EventArgs e)
        {
            bd.AbrirConexion();

            string command = "delete from ingredientes where  id_ing =" + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.EjecutarComando(command);

            bd.CerrarConexion();


            dataGridView1.Rows.Clear();

            foreach (var item in obj.MostrarIngredientes())
            {
                dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            }
          

               //{
               // DialogResult Result;
               // Result = MessageBox.Show("Borrar este registro", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
               // if (Result == DialogResult.Yes)
               // {
               //     clsManejadorProducto delete = new clsManejadorProducto();
               //     delete.eliminarproducto(Convert.ToInt32(dtgTablaProductos.CurrentRow.Cells[0].Value));
               //     LlenarDatosProductosYEmpleados();
               //     MessageBox.Show("Producto Eliminado");


               // }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection("server = localhost; database =  Caffenio ; uid =  root; pwd =   123  ;");

                MySqlCommand comando = new MySqlCommand("insert into ingredientes (nombre_ing, precio_ing)values('" + textBox1.Text + "'," + textBox2.Text + ");", conexion);
                conexion.Open();

                comando.ExecuteNonQuery();

                conexion.Close();

                dataGridView1.Rows.Clear();

                obj.MostrarIngredientes();

                foreach (var item in obj.MostrarIngredientes())
                {
                    dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
                }
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;

            }
            catch (Exception)
            {

                MessageBox.Show("Este producto ya se encuentra en la base de datos");
                textBox1.Text = string.Empty;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bd.AbrirConexion();

            string command = "update ingredientes set nombre_ing = '" + textBox1.Text + "', precio_ing = " + textBox2.Text + " where id_ing = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.EjecutarComando(command);

            bd.CerrarConexion();

            dataGridView1.Rows.Clear();


            foreach (var item in obj.MostrarIngredientes())
	         {
                 dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
	         }
             
        }

        private void button5_Click(object sender, EventArgs e)
        {



            Tipos obj = new Tipos();
            obj.Show();
        }
    }
}
