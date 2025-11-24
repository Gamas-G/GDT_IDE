using GDTKernel_Model;
using GDTKernel_Util.Observador;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDTKernel_Interprete.Almacen
{
    public class Almacen
    {
        private const string _Todos = "Todos";
        private static DataTable _catalogoReglas { get; set; } = new DataTable { Columns = { "BloqueRegla" } };

        private static readonly Dictionary<string, List<ReglaK>> _dicReglas = new Dictionary<string, List<ReglaK>>();

        public static HashSet<string> _bloquesProcesados = new HashSet<string>();

        private static readonly string[] PalabrasClave = { "fire", "invoke", "thread" };

        private static readonly DataTable _tablaReglasFiltradas = new DataTable
        {
            Columns =
            {
                new DataColumn("fiItemId", typeof(int)),
                new DataColumn("fiSubItemId", typeof(int)),
                new DataColumn("fcValor", typeof(string)),
                new DataColumn("fcCatDesc", typeof(string)),
                new DataColumn("fiSubItemStat", typeof(int))
            }
        };

        private static DataSet _dtReglas526_100 { get; set; }

        public static void GuardarReglas(DataSet reglas)
        {
            _dtReglas526_100 = reglas;
            _catalogoReglas.Rows.Add(_Todos);
        }

        public static DataSet ConsultarReglas()
        {
            return _dtReglas526_100.Copy();
        }

        public static DataTable ConsultarCatalogo()
        {
            return _catalogoReglas.Copy();
        }

        public static DataTable ConsultarReglas(string indexSelect)
        {
            if (indexSelect.Equals(_Todos))
            {
                return _dtReglas526_100.Tables[2].Copy();
            }

            List<ReglaK> _reg = _dicReglas[indexSelect];

            _tablaReglasFiltradas.Clear();
            _reg.ForEach(re => {
                _tablaReglasFiltradas.Rows.Add(re.fiItemId, re.fiSubItemId, re.fcValor, re.fcCatDesc, re.fiSubItemStat);
            });

            return _tablaReglasFiltradas.Copy();
        }

        public static DataTable BuscarReglaFiltro(string reglaValor, string catDesc, int status, int Regla526_100, int fiSubItemId = 0, string bloqueRegla = _Todos)
        {
            DataTable reglasBusqueda = bloqueRegla.Equals(_Todos) || Regla526_100 == 3 ? _dtReglas526_100.Tables[Regla526_100].Copy() : _tablaReglasFiltradas;

            var result = reglasBusqueda.AsEnumerable()
                                       .Where(regla => regla.Field<string>("fcValor").ToLower().Contains(reglaValor.ToLower()) &&
                                                       regla.Field<string>("fcCatDesc").ToLower().Contains(catDesc.ToLower()) &&
                                                       ( fiSubItemId == 0 || regla.Field<int>("fiSubItemId") == fiSubItemId) &&
                                                       (
                                                       (status == 2)
                                                        ? regla.Field<int>("fiSubItemStat") == 1 || regla.Field<int>("fiSubItemStat") == 0
                                                        : regla.Field<int>("fiSubItemStat") == status
                                                       ));

            return (!result.Any()) ? new DataTable() : result.CopyToDataTable();
        }

        public static async Task<bool> GuardarReglasAlmacen(List<ReglaK> reglaKernelInterprete)
        {
            try
            {
                foreach (ReglaK regla in reglaKernelInterprete)
                {
                    if (!JsonValido(regla.fcValor))
                    {
                        Observador._observadorEstatus($"Error en formato json de la regla fiitemid: {regla.fiItemId}, fisubitemid: {regla.fiSubItemId}. Favor de validar");
                        return false;
                    }
                    JObject json = JObject.Parse(regla.fcValor);
                    foreach (var item in json.Properties())
                    {
                        if (item.Name.Equals("e"))
                        {
                            AddDicRelgas(item.Value.ToString(), regla);
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw new Exception("ERROR");
            }
        }

        private static string ObtenerBloqueRegla(string regla)
        {
            string bloqueRegla = string.Empty;

            if (!JsonValido(regla)) return regla;

            JObject objeto = JObject.Parse(regla);
            foreach (var item in objeto.Properties())
            {
                if(item.Name.Equals("e")) bloqueRegla = item.Value.ToString(); break;
            }
            return bloqueRegla;
        }

        private static void AddDicRelgas(string reglaBloque, ReglaK regla)
        {
            regla.ReglaBloque = reglaBloque;
            if (!_dicReglas.ContainsKey(reglaBloque))
            {
                _dicReglas.Add(reglaBloque, new List<ReglaK> { regla });

                DataRow _bloque = _catalogoReglas.NewRow();
                _bloque["BloqueRegla"] = reglaBloque;
                _catalogoReglas.Rows.Add(_bloque);
                return;
            }

            List<ReglaK> _reglas = _dicReglas[reglaBloque];
            _reglas.Add(regla);
            _dicReglas[reglaBloque] = _reglas;
        }

        public static async Task DepurarTablas()
        {
            if (_dicReglas.Count > 0)
                _dtReglas526_100.Clear();

            if (_catalogoReglas.Rows.Count > 0)
                _catalogoReglas.Clear();

            if (_dicReglas.Count > 0)
                _dicReglas.Clear();
        }

        private static bool JsonValido(string value)
        {
            try
            {
                if (int.TryParse(value, out _)) return false;

                JToken token = JToken.Parse(value);

                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
        public static List<ReglaKernelArbol> ConsultarArbolSeguimiento(string bloque, string bloquePadre = "")
        {
            return ConsultarArbolSeguimiento(bloque, bloquePadre, new HashSet<string>());
        }
        private static List<ReglaKernelArbol> ConsultarArbolSeguimiento(string bloque, string bloquePadre, HashSet<string> pila)
        {
            /*
            string _bloqueRegla = ObtenerBloqueRegla(bloque);
            List<ReglaKernelArbol> reglasArbol = new List<ReglaKernelArbol>();

            if (_dicReglas.TryGetValue(_bloqueRegla, out var reglas))
            {
                foreach (var r in reglas)
                {
                    var reglaBloque = new ReglaKernelArbol
                    {
                        fiItemId = r.fiItemId,
                        fiSubItemId = r.fiSubItemId,
                        fcValor = r.fcValor,
                        fcCatDesc = r.fcCatDesc,
                        fiSubItemStat = r.fiSubItemStat
                    };

                    reglasArbol.Add(reglaBloque);

                    if (!ContieneEventos(r.fcValor) && !TieneFormatoSeguimiento(r.fcValor))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(bloquePadre) && r.fcValor.Contains($"\"{bloquePadre}\""))
                    {
                        continue;
                    }

                    JObject json = JObject.Parse(r.fcValor);
                    foreach (var propiedad in json.Properties())
                    {
                        if (EsEvento(propiedad.Name) || TieneFormatoSeguimiento(propiedad.Name))
                        {
                            if (!pila.Contains(propiedad.Value.ToString()))
                            {
                                pila.Add(propiedad.Value.ToString());
                                reglaBloque.ReglasSeguimiento = ConsultarArbolSeguimiento(propiedad.Value.ToString(), _bloqueRegla, pila);
                                pila.Remove(propiedad.Value.ToString());
                            }
                        }
                        else if (propiedad.Value.Type == JTokenType.Object)
                        {
                            JObject subJson = (JObject)propiedad.Value;
                            foreach (var subPropiedad in subJson.Properties())
                            {
                                if (EsEvento(subPropiedad.Name) || TieneFormatoSeguimiento(subPropiedad.Name))
                                {
                                    if (!pila.Contains(subPropiedad.Value.ToString()))
                                    {
                                        pila.Add(subPropiedad.Value.ToString());
                                        reglaBloque.ReglasSeguimiento = ConsultarArbolSeguimiento(subPropiedad.Value.ToString(), _bloqueRegla, pila);
                                        pila.Remove(subPropiedad.Value.ToString());
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return reglasArbol;
            */
            
            string _bloqueRegla = ObtenerBloqueRegla(bloque);
            List<ReglaKernelArbol> reglasArbol = new List<ReglaKernelArbol>();

            if (_dicReglas.TryGetValue(_bloqueRegla, out var reglas))
            {
                foreach (var r in reglas)
                {
                    var reglaBloque = new ReglaKernelArbol
                    {
                        fiItemId = r.fiItemId,
                        fiSubItemId = r.fiSubItemId,
                        fcValor = r.fcValor,
                        fcCatDesc = r.fcCatDesc,
                        fiSubItemStat = r.fiSubItemStat
                    };

                    reglasArbol.Add(reglaBloque);

                    if (!ContieneEventos(r.fcValor))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(bloquePadre) && r.fcValor.Contains($"\"{bloquePadre}\""))
                    {
                        continue;
                    }

                    if (r.fcValor.Contains($"\"fire\":\"{_bloqueRegla}\""))
                    {
                        continue;
                    }

                    JObject json = JObject.Parse(r.fcValor);
                    foreach (var propiedad in json.Properties())
                    {
                        var (IsEvento, BloqueSubArbol) = EsEvento(propiedad.Name, propiedad.Value.ToString());
                        //if (!EsEvento(propiedad.Name, propiedad.Value.ToString()))
                        //{
                        //    continue;
                        //}

                        if (!IsEvento) continue;

                        if(IsEvento && !string.IsNullOrEmpty(BloqueSubArbol))
                        {
                            pila.Add(BloqueSubArbol);
                            reglaBloque.ReglasSeguimiento = ConsultarArbolSeguimiento(BloqueSubArbol, _bloqueRegla, pila);
                            pila.Remove(BloqueSubArbol);
                        }

                        if (!pila.Contains(propiedad.Value.ToString()) && (IsEvento && string.IsNullOrEmpty(BloqueSubArbol)))
                        {
                            pila.Add(propiedad.Value.ToString());
                            reglaBloque.ReglasSeguimiento = ConsultarArbolSeguimiento(propiedad.Value.ToString(), _bloqueRegla, pila);
                            pila.Remove(propiedad.Value.ToString());
                        }
                    }
                }
            }

            return reglasArbol;
            
        }


        private static bool ContieneEventos(string valor)
        {
            return valor.Contains("\"fire\":") || valor.Contains("\"invoke\":") || valor.Contains("\"thread\":");
        }

        private static Tuple<bool, string> EsEvento(string nombrePropiedad, string valorPropiedad)
        {
            if ( !ValidarNombrePropiedad(nombrePropiedad) && ContieneEventos(valorPropiedad))
            {
                //Obtener el valor de una key en n niveles del json
                JObject json = JObject.Parse(valorPropiedad);
                foreach (string clave in PalabrasClave)
                {
                    string valorClave = ObtenerValorClave(json, clave);
                    if (!string.IsNullOrEmpty(valorClave)) return new Tuple<bool, string>(true,valorClave);
                }
                return new Tuple<bool, string>(true,null);
            }

            return new Tuple<bool, string>(ValidarNombrePropiedad(nombrePropiedad),string.Empty);
        }

        private static bool ValidarNombrePropiedad(string nombrePropiedad)
        {
            return nombrePropiedad.Equals("fire") || nombrePropiedad.Equals("invoke") || nombrePropiedad.Equals("thread");
        }

        private static string ObtenerValorClave(JObject json, string clave)
        {
            foreach (var propiedad in json.Properties())
            {
                if (propiedad.Name.Equals(clave, StringComparison.OrdinalIgnoreCase))
                {
                    return propiedad.Value.ToString();
                }

                // Si el valor es otro objeto JSON, realizar la búsqueda recursiva
                if (propiedad.Value is JObject objetoAnidado)
                {
                    var valor = ObtenerValorClave(objetoAnidado, clave);
                    if (!string.IsNullOrEmpty(valor))
                    {
                        return valor;
                    }
                }

                // Si el valor es un array, navegar por sus elementos
                if (propiedad.Value is JArray arrayAnidado)
                {
                    foreach (var elemento in arrayAnidado)
                    {
                        if (elemento is JObject objetoEnArray)
                        {
                            var valor = ObtenerValorClave(objetoEnArray, clave);
                            if (!string.IsNullOrEmpty(valor))
                            {
                                return valor;
                            }
                        }
                    }
                }
            }

            return null; // Retornar null si no se encuentra la clave
        }

            /*
            public static List<ReglaKernelArbol> ConsultarArbolSeguimiento(string bloque, string bloquePadre = "") 
            {
                string _bloqueRegla = ObtenerBloqueRegla(bloque);

                if (_bloquesProcesados.Contains(_bloqueRegla))
                {
                    return new List<ReglaKernelArbol>();
                }
                _bloquesProcesados.Add(_bloqueRegla);
                var reglas = _dicReglas[_bloqueRegla];
                List<ReglaKernelArbol> reglasArbol = new List<ReglaKernelArbol>();

                ReglaKernelArbol reglaBloque;

                otroBloque += $"{_bloqueRegla},";
                //ProcesarReglasArbol(regla, ref reglasArbol);

                reglas.ForEach(r => {
                    //if (r.fcValor.Contains("{\"e\":\"init\",\"i\":2000,\"fire\":\"initbrowser\"}"))
                    //{
                    //    int i = 0;
                    //}
                    reglaBloque = new ReglaKernelArbol {
                        fiItemId      = r.fiItemId,
                        fiSubItemId   = r.fiSubItemId,
                        fcValor       = r.fcValor,
                        fcCatDesc     = r.fcCatDesc,
                        fiSubItemStat = r.fiSubItemStat
                    };
                    if (!r.fcValor.Contains("\"fire\":") && !r.fcValor.Contains("\"invoke\":") && !r.fcValor.Contains("\"thread\":"))
                    {
                        reglasArbol.Add(reglaBloque);
                        return;
                    }

                    if (r.fcValor.Contains($"\"{bloquePadre}\"") && !string.IsNullOrEmpty(bloquePadre))
                    {
                        reglasArbol.Add(reglaBloque);
                        return;
                    }

                    if (r.fcValor.Contains($"\"fire\":\"{_bloqueRegla}\""))
                    {
                        reglasArbol.Add(reglaBloque);
                        return;
                    }

                    //foreach (var item in otroBloque.Split(','))
                    //{
                    //    if (r.fcValor.Contains($"\"fire\":\"{item}\""))
                    //    {
                    //        reglasArbol.Add(reglaBloque);
                    //        return;
                    //    }
                    //}

                    //if (bloquePadre.Contains($"\"fire\":\"{_bloqueRegla}\""))
                    //{
                    //    reglasArbol.Add(reglaBloque);
                    //    return;
                    //}

                    JObject json = JObject.Parse(r.fcValor);
                    foreach (var propiedad in json.Properties())
                    {
                        if(propiedad.Name.Equals("fire") || propiedad.Name.Equals("invoke") || propiedad.Name.Equals("thread"))
                        {
                            var mio = ConsultarArbolSeguimiento(propiedad.Value.ToString(), _bloqueRegla);
                            reglaBloque.ReglasSeguimiento = mio;
                            continue;
                        }
                    }
                    reglasArbol.Add(reglaBloque);
                });
                return reglasArbol;
            }
            */
    }
}
