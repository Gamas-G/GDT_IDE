using System;
using System.Data;

namespace GDTKernel_Bussiness.GDTKernel_CrearBLL
{
    public interface IGDTKernel_CrearBLL
    {
        Tuple<string, bool> ValidarFormatoReglas(string reglas);

        void GenScriptUpdate(DataTable reglasTable, string UseSubItem);
    }
}
