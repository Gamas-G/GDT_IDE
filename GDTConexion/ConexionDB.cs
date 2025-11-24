using GDTConexion.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GDTConexion
{
    public class ConexionDB : IConexionDB
    {
        //public static string[] credentials = new string[4];// credentials server,database,user,password
        public static string[] credentials = { "10.57.111.107", "ADN", "AccesDesarrollo", "AccesDesarrollo123" };// credentials server,database,user,password


        string conexionString = "Data Source=" + credentials[0] +
                                    ";Initial Catalog=" + credentials[1] +
                                    ";User Id=" + credentials[2] +
                                    ";Password=" + credentials[3];
        //public void Conexion_db()
        //{
            /*
             * BUILDER A CONCIDERAR
             * SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "<your_server>.database.windows.net"; 
                builder.UserID = "<your_username>";            
                builder.Password = "<your_password>";     
                builder.InitialCatalog = "<your_database>";
             */


            

            //SqlConnection Conexion = new SqlConnection(conexionString);
            //Conexion.Open();
            //return Conexion;
        //}

        public DataTable Reglas( string query )
        {
            //var conn = ConexionDB.Conexion_db();
            DataTable dt = new DataTable();
            using (SqlConnection Conexion = new SqlConnection(conexionString))
            {
                SqlCommand cmd = new SqlCommand(query, Conexion);
                //cmd.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                //cmd.Close();
                //conn.Dispose();
            }

            return dt;
        }
    }
}
