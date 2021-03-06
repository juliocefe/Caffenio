﻿using System;
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
    public partial class Tipos : Form
    {
        public Tipos()
        {
            InitializeComponent();
        }


        public Tipos(int id)
        {
            InitializeComponent();
            this.idprod = id;
        }

        public Tipos(int id, string nombre, double precio)
        {
            InitializeComponent();

            idprod = id;
            nombreprod = nombre;
            precioprod = precio;

        }


        int idprod;

        string nombreprod;

        double precioprod;

        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        Manejador_Productos obj = new Manejador_Productos();
        private void Tipos_Load(object sender, EventArgs e)
        {

            foreach (var t in obj.MostrarPorId(idprod))
            {
                dataGridView1.Rows.Add(t.Id, t.Fk, t.Tipo, t.Descripcion);
            }

        }

        int idTipos;
        string tipo;



        private void button5_Click(object sender, EventArgs e)
        {

            string query = "select * from detallespro where id_det_pro =" + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.AbrirConexion();

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                idTipos = Convert.ToInt32(bd.ResultadoConsulta["id_det_pro"]);
                tipo = bd.ResultadoConsulta["tipo_pro"].ToString();
            }

            bd.CerrarConexion();

            Ingredientes obj = new Ingredientes(idprod, nombreprod, precioprod, idTipos, tipo);
            obj.Show();

            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcional, pero faltan validaciones");
            //try
            //{
            //    MySqlConnection conexion = new MySqlConnection("server = localhost; database = caffenio2; uid = root; pwd = 123");
            //    conexion.Open();

            //    MySqlCommand comando = new MySqlCommand("insert into detallespro values(null," + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "')", conexion);

            //    comando.ExecuteNonQuery();



            //    conexion.Close();
            //    MessageBox.Show("Datos enviados a la BD");
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("El producto seleccionado no se encuentra en la Base de Datos");
            //}

            //foreach (var t in obj.MostrarTipos())
            //{
            //    dataGridView1.Rows.Add(t.Id, t.Fk, t.Tipo, t.Descripcion);
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //string query = "select * from detallespro where id_det_pro =" + dataGridView1.CurrentRow.Cells[0].Value + ";";

            //bd.AbrirConexion();

            //bd.EjecutarConsulta(query);

            //while (bd.ResultadoConsulta.Read())
            //{
            //    idTipos = Convert.ToInt32(bd.ResultadoConsulta["id_det_pro"]);
            //    tipo = bd.ResultadoConsulta["tipo_pro"].ToString();
            //}

            //bd.CerrarConexion();

            //Ingredientes obj = new Ingredientes(idprod, nombreprod, precioprod, idTipos, tipo);
            //obj.Show();

            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            //{
            //    if (textBox1.Text != dataGridView1.CurrentRow.Cells[1].Value.ToString() || textBox2.Text != dataGridView1.CurrentRow.Cells[2].Value.ToString() || textBox3.Text != dataGridView1.CurrentRow.Cells[3].Value.ToString())
            //    {


            //        bd.AbrirConexion();

            //        string command = "update detallespro set Tipo_pro = '" + textBox2.Text + "', Descri_pro = '" + textBox3.Text + "' where id_pro =" + textBox1.Text + ";";

            //        bd.EjecutarComando(command);

            //        bd.CerrarConexion();

            //        dataGridView1.Rows.Clear();

            //        foreach (var item in obj.MostrarTipos())
            //        {
            //            dataGridView1.Rows.Add(item.Id, item.Fk, item.Tipo, item.Descripcion);
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("Los datos son los mismos cavezon");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Estas dejando espacios vacios cavezon");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
