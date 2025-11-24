using System;
using System.Configuration;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorDefault : IValidadorBloque
    {
        private readonly static string[] propiedadesPermitidas = ConfigurationManager.AppSettings["PropiedadesPermitidas"].Split(',');
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;

            if (!isChild)
            {
                (bool resp, string mensaje) = ObtenerPropiedad(bloque, "e", JsonValueKind.String);
                if (!resp) return (resp, mensaje);

                (bool respI, string mensajeI) = ObtenerPropiedad(bloque, "i", JsonValueKind.Number);
                if (!respI) return (respI, mensajeI);
            }
            (bool respC, string mensajeC) = IsClaveVacia(bloque);
            if (!respC) return (respC, mensajeC);

            (bool respP, string mensajeP) = IsPropPermitida(bloque);
            if (!respP && !isChild) return (respP, mensajeP);

            return (true, mensajeError);
        }

        private (bool, string) ObtenerPropiedad(JsonElement bloque, string clave, JsonValueKind tipo)
        {
            string mensaje = string.Empty;
            if (!bloque.TryGetProperty(clave, out var valor))
            {
                mensaje = $"Falta la clave \"{clave}\".";
                return (false, mensaje);
            }

            if (valor.ValueKind != tipo)
            {
                mensaje = $"El tipo de valor \"{clave}\" debe de ser {tipo}";
                return (false, mensaje);
            }

            return (true, mensaje);
        }

        private (bool, string) IsClaveVacia(JsonElement bloque)
        {
            string mensajeError = string.Empty;
            foreach (JsonProperty item in bloque.EnumerateObject())
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    mensajeError = "Se detecta clave vacia, favor de validar";
                    return (false, mensajeError);
                }
            }
            return (true, mensajeError);
        }

        private (bool, string) IsPropPermitida(JsonElement bloque)
        {
            string mensajeError = string.Empty;
            foreach (JsonProperty item in bloque.EnumerateObject())
            {
                if (!propiedadesPermitidas.Contains(item.Name))
                {
                    mensajeError = $"Clave \"{item.Name}\" no valida";
                    return (false, mensajeError);
                }
            }
            return (true, mensajeError);
        }
    }
}
