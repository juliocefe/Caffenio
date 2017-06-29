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

        //kjasndkjasndkjansdjk
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
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
    }
}
