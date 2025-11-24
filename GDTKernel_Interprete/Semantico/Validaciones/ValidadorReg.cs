using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorReg : IValidadorBloque
    {
        const string _evento = "reg";
        string[] clavesPermitidas = new[] { "hkcr", "hkcc", "hkcu", "hklm", "hkpd", "hkus" };
        int[] tipoDatoPermitidas = new[] { -1, 0, 1, 2, 3, 4, 7, 11 };
        string[] propiedadesPermitidas = new[] { "k", "s", "n", "v", "t", "d", "ds" };
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

            if (!objeto.TryGetProperty("k", out var k) || k.ValueKind != JsonValueKind.String || !IsClave(k.ToString()))
            {
                return (false, $"Se requiere la clave \"{_evento}.k\" debe ser String y un tipo de clave valida");
            }

            if (!objeto.TryGetProperty("s", out var s) || s.ValueKind != JsonValueKind.String)
            {
                return (false, $"Se requiere la subclave \"{_evento}.s\" debe ser String");
            }

            if (!objeto.TryGetProperty("n", out var n) || n.ValueKind != JsonValueKind.String)
            {
                return (false, $"Se requiere el nombre \"{_evento}.n\" debe ser String");
            }

            if (objeto.TryGetProperty("v", out var v) && v.ValueKind != JsonValueKind.String)
            {
                return (false, $"El valor a asignar \"{_evento}.v\" debe ser String");
            }


            bool respT = objeto.TryGetProperty("t", out var t);
            if (respT && t.ValueKind != JsonValueKind.Number)
            {
                return (false, $"El tipo de dato \"{_evento}.t\" debe ser Number");
            }

            if (respT)
            {
                bool respValor = t.TryGetInt32(out int valor);
                if (respValor && !IsTipoDato(valor))
                {
                    return (false, $"El tipo de dato \"{_evento}.t\" debe ser uno valido");
                }
            }

            if (!objeto.TryGetProperty("d", out var d) || (d.ValueKind != JsonValueKind.True && d.ValueKind != JsonValueKind.False))
            {
                return (false, $"El valor \"{_evento}.d\" debe ser Boolean");
            }

            if (objeto.TryGetProperty("ds", out var ds) && (ds.ValueKind != JsonValueKind.True && ds.ValueKind != JsonValueKind.False))
            {
                return (false, $"El valor \"{_evento}.ds\" debe ser Boolean");
            }

            return (true, mensajeError);
        }

        private bool IsClave(string clave)
        {
            return clavesPermitidas.Contains(clave);
        }

        private bool IsTipoDato(int clave)
        {
            return tipoDatoPermitidas.Contains(clave);
        }

        private (bool, string) RequiereClave(JsonElement objeto, string key, JsonValueKind tipo)
        {
            var resp = objeto.TryGetProperty(key, out var k);
            if (!resp)
            {
                return (false, $"Se requiere la clave \"{key}\"");
            }

            if(k.ValueKind != tipo)
            {
                return (false , $"El valor \"{_evento}.{key}\" requiere que sea de tipo {tipo}");
            }

            //if (!IsClave(k.ToString()))
            //{

            //}

            return (true, "");
        }

        private (bool, string) NoRequiereClave()
        {
            return (true, "");
        }
    }
}
