using GDTKernel_Model;
using GDTKernel_Model.Sevidores;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GDTKernel_Bussiness.GDTKernel
{
    public interface IGDTKernel_BLL
    {
        Task<bool> CargarReglasKernel(DetalleServidor detalleServidor, string pais, string canal);
        DataSet ConsultarReglas();
        DataTable BuscarReglaFiltro(string reglaValor, string catDesc, int status, int regla526_100, int fisubItemId, string bloqueRegla);
        List<ReglaKernelArbol> ConsultarArbolSeguimiento(ReglaK regla);
    }
}
