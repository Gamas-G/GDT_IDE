using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorKey : IValidadorBloque
    {
        const string _evento = "key";

        string[] propiedadesPermitidas = new[] { "k", "c", "d", "a" };
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
            if (!objeto.TryGetProperty("k", out var k) || k.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.k\" debe ser String";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("c", out var c) && c.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.c\" debe ser String";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("d", out var d) && (d.ValueKind != JsonValueKind.False && d.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.d\" debe ser Boolean";
                return (false, mensajeError);
            }
            bool respA = objeto.TryGetProperty("a", out var a);
            if (respA && a.ValueKind != JsonValueKind.Object)
            {
                mensajeError = $"\"{_evento}.a\" debe ser una instrucción JSON";
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
