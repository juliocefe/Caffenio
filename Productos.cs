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

        public Productos(bool cambioEstructura)
        {
            InitializeComponent();
            this.cambioEstructura = cambioEstructura;
        }

        bool cambioEstructura = false;


        public Productos(double total)
        {
            InitializeComponent();

            this.total = total;
        }

        double total;

      
        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        Manejador_Productos obj = new Manejador_Productos();
        private void Form1_Load(object sender, EventArgs e)
        {
         
            if (cambioEstructura == true)
            {
                dataGridView1.Size = new Size(303, 300);
                this.Size = new Size(343, 390);
                button5.Location = new System.Drawing.Point(121, 320);
                button5.Size = new Size(75, 23);

                textBox1.Visible = false;
                textBox2.Visible = false;

                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            
                button6.Visible = false;

            }

            obj.Mostrar_Productos();


            foreach (var item in obj.Mostrar_Productos())
            {
                    dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            }

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {


                try
                {
                    MySqlConnection conexion = new MySqlConnection("server = localhost; database = Caffenio2; uid = root; pwd = 123;");


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
            else
            {
                MessageBox.Show("No puedes dejar espacios vacios");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != dataGridView1.CurrentRow.Cells[1].Value.ToString() || textBox2.Text != dataGridView1.CurrentRow.Cells[2].Value.ToString())
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
            else
            {
                MessageBox.Show("Los datos son los mismos cavezon");
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

        int id;
        string nombre;
        double precio;
        private void button5_Click(object sender, EventArgs e)
        {
           

            bd.AbrirConexion();

            string query = "select * from productos where id_pro = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                id = Convert.ToInt32(bd.ResultadoConsulta["id_pro"]);
                nombre = bd.ResultadoConsulta["nombre_pro"].ToString();
                precio = Convert.ToDouble(bd.ResultadoConsulta["precio_pro"]);
            }
            

            Tipos obj = new Tipos(id,nombre, precio);
            obj.Show();

            bd.CerrarConexion();

            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            bd.AbrirConexion();

            string query = "select * from productos where id_pro = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                id = Convert.ToInt32(bd.ResultadoConsulta["id_pro"]);
                nombre = bd.ResultadoConsulta["nombre_pro"].ToString();
                precio = Convert.ToDouble(bd.ResultadoConsulta["precio_pro"]);
            }
            
            
            Tipos obj = new Tipos(id, nombre, precio);
            obj.Show();

            bd.CerrarConexion();

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

        private void textBox2_TextChanged(object sender, EventArgs e)
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
