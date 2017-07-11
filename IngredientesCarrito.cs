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
    public partial class IngredientesCarrito : Form
    {
        public IngredientesCarrito()
        {
            InitializeComponent();
        }


        public IngredientesCarrito( /*Datos Producto */int idprod, string nombreprod, double precio, /* Datos Tipo  */  int idtipo, string tipo)
        {
            InitializeComponent();

            //Datos del Modulo producto
            this.idprod = idprod;
            this.nombreprod = nombreprod;
            this.precioprod = precio;

            //Datos del MOdulo Tipos
            this.idtipos = idtipo;
            this.tipo = tipo;

        }

        //Productos
        int idprod;
        string nombreprod;
        double precioprod;


        //Tipos
        int idtipos;
        string tipo;

        Manejador_Base_Datos bd = new Manejador_Base_Datos();

        Manejador_Ingredientes obj = new Manejador_Ingredientes();
        private void IngredientesCarrito_Load(object sender, EventArgs e)
        {
            foreach (var item in obj.MostrarIngredientes())
            {
                dataGridView1.Rows.Add(item.Id, item.Nombre, item.Precio);
            }
        }


        int idIng;
        string nombreing;
        double precioing;

        double total;


        int idventa;
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from ingredientes where id_ing = " + dataGridView1.CurrentRow.Cells[0].Value + ";";

            bd.AbrirConexion();

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                idIng = Convert.ToInt32(bd.ResultadoConsulta["id_ing"]);
                nombreing = bd.ResultadoConsulta["nombre_ing"].ToString();
                precioing = Convert.ToDouble(bd.ResultadoConsulta["precio_ing"]);
            }
            bd.CerrarConexion();



            //Suma de el precio del producto con el precio ingrediente
            total = precioprod + precioing;


            ///Capturar el id de la venta
            bd.AbrirConexion();

            string query2 = "select max(id_ven) from ventas";

            bd.EjecutarConsulta(query2);

            while (bd.ResultadoConsulta.Read())
            {
                idventa = bd.ResultadoConsulta.GetInt32(0);
            }

            bd.CerrarConexion();


            //le doy + 1 por que sera el id que tendr  la proxima venta(la venta que se esta  generando)
            idventa += 1;

            CarritoVentas.total += this.total;


            CarritoVentas.iding = idIng;
            CarritoVentas.idven = idventa;
            CarritoVentas.idprod = idprod;

            CarritoVentas.dataGridView1.Rows.Add(idventa, nombreprod, idprod, tipo, idtipos, nombreing, idIng, total);
            CarritoVentas.lblTotal.Text = CarritoVentas.total.ToString();

            this.Close();
        }
    }
}
