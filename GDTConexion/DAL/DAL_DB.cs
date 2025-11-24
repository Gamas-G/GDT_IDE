using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GDTConexion.DAL
{
    public class DAL_DB : IDAL_DB
    {
        private IConexionDB _conexion;
        public DAL_DB( IConexionDB conexion )
        {
            _conexion = conexion;
        }
        public DataTable SelectRulesKrnl(string fcValor)
        {
            string query = String.Empty;
            try
            {
                query = String.Format(templateQuery, fcValor);
                return _conexion.Reglas(query);
                //return dt;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw;
            }
        }

        public DataTable SelecAdvancedtRulesKrnl(string fcValor)
        {
            string query = String.Empty;
            try
            {
                query = String.Format(templateAdvancedQuery, fcValor);
                return _conexion.Reglas(query);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw;
            }
        }



        //Querys estaticos
        const string templateQuery = @"
                         SELECT * FROM CATGDIDESTEC WHERE fiItemId = 526 AND fcValor LIKE '%{0}%'
                       ";

        const string templateAdvancedQuery = @"
                         SELECT * FROM CATGDIDESTEC WHERE fiItemId = 526 AND fcValor LIKE '%{0}%'
                       ";
    }
}
