using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Caffenio
{
    class Manejador_Base_Datos
    {
        //Atributo para la conexión
        MySqlConnection conexion;
        //Atributo para los comandos de MySQL
        MySqlCommand comando;
        //Atributo para almacenar el resultado de las consultas
        MySqlDataReader lectorDatos;

        //Se declaran aqui, por si se quiere llegar a cambiar la base de datos, psw o usuario
        string bd = "Caffenio";
        string user = "root";
        string psw = "123";



        //Conexión BD
        public Manejador_Base_Datos()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server = localhost; database = " + bd + "; uid = " + user + "; pwd = " + psw + ";";
        }


        //Habilitar conexión
        public void AbrirConexion()
        {
            //Si el estado de la conexión está cerrada, se usara el comando "Open" para abrirla
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open(); //Esto se hace más que nada, para evitar que se repita la conexión, de lo contrario habrá errores
            }
        }


        //Terminar conexión  ***Aplica igual pero alrevés***e
        public void CerrarConexion()
        {

            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }


        //Ejecutar comandos INSERT-UPDATE-DELETE
        public void EjecutarComando(string query)
        {
            comando = new MySqlCommand();
            comando.CommandText = query;
            comando.Connection = conexion;
            //No se espera resultado a cambio    ****NOTA : Sólo para INSERT-UPDATE-DELETE***
            comando.ExecuteNonQuery();
        }


        //Ejecutar consulta
        public void EjecutarConsulta(string query)
        {
            comando = new MySqlCommand();
            comando.CommandText = query;
            comando.Connection = conexion;
            //Guarda los datos  en  lectorDatos
            lectorDatos = comando.ExecuteReader(); /* comando.ExecuteReader(); Se usa para guardar los datos*/
        }




        //
        public MySqlDataReader ResultadoConsulta
        {
            //GET porque sólo se ocupa leer
            get { return lectorDatos; }
        }
    }
}
