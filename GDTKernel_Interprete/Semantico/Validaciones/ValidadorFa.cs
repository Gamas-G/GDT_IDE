using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorFa : IValidadorBloque
    {
        const string _evento = "fa";
        string[] propiedadesPermitidas = new[] { "f", "a" };
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;
            
            bool resp = bloque.TryGetProperty(_evento, out JsonElement objeto);

            if (!resp) return (true, mensajeError);

            if (objeto.ValueKind != JsonValueKind.Object) return (false, mensajeError = $"\"{_evento}\" requiere de un objeto JSON.");

            foreach (var propiedad in objeto.EnumerateObject())
            {
                if (!propiedadesPermitidas.Contains(propiedad.Name))
                {
                    mensajeError = $"\"{_evento}.{propiedad.Name}\" no es una propiedad válida.";
                    return (false, mensajeError);
                }
            }

            // Validaciones existentes...
            if (!objeto.TryGetProperty("f", out var f) || f.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.f\" debe ser String";
                return (false, mensajeError);
            }

            if (!objeto.TryGetProperty("a", out var a) || a.ValueKind != JsonValueKind.Number)
            {
                mensajeError = $"\"{_evento}.a\" debe ser Number";
                return (false, mensajeError);
            }

            int nivel = a.GetInt32();
            if (nivel != 0 && nivel != 1 && nivel != 2 && nivel != 4 && nivel != 8 && nivel != 15)
            {
                mensajeError = $"\"{_evento}.a\" nivel de acceso no reconociada (0-NoAccess, 1-Read, 2-Write, 4-Append, 8-PathDiscovery, 15-AllAccess).";
                return (false, mensajeError);
            }

            return (true, mensajeError);
        }
    }
}
