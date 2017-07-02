using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class ClaseTipos
    {


        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        int fk;

        public int Fk
        {
            get { return fk; }
            set { fk = value; }
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



    }
}
