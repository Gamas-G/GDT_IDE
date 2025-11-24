using System.Data;

namespace GDTKernel_Bussiness.GDTKernel_EliminarBLL
{
    public interface IGDTKernel_EliminarBLL
    {
        bool ValidarFormatoReglas(DataTable reglas);
        void GenScriptDelete(DataTable reglasTable, DataTable reglasReverso, string UseSibItem);
    }
}
