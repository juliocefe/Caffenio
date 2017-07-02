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

namespace Caffenio
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        Manejador_Productos obj = new Manejador_Productos();
        private void Form1_Load(object sender, EventArgs e)
        {
            obj.Mostrar_Productos();


            foreach (var item in obj.Mostrar_Productos())
            {
                    dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                MySqlConnection conexion = new MySqlConnection("server = localhost; database = Caffenio; uid = root; pwd = 123;");


                MySqlCommand Insertar = new MySqlCommand("insert into productos (nombre_pro, precio_pro)values('" + textBox1.Text + "'," + textBox2.Text + ");", conexion);
                conexion.Open();

                Insertar.ExecuteNonQuery();

                conexion.Close();

                dataGridView1.Rows.Clear();

                foreach (var item in obj.Mostrar_Productos())
                {
                    dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
                }

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("El producto ya se encuentra en la base de datos");
                textBox1.Text = string.Empty;
              
            }
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bd.AbrirConexion();

            string command = "update productos set nombre_pro = '" + textBox1.Text + "', precio_pro = " + textBox2.Text + " where id_pro =" + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.EjecutarComando(command);

            bd.CerrarConexion();

            dataGridView1.Rows.Clear();

            foreach (var item in obj.Mostrar_Productos())
            {
                dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                bd.AbrirConexion();

                string command = "delete from productos where id_pro = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

                bd.EjecutarComando(command);

                bd.CerrarConexion();

                dataGridView1.Rows.Clear();

                foreach (var item in obj.Mostrar_Productos())
                {
                    dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Necesitas borrar tu referencias(foreing keys) en otras tablas para poder borrar este poducto");
           
            }
           

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        string nombre;
        double precio;
        private void button5_Click(object sender, EventArgs e)
        {
           

            bd.AbrirConexion();

            string query = "select * from productos where id_pro = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                nombre = bd.ResultadoConsulta["nombre_pro"].ToString();
                precio = Convert.ToDouble(bd.ResultadoConsulta["precio_pro"]);
            }
            

            Ingredientes obj = new Ingredientes(nombre, precio);
            obj.Show();



        }
    }
}
