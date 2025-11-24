using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorDel : IValidadorBloque
    {
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;
            if (bloque.TryGetProperty("del", out var log) && log.ValueKind != JsonValueKind.String)
            {
                mensajeError = "El tipo de valor \"del\" debe ser String";
                return (false, mensajeError);
            }
            return (true, mensajeError);
        }
    }
}
