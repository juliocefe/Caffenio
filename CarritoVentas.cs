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
    public partial class CarritoVentas : Form
    {
        public CarritoVentas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productos obj = new Productos();
            obj.Show();
            
        }
    }
}
