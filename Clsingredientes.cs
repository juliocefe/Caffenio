using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class Clsingredientes
    {

        int id;
        string nombre;
        double precio;
        //int cantidad;
        
 
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
       

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        //public int Cantidad
        //{
        //    get { return cantidad; }
        //    set { cantidad = value; }
        //}
    }
}
