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
    public partial class Detalles_Venta : Form
    {
        public Detalles_Venta()
        {
            InitializeComponent();
        }

        Manejador_Base_Datos bd = new Manejador_Base_Datos();

        Manejador_ventas obj = new Manejador_ventas();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Manejadora_detallesVentas obj2 = new Manejadora_detallesVentas();
        private void Ventas_Load(object sender, EventArgs e)
        {
            bd.AbrirConexion();

            //string superquery = "select t6.id_venf, t6.nombre_pro, t6.tipo_pro, t6.Descri_pro, t6.cant_ing , t6.total, t6.fecha, t6.hora from (select id_ing, nombre_ing, precio_ing from ingredientes) as t5 inner join ( select  t3.nombre_pro,   t3.tipo_pro, t3.Descri_pro, t4.id_venf,   t4.cant_ing , t4.id_ven,  t4.id_ingf, t4.total, t4.fecha, t4.hora from ( select t1.id_pro, t1.nombre_pro, t1.precio_pro, t2.id_det_pro, t2.id_prodff, t2.tipo_pro, t2.Descri_pro from ( select id_pro, nombre_pro, precio_pro from Productos ) as t1 inner join ( select id_det_pro, id_prodff, tipo_pro, Descri_pro from DetallesPro ) as t2 on t1.id_pro=t2.id_prodff ) as t3 inner join ( select t1.id_det_ven, t1.id_venf, t1.cant_ing , t2.id_ven, t2.id_prodf, t2.id_ingf, t2.total, t2.fecha, t2.hora from ( select id_det_ven, id_venf, cant_ing from DetallesVen ) as t1 inner join ( select id_ven, id_prodf, id_ingf, total, fecha, hora from ventas ) as t2 on t1.id_venf = t2.id_ven ) as t4 on t3.id_pro=t4.id_prodf ) as t6 on t5.id_ing=t6.id_ingf group by t6.id_venf;";



            foreach (var i in obj2.MostrarDetalles())
            {
                dataGridView1.Rows.Add(i.Id, i.Nombre, i.Tipo, i.Descripcion, i.Ingrediente, i.Cantidad, i.Total, i.Fecha, i.Hora);
            }

           


        }
    }
}
