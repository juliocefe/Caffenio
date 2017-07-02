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

           



            foreach (var i in obj2.MostrarDetalles())
            {
                dataGridView1.Rows.Add(i.Id, i.Nombre, i.Tipo, i.Descripcion, i.Ingrediente, i.Cantidad, i.Total, i.Fecha, i.Hora);
            }

           


        }
    }
}
