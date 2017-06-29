using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class clsventas
    {

        int id;
        //int producto;
        //int ingrediente;
        double total;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        //public int Producto
        //{
        //    get { return producto; }
        //    set { producto = value; }
        //}
        

        //public int Ingrediente
        //{
        //    get { return ingrediente; }
        //    set { ingrediente = value; }
        //}
        

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
        string hora;

        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }

    }
}
