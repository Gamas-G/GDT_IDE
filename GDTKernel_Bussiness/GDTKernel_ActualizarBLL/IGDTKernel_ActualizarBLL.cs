using System.Data;

namespace GDTKernel_Bussiness.GDTKernel_ActualizarBLL
{
    public interface IGDTKernel_ActualizarBLL
    {
        bool ValidarFormatoReglas(DataTable reglas);
        void GenScriptUpdate(DataTable reglasTable, DataTable reglasReverso, string UseSubItem);
    }
}
