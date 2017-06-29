using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class Manejador_Productos
    {
        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        
        public List<Productos> Mostrar_Productos()
        {
            List<Productos> Lista = new List<Productos>();
            Productos obj = null;

            string query  = "select * from productos";

            bd.AbrirConexion();
            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                obj = new Productos();

                obj.Id = Convert.ToInt32(bd.ResultadoConsulta["id_pro"]);
                obj.Nombre = bd.ResultadoConsulta["nombre_pro"].ToString();
                obj.Precio = Convert.ToInt32(bd.ResultadoConsulta["precio_pro"]);
               


                Lista.Add(obj);
            }

            bd.CerrarConexion();

            return Lista;

       
   



                
        }

    }
}
