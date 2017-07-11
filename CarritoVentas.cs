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


        //public CarritoVentas(List<ClaseCarrito> Lista1)
        //{
        //    InitializeComponent();

        //    Lista = Lista1;

        //}

        Manejador_Base_Datos bd = new Manejador_Base_Datos();


        public CarritoVentas(int Idprod, int Iding, int idven)
        {
            InitializeComponent();

            //this.idven = idven;
            //this.idprod = Idprod;
            //this.iding = Iding;
            //this.nombreprod = Nombreprod;
            //this.tipo = Tipo;
            //this.nombreing = NombreIng;
            //this.total = Total;
        }

        public static int idven;
        public static int idprod;
        public static int iding;

        //string nombreprod;
        //string tipo;
        //string nombreing;

        public static double total = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            //bool cambiaEstructura =true; esto era para modificar el form productos orginal
            ProductosCarrito obj = new ProductosCarrito();
            obj.Show();

        }

        public static bool columnas_creadas;
        public static DataGridView dataGridView1 = new DataGridView();

        public static Label lblTotal = new Label();
        private void CarritoVentas_Load(object sender, EventArgs e)
        {

            lblTotal.Text = total.ToString();
            lblTotal.Visible = true;
            lblTotal.BackColor = Color.Transparent;
            this.Controls.Add(lblTotal);
            this.Controls.Add(dataGridView1);
            lblTotal.Location = new System.Drawing.Point(640, 260);
            dataGridView1.Location = new System.Drawing.Point(20, 20);
            dataGridView1.Size = new System.Drawing.Size(500, 200);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (columnas_creadas == false)
            {


                dataGridView1.Columns.Add("id_venf", "id venta");
                dataGridView1.Columns.Add("nombrepro", "Producto");
                dataGridView1.Columns.Add("idprod", "idprod"); // columna 2
                dataGridView1.Columns.Add("tipo ", "tipo");
                dataGridView1.Columns.Add("id_tipo", "id_tipo"); // columna 4
                dataGridView1.Columns.Add("Ingrediente", "Ingrediente");
                dataGridView1.Columns.Add("iding", "iding"); // columna 6
                dataGridView1.Columns.Add("Precio", "Precio");//columna 7
                columnas_creadas = true;

            }


            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            // dataGridView1.Rows.Add(nombreprod, tipo, nombreing, total);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // public static List<Carritoventass> Listaa = new List<Carritoventass>();

        public static List<int> lista3 = new List<int>() { };

        private void button2_Click(object sender, EventArgs e)
        {


            if (dataGridView1.Rows.Count > 1)
            {


                //Manejador_ventas obj5 = new Manejador_ventas();

                bd.AbrirConexion();


                string insertventa = "insert into ventas values(null, " + total + ", curdate(), curtime())";

                bd.EjecutarComando(insertventa);


                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    string comando = "insert into detallesven (id_venf,id_prodf, id_det_prof, id_ingf, total_detven) values(" + dataGridView1.Rows[i].Cells[0].Value + ",'" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + dataGridView1.Rows[i].Cells[7].Value + "');";



                    bd.EjecutarComando(comando);

                }


                dataGridView1.Rows.Clear();


                //List<Carritoventass> Lista = new List<Carritoventass>();

                //Lista = obj5.Agregarids(idven, idprod, iding);


                //foreach (var i in Lista)
                //{
                //    string comando = "insert into detallesven values(null," + i.Idven + "," + i.Idprod + "," + i.Iding + ");";

                //    bd.EjecutarComando(comando);
                //}


                bd.CerrarConexion();

                lblTotal.Text = "";
                MessageBox.Show("Compra realizada!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tu carrito esta vacio");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu_usuario obj4 = new Menu_usuario();
            obj4.Show();
        }

        private void CarritoVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            total = 0;
            lblTotal.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1)
                {
                    MessageBox.Show("Seleccionaste una fila vacia");
                }
                else
                {
                    total -= Convert.ToDouble(dataGridView1.CurrentRow.Cells[7].Value);
                    lblTotal.Text = total.ToString(); ;
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Tu carrito esta vacio");
            }

        }
    }
}
