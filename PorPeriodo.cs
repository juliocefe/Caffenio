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
    public partial class PorPeriodo : Form
    {
        public PorPeriodo()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }

        private void PorPeriodo_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

        }

        Manejador_Base_Datos bd = new Manejador_Base_Datos();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            MySqlConnection conexion = new MySqlConnection("Server = localhost; database = Caffenio3; Uid = root; pwd= 123;");           
            conexion.Open();
            MySqlCommand query = new MySqlCommand("select id_ven, total, fecha, hora from ventas where fecha between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "';", conexion);

            MySqlDataReader Reader = query.ExecuteReader();

            while (Reader.Read())
            {
                dataGridView1.Rows.Add(Reader.GetInt32(0), Reader.GetDouble(1), Reader.GetString(2), Reader.GetString(3));
            }
            conexion.Close();

            //string query = "select id_ven, total, fecha, hora from ventas where fecha between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "';";
            //bd.AbrirConexion();
            //bd.EjecutarConsulta(query);
            //while (bd.ResultadoConsulta.Read())
            //{
            //dataGridView1.Rows.Add(bd.ResultadoConsulta.GetInt32(0), bd.ResultadoConsulta.GetDouble(1), bd.ResultadoConsulta.GetString(2), bd.ResultadoConsulta.GetString(3));
            //}
            //bd.CerrarConexion();
        }
    }
}
