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
    public partial class ListaIngredientes : Form
    {
        public ListaIngredientes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void ListaIngredientes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        Manejador_Ingredientes obj = new Manejador_Ingredientes();
        private void ListaIngredientes_Load_1(object sender, EventArgs e)
        {
            foreach (var item in obj.MostrarIngredientes())
            {
                dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            }
        }


    }
}
