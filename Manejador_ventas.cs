using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class Manejador_ventas
    {
        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        public List<clsventas> Mostrar_Ventas()
        {
            List<clsventas> Lista = new List<clsventas>();

            clsventas obj = null;

            string query = "select* from ventas;";

            bd.AbrirConexion();

            bd.EjecutarConsulta(query);


            while (bd.ResultadoConsulta.Read())
            {
                obj = new clsventas();

                obj.Id = Convert.ToInt32(bd.ResultadoConsulta["id_ven"]);
                //obj.Ingrediente = Convert.ToInt32(bd.ResultadoConsulta["id_ingf"]);
                //obj.Producto = Convert.ToInt32(bd.ResultadoConsulta["id_prodf"]);
                obj.Total = Convert.ToDouble(bd.ResultadoConsulta["total"]);
                obj.Fecha = bd.ResultadoConsulta["fecha"].ToString();
                obj.Hora = bd.ResultadoConsulta["hora"].ToString();


                Lista.Add(obj);

            }

            bd.CerrarConexion();

            return Lista;


            
        }




        public List<Carritoventass> Agregarids(int idven, int idprod, int iding)
        {
            List<Carritoventass> Lista = new List<Carritoventass>();

            Carritoventass obj = new Carritoventass();


            obj.Idven = idven;
            obj.Idprod = idprod;
            obj.Iding = iding;

          
            Lista.Add(obj);

            return Lista;



        }


     
    }
}
