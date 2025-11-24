using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public interface IValidadorBloque
    {
        (bool, string) Validar(JsonElement bloque, bool isChild = false);
    }
}
