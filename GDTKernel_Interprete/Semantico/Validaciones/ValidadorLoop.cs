using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorLoop : IValidadorBloque
    {
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;
            if (bloque.TryGetProperty("loop", out var log) && log.ValueKind != JsonValueKind.Number)
            {
                mensajeError = "El tipo de valor \"loop\" debe ser Number";
                return (false, mensajeError);
            }
            return (true, mensajeError);
        }
    }
}
