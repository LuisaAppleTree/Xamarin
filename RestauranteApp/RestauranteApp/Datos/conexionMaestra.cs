using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace RestauranteApp.Datos
{
    class conexionMaestra
    {
        public static string ruta = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "connection.txt");
        public static string text = File.ReadAllText(ruta);
        public static string conexion = (text);
        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void Abrir()
        {
            if(conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }

        public static void Cerrar()
        {
            if(conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
