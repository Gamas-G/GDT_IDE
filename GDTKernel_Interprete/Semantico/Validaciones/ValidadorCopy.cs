using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorCopy : IValidadorBloque
    {
        const string _evento = "copy";
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;

            var propiedadesPermitidas = new[] { "s", "d", "o" };

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
            if (!objeto.TryGetProperty("s", out var rutaOrigen) || rutaOrigen.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.s\" debe ser String";
                return (false, mensajeError);
            }

            if (!objeto.TryGetProperty("d", out var rutaDestino) || rutaDestino.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.d\" debe ser String";
                return (false, mensajeError);
            }

            if (!objeto.TryGetProperty("o", out var s) || (s.ValueKind != JsonValueKind.False && s.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.o\" debe ser Boolean";
                return (false, mensajeError);
            }

            return (true, mensajeError);
        }
    }
}
