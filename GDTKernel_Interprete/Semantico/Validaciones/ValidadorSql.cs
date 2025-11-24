using System;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorSql : IValidadorBloque
    {
        private string _evento = "sql";
        string[] propiedadesPermitidas = new[] { "c", "p"};
        JsonElement objeto;
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;

           bool resp = bloque.TryGetProperty(_evento, out objeto);

            //Condicional cuando param hace uso de 'q' el equivalente de sql pero como subpar
            if (isChild)
            {
                _evento = "q";
                resp = bloque.TryGetProperty(_evento, out objeto);
            }

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
            if (!objeto.TryGetProperty("c", out var c) || c.ValueKind != JsonValueKind.String)
            {
                mensajeError = $"\"{_evento}.c\". Debe existir y ser de tipo String";
                return (false, mensajeError);
            }

            if (objeto.TryGetProperty("p", out var p) && p.ValueKind != JsonValueKind.Object)
            {
                mensajeError = $"\"{_evento}.p\" debe ser un objeto JSON con parametros";
                return (false, mensajeError);
            }

            string query = objeto.ToString();

            // Extraer parámetros usados en el query
            var usadosEnQuery = Regex.Matches(query, @"@\w+")
                                      .Cast<Match>()
                                      .Select(m => m.Value.Substring(1)) // quitar el @
                                      .Distinct()
                                      .ToList();

            if (!string.IsNullOrEmpty(p.ToString()))
            {
                // Extraer parámetros definidos en "p"
                var definidosEnJson = p.EnumerateObject()
                                                       .Select(_p => _p.Name)
                                                       .ToList();
                // Verificar faltantes
                var faltantes = usadosEnQuery.Except(definidosEnJson).ToList();
                if (faltantes.Any())
                {
                    mensajeError = $"Faltan parámetros en \"sql.p\": {string.Join(", ", faltantes)}.";
                    return (false, mensajeError);
                }
            }


            return (true, mensajeError);
        }
    }
}
