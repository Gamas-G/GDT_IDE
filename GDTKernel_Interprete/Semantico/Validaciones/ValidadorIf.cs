using System.Collections.Generic;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorIf : IValidadorBloque
    {
        const string _evento = "if";
        private static readonly HashSet<string> operadoresSimples = new HashSet<string>
    {
        "eq", "ne", "gt", "ge", "lt", "le", "co"
    };

        private static readonly HashSet<string> operadoresCompuestos = new HashSet<string>
    {
        "in", "ni"
    };
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;

            bool resp = bloque.TryGetProperty(_evento, out JsonElement objeto);

            if (!resp) return (true, mensajeError);

            if (objeto.ValueKind != JsonValueKind.Object) return (false, mensajeError = $"\"{_evento}\" requiere de un objeto JSON.");

            foreach (var parametro in objeto.EnumerateObject())
            {
                var operadorObj = parametro.Value;

                if (operadorObj.ValueKind != JsonValueKind.Object)
                {
                    return (false, mensajeError = $"El valor de \"{parametro.Name}\" debe ser un objeto con operador.");
                }

                foreach (var operador in operadorObj.EnumerateObject())
                {
                    string op = operador.Name;
                    var valor = operador.Value;

                    if (operadoresSimples.Contains(op))
                    {
                        if (!EsValorSimpleValido(valor))
                        {
                            return (false, mensajeError = $"El operador \"{op}\" en \"{parametro.Name}\" requiere un valor simple (Number, String o Boolean).");
                        }
                    }
                    else if (operadoresCompuestos.Contains(op))
                    {
                        if (valor.ValueKind != JsonValueKind.Object)
                        {
                            return (false, mensajeError = $"El operador \"{op}\" en \"{parametro.Name}\" requiere un objeto con \"p\" y \"s\".");
                        }

                        if (!valor.TryGetProperty("p", out var lista) || lista.ValueKind != JsonValueKind.String)
                        {                            
                            return (false, mensajeError = $"Falta \"p\" como lista de valores en \"{parametro.Name}\".");
                        }

                        if (!valor.TryGetProperty("s", out var separador) || separador.ValueKind != JsonValueKind.String)
                        {
                            return (false, mensajeError = $"Falta \"s\" como separador en \"{parametro.Name}\".");
                        }
                    }
                    else
                    {
                        return (false, mensajeError = $"Operador desconocido \"{op}\" en \"{parametro.Name}\".");
                    }
                }
            }

            return (true, mensajeError);
        }

        private static bool EsValorSimpleValido(JsonElement valor)
        {
            return valor.ValueKind == JsonValueKind.String || 
                   valor.ValueKind == JsonValueKind.Number ||
                   valor.ValueKind == JsonValueKind.True   ||
                   valor.ValueKind == JsonValueKind.False;
        }
    }
}
