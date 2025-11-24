using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorForeach : IValidadorBloque
    {
        const string _evento = "foreach";
        string[] propiedadesPermitidas = new[] { "v", "i", "a" };
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
            if (!objeto.TryGetProperty("v", out var v) || v.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.v\" debe ser String";
                return (false, mensajeError);
            }

            if (!objeto.TryGetProperty("i", out var i) || i.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.i\" debe ser String";
                return (false, mensajeError);
            }

            bool respA = objeto.TryGetProperty("a", out var a);

            if (!respA || a.ValueKind != JsonValueKind.Object)
            {
                mensajeError = $"\"{_evento}.a\" debe ser un objeto JSON";
                return (false, mensajeError);
            }

            if (respA)
            {
                foreach (IValidadorBloque _validador in Validadores.ObtnerValidadores())
                {
                    (bool re, string msj) = _validador.Validar(a, true);
                    if (!re)
                    {
                        mensajeError = msj;
                        return (false, mensajeError);
                    }
                }
            }

            return (true, mensajeError);
        }
    }
}
