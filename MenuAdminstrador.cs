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
    public partial class MenuAdminstrador : Form
    {
        public MenuAdminstrador()
        {
            InitializeComponent();
        }

        Manejador_Productos man = new Manejador_Productos();
        private void porProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PorProducto obj = new PorProducto();
            obj.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productos obj = new Productos();
            obj.Show();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingredientes obj = new Ingredientes();
            obj.Show();
        }


        private void carritoToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listaDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas obj = new Ventas();
            obj.Show();
        }



        private void listaDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListaProductos obj = new ListaProductos();
            obj.Show();
        }

        private void MenuAdminstrador_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.White;
        }

        private void porPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PorPeriodo obj = new PorPeriodo();
            obj.Show();
        }

        private void MenuAdminstrador_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listaDeIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaIngredientes obj = new ListaIngredientes();
            obj.Show();
        }

    }
}
