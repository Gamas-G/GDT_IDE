using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorInvoke : IValidadorBloque
    {
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;
            if (bloque.TryGetProperty("invoke", out var log) && log.ValueKind != JsonValueKind.String)
            {
                mensajeError = "El tipo de valor \"invoke\" debe ser String";
                return (false, mensajeError);
            }
            return (true, mensajeError);
        }
    }
}
