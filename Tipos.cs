﻿using System;
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
    public partial class Tipos : Form
    {
        public Tipos()
        {
            InitializeComponent();
        }


        public Tipos(int id, string nombre, double precio )
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


            foreach (var t in obj.MostrarTipos() )
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

            Ingredientes obj = new Ingredientes(idprod,nombreprod,precioprod, idTipos, tipo);
            obj.Show();

        }
    }
}
