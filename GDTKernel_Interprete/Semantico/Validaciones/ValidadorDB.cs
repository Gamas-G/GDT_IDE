using System;
using System.Data.SqlClient;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorDB : IValidadorBloque
    {
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;
            var resp = bloque.TryGetProperty("db", out var log);

            if (!resp)
            {
                return (true, mensajeError);
            }

            if(log.ValueKind != JsonValueKind.String)
            {
                mensajeError = "El tipo de valor \"db\" debe ser String";
                return (false, mensajeError);
            }

            if (!IsConnectionString(log.GetString()))
            {
                mensajeError = "La cadena de conexión es invalida, favor de validar";
                return (false, mensajeError);
            }
            
            return (true, mensajeError);
        }

        private bool IsConnectionString(string connectionString)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(connectionString);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
