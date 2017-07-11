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
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }


        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        Manejador_ventas obj = new Manejador_ventas();
        private void Ventas_Load(object sender, EventArgs e)
        {
            bd.AbrirConexion();



            foreach (var item in obj.Mostrar_Ventas())
            {
                dataGridView1.Rows.Add(item.Id, item.Total, item.Fecha, item.Hora);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "select t6.id_det_ven, t6.nombre_pro, t6.tipo_pro, t6.Descri_pro, t5.nombre_ing,  t6.total_detven from (select id_ing, nombre_ing, precio_ing from ingredientes) as t5 inner join (select  t3.nombre_pro,  t3.id_det_pro, t3.tipo_pro, t3.Descri_pro, t4.id_det_ven, t4.id_venf, t4.id_prodf, t4.id_ingf, t4.total_detven, t4.total, t4.fecha, t4.hora from (select t1.id_pro, t1.nombre_pro, t1.precio_pro, t2.id_det_pro, t2.id_prodff, t2.tipo_pro, t2.Descri_pro from (select id_pro, nombre_pro, precio_pro from Productos) as t1 inner join (select id_det_pro, id_prodff, tipo_pro, Descri_pro from DetallesPro ) as t2 on t1.id_pro=t2.id_prodff ) as t3 inner join (select t1.id_det_ven, t1.id_venf, t2.id_ven, t1.id_prodf, t1.id_ingf, t1.total_detven, t2.total, t2.fecha, t2.hora from (select id_det_ven, id_venf, id_prodf, id_ingf, total_detven  from DetallesVen ) as t1 inner join ( select id_ven, total, fecha, hora from ventas ) as t2 on t1.id_venf = t2.id_ven ) as t4 on t3.id_pro=t4.id_prodf ) as t6 on t5.id_ing=t6.id_ingf where t6.id_venf = " + dataGridView1.CurrentRow.Cells[0].Value + " group by t6.id_det_ven;";

            Detalles_Venta obj = new Detalles_Venta(query);
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
