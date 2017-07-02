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

        public Ingredientes( /*Datos Producto */int idprod, string nombreprod, double precio, /* Datos Tipo  */  int idtipo, string tipo)
        {
            InitializeComponent();

            //Datos del Modulo producto
            this.idprod = idprod;
            this.nombreprod = nombreprod;
            this.precioprod = precio;

            //Datos del MOdulo Tipos
            this.idtipos = idtipo;
            this.tipo = tipo;

        }

        //Productos
        int idprod;
        string nombreprod;
        double precioprod;


        //Tipos
        int idtipos;
        string tipo;


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
                MySqlConnection conexion = new MySqlConnection("server = localhost; database =  Caffenio2 ; uid =  root; pwd =   123  ;");

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

        int idIng;
        string nombreing;
        double precioing;

        double total;


        int idventa;
        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select * from ingredientes where id_ing = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.AbrirConexion();

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                idIng = Convert.ToInt32(bd.ResultadoConsulta["id_ing"]);
                nombreing = bd.ResultadoConsulta["nombre_ing"].ToString();
                precioing = Convert.ToDouble(bd.ResultadoConsulta["precio_ing"]);
            }
            bd.CerrarConexion();
            //Suma de el precio del producto con el precio ingrediente
            total = precioprod + precioing;

            MessageBox.Show("Producto: " +nombreprod+ " Precio: "+ precioprod + " Tipo: "+ tipo +" Ingrediente: "+ nombreing +" Precion ing: "+ precioing+ " Total = " + total);



            string comando = "insert into ventas values(null," + idprod + "," + idIng + "," + total + ", curdate(), curtime());";

            bd.AbrirConexion();

            bd.EjecutarComando(comando);

            MessageBox.Show("Compra enviada a la BD");
            bd.CerrarConexion();




            ///Capturar el id de la venta
            bd.AbrirConexion();


            string query2 = "select max(id_ven) from ventas";

            bd.EjecutarConsulta(query2);



            while (bd.ResultadoConsulta.Read())
            {
                idventa = bd.ResultadoConsulta.GetInt32(0);   
            }

            bd.CerrarConexion();


            //Mandar datos a Detalles de venta

            bd.AbrirConexion();

            string comando3 = "insert into detallesven values(null," + idventa + ",'" + nombreprod + "','" + tipo + "','" + nombreing + "');";

            bd.EjecutarComando(comando3);

            bd.CerrarConexion();

            Productos obj = new Productos(total);
            obj.Show();
         
        }
    }
}
