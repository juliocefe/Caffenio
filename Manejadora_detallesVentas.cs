﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffenio
{
    class Manejadora_detallesVentas
    {
        Manejador_Base_Datos bd = new Manejador_Base_Datos();
        public List<clsDetallesVenta> MostrarDetalles(string query)
        {
            List<clsDetallesVenta> lista = new List<clsDetallesVenta>();
            clsDetallesVenta obj = null;

            //string superquery = "select t6.id_det_ven, t6.nombre_pro, t6.tipo_pro, t6.Descri_pro, t5.nombre_ing,  t6.total_detven, t6.fecha, t6.hora from (select id_ing, nombre_ing, precio_ing from ingredientes) as t5 inner join (select  t3.nombre_pro,  t3.id_det_pro, t3.tipo_pro, t3.Descri_pro, t4.id_det_ven, t4.id_venf, t4.id_prodf, t4.id_ingf, t4.total_detven, t4.total, t4.fecha, t4.hora from (select t1.id_pro, t1.nombre_pro, t1.precio_pro, t2.id_det_pro, t2.id_prodff, t2.tipo_pro, t2.Descri_pro from (select id_pro, nombre_pro, precio_pro from Productos) as t1 inner join (select id_det_pro, id_prodff, tipo_pro, Descri_pro from DetallesPro ) as t2 on t1.id_pro=t2.id_prodff ) as t3 inner join (select t1.id_det_ven, t1.id_venf, t2.id_ven, t1.id_prodf, t1.id_ingf, t1.total_detven, t2.total, t2.fecha, t2.hora from (select id_det_ven, id_venf, id_prodf, id_ingf, total_detven  from DetallesVen ) as t1 inner join ( select id_ven, total, fecha, hora from ventas ) as t2 on t1.id_venf = t2.id_ven ) as t4 on t3.id_pro=t4.id_prodf ) as t6 on t5.id_ing=t6.id_ingf where t6.id_venf ="+ id +"group by t6.id_det_ven;";

           bd.AbrirConexion();

           bd.EjecutarConsulta(query);


           while (bd.ResultadoConsulta.Read())
           {
               obj = new clsDetallesVenta();
      

               obj.Id = bd.ResultadoConsulta.GetInt32(0);
               obj.Nombre = bd.ResultadoConsulta.GetString(1);
               obj.Tipo = bd.ResultadoConsulta.GetString(2);
               obj.Descripcion = bd.ResultadoConsulta.GetString(3);
               obj.Ingrediente = bd.ResultadoConsulta.GetString(4);
               obj.Total = bd.ResultadoConsulta.GetDouble(5);
               


               lista.Add(obj);

           }

           bd.CerrarConexion();
           return lista;
            
        }   
    }
}
