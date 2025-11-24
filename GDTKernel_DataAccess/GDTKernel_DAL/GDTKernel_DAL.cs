using System;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GDTKernel_Model;
using System.Configuration;
using System.IO;

namespace GDTKernel_DataAccess.GDTKernel_DAL
{
    public class GDTKernel_DAL : IGDTKernel_DAL
    {
        private string _cadenaConexion = string.Empty;
        string _IsProd = ConfigurationManager.AppSettings["IsProd"];

        public GDTKernel_DAL()
        {
            _cadenaConexion = _IsProd.Contains("0") 
                              ? ConfigurationManager.AppSettings["connDebug"]
                              : ConfigurationManager.AppSettings["conn"];
        }

        public async Task<DataSet> CargarReglasKernel( CredencialesServidor credenciales )
        {
            _cadenaConexion = String.Format(_cadenaConexion, credenciales.Ip, credenciales.DB, credenciales.Usuario, credenciales.Password);
            DataSet dt = new DataSet();
            await Task.Run(() => 
            {
                try
                {
                    using (SqlConnection Conexion = new SqlConnection(_cadenaConexion))
                    {
                        Conexion.Open();
                        SqlCommand cmd = new SqlCommand("spConKernelIDE", Conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        Conexion.Close();
                    }
                }
                catch (Exception ex)
                {
                    //if (ex.Message.Contains("Could not find stored procedure"))
                    //{
                    //    CrearSP();
                    //    CargarReglasKernel(credenciales);
                    //}

                    dt = null;
                }
            });
            return dt;
        }

        private void CrearSP()
        {
            string _codeCreate;
            using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings["PathScriptSQL"]))
            {
                _codeCreate = r.ReadToEnd();
            }
            using (SqlConnection Conexion = new SqlConnection(_cadenaConexion))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand(_codeCreate, Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                Conexion.Close();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            }
        }
    }
}
