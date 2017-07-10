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
    public partial class ListaProductos : Form
    {
        public ListaProductos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Manejador_Productos man = new Manejador_Productos();

        private void ListaProductos_Load(object sender, EventArgs e)
        {

            foreach (var i in man.Mostrar_Productos())
            {
                dataGridView1.Rows.Add(i.Id, i.Nombre, i.Precio);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //form productos; 346, 398 pasara a : 702, 398
            //boton salir; 242, 324 pasara a: 599, 324
            
            dataGridView2.Rows.Clear();
            this.Size = new System.Drawing.Size(702, 398);
            button2.Location = new System.Drawing.Point(599, 324);

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            foreach (var i in man.MostrarListaPorId(id))
            {
                dataGridView2.Rows.Add(i.Id, i.Tipo, i.Descripcion);
            }
              
        }
    }
}
