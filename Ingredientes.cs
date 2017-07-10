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

            textBox1.Text = "";
            textBox2.Text = string.Empty;
       }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           ;
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

            if (textBox1.Text != "" && textBox2.Text != "")
            {

                try
                {
                    MySqlConnection conexion = new MySqlConnection("server = localhost; database =  Caffenio3 ; uid =  root; pwd =   123  ;");

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
            else
            {
                MessageBox.Show("No puedes dejar espacios vacios");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != dataGridView1.CurrentRow.Cells[1].Value.ToString() || textBox2.Text != dataGridView1.CurrentRow.Cells[2].Value.ToString())
            {
                bd.AbrirConexion();

                string command = "update ingredientes set nombre_ing = '" + textBox1.Text + "', precio_ing = " + textBox2.Text + " where id_ing = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

                bd.EjecutarComando(command);

                dataGridView1.Rows.Clear();

                foreach (var item in obj.MostrarIngredientes())
                {
                    dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
                }

                bd.CerrarConexion();
            }
            else
            {
                MessageBox.Show("No hay cambio alguno en los datos que intentas modificar");
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

       
            ///Capturar el id de la venta
            bd.AbrirConexion();

            string query2 = "select max(id_ven) from ventas";

             bd.EjecutarConsulta(query2);

             while (bd.ResultadoConsulta.Read())
             {
                 idventa = bd.ResultadoConsulta.GetInt32(0);
             }

            bd.CerrarConexion();


            idventa += 1;
           
            //obj2.Show();

            Carritoventass obj8 = new Carritoventass();

            //int[,] array = new int[2,2];

            //array[0, 0] = idventa;
            //array[0, 1] = idprod;
            //array[0, 2] = idIng;
            
            obj8.Idven = idventa;
            obj8.Idprod = idprod;
            obj8.Iding = idIng;

            CarritoVentas.total += this.total;


            List<Carritoventass> listac = new List<Carritoventass>();

            Manejador_ventas obj3 = new Manejador_ventas();


            CarritoVentas.iding = idIng;
            CarritoVentas.idven = idventa;
            CarritoVentas.idprod = idprod;

            CarritoVentas.dataGridView1.Rows.Add(idventa ,nombreprod ,idprod, tipo, idtipos, nombreing, idIng, total);
            CarritoVentas.lblTotal.Text = CarritoVentas.total.ToString();

            CarritoVentas obj7 = new CarritoVentas(idventa, idprod, idIng);     
            this.Close();
         
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
             textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
             textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
