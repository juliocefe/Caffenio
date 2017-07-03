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
        
        public List<ClaseProductos> Mostrar_Productos()
        {
            //List<Productos> Lista = new List<Productos>();
            //Productos obj = null;

            List<ClaseProductos> Lista = new List<ClaseProductos>();
            ClaseProductos obj = null;

            string query  = "select * from productos";

            bd.AbrirConexion();
            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                obj = new ClaseProductos();

                obj.Id = Convert.ToInt32(bd.ResultadoConsulta["id_pro"]);
                obj.Nombre = bd.ResultadoConsulta["nombre_pro"].ToString();
                obj.Precio = Convert.ToDouble(bd.ResultadoConsulta["precio_pro"]);


                Lista.Add(obj);
            
            }

            bd.CerrarConexion();

            return Lista;

       
   



                
        }


        public List<ClaseTipos> MostrarTipos()
         {
             List<ClaseTipos> Lista = new List<ClaseTipos>();

            // ClaseTipos obj = null;

             string query = "select id_det_pro, id_prodff, tipo_pro, descri_pro from detallespro;";

             bd.AbrirConexion();

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                ClaseTipos obj = new ClaseTipos();


                obj.Id = bd.ResultadoConsulta.GetInt32(0);
                obj.Fk = bd.ResultadoConsulta.GetInt32(1);
                obj.Tipo = bd.ResultadoConsulta.GetString(2);
                obj.Descripcion = bd.ResultadoConsulta.GetString(3);


                Lista.Add(obj);
            }


            bd.CerrarConexion();

            return Lista;
         }


        public List<ClaseTipos> MostrarPorId(int id)

        {

            List<ClaseTipos> Lista = new List<ClaseTipos>();

            // ClaseTipos obj = null;

            string query = "select id_det_pro, id_prodff, tipo_pro, descri_pro from detallespro where id_prodff = " + id + ";";

            bd.AbrirConexion();

            bd.EjecutarConsulta(query);

            while (bd.ResultadoConsulta.Read())
            {
                ClaseTipos obj = new ClaseTipos();


                obj.Id = bd.ResultadoConsulta.GetInt32(0);
                obj.Fk = bd.ResultadoConsulta.GetInt32(1);
                obj.Tipo = bd.ResultadoConsulta.GetString(2);
                obj.Descripcion = bd.ResultadoConsulta.GetString(3);


                Lista.Add(obj);
            }


            bd.CerrarConexion();

            return Lista;
        }

    }
}
