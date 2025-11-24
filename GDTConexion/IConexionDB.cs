using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GDTConexion.DAL
{
    public interface IConexionDB
    {
        //public static string[] credentials;
        //SqlConnection Conexion_db();
        DataTable Reglas(string query);
    }
}
