using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class clsDetallesVenta
    {

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        string ingrediente;

        public string Ingrediente
        {
            get { return ingrediente; }
            set { ingrediente = value; }
        }

        int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
       TimeSpan hora;

        public TimeSpan Hora
        {
            get { return hora; }
            set { hora = value; }
        }
    }
}
