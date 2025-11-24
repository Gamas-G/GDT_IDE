using GDTKernel_DataAccess.GDTKernel_DAL;
using GDTKernel_Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GDTKernel_Interprete.Almacen;
using System.Data;
using GDTKernel_Model.Sevidores;
using GDTKernel_Util.Servidores;
using GDTKernel_Util.Observador;

namespace GDTKernel_Bussiness.GDTKernel
{
    public class GDTKernel_BLL : IGDTKernel_BLL
    {
        private IGDTKernel_DAL _IgdtKernel_DAL = new GDTKernel_DAL();
        
        public async Task<bool> CargarReglasKernel(DetalleServidor detalleServidor, string pais, string canal)
        {
            Observador._observadorEstatus("Conectando...");
            
            CredencialesServidor credencialesServidor = new CredencialesServidor {
                Nombre   = detalleServidor.Nombre,
                Ip       = detalleServidor.Ip,
                Usuario  = detalleServidor.Usuario,
                DB       = detalleServidor.BD,
                Password = detalleServidor.Password
            };

            DataSet dataSet = await _IgdtKernel_DAL.CargarReglasKernel(credencialesServidor);

            if(dataSet == null)
            {
                Observador._observadorEstatus("Finaliza conexión, no se pudo establecer conexión a la base...");
                return false;
            }

            detalleServidor.TotalAct   = dataSet.Tables[0].Rows[0]["Activas"].ToString();
            detalleServidor.TotalDesac = dataSet.Tables[0].Rows[0]["Desactivadas"].ToString();

            detalleServidor.TotalAct100   = dataSet.Tables[1].Rows[0]["Activas"].ToString();
            detalleServidor.TotalDesac100 = dataSet.Tables[1].Rows[0]["Desactivadas"].ToString();

            //Agregamos el MAXIMO de 526 y 100 para el uso de la creación de nuevas reglas

            Servidores.SetMAXSubItem_526_100(MAX526: Convert.ToInt32(dataSet.Tables[4].Rows[0]["MAX526"]), MAX100: Convert.ToInt32(dataSet.Tables[5].Rows[0]["MAX100"]));

            await Servidores.ActuaizarInformacionLaboratorio(detalleServidor, pais, canal);


            //Trabajar los datos para procesar los datos en JSON y uso de Diccionario
            bool resp = await ProcesarDatosToJson(dataSet);

            if (resp)
            {
                Observador._observadorEstatus("Finaliza conexión...");
            }
            return resp;
        }
        public DataSet ConsultarReglas()
        {
            return Almacen.ConsultarReglas();
        }
        public DataTable BuscarReglaFiltro(string reglaValor, string catDesc, int status, int relga526_100, int fiSubItemId, string bloqueRegla)
        {
            return Almacen.BuscarReglaFiltro(reglaValor, catDesc, status, Regla526_100:relga526_100, fiSubItemId, bloqueRegla);
        }
        private async Task<bool> ProcesarDatosToJson(DataSet dataSetReglas)
        {
            await Almacen.DepurarTablas();

            Almacen.GuardarReglas(dataSetReglas);

            List<ReglaK> reglaKernels = new List<ReglaK>();
            ReglaK _re;
            foreach (DataRow rowCollection in dataSetReglas.Tables[2].Rows)
            {
                _re = new ReglaK {
                    fiItemId      = Convert.ToInt32(rowCollection["fiItemId"]),
                    fiSubItemId   = Convert.ToInt32(rowCollection["fiSubItemId"]),
                    fcValor       = (String)rowCollection["fcValor"],
                    fcCatDesc     = (String)rowCollection["fcCatDesc"],
                    fiSubItemStat = Convert.ToInt32(rowCollection["fiSubItemStat"]),
                };

                reglaKernels.Add(_re);

            }
            return await Almacen.GuardarReglasAlmacen(reglaKernels);
        }

        public List<ReglaKernelArbol> ConsultarArbolSeguimiento(ReglaK regla)
        {
            //var m = new List<ReglaKernelArbol>();
            //await Task.Run(() => {
            //   m = Almacen.ConsultarArbolSeguimiento(regla.fcValor);
            //});

            //return m;
            if (Almacen._bloquesProcesados.Count > 0) Almacen._bloquesProcesados.Clear();
            return Almacen.ConsultarArbolSeguimiento(regla.fcValor);
        }
    }
}
