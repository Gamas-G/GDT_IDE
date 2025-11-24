using GDTKernel_Bussiness.GDTKernel_BuscarBLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GDTKernel_Bussiness.GDTKernel_Buscar
{
    public class GDTKernel_BuscarReglaBLL : IGDTKernel_BuscarReglaBLL
    {
        //private IGDTKernel_BuscarDAL _IgdtKernel_BusacarDAL;
        public GDTKernel_BuscarReglaBLL()
        {
            //this._IgdtKernel_BusacarDAL = gdtKernel_BuscarDAL;
        }
        public DataTable SelectAdvancedRulesKrnl(string fcValor, string fiItemid, string fiSubItemId, string fcCatDesc, bool fiSubItemStat)
        {
            return new DataTable();
            //return _IgdtKernel_BusacarDAL.SelecAdvancedtRulesKrnl(fcValor, fiItemid, fiSubItemId, fcCatDesc, fiSubItemStat);
        }

        public void CargarReglasKernel( string ip, string usuer, string password, string db )
        {

        }

        public DataTable SelectRulesKrnl(string fcValor)
        {
            try
            {
                return new DataTable();
                //return _IgdtKernel_BusacarDAL.SelectRulesKrnl(fcValor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static DataTable CustomGridViewBuscarEliminarRegla(DataTable tablaFiltrado)
        {
            DataTable _customTable = tablaFiltrado;
            //Colocamos la columna de checkbox
            if (!_customTable.Columns.Contains("Check"))
            {
                _customTable.Columns.Add( new DataColumn("Check", typeof(bool)));
            }
            _customTable.Columns["Check"].SetOrdinal(0);
            _customTable.Columns["Check"].ReadOnly = false;
            return _customTable;
        }


        /// <summary>
        /// Metodo usado para el filtrado de reglas seleccionadas para
        /// su uso ya sea, actualizar o eliminar
        /// </summary>
        /// <param name="dtSelected"></param>
        /// <returns></returns>
        //public static DataTable FilterReglasSelectedUser( DataTable dtSelected526, DataTable dtSelected100 )
        public static DataTable FilterReglasSelectedUser(DataTable dtSelected)
        {
            try
            {
                //EN ESTE CODIGO SE IMPLEMENTABLA LA EXTRACCIÓN DE LAS REGLAS SELECCIONADAS TANTO PARA EL 526 Y 100
                //VALIDACIONES DE CONTENIDO Y LA TABLA DEL 100 COMO NO RENDERIZA NO TIENE LA COLUMNA 'CHECK' ESTO REALIZA UN CATCH
                /*
                DataTable _filterReglas = new DataTable();
                DataTable _filasSeleccionadas526 = dtSelected526.AsEnumerable()
                                                   .Where(row => row.Field<bool?>("Check") ?? false)
                                                   .CopyToDataTable();
                _filasSeleccionadas526.Columns.Remove("Check");

                DataTable _filasSeleccionadas100 = dtSelected100.AsEnumerable()
                                                   .Where(row => row.Field<bool?>("Check") ?? false)
                                                   .CopyToDataTable();
                _filasSeleccionadas100.Columns.Remove("Check");

                _filterReglas.Merge(_filasSeleccionadas526);
                _filterReglas.Merge(_filasSeleccionadas100);
                */

                    DataTable _filterReglas = dtSelected.AsEnumerable()
                    .Where(row => row.Field<bool?>("Check") ?? false)
                    .CopyToDataTable();

                    _filterReglas.Columns.Remove("Check");

                //_filterReglas.Columns.Remove("ReglaBloque");
                //_filterReglas.Columns.Remove("FireEvento");
                return _filterReglas;
                
                
        }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
