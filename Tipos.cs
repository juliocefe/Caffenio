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
    public partial class Tipos : Form
    {
        public Tipos()
        {
            InitializeComponent();
        }


        Manejador_Productos obj = new Manejador_Productos();
        private void Tipos_Load(object sender, EventArgs e)
        {


            foreach (var t in obj.MostrarTipos() )
            {
                dataGridView1.Rows.Add(t.Id, t.Fk, t.Tipo, t.Descripcion);
            }

        }
    }
}
