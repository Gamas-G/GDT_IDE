using System;
using System.Linq;
using System.Text.Json;

namespace GDTKernel_Interprete.Semantico.Validaciones
{
    public class ValidadorParam : IValidadorBloque
    {
        const string _evento = "param";
        string[] propiedadesPermitidas = new[] {"n", "v", "if", "f", "p", "q", "r", "a", "d", "x", "o", "c", "s", "+", "-", "*", "/", "%", "|", "&" };
        string[] clavesR = new[] { "k", "s", "n", "d" };
        string[] clavesRK = new[] { "hkcr", "hkcc", "hkcu", "hklm", "hkpd", "hkus" };
        public (bool, string) Validar(JsonElement bloque, bool isChild = false)
        {
            string mensajeError = string.Empty;

            bool resp = bloque.TryGetProperty(_evento, out JsonElement param);

            if (!resp) return (true, mensajeError);

            if (param.ValueKind != JsonValueKind.Object) return (false, mensajeError = $"\"{_evento}\" requiere de un objeto JSON.");

            foreach (var propiedad in param.EnumerateObject())
            {
                if (!propiedadesPermitidas.Contains(propiedad.Name))
                {
                    mensajeError = $"\"{_evento}.{propiedad.Name}\" no es una propiedad válida.";
                    return (false, mensajeError);
                }
            }

            // Validar que "n" exista y sea cadena
            if (!param.TryGetProperty("n", out var nombre) || nombre.ValueKind != JsonValueKind.String)
            {
                //mensajeError = ;
                return (false, $"\"{_evento}.n\" debe existir y ser de tipo String.");
            }

            if (param.TryGetProperty("v", out var v) && (v.ValueKind != JsonValueKind.String && v.ValueKind != JsonValueKind.Number && v.ValueKind != JsonValueKind.True && v.ValueKind != JsonValueKind.False))
            {
                //mensajeError = ;
                return (false, $"\"{_evento}.v\" no puede ser un objeto JSON.");
            }

            bool respIf = param.TryGetProperty("if", out var condic);

            if (respIf && condic.ValueKind != JsonValueKind.Object)
            {
                //mensajeError = ;
                return (false, $"\"{_evento}.if\" debe ser un objeto JSON.");
            }

            if (respIf)
            {
                foreach (IValidadorBloque _validador in Validadores.ObtnerValidadores())
                {
                    (bool re, string msj) = _validador.Validar(param, true);
                    if (!re)
                    {
                        mensajeError = msj;
                        return (false, mensajeError);
                    }
                }
            }

            bool respP = param.TryGetProperty("p", out var p);

            if (respP && p.ValueKind == JsonValueKind.Object)
            {
                if (!p.TryGetProperty("i", out var id) || id.ValueKind != JsonValueKind.Number ||
                    !p.TryGetProperty("s", out var sub) || sub.ValueKind != JsonValueKind.Number)
                {
                    //mensajeError = ;
                    return (false, $"\"{_evento}.p\" debe contener \"i\" y \"s\" de tipo Number.");
                }
            }
            else if(respP && p.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.p\" debe ser un objto JSON");
            }
            
            bool respQ = param.TryGetProperty("q", out var q);

            if (respQ && q.ValueKind == JsonValueKind.Object)
            {
                if (!q.TryGetProperty("c", out var comando) || comando.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, "\"param.q.c\" debe ser una cadena con el comando SQL.");
                }

                if (q.TryGetProperty("p", out var parametros) && parametros.ValueKind != JsonValueKind.Object)
                {
                    //mensajeError = ;
                    return (false, "\"param.q.p\" debe ser un objeto con parámetros.");
                }
                
                foreach (IValidadorBloque _validador in Validadores.ObtnerValidadores())
                {
                    (bool re, string msj) = _validador.Validar(param, true);
                    if (!re)
                    {
                        mensajeError = msj;
                        return (false, mensajeError);
                    }
                }

            }
            else if(respQ && q.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.q\" debe ser un objto JSON");
            }


            bool respR = param.TryGetProperty("r", out var r);
            if (respR && r.ValueKind == JsonValueKind.Object)
            {
                foreach (var clave in clavesR)
                {
                    bool respClave = r.TryGetProperty(clave, out var val);
                    
                    //la clave puede ir o no ir.
                    if (clave == "d" && string.IsNullOrEmpty(val.ToString())) continue;

                    if (!respClave || val.ValueKind != JsonValueKind.String)
                    {
                        //mensajeError = ;
                        return (false, $"\"param.r.{clave}\" debe ser de tipo String.");
                    }

                    if (clave != "k") continue;

                    if(!IsClave(val.ToString())) return (false, $"\"param.r.{clave}\" debe ser una clave valida.");
                }
            }
            else if(respR && r.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.r\" debe ser un objeto JSON.");
            }
                
            
            if(param.TryGetProperty("a", out var a) && a.ValueKind != JsonValueKind.String)
            {
                return (false, $"\"{_evento}.a\" no debe ser de tipo String.");
            }

            if (param.TryGetProperty("d", out var d) && (d.ValueKind != JsonValueKind.True && d.ValueKind != JsonValueKind.False))
            {
                return (false, $"\"{_evento}.d\" no debe ser de tipo Boolean.");
            }

            if (param.TryGetProperty("s", out var s) && s.ValueKind != JsonValueKind.String)
            {
                return (false, $"\"{_evento}.s\" no debe ser de tipo String.");
            }

            bool respX = param.TryGetProperty("x", out var x);
            if (respX && x.ValueKind == JsonValueKind.Object)
            {
                if (!x.TryGetProperty("o", out var original) || original.ValueKind != JsonValueKind.String ||
                    !x.TryGetProperty("n", out var nuevo) || nuevo.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, $"\"{_evento}.x\" debe contener \"o\" y \"n\" de tipo String.");
                }
            }
            else if (respX && x.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.x\" debe ser un objeto JSON");
            }

            bool respO = param.TryGetProperty("o", out var objeto);
            if (respO && objeto.ValueKind == JsonValueKind.Object)
            {
                if (!objeto.TryGetProperty("#", out var tipo) || tipo.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, "\"param.o.#\" debe ser una cadena con el tipo de objeto.");
                }
            }
            else if (respO && objeto.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.o\" debe ser un objto JSON");
            }


            bool respC = param.TryGetProperty("c", out var c);
            if (respC && c.ValueKind == JsonValueKind.Object)
            {
                // Validar "t" si existe
                if (c.TryGetProperty("t", out var tipo) && tipo.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, $"\"{_evento}.c.t\" debe ser tipo String.");
                }

                if (c.TryGetProperty("o", out var co) && co.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, $"\"{_evento}.c.o\" debe ser tipo String.");
                }
                    
                // Validar "p" si existe
                if (c.TryGetProperty("p", out var cp) && cp.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, $"\"{_evento}.c.p\" debe ser tipo String.");
                }

                // Validar "m" si existe
                if (c.TryGetProperty("m", out var metodo) && metodo.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, "\"param.c.m\" debe ser una cadena.");
                }

                // Validar "a" si existe
                if (c.TryGetProperty("a", out var args) && args.ValueKind != JsonValueKind.Array)
                {
                    //mensajeErro
                    return (false, "\"param.c.a\" debe ser un arreglo.");
                }

                // Validar "at" si existe
                if (c.TryGetProperty("at", out var tipos) && tipos.ValueKind != JsonValueKind.Array)
                {
                    //mensajeError = ;
                    return (false, "\"param.c.at\" debe ser un arreglo.");
                }
            }
            else if (respC && c.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.c\" debe ser un objto JSON");
            }

            bool respH = param.TryGetProperty("h", out var h);
            if (respH && h.ValueKind == JsonValueKind.Object)
            {
                if (!h.TryGetProperty("e", out var formEvento) || formEvento.ValueKind != JsonValueKind.String ||
                    !h.TryGetProperty("s", out var firmaEvent ) || firmaEvent.ValueKind != JsonValueKind.String ||
                    !h.TryGetProperty("f", out var eventoKernel) || eventoKernel.ValueKind != JsonValueKind.String)
                {
                    //mensajeError = ;
                    return (false, $"\"{_evento}.h\" debe contener \"e\", \"s\" y \"f\" de tipo String.");
                }
            }
            else if (respH && h.ValueKind != JsonValueKind.Object)
            {
                return (false, $"\"{_evento}.h\" debe ser un objeto JSON");
            }

            return (true, mensajeError);
        }

        private bool IsClave(string clave)
        {
            return clavesRK.Contains(clave);
        }
    }
}
