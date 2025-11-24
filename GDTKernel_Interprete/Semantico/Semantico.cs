using GDTKernel_Interprete.Semantico.Validaciones;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico
{
    public static class Semantico
    {
        public static bool ValidarSemantica(JsonElement bloque, out string mensajeError)
        {
            mensajeError = string.Empty;

            foreach (IValidadorBloque _validador in Validadores.ObtnerValidadores())
            {
                (bool re, string msj) = _validador.Validar(bloque);
                if (!re)
                {
                    mensajeError = msj;
                    return false;
                }
            }

            return true;
        }
    }
}
