using GDTKernel_Model.Eliminar;
using GDTKernel_Model.Sevidores;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GDTKernel_Util.Servidores
{
    public static class Servidores
    {
        private static string _hash { get; set; } = ConfigurationManager.AppSettings["HashServidores"];
        private static string _PathServidoresJson { get; set; } = ConfigurationManager.AppSettings["PathServidoresJson"];
        private static string _PathScriptSQL { get; set; } = ConfigurationManager.AppSettings["PathScriptSQL"];
        private static string _servidorUsando { get; set; } = string.Empty;

        private static int _fisubItemIdMAX_526 = 0;
        private static int _fisubItemIdMAX_100 = 0;

        private readonly static Dictionary<string, List<Canal>> DicciServidores = new Dictionary<string, List<Canal>>();
        private readonly static Dictionary<string, List<string>> PaisesCanales = new Dictionary<string, List<string>>();

        public static async Task<bool> ActualizarGuardarServidor( NuevoServidor servidor )
        {
            Observador.Observador._observadorEstatus("Actualizando servidores");
            await Task.Delay(1000);

            if (!ValidarServidor(servidor: servidor)) return false;

            await ActualizarServidor();

            Observador.Observador._observadorEstatus("Finaliza servidores...");
            Observador.Observador.NotificarVentana();
            return true;
        }

        public static void SetMAXSubItem_526_100(int MAX526,int MAX100)
        {
            _fisubItemIdMAX_526 = MAX526;
            _fisubItemIdMAX_100 = MAX100;
        }

        public static Tuple<int, int> GetMAXSubItem_526_100()
        {
            return new Tuple<int, int>(_fisubItemIdMAX_526, _fisubItemIdMAX_100);
        }

        public static bool ValidarServidorUso(string servidor)
        {
            return _servidorUsando.Contains(servidor);
        }

        public static bool ValidarServidorEnCanal( string pais )
        {
            List<Canal> _canales = DicciServidores[pais];
            string _servidorUsando = ObtenerServidorUsando();
            if (String.IsNullOrEmpty(_servidorUsando)) return false;
            bool _matchServ = false;
            foreach (Canal _canal in _canales)
            {
                foreach (DetalleServidor _detServidor in _canal.Servidores)
                {
                    if(_detServidor.Nombre == _servidorUsando)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void AgregarServidor(NuevoServidor servidor)
        {
            PaisesCanales.Add(servidor.PaisNombre, new List<string> { servidor.InfoServidor.Nombre });
            DicciServidores.Add(servidor.PaisNombre, new List<Canal> { servidor.InfoServidor });
        }

        private static void AgregarCanal(NuevoServidor canal)
        {
            List<string> _paiscanalesValue = PaisesCanales[canal.PaisNombre];
            _paiscanalesValue.Add(canal.InfoServidor.Nombre);
            PaisesCanales[canal.PaisNombre] = _paiscanalesValue;

            List<Canal> _canales = DicciServidores[canal.PaisNombre];
            _canales.Add(canal.InfoServidor);
            DicciServidores[canal.PaisNombre] = _canales;
        }

        private static void AgregarLaboratorio(NuevoServidor servidor)
        {
            List<Canal> _listCanal =  DicciServidores[servidor.PaisNombre];

            for (int i = 0; i < _listCanal.Count; i++)
            {
                if(_listCanal[i].Nombre == servidor.InfoServidor.Nombre)
                {
                    _listCanal[i].Servidores.Add(servidor.InfoServidor.Servidores[0]);
                    break;
                }
            }

            DicciServidores[servidor.PaisNombre] = _listCanal ;
        }

        private static async Task ActualizarServidor()
        {
            Observador.Observador._observadorEstatus("Actualizando archivo maestro...");
            await Task.Delay(1000);

            await Task.Run(() =>
            {
                Servidor srv = new Servidor();

                List<Pais> listP = new List<Pais>();
                Pais _p;
                DicciServidores.ToList().ForEach(d => {
                    _p = new Pais { 
                        Nombre = d.Key,
                        Canales = d.Value
                    };

                    listP.Add(_p);
                });
                srv.Paises = listP;

                var json = JsonConvert.SerializeObject(srv);
                File.WriteAllText(_PathServidoresJson, json);
            });

            Observador.Observador._observadorEstatus("Finaliza archivo maestro...");
        }

        public static async Task<bool> EliminarServidor(PaisDel _pais)
        {
            bool result = false;
            result = Eliminar(_pais);
            await ActualizarServidor();
            Observador.Observador.NotificarVentana();
            //NotificarObservadores();

            return result;
        }

        private static void EliminarTodoCanal(string nombre)
        {
            PaisesCanales.Remove(nombre);
            DicciServidores.Remove(nombre);

            if(PaisesCanales.Count <= 0)
            {
                File.Delete(_PathServidoresJson);
                ValidarArchivoServidoresJson();
                CalcularHash();
                CargarServidores();
            }
        }

        private static bool Eliminar(PaisDel _pais)
        {
            bool result = false;
            if (_pais.Seleccionado)
            {
                EliminarTodoCanal(_pais.Nombre);

                return true;
            }

            foreach (CanalDel canal in _pais.CanalesDel)
            {
                if (canal.Seleccionado)
                {
                    List<string> paisca = PaisesCanales[_pais.Nombre];
                    paisca.Remove(canal.Nombre);

                    List<Canal> _c = DicciServidores[_pais.Nombre];
                    for (int i = 0; i < _c.Count; i++)
                    {
                        if (_c[i].Nombre == canal.Nombre)
                        {
                            _c.RemoveAt(i);
                        }
                    }

                    DicciServidores[_pais.Nombre] = _c;
                    PaisesCanales[_pais.Nombre] = paisca;
                    continue;
                }

                List<Canal> _testC = DicciServidores[_pais.Nombre];
                int countLaboratorios = _testC.Find( p => p.Nombre == canal.Nombre ).Servidores.Count;

                if (canal.Servidores.Count == countLaboratorios)
                {
                    List<string> paisca = PaisesCanales[_pais.Nombre];
                    paisca.Remove(canal.Nombre);

                    List<Canal> _c = DicciServidores[_pais.Nombre];
                    //Creo que se puede mejorar con un simple foreach
                    for (int i = 0; i < _c.Count; i++)
                    {
                        if (_c[i].Nombre == canal.Nombre)
                        {
                            _c.RemoveAt(i);
                        }
                    }

                    DicciServidores[_pais.Nombre] = _c;
                    PaisesCanales[_pais.Nombre] = paisca;
                    continue;
                }

                List<Canal> _canales = DicciServidores[_pais.Nombre];
                Canal _canal = _canales.Find(e => e.Nombre == canal.Nombre);
                List<DetalleServidor> _detallesServidores = _canal.Servidores;


                foreach (DetalleServidor servidor in canal.Servidores)
                {
                    for (int i = 0; i < _detallesServidores.Count; i++)
                    {
                        if (_detallesServidores[i].Nombre != servidor.Nombre)
                        {
                            continue;
                        }
                        
                        _detallesServidores.RemoveAt(i);
                    }
                }

                _canales.Remove(_canal);
                _canal.Servidores = _detallesServidores;
                _canales.Add(_canal);

                DicciServidores[_pais.Nombre] = _canales;
            }

            //Validamos que hayan canales, si fue una eliminación de todos los canales
            if (DicciServidores[_pais.Nombre].Count <= 0 && !_pais.Seleccionado)
            {
                EliminarTodoCanal(_pais.Nombre);
                result = true;
            }

            return result;
        }


        public static Servidor CargarServidores()
        {
            return LeerArchivo();
        }

        public static List<Canal> ConsultarDetallePais(string keyPais)
        {
            return DicciServidores[keyPais];
        }

        public static List<DetalleServidor> ConsultarServidores(string keyPais = "MX", string keyCanal = "EKT")
        {
            if (!DicciServidores.ContainsKey(keyPais)) return new List<DetalleServidor>();

            List<Canal> _canal = DicciServidores[keyPais];
            List<DetalleServidor> _canalFiltrado = _canal.Find(canalName => canalName.Nombre == keyCanal).Servidores;

            return _canalFiltrado;
        }

        private static bool ValidarServidor(NuevoServidor servidor)
        {
            bool result = false;
            //Validamos el pais
            if (ValidarPais(servidor: servidor)) return true;

            //Validamos el canal
            if (ValidarCanal(servidor: servidor)) return true;

            //Validamos el laboratorio
            if (ValidarLaboratorio(servidor: servidor)) return true;

            //Validamos la data del servidor
            if (ValidarDataLaboratorio(servidor: servidor)) return true;


            return result;
        }

        private static bool ValidarPais(NuevoServidor servidor)
        {
            if (!PaisesCanales.ContainsKey(servidor.PaisNombre))
            {
                AgregarServidor(servidor: servidor);
                return true;
            }
            return false;
        }

        private static bool ValidarCanal(NuevoServidor servidor)
        {
            if (!PaisesCanales[servidor.PaisNombre].ToList().Any(_canal => _canal == servidor.InfoServidor.Nombre))
            {
                AgregarCanal(canal: servidor);
                return true;
            }
            return false;
        }

        private static bool ValidarLaboratorio(NuevoServidor servidor)
        {
            Canal _canal = DicciServidores[servidor.PaisNombre].Find(_c => _c.Nombre == servidor.InfoServidor.Nombre);
            if (!_canal.Servidores.Any( _lab => _lab.Nombre == servidor.InfoServidor.Servidores[0].Nombre))
            {
                AgregarLaboratorio(servidor);
                return true;
            }

            return false;
        }

        private static bool ValidarDataLaboratorio(NuevoServidor servidor)
        {
            string _nombrePaisNuevo = servidor.PaisNombre;
            Canal DetalleServidorNuevo = servidor.InfoServidor;

            //Información del servidor en diccionario
            DetalleServidor _servidorJson = ConsultarDetalleServidor(nombreServidor: DetalleServidorNuevo.Servidores[0].Nombre, keyPais: _nombrePaisNuevo, keyCanal: DetalleServidorNuevo.Nombre);
            if (_servidorJson.Nombre != DetalleServidorNuevo.Servidores[0].Nombre || _servidorJson.Ip != DetalleServidorNuevo.Servidores[0].Ip || _servidorJson.Usuario != DetalleServidorNuevo.Servidores[0].Usuario
                || _servidorJson.Password != DetalleServidorNuevo.Servidores[0].Password || _servidorJson.BD != DetalleServidorNuevo.Servidores[0].BD)
            {
                ActualizarLaboratorio( laboratorio: DetalleServidorNuevo.Servidores[0], keyPais: _nombrePaisNuevo, keyCanal: DetalleServidorNuevo.Nombre);
                return true;
            }
            return false;
        }

        public static async Task ActuaizarInformacionLaboratorio(DetalleServidor laboratorio, string keyPais, string keyCanal)
        {
            ActualizarLaboratorio(laboratorio, keyPais,keyCanal);
            await ActualizarServidor();
            Observador.Observador.NotificarVentana();
        }

        private static bool ActualizarLaboratorio(DetalleServidor laboratorio, string keyPais, string keyCanal)
        {
            List<Canal> _canal = DicciServidores[keyPais];
            List<DetalleServidor> _canalFiltrado = _canal.Find(canalName => canalName.Nombre == keyCanal).Servidores;

            DetalleServidor _detalle = _canalFiltrado.Find( _d => _d.Nombre == laboratorio.Nombre );

            _canalFiltrado.Remove(_detalle);

            _canalFiltrado.Add(laboratorio);

            _canal.ForEach( _p => {

                if(_p.Nombre != keyCanal)
                {
                    return;
                }
                
                _p.Servidores = _canalFiltrado;
            });

            DicciServidores[keyPais] = _canal;
            
            return true;
        }

        /// <summary>
        /// Retorna la lista de paises
        /// </summary>
        /// <returns></returns>
        public static List<string> ConsultarPaises()
        {
            return new List<string>(PaisesCanales.Keys);
        }

        /// <summary>
        /// Retorna una lista de canales en base al pais[keyPais]
        /// </summary>
        /// <param name="keyPais"></param>
        /// <returns></returns>
        public static List<string> ConsultarCanales(string keyPais)
        {
            return PaisesCanales[keyPais];
        }


        /// <summary>
        /// Lee el archivo json que contiene todos los servidores, canales, paises, credenciales para conectar
        /// </summary>
        /// <returns></returns>
        private static Servidor LeerArchivo()
        {
            Observador.Observador._observadorEstatus("Cargando servidores...");
            //await Task.Delay(1000);
            Servidor ServidoresJson;
            //Leemos la lista de servidores de nuestro json
            using (StreamReader r = new StreamReader(_PathServidoresJson))
            {
                string json = r.ReadToEnd();
                ServidoresJson = JsonConvert.DeserializeObject<Servidor>(json);
            }
            //Guardamos en nuestro diccionario
            GuardarDiccionarioServidores(ServidoresJson.Paises);
            Observador.Observador._observadorEstatus("Servidores cargados...");
            return ServidoresJson;
        }

        /// <summary>
        /// Actualiza el hash de Resources.resc cuando se modifica algun servidor
        /// </summary>
        /// <param name="hashCalculado"></param>
        public static void ActualizarHash()
        {
            Observador.Observador._observadorEstatus("Validando hash...");
            ValidarArchivoServidoresJson();
            string hashCalculado = CalcularHash();
            if (_hash.Contains(hashCalculado)) return;

            UpdateSetting("HashServidores", hashCalculado );

            //Actualizamos nuestra variable local
            _hash = ConfigurationManager.AppSettings["HashServidores"];

            Observador.Observador._observadorEstatus("Finaliza validación de hash...");
        }

        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("app.config");
        }

        /// <summary>
        /// Realiza el calculo del hash del archvio json
        /// </summary>
        /// <returns></returns>
        private static string CalcularHash()
        {
            FileInfo info = new FileInfo(_PathServidoresJson);
            //FileInfo info = new FileInfo(@"C:\ADN\servidores.json");
            string value = $"{info.FullName},{info.CreationTime},{info.Length}";

            StringBuilder stringBuilder = new StringBuilder();
            GetHash(value).ToList().ForEach( b => {
                stringBuilder.Append(b.ToString());
            });

            return stringBuilder.ToString();
        }

        private static void ValidarArchivoServidoresJson()
        {
            if (!File.Exists(_PathScriptSQL))
            {
                if (!Directory.Exists("C:\\ADN\\IDEKernel"))
                    Directory.CreateDirectory("C:\\ADN\\IDEKernel");

                File.Copy($"{Directory.GetCurrentDirectory()}\\spConKernelIDE.sql", _PathScriptSQL);
            }

            if (File.Exists(_PathServidoresJson)) return;

            try
            {
                string _jsonDefaulServer = ConfigurationManager.AppSettings["LabDefault"];
                using (StreamWriter sw = new StreamWriter(_PathServidoresJson, true))
                {
                    sw.WriteLine(_jsonDefaulServer);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); ;
            }
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        private static void GuardarDiccionarioServidores(List<Pais> listPaises)
        {
            listPaises.ForEach( pais => {

                if (!DicciServidores.ContainsKey(pais.Nombre))
                {
                    //Agregamos en el diccionario
                    DicciServidores.Add(pais.Nombre, pais.Canales);

                    //Agregamos en el diccionario de paises y canales que se usan en los filtors
                    List<string> _canales = new List<string>();
                    pais.Canales.ForEach(canal => _canales.Add(canal.Nombre));

                    PaisesCanales.Add(pais.Nombre, _canales);

                    return;
                }
            
            });
        }

        public static DetalleServidor ConsultarDetalleServidor(string nombreServidor, string keyPais = "MX", string keyCanal = "EKT" )
        {
            if (!DicciServidores.ContainsKey(keyPais)) return new DetalleServidor();

            List<Canal> _canal = DicciServidores[keyPais];
            List<DetalleServidor> _canalFiltrado = _canal.Find(canalName => canalName.Nombre == keyCanal).Servidores;

            DetalleServidor detalle = _canalFiltrado.Find( _detalle => _detalle.Nombre == nombreServidor );

            detalle = detalle == null ? _canalFiltrado[0] : detalle;

            return detalle;
        }

        public static string ObtenerServidorUsando()
        {
            return _servidorUsando;
        }

        public static void SetServidorUsando( string servidor )
        {
            _servidorUsando = servidor;
        }
    }
}
