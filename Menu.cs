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
    public partial class Menu : Form
    {

///sadasdsss
        public Menu()
        {
            InitializeComponent();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            Productos obj = new Productos();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ingredientes obj = new Ingredientes();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ventas obj = new Ventas();
            obj.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            CarritoVentas obj = new CarritoVentas();
            obj.ShowDialog();



            this.Show();



        }
    }
}
