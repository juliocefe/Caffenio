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
                dataGridView1.Rows.Add(item.Id, item.Total, item.Fecha , item.Hora);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Detalles_Venta obj = new Detalles_Venta();
            obj.Show();
        }
    }
}
