using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorKill : IValidadorBloque
    {
        const string _evento = "kill";
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;

            var propiedadesPermitidas = new[] { "n", "w", "s" };

            bool resp = bloque.TryGetProperty(_evento, out JsonElement objeto);

            if (!resp) return (true, mensajeError);

            if(objeto.ValueKind != JsonValueKind.Object) return (false, mensajeError = $"\"{_evento}\" requiere de un objeto JSON.");

            foreach (var propiedad in objeto.EnumerateObject())
            {
                if (!propiedadesPermitidas.Contains(propiedad.Name))
                {
                    mensajeError = $"\"{_evento}.{propiedad.Name}\" no es una propiedad válida.";
                    return (false, mensajeError);
                }
            }

            // Validaciones existentes...
            if (!objeto.TryGetProperty("n", out var proceso) || proceso.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.n\" debe ser String";
                return (false, mensajeError);
            }

            if (!objeto.TryGetProperty("w", out var w) || (w.ValueKind != JsonValueKind.False && w.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.w\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (!objeto.TryGetProperty("s", out var s) || (s.ValueKind != JsonValueKind.False && s.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.s\" debe ser Boolean";
                return (false, mensajeError);
            }

            return (true, mensajeError);
        }
    }
}
