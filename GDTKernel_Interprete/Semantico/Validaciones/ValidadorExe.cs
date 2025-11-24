using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorExe : IValidadorBloque
    {
        const string _evento = "exe";
        
        string[] propiedadesPermitidas = new[] { "f", "a", "h", "w", "v", "t", "o", "s", "i", "e", "l", "p" };
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

            if (objeto.TryGetProperty("a", out var a) && a.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.a\" debe ser String";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("h", out var h) && (h.ValueKind != JsonValueKind.False && h.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.h\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("w", out var w) && (w.ValueKind != JsonValueKind.False && w.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.w\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("v", out var v) && (v.ValueKind != JsonValueKind.False && v.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.v\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("t", out var t) && (t.ValueKind != JsonValueKind.False && t.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.t\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("o", out var o) && a.ValueKind != JsonValueKind.Number)
            {
                mensajeError = $"\"{_evento}.o\" debe ser Number";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("s", out var s) && (s.ValueKind != JsonValueKind.False && s.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.s\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("i", out var i) && (i.ValueKind != JsonValueKind.False && i.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.i\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("e", out var e) && e.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.e\" debe ser String";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("l", out var l) && (l.ValueKind != JsonValueKind.False && l.ValueKind != JsonValueKind.True))
            {
                mensajeError = $"\"{_evento}.l\" debe ser Boolean";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("p", out var p) && p.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.p\" debe ser String";
                return (false, mensajeError);
            }

            return (true, mensajeError);
        }
    }
}
