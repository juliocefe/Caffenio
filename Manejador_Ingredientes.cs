using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class Manejador_Ingredientes
    {
        Manejador_Base_Datos bd = new Manejador_Base_Datos();

       
        
        public List<Clsingredientes> MostrarIngredientes()
        {
            List<Clsingredientes> Lista = new List<Clsingredientes>();
           
            Clsingredientes obj = null;

            string query =  "select* from ingredientes;";

            bd.AbrirConexion();
            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {

                obj = new Clsingredientes();


                obj.Id = Convert.ToInt32(bd.ResultadoConsulta["id_ing"]);
                obj.Nombre = bd.ResultadoConsulta["nombre_ing"].ToString();
                obj.Precio = Convert.ToInt32(bd.ResultadoConsulta["precio_ing"]);

                Lista.Add(obj);
            }

           

            bd.CerrarConexion();

            return Lista;

        
        }


       
        

    }
}
