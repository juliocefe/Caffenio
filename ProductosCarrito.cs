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
    public partial class ProductosCarrito : Form
    {
        public ProductosCarrito()
        {
            InitializeComponent();
        }

        public ProductosCarrito(bool cambioEstructura)
        {
            InitializeComponent();
            this.cambioEstructura = cambioEstructura;
        }

        bool cambioEstructura = false;


        public ProductosCarrito(double total)
        {
            InitializeComponent();

            this.total = total;
        }

        double total;


        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        Manejador_Productos man = new Manejador_Productos();
        private void ProductosCarrito_Load(object sender, EventArgs e)
        {
            foreach (var i in man.Mostrar_Productos())
            {
                dataGridView1.Rows.Add(i.Id, i.Nombre, i.Precio);
            }
        }


        int id;
        string nombre;
        double precio;
        private void button1_Click(object sender, EventArgs e)
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


            TiposCarrito obj = new TiposCarrito(id, nombre, precio);
            obj.Show();

            bd.CerrarConexion();

            this.Close();
        }
    }
}
