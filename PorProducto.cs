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
    public partial class PorProducto : Form
    {
        public PorProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Manejador_Base_Datos bd = new Manejador_Base_Datos();


        private void PorProducto_Load(object sender, EventArgs e)
        {
            int id;
            string producto;
            string veces;
            double precio;
            double total;


            string query = "select  t3.id_prodf, t3.nombre_pro, t3.veces, t3.precio_pro, t3.veces*t3.precio_pro as Monto_Generado from (select t2.id_prodf, t1.nombre_pro, count(t2.id_prodf) as veces, t1.precio_pro from (select id_pro, nombre_pro, precio_pro from Productos) as t1 inner join (select id_det_ven, id_venf, id_prodf, total_detven  from DetallesVen) as t2 on t1.id_pro=t2.id_prodf group by id_prodf) as t3 group by t3.id_prodf;";

            bd.AbrirConexion();

            bd.EjecutarConsulta(query);


            while (bd.ResultadoConsulta.Read())
            {
                id = bd.ResultadoConsulta.GetInt32(0);
                producto = bd.ResultadoConsulta.GetString(1);
                veces = bd.ResultadoConsulta.GetString(2);
                precio = bd.ResultadoConsulta.GetDouble(3);
                total = bd.ResultadoConsulta.GetDouble(4);


                dataGridView1.Rows.Add(id, producto, veces, precio, total);
            }

            bd.CerrarConexion();


        }
    }
}
